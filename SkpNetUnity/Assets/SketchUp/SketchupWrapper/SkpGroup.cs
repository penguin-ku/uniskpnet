using PgSkpDK.SketchupRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace PgSkpDK.SketchupWrapper
{
    /// <summary>
    /// 组
    /// </summary>
    public class SkpGroup : IDisposable
    {
        #region private members

        private string m_identity;
        private SkpModel m_model;
        private string m_defaultMaterialIdentity;

        private Dictionary<string, SkpInstance> m_instances = new Dictionary<string, SkpInstance>();
        private Dictionary<string, SkpGroup> m_groups = new Dictionary<string, SkpGroup>();
        private Dictionary<string, SkpFace> m_faces = new Dictionary<string, SkpFace>();

        private Dictionary<string, SkpFaceCluster> m_clusters = new Dictionary<string, SkpFaceCluster>();
        private SkpTransform m_transform;
        private string m_name;

        #endregion

        #region public properties

        /// <summary>
        /// 设置或获取唯一标记
        /// </summary>
        public string Identity
        {
            set
            {
                m_identity = value;
            }
            get
            {
                return m_identity;
            }
        }

        /// <summary>
        /// 获取所属文档
        /// </summary>
        public SkpModel Model
        {
            get
            {
                return m_model;
            }
        }

        /// <summary>
        /// 设置或获取默认材质
        /// </summary>
        public string DefaultMaterialIdentity
        {
            set
            {
                m_defaultMaterialIdentity = value;
            }
            get
            {
                return m_defaultMaterialIdentity;
            }
        }

        /// <summary>
        /// 设置或获取子实例
        /// </summary>
        public Dictionary<string, SkpInstance> Instances
        {
            set
            {
                m_instances = value;
            }
            get
            {
                return m_instances;
            }
        }

        /// <summary>
        /// 设置或获取子群组
        /// </summary>
        public Dictionary<string, SkpGroup> Groups
        {
            set
            {
                m_groups = value;
            }
            get
            {
                return m_groups;
            }
        }

        /// <summary>
        /// 设置或获取面
        /// </summary>
        public Dictionary<string, SkpFaceCluster> Clusters
        {
            set
            {
                m_clusters = value;
            }
            get
            {
                return m_clusters;
            }
        }

        /// <summary>
        /// 设置或获取面
        /// </summary>
        public Dictionary<string, SkpFace> Faces
        {
            set
            {
                m_faces = value;
            }
            get
            {
                return m_faces;
            }
        }

        /// <summary>
        /// 设置或获取变换
        /// </summary>
        public SkpTransform Transform
        {
            set
            {
                m_transform = value;
            }
            get
            {
                return m_transform;
            }
        }

        /// <summary>
        /// 获取名称
        /// </summary>
        public string Name
        {
            get
            {
                return m_name;
            }
        }

        #endregion

        #region constructors

        public SkpGroup(SkpModel p_model)
        {
            m_model = p_model;
            //m_model.MeshContainers.Add(this);
        }

        #endregion

        #region public functions

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="groupRef"></param>
        public void Load(SUGroupRef groupRef)
        {
            SUDrawingElementRef drawingRef = SKPCExport.SUGroupToDrawingElement(groupRef);
            SUEntityRef entityRef = SKPCExport.SUDrawingElementToEntity(drawingRef);

            m_identity = SkpEntityCache.GetIdentity(entityRef);
            m_defaultMaterialIdentity = SkpEntityCache.GetMaterialDefault(drawingRef);

            SUEntitiesRef entities = default;
            SKPCExport.SUGroupGetEntities(groupRef, ref entities);

            m_faces = SkpFace.GetEntityFaces(entities, Model);
            m_instances = SkpInstance.GetEntityInstances(entities, Model);
            m_groups = SkpGroup.GetEntityGroups(entities, Model);

            SUTransformation transform = default;
            SKPCExport.SUGroupGetTransform(groupRef, ref transform);
            m_transform = new SkpTransform(transform);

            SUStringRef groupName = default(SUStringRef);
            SKPCExport.SUStringCreate(ref groupName);
            SKPCExport.SUGroupGetName(groupRef, ref groupName);
            m_name = Utilities.GetString(groupName);
            SKPCExport.SUStringRelease(ref groupName);

            m_clusters = SkpFaceCluster.Load(m_faces.Values, m_model);
        }

        /// <summary>
        /// 生成GameObject
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="materialDefault"></param>
        public void GenerateGameObject(Transform transform)
        {
            GameObject gObject = new GameObject($"{Identity}");
            gObject.transform.localRotation = Quaternion.identity;
            gObject.transform.localPosition = Vector3.zero;
            gObject.transform.localScale = Vector3.one;
            gObject.transform.SetParent(transform);

            foreach (var item in m_clusters.Keys)
            {
                m_clusters[item].GenerateGameObject(gObject.transform);
            }
            foreach (var item in m_instances.Keys)
            {
                m_instances[item].GenerateGameObject(gObject.transform);
            }
            foreach (var item in m_groups.Keys)
            {
                m_groups[item].GenerateGameObject(gObject.transform);
            }

            // 如果实例指定了默认材质，则需要检查组件中哪些是缺省材质，需要替换为默认材质
            // 另外，默认材质的uv缩放信息需要携带过来
            if (!string.IsNullOrEmpty(m_defaultMaterialIdentity) && m_defaultMaterialIdentity != m_model.DefaultMaterialName && m_model.Materials.ContainsKey(m_defaultMaterialIdentity))
            {
                var skpMaterials = m_model.Materials[m_defaultMaterialIdentity];

                Material material = skpMaterials.UnityMaterial;
                Renderer[] renders = gObject.transform.GetComponentsInChildren<Renderer>();
                foreach (var item in renders)
                {
                    if (item.sharedMaterial.name.StartsWith(m_model.DefaultMaterialName))// 此处因为组件呗clone之后，material的name后面会被unity自动追加一些字符
                    {
                        // 此处切记不准用sharedmaterial，因为如果针对face指定了material，face的material是不可以设定缩放的，其缩放信息已经反应到了uv上
                        item.sharedMaterial = material;
                        Vector2 scale = Vector2.one;
                        if (m_model.Materials[m_defaultMaterialIdentity].MaterialTexture != null)
                        {
                            scale = new Vector2((float)m_model.Materials[m_defaultMaterialIdentity].MaterialTexture.ScaleX, (float)m_model.Materials[m_defaultMaterialIdentity].MaterialTexture.ScaleY);
                        }
                        if (m_model.Materials[m_defaultMaterialIdentity].MaterialTexture != null)
                        {
                            Mesh mesh = item.GetComponent<MeshFilter>().mesh;
                            mesh.uv = mesh.uv.Select(p => new Vector2(p.x * scale.x, p.y * scale.y)).ToArray();
                        }
                    }
                }
            }

            m_transform.ToTransform(gObject.transform);// transform转述
        }

        #endregion

        #region public static functions

        public static Dictionary<string, SkpGroup> GetEntityGroups(SUEntitiesRef p_suEntitiesRef, SkpModel p_model)
        {
            Dictionary<string, SkpGroup> groups = new Dictionary<string, SkpGroup>(100);

            long groupsCount = 0;
            SKPCExport.SUEntitiesGetNumGroups(p_suEntitiesRef, ref groupsCount);

            if (groupsCount > 0)
            {
                SUGroupRef[] groupRefs = new SUGroupRef[groupsCount];
                SKPCExport.SUEntitiesGetGroups(p_suEntitiesRef, groupsCount, groupRefs, ref groupsCount);

                for (long i = 0; i < groupsCount; i++)
                {
                    SkpGroup group = new SkpGroup(p_model);
                    group.Load(groupRefs[i]);
                    groups.Add(group.Identity, group);
                }
            }

            return groups;
        }

        public static Task<Dictionary<string, SkpGroup>> GetEntityGroupsAsync(SUEntitiesRef p_suEntitiesRef, SkpModel p_model)
        {
            TaskCompletionSource<Dictionary<string, SkpGroup>> tcs = new TaskCompletionSource<Dictionary<string, SkpGroup>>();

            long groupsCount = 0;
            SKPCExport.SUEntitiesGetNumGroups(p_suEntitiesRef, ref groupsCount);

            if (groupsCount > 0)
            {
                SUGroupRef[] groupRefs = new SUGroupRef[groupsCount];
                SKPCExport.SUEntitiesGetGroups(p_suEntitiesRef, groupsCount, groupRefs, ref groupsCount);

                TaskExcutor.Run<SkpGroup, SUGroupRef>(groupRefs, g =>
                {
                    SkpGroup group = new SkpGroup(p_model);
                    group.Load(g);

                    return group;
                }).ContinueWith(t =>
                {
                    if (t.IsFaulted)
                    {
                        tcs.TrySetException(t.Exception);
                    }
                    else
                    {
                        tcs.TrySetResult(t.Result.ToDictionary(p => p.Identity, p => p));
                    }
                });
            }
            else
            {
                tcs.TrySetResult(new Dictionary<string, SkpGroup>());
            }

            return tcs.Task;
        }

        public void Dispose()
        {
            m_identity = null;
            m_model = null;
            m_defaultMaterialIdentity = null;
            foreach (var item in m_instances.Keys)
            {
                m_instances[item].Dispose();
                //m_instances[item] = null;
            }
            foreach (var item in m_groups.Keys)
            {
                m_groups[item].Dispose();
                //m_groups[item] = null;
            }
            foreach (var item in m_faces.Keys)
            {
                m_faces[item].Dispose();
                //m_faces[item] = null;
            }
            foreach (var item in m_clusters.Keys)
            {
                m_clusters[item].Dispose();
                //m_clusters[item] = null;
            }
            m_name = null;
            m_transform = null;
        }


        #endregion
    }
}
