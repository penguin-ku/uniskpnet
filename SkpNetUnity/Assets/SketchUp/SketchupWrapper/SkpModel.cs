using PgSkpDK.SketchupRef;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.TaskExtension;

namespace PgSkpDK.SketchupWrapper
{
    public class SkpModel : IDisposable
    {
        #region private members

        private Dictionary<string, SkpMaterial> m_materials = new Dictionary<string, SkpMaterial>();         // 材质
        private Dictionary<string, SkpComponent> m_components = new Dictionary<string, SkpComponent>();      // 材质
        private Dictionary<string, SkpInstance> m_instances = new Dictionary<string, SkpInstance>();         // 实例
        private Dictionary<string, SkpGroup> m_groups = new Dictionary<string, SkpGroup>();                  // 组
        private Dictionary<string, SkpFace> m_faces = new Dictionary<string, SkpFace>();                     // 面
        private Dictionary<string, SkpFaceCluster> m_clusers = new Dictionary<string, SkpFaceCluster>();     // 面簇
        private string m_filePath;                                                                              // 文件路径
        private SkpMaterial m_defaultMaterial;                                                                  // 默认材质

        private GameObject m_unityObject;

        #endregion

        #region public events

        /// <summary>
        /// 开始刷新事件
        /// </summary>
        public event Action BeginRefreshModelEvent;

        /// <summary>
        /// 结束刷新事件
        /// </summary>
        public event Action EndRefreshModelEvent;

        /// <summary>
        /// 物体生成事件
        /// </summary>
        public event Action<SkpModel> GameObjectCreatedEvent;

        #endregion

        #region public properties

        //public List<IMeshContainer> MeshContainers
        //{
        //    get
        //    {
        //        return m_meshContainer;
        //    }
        //}

        public GameObject UnityObject
        {
            get
            {
                return m_unityObject;
            }
        }

        public string FilePath
        {
            get
            {
                return m_filePath;
            }
        }

        public string FileName
        {
            get
            {
                return new System.IO.FileInfo(m_filePath).Name;
            }
        }

        public string FileDirectory
        {
            get
            {
                return new System.IO.FileInfo(m_filePath).DirectoryName;
            }
        }

        //public Dictionary<string, SkpLayer> Layters
        //{
        //    get
        //    {
        //        return m_layers;
        //    }
        //}

        public Dictionary<string, SkpMaterial> Materials
        {
            get
            {
                return m_materials;
            }
        }

        /// <summary>
        /// 默认材质，每个文档独享一份，彼此不干扰
        /// </summary>
        public SkpMaterial DefaultMaterial
        {
            get
            {
                if (m_defaultMaterial == null)
                {
                    m_defaultMaterial = new SkpMaterial(this);
                    m_defaultMaterial.Identity = DefaultMaterialName;
                    m_defaultMaterial.Name = DefaultMaterialName;
                    m_defaultMaterial.GenerateUnityMaterial();
                }
                return m_defaultMaterial;
            }
        }

        /// <summary>
        /// 默认材质，每个文档独享一份，彼此不干扰
        /// </summary>
        public string DefaultMaterialName
        {
            get
            {
                return "less_default";
            }
        }

        public Dictionary<string, SkpComponent> Components
        {
            get
            {
                return m_components;
            }
        }

        public Dictionary<string, SkpInstance> Instances
        {
            get
            {
                return m_instances;
            }
        }

        public Dictionary<string, SkpGroup> Groups
        {
            get
            {
                return m_groups;
            }
        }

