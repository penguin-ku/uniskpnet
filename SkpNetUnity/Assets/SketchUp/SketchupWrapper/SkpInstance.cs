using PgSkpDK.SketchupRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using size_t = System.Int64;

namespace PgSkpDK.SketchupWrapper
{
    /// <summary>
    /// 实例
    /// </summary>
    public class SkpInstance:IDisposable
    {
        #region private members

        private string m_identity;
        private SkpModel m_model;
        private string m_defaultMaterialIdentity;

        private SkpTransform m_transform;
        private string m_componentIdentity;
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
        /// 设置或获取变换矩阵
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
        /// 设置或获取组件（原型）
        /// </summary>
        public string ComponentIdentity
        {
            set
            {
                m_componentIdentity = value;
            }
            get
            {
                return m_componentIdentity;
            }
        }

        public string Name
        {
            set
            {
                m_name = value;
            }
            get
            {
                return m_name;
            }
        }

        #endregion

        #region constructors

        public SkpInstance(SkpModel p_model)
        {
            m_model = p_model;
        }


        #endregion

        #region public functions

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="p_suInstance"></param>
        public void Load(SUComponentInstanceRef p_suInstance)
        {
            SUDrawingElementRef drawingRef = SKPCExport.SUComponentInstanceToDrawingElement(p_suInstance);
            SUEntityRef entityRef = SKPCExport.SUDrawingElementToEntity(drawingRef);

            m_identity = SkpEntityCache.GetIdentity(entityRef);
            m_defaultMaterialIdentity = SkpEntityCache.GetMaterialDefault(drawingRef);

            SUComponentDefinitionRef definition = default(SUComponentDefinitionRef);
            SKPCExport.SUComponentInstanceGetDefinition(p_suInstance, ref definition);
            m_componentIdentity = SkpComponent.GetIdentity(definition);

            SUStringRef instanceName = default(SUStringRef);
            SKPCExport.SUStringCreate(ref instanceName);
            SKPCExport.SUComponentInstanceGetName(p_suInstance, ref instanceName);
            m_name = Utilities.GetString(instanceName);
            SKPCExport.SUStringRelease(ref instanceName);

            SUTransformation transform = default(SUTransformation);
            SKPCExport.SUComponentInstanceGetTransform(p_suInstance, ref transform);
            m_transform = new SkpTransform(transform);

            if (string.IsNullOrEmpty(m_name))
            {
                SUComponentDefinitionRef componentRef = default(SUComponentDefinitionRef);
                SKPCExport.SUComponentInstanceGetDefinition(p_suInstance, ref componentRef);
                SUStringRef componentName = default(SUStringRef);
                SKPCExport.SUStringCreate(ref componentName);
                SKPCExport.SUComponentDefinitionGetName(componentRef, ref componentName);
                m_name = Utilities.GetString(componentName);
                SKPCExport.SUStringRelease(ref componentName);
            }
        }

        /// <summary>
        /// 生成GameObject
        /// </summary>
        /// <param name="parents"></param>
        public void GenerateGameObject(Transform parents)
        {
            GameObject gObject = GameObject.Instantiate(m_model.GenerateComponetIfNeed(m_componentIdentity));
            gObject.name = $"{Identity}";
            gObject.transform.SetParent(parents);
            gObject.transform.localRotation = Quaternion.identity;
            gObject.transform.localPosition = Vector3.zero;
            gObject.transform.localScale = Vector3.one;

            // transform转述，前方高能
            m_transform.ToTransform(gObject.transform);

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

            gObject.gameObject.SetActive(true);
        }

        #endregion

        #region public static functions

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="p_model"></param>
        /// <returns></returns>
        public static Dictionary<string, SkpInstance> GetEntityInstances(SUEntitiesRef entities, SkpModel p_model)
        {
            Dictionary<string, SkpInstance> instancelist = new Dictionary<string, SkpInstance>(100);

            size_t instanceCount = 0;
            SKPCExport.SUEntitiesGetNumInstances(entities, ref instanceCount);

            if (instanceCount > 0)
            {
                SUComponentInstanceRef[] instances = new SUComponentInstanceRef[instanceCount];
                SKPCExport.SUEntitiesGetInstances(entities, instanceCount, instances, ref instanceCount);

                for (size_t i = 0; i < instanceCount; i++)
                {
                    SkpInstance inst = new SkpInstance(p_model);
                    inst.Load(instances[i]);
                    instancelist.Add(inst.Identity, inst);
                }
            }

            return instancelist;
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="entities"></param>
        /// <param name="p_model"></param>
        /// <returns></returns>
        public static Task<Dictionary<string, SkpInstance>> GetEntityInstancesAsync(SUEntitiesRef entities, SkpModel p_model)
        {
            TaskCompletionSource<Dictionary<string, SkpInstance>> tcs = new TaskCompletionSource<Dictionary<string, SkpInstance>>();

            size_t instanceCount = 0;
            SKPCExport.SUEntitiesGetNumInstances(entities, ref instanceCount);

            if (instanceCount > 0)
            {
                SUComponentInstanceRef[] instances = new SUComponentInstanceRef[instanceCount];
                SKPCExport.SUEntitiesGetInstances(entities, instanceCount, instances, ref instanceCount);

                TaskExcutor.Run<SkpInstance, SUComponentInstanceRef>(instances, i => 
                {
                    SkpInstance inst = new SkpInstance(p_model);
                    inst.Load(i);
                    return inst;
                }).ContinueWith(t=> 
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
                tcs.TrySetResult(new Dictionary<string, SkpInstance>());
            }

            return tcs.Task;
        }

        public void Dispose()
        {
            m_identity = null;
            m_model = null;
            m_defaultMaterialIdentity = null;
            m_transform = null;
            m_componentIdentity = null;
            m_name = null;
        }


        #endregion
    }
}
