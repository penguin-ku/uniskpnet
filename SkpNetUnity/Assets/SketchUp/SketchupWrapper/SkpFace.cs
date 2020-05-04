using PgSkpDK.SketchupRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace PgSkpDK.SketchupWrapper
{
    /// <summary>
    /// 面
    /// </summary>
    public class SkpFace:IDisposable
    {
        #region private members

        private string m_identity;
        private SkpModel m_model;
        private string m_frontMaterialIdentity;
        private string m_backMaterialIdentity;
        private SkpFaceMesh m_faceMesh;

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
        /// 设置或获取网格
        /// </summary>
        public SkpFaceMesh FaceMesh
        {
            set
            {
                m_faceMesh = value;
            }
            get
            {
                return m_faceMesh;
            }
        }

        /// <summary>
        /// 设置或获取前表面材质
        /// </summary>
        public string FrontMaterialIdentity
        {
            set
            {
                m_frontMaterialIdentity = value;
            }
            get
            {
                return m_frontMaterialIdentity;
            }
        }

        public string BackMaterialIdentity
        {
            set
            {
                m_backMaterialIdentity = value;
            }
            get
            {
                return m_backMaterialIdentity;
            }
        }

        #endregion

        #region constructors

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="face"></param>
        public SkpFace(SkpModel p_model)
        {
            m_model = p_model;
        }

        #endregion

        #region public functions

        public void Load(SUFaceRef p_suFaceRef)
        {
            SUDrawingElementRef drawingRef = SKPCExport.SUFaceToDrawingElement(p_suFaceRef);
            SUEntityRef entityRef = SKPCExport.SUDrawingElementToEntity(drawingRef);

            m_identity = SkpEntityCache.GetIdentity(entityRef);

            SUMaterialRef suFrontMaterialRef = default(SUMaterialRef);
            SKPCExport.SUFaceGetFrontMaterial(p_suFaceRef, ref suFrontMaterialRef);
            m_frontMaterialIdentity = SkpEntityCache.GetIdentity(SKPCExport.SUMaterialToEntity(suFrontMaterialRef));

            SUMaterialRef suBackMaterialRef = default(SUMaterialRef);
            SKPCExport.SUFaceGetBackMaterial(p_suFaceRef, ref suBackMaterialRef);
            m_backMaterialIdentity = SkpEntityCache.GetIdentity(SKPCExport.SUMaterialToEntity(suBackMaterialRef));

            m_faceMesh = new SkpFaceMesh(this);
            m_faceMesh.Load(p_suFaceRef);
        }

        #endregion

        #region public static functions

        public static Dictionary<string, SkpFace> GetEntityFaces(SUEntitiesRef p_suEntitiesRef, SkpModel p_model)
        {
            Dictionary<string, SkpFace> surfaces = new Dictionary<string, SkpFace>(200);

            long faceCount = 0;
            SKPCExport.SUEntitiesGetNumFaces(p_suEntitiesRef, ref faceCount);

            if (faceCount > 0)
            {
                SUFaceRef[] faces = new SUFaceRef[faceCount];
                SKPCExport.SUEntitiesGetFaces(p_suEntitiesRef, faceCount, faces, ref faceCount);

                for (long i = 0; i < faceCount; i++)
                {
                    SkpFace surface = new SkpFace(p_model);
                    surface.Load(faces[i]);
                    surfaces.Add(surface.Identity, surface);
                }
            }

            return surfaces;
        }

        public static Task<Dictionary<string, SkpFace>> GetEntityFacesAsync(SUEntitiesRef p_suEntitiesRef, SkpModel p_model)
        {
            TaskCompletionSource<Dictionary<string, SkpFace>> tcs = new TaskCompletionSource<Dictionary<string, SkpFace>>();
            long faceCount = 0;
            SKPCExport.SUEntitiesGetNumFaces(p_suEntitiesRef, ref faceCount);

            if (faceCount > 0)
            {
                SUFaceRef[] faces = new SUFaceRef[faceCount];
                SKPCExport.SUEntitiesGetFaces(p_suEntitiesRef, faceCount, faces, ref faceCount);

                TaskExcutor.Run<SkpFace, SUFaceRef>(faces, f =>
                {
                    SkpFace surface = new SkpFace(p_model);
                    surface.Load(f);
                    return surface;
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
                tcs.TrySetResult(new Dictionary<string, SkpFace>());
            }

            return tcs.Task;
        }

        public void Dispose()
        {
            m_identity = null;
            m_model = null;
            m_frontMaterialIdentity = null;
            m_backMaterialIdentity = null;
            if (m_faceMesh != null)
            {
                m_faceMesh.Dispose();
                m_faceMesh = null;
            }
        }

        #endregion
    }
}
