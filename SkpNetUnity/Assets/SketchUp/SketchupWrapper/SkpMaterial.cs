using PgSkpDK.SketchupRef;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PgSkpDK.SketchupWrapper
{
    /// <summary>
    /// 材质
    /// </summary>
    public class SkpMaterial:IDisposable
    {
        #region private static members

        private static Material g_opaqueStandard;
        private static Material g_transparentStandard;

        #endregion

        #region private static properties

        private static Material OpaqueStandard
        {
            get
            {
                if (g_opaqueStandard == null)
                {
                    g_opaqueStandard = Resources.Load<Material>("material/Opaque_Standard");
                }
                return g_opaqueStandard;
            }
        }

        private static Material TransparentStandard
        {
            get
            {
                if (g_transparentStandard == null)
                {
                    g_transparentStandard = Resources.Load<Material>("material/Transparent_Standard");
                }
                return g_transparentStandard;
            }
        }

        #endregion

        #region private members

        private SkpModel m_model;
        private string m_identity;
        private SUColor m_color;
        private string m_name;
        private double m_opacity;
        private SkpTexture m_materialTexture;
        private bool m_drawTransparent;

        private Material m_material;

        private List<Renderer> m_renderers;

        #endregion

        #region public properties

        /// <summary>
        /// 设置或获取Identity
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

        public SUColor Color
        {
            set
            {
                m_color = value;
            }
            get
            {
                return m_color;
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

        public double Opacity
        {
            set
            {
                m_opacity = value;
            }
            get
            {
                return m_opacity;
            }
        }

        public SkpTexture MaterialTexture
        {
            set
            {
                m_materialTexture = value;
            }
            get
            {
                return m_materialTexture;
            }
        }

        public bool DrawTransparent
        {
            set
            {
                m_drawTransparent = value;
            }
            get
            {
                return m_drawTransparent;
            }
        }

        public Material UnityMaterial
        {
            get
            {
                return m_material;
            }
        }

        public List<Renderer> Renderers
        {
            get
            {
                return m_renderers;
            }
        }

        /// <summary>
        /// 获取模型
        /// </summary>
        public SkpModel Model
        {
            get
            {
                return m_model;
            }
        }

        #endregion

        #region constructors

        public SkpMaterial(SkpModel p_model)
        {
            m_color = new SUColor() { red = 255, green = 255, blue = 255, alpha = 255 };
            m_model = p_model;
        }

        #endregion

        #region public functions

        public void AddMeshRenderer(Renderer render)
        {
            if (m_renderers == null)
                m_renderers = new List<Renderer>();
            m_renderers.Add(render);
        }

        public void RemoveRenderer(Renderer render)
        {
            if (m_renderers == null)
                m_renderers = new List<Renderer>();
            if (m_renderers.Contains(render))
                m_renderers.Remove(render);
        }

        public void DestroyUnityMaterial()
        {
            if (m_material!=null)
            {
                UnityEngine.Object.DestroyImmediate(m_material);
                m_material = null;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="p_suMaterialRef"></param>
        public void Load(SUMaterialRef p_suMaterialRef)
        {
            SUEntityRef entityRef = SKPCExport.SUMaterialToEntity(p_suMaterialRef);
            Identity = SkpEntityCache.GetIdentity(entityRef);

            if (p_suMaterialRef.ptr == IntPtr.Zero)
            {
                Debug.LogError("材质为空");
                return;
            }

            SUStringRef name = default;
            SKPCExport.SUStringCreate(ref name);
            SKPCExport.SUMaterialGetName(p_suMaterialRef, ref name);
            m_name = Utilities.GetString(name);
            SKPCExport.SUStringRelease(ref name);

            double opactity = 0;
            SKPCExport.SUMaterialGetOpacity(p_suMaterialRef, ref opactity);
            m_opacity = opactity;

            SUColor color = default;
            SKPCExport.SUMaterialGetColor(p_suMaterialRef, ref color);
            m_color = color;

            SUTextureRef texture = default;
            SKPCExport.SUMaterialGetTexture(p_suMaterialRef, ref texture);
            m_materialTexture = new SkpTexture(texture);

            bool transparent = default;
            SKPCExport.SUMaterialIsDrawnTransparent(p_suMaterialRef, ref transparent);
            m_drawTransparent = transparent;
        }

        public void GenerateUnityMaterial()
        {
            if (m_material != null)
            {
                UnityEngine.Object.DestroyImmediate(m_material);
                m_material = null;
            }

            bool transparent = false;
            if (m_drawTransparent)
            {
                transparent = true;
            }

            Material materialPrototype = transparent ? TransparentStandard : OpaqueStandard;
            m_material = UnityEngine.Object.Instantiate(materialPrototype);
            m_material.SetColor("_Color", m_color.ToUnityColor());
            if (m_materialTexture != null)
            {
                m_material.SetTexture("_MainTex", m_materialTexture.UnityTexture);
            }

            m_material.name = Identity;
        }

        #endregion

        #region public static functions

        /// <summary>
        /// 获取层名称
        /// </summary>
        /// <param name="suMaterialRef"></param>
        /// <returns></returns>
        public static string GetIdentity(SUMaterialRef suMaterialRef)
        {
            return SkpEntityCache.GetIdentity(SKPCExport.SUMaterialToEntity(suMaterialRef));
        }

        public static Dictionary<string, SkpMaterial> GetMaterials(SUModelRef p_suModel, SkpModel p_model)
        {
            Dictionary<string, SkpMaterial> materials = new Dictionary<string, SkpMaterial>(500);

            long materialsCount = 0;
            SKPCExport.SUModelGetNumMaterials(p_suModel, ref materialsCount);

            if (materialsCount > 0)
            {
                SUMaterialRef[] materialRefs = new SUMaterialRef[materialsCount];
                SKPCExport.SUModelGetMaterials(p_suModel, materialsCount, materialRefs, ref materialsCount);

                for (long i = 0; i < materialsCount; i++)
                {
                    SkpMaterial material = new SkpMaterial(p_model);
                    material.Load(materialRefs[i]);
                    materials.Add(material.Identity, material);
                }
            }
            return materials;
        }

        public static Task<Dictionary<string, SkpMaterial>> GetMaterialsAsync(SUModelRef p_suModel, SkpModel p_model)
        {
            TaskCompletionSource<Dictionary<string, SkpMaterial>> tcs = new TaskCompletionSource<Dictionary<string, SkpMaterial>>();
            long materialsCount = 0;
            SKPCExport.SUModelGetNumMaterials(p_suModel, ref materialsCount);
            if (materialsCount > 0)
            {
                SUMaterialRef[] materialRefs = new SUMaterialRef[materialsCount];
                SKPCExport.SUModelGetMaterials(p_suModel, materialsCount, materialRefs, ref materialsCount);

                TaskExcutor.Run<SkpMaterial, SUMaterialRef>(materialRefs, m =>
                {
                    SkpMaterial material = new SkpMaterial(p_model);
                    material.Load(m);
                    return material;
                }).ContinueWith(t=> 
                {
                    if (t.IsFaulted)
                    {
                        tcs.TrySetException(t.Exception);
                    }
                    else
                    {
                        Dictionary<string, SkpMaterial> materials = t.Result.ToDictionary(p => p.Identity, p => p);
                        tcs.TrySetResult(materials);
                    }
                });
            }
            else
            {
                tcs.TrySetResult(new Dictionary<string, SkpMaterial>());
            }
            return tcs.Task;
        }

        public static Texture2D GenerateTextureFromFile(string p_rootDirectory, string p_path, Texture2D p_default = null)
        {
            if (string.IsNullOrEmpty(p_path) || string.IsNullOrEmpty(p_rootDirectory))
            {
                return null;
            }
            string path = string.Format($"{p_rootDirectory}//{p_path}");
            if (!System.IO.File.Exists(path))
            {
                return p_default;
            }
            try
            {
                byte[] buffer = System.IO.File.ReadAllBytes(path);
                Texture2D texture = new Texture2D(1, 1, TextureFormat.ARGB32, true, true);
                texture.LoadImage(buffer);
                return texture;
            }
            catch (Exception ex)
            {
                return p_default;
            }
        }

        public void Dispose()
        {
            m_model = null;
            m_identity = null;
            if (m_materialTexture != null)
            {
                m_materialTexture.Dispose();
                m_materialTexture = null;
            }
        }

        #endregion
    }
}
