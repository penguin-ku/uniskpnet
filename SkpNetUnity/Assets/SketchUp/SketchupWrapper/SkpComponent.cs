using PgSkpDK.SketchupRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PgSkpDK.SketchupWrapper
{
    public class SkpComponent:IDisposable
    {

        #region private members

        private string m_identity;
        private SkpModel m_model;
        private string m_defaultMaterialIdentity;
        private Dictionary<string, SkpFace> m_faces = new Dictionary<string, SkpFace>();
        private Dictionary<string, SkpFaceCluster> m_clusters = new Dictionary<string, SkpFaceCluster>();
        private Dictionary<string, SkpInstance> m_instances = new Dictionary<string, SkpInstance>();
        private Dictionary<string, SkpGroup> m_groups = new Dictionary<string, SkpGroup>();

        private GameObject m_gameObject;

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

        public GameObject GameObject
        {
            get
            {
                if (m_gameObject==null)
                {
                    GenerateGameObject();
                }
                return m_gameObject;
            }
            set
            {
                m_gameObject = value;
            }
        }

        #endregion

        #region constructors

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="p_model"></param>
        public SkpComponent(SkpModel p_model)
        {
            m_model = p_model;
        }

        #endregion

        #region public functions

        public void DestroyGameObject()
        {
            if (m_gameObject!=null)
            {
                UnityEngine.Object.DestroyImmediate(m_gameObject);
                m_gameObject = null;
            }
        }

        public void Load(SUComponentDefinitionRef p_suComponentRef)
        {
            SUDrawingElementRef drawingRef = SKPCExport.SUComponentDefinitionToDrawingElement(p_suComponentRef);
            SUEntityRef entityRef = SKPCExport.SUDrawingElementToEntity(drawingRef);

            m_identity = SkpEntityCache.GetIdentity(entityRef);
            m_defaultMaterialIdentity = SkpEntityCache.GetMaterialDefault(drawingRef);

            SUEntitiesRef entities = default(SUEntitiesRef);
            SKPCExport.SUComponentDefinitionGetEntities(p_suComponentRef, ref entities);
            m_instances = SkpInstance.GetEntityInstances(entities, Model);
            m_groups = SkpGroup.GetEntityGroups(entities, Model);
            m_faces = SkpFace.GetEntityFaces(entities, Model);
            m_clusters = SkpFaceCluster.Load(m_faces.Values, m_model);
        }

        #endregion

        #region public functions

        /// <summary>
        /// 生成物体
        /// </summary>
        /// <param name="materialDefault"></param>
        public void GenerateGameObject()
        {
            if (m_gameObject!=null)// 如果已经生成过，则重新生成
            {
                UnityEngine.Object.DestroyImmediate(m_gameObject);
                m_gameObject = null;
            }

            GameObject gObject = new GameObject(string.Format("#{0}", Identity));
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
                Material material = m_model.Materials[m_defaultMaterialIdentity].UnityMaterial;
                Renderer[] renders = gObject.transform.GetComponentsInChildren<Renderer>();
                foreach (var item in renders)
                {
                    if (item.sharedMaterial.name.StartsWith(m_model.DefaultMaterialName))// 此处因为组件呗clone之后，material的name后面会被unity自动追加一些字符
                    {
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
            gObject.SetActive(false);

            m_gameObject = gObject;
        }

        private GameObject LoadFromFile(string filePath)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region public static functions

        /// <summary>
        /// 获取组件identity
        /// </summary>
        /// <param name="p_suComponentRef"></param>
        /// <returns></returns>
        public static string GetIdentity(SUComponentDefinitionRef p_suComponentRef)
        {
            return SkpEntityCache.GetIdentity(SKPCExport.SUComponentDefinitionToEntity(p_suComponentRef));
        }

        public static Dictionary<string, SkpComponent> GetComponents(SUModelRef model, SkpModel p_model)
        {
            Dictionary<string, SkpComponent> components = new Dictionary<string, SkpComponent>(200);

            long componentsCount = 0;
            SKPCExport.SUModelGetNumComponentDefinitions(model, ref componentsCount);

            if (componentsCount > 0)
            {
                SUComponentDefinitionRef[] componentRefs = new SUComponentDefinitionRef[componentsCount];
                SKPCExport.SUModelGetComponentDefinitions(model, componentsCount, componentRefs, ref componentsCount);

                for (long i = 0; i < componentsCount; i++)
                {
                    SkpComponent component = new SkpComponent(p_model);
                    component.Load(componentRefs[i]);
                    components.Add(component.Identity, component);
                }
            }

            return components;

        }

        /// <summary>
        /// 异步加载组件
        /// </summary>
        /// <param name="model"></param>
        /// <param name="p_model"></param>
        /// <returns></returns>
        public static Task<Dictionary<string, SkpComponent>> GetComponentsAsync(SUModelRef model, SkpModel p_model)
        {
            TaskCompletionSource<Dictionary<string, SkpComponent>> tcs = new TaskCompletionSource<Dictionary<string, SkpComponent>>();
            Task.Run(() => 
            {
                long componentsCount = 0;
                SKPCExport.SUModelGetNumComponentDefinitions(model, ref componentsCount);

                if (componentsCount > 0)
                {
                    SUComponentDefinitionRef[] componentRefs = new SUComponentDefinitionRef[componentsCount];
                    SKPCExport.SUModelGetComponentDefinitions(model, componentsCount, componentRefs, ref componentsCount);

                    TaskExcutor.Run<SkpComponent, SUComponentDefinitionRef>(componentRefs, c =>
                    {
                        SkpComponent component = new SkpComponent(p_model);
                        component.Load(c);
                        return component;
                    }).ContinueWith(t =>
                    {
                        if (t.IsFaulted)
                        {
                            tcs.TrySetException(t.Exception);
                        }
                        else
                        {
                            Dictionary<string, SkpComponent> components = t.Result.ToDictionary(p => p.Identity, p => p);
                            tcs.TrySetResult(components);
                        }
                    });
                }
                else
                {
                    tcs.TrySetResult(new Dictionary<string, SkpComponent>());
                }
            });

            return tcs.Task;
        }

        public void Dispose()
        {
            m_model = null;
            foreach (var item in m_instances.Keys)
            {
                m_instances[item].Dispose();
            }
            m_instances.Clear();
            foreach (var item in m_groups.Keys)
            {
                m_groups[item].Dispose();
            }
            m_groups.Clear();
            foreach (var item in m_faces.Keys)
            {
                m_faces[item].Dispose();
            }
            foreach (var item in m_clusters.Keys)
            {
                m_clusters[item].Dispose();
            }
            m_clusters.Clear();
        }

        #endregion
    }
}