        public Dictionary<string, SkpFaceCluster> Clusters
        {
            get
            {
                return m_clusers;
            }
            set
            {
                m_clusers = value;
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

        //public Dictionary<string, SkpLayer> Layers
        //{
        //    get
        //    {
        //        return m_layers;
        //    }
        //}

        #endregion

        #region constructors

        public SkpModel(string p_fileName)
        {
            m_filePath = p_fileName;
        }

        #endregion

        #region public functions

        /// <summary>
        /// Load SKP Model
        /// </summary>
        public void LoadModel()
        {
            Task.Run(() =>
            {
                try
                {
                    Debug.Log("begin: " +  DateTime.Now.ToString("HH:mm:ss ffffff"));

                    SKPCExport.SUInitialize();
                    Debug.Log("SUInitialize: " + DateTime.Now.ToString("HH:mm:ss ffffff"));

                    SUModelRef model = default(SUModelRef);

                    SUResult res = SKPCExport.SUModelCreateFromFile(ref model, m_filePath);
                    Debug.Log("SUModelCreateFromFile: " + DateTime.Now.ToString("HH:mm:ss ffffff"));
                    if (res != SUResult.SU_ERROR_NONE)
                        return;
                    m_materials = SkpMaterial.GetMaterialsAsync(model, this).Result;
                    Debug.Log("GetMaterials: " + m_materials.Count + " " + DateTime.Now.ToString("HH:mm:ss ffffff"));
                    // 解析所有组件
                    m_components = SkpComponent.GetComponentsAsync(model, this).Result;
                    Debug.Log("GetComponents: " + m_components.Count + " " + DateTime.Now.ToString("HH:mm:ss ffffff"));

                    SUEntitiesRef entities = default;
                    SKPCExport.SUModelGetEntities(model, ref entities);

                    m_groups = SkpGroup.GetEntityGroupsAsync(entities, this).Result;
                    Debug.Log("GetEntityGroups: " + m_groups.Count + " " + DateTime.Now.ToString("HH:mm:ss ffffff"));
                    m_faces = SkpFace.GetEntityFacesAsync(entities, this).Result;

                    // 根据层，材质分类汇总
                    m_clusers = SkpFaceCluster.Load(m_faces.Values, this);
                    Debug.Log("GetEntityFaces: " + m_instances.Count + " " + DateTime.Now.ToString("HH:mm:ss ffffff"));
                    m_instances = SkpInstance.GetEntityInstancesAsync(entities, this).Result;
                    Debug.Log("GetEntityInstances: " + m_faces.Count + " " + DateTime.Now.ToString("HH:mm:ss ffffff"));

                    SKPCExport.SUModelRelease(ref model);
                    Debug.Log(DateTime.Now.ToString("HH:mm:ss ffffff"));
                    SKPCExport.SUTerminate();
                    BeginRefreshModelEvent?.Invoke();
                    Debug.Log(DateTime.Now.ToString("HH:mm:ss ffffff"));

                    GenerateGameObject();
                }
                catch (Exception ex)
                {
                    string error = "加载模型失败：原因" + ex;
                    Debug.LogError(error);
                    throw ex;
                }
            });
        }

        public SkpMaterial GetMaterial(string p_materialName)
        {
            if (string.IsNullOrEmpty(p_materialName))
            {
                return DefaultMaterial;
            }
            if (m_materials.ContainsKey(p_materialName))
            {
                return m_materials[p_materialName];
            }
            return DefaultMaterial;
        }

        public GameObject GenerateComponetIfNeed(string p_componentGuid)
        {
            if (!m_components.ContainsKey(p_componentGuid))
            {
                return new GameObject();
            }

            SkpComponent skpComponent = m_components[p_componentGuid];
            skpComponent.GameObject.transform.SetParent(m_unityObject.transform.Find("prefabs"));
            skpComponent.GameObject.transform.localRotation = Quaternion.identity;
            skpComponent.GameObject.transform.localPosition = Vector3.zero;
            skpComponent.GameObject.transform.localScale = Vector3.one;

            return skpComponent.GameObject;
        }

        public void Dispose()
        {
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
            foreach (var item in m_clusers.Keys)
            {
                m_clusers[item].Dispose();
            }
            m_clusers.Clear();
            foreach (var item in m_materials.Keys)
            {
                m_materials[item].Dispose();
            }
            m_materials.Clear();

            if (m_defaultMaterial != null)
            {
                m_defaultMaterial.Dispose();
                m_defaultMaterial = null;
            }

            GC.Collect();
            GC.Collect();
            GC.Collect();
            GC.Collect();
            GC.Collect();
            GC.Collect();
            GC.Collect();
            GC.Collect();
        }

        #endregion

        #region private functions

        private void GenerateGameObject()
        {
            UnityTask.Run(() =>
            {
                foreach (var item in m_components.Keys)
                {
                    m_components[item].DestroyGameObject();
                }
                if (m_unityObject != null)
                {
                    UnityEngine.Object.DestroyImmediate(m_unityObject);
                    m_unityObject = null;
                }

                m_unityObject = new GameObject(new System.IO.FileInfo(m_filePath).Name);

                GameObject prefabs = new GameObject("prefabs");
                prefabs.transform.SetParent(m_unityObject.transform);
                prefabs.transform.localRotation = Quaternion.identity;
                prefabs.transform.localPosition = Vector3.zero;
                prefabs.transform.localScale = Vector3.one;

                foreach (var item in m_materials.Keys)
                {
                    m_materials[item].GenerateUnityMaterial();
                }

                foreach (var item in m_clusers.Keys)
                {
                    m_clusers[item].GenerateGameObject(m_unityObject.transform);
                }
                foreach (var item in m_instances.Keys)
                {
                    m_instances[item].GenerateGameObject(m_unityObject.transform);
                }
                foreach (var item in m_groups.Keys)
                {
                    m_groups[item].GenerateGameObject(m_unityObject.transform);
                }
                GameObjectCreatedEvent?.Invoke(this);

                EndRefreshModelEvent?.Invoke();

                Debug.Log(DateTime.Now.ToString("HH:mm:ss ffffff"));
            });
        }

        #endregion
    }
}
