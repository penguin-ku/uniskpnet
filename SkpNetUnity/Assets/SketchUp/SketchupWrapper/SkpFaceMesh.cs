using PgSkpDK.SketchupRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace PgSkpDK.SketchupWrapper
{
    public class SkpFaceMesh:IDisposable
    {
        #region private members

        private SUPoint3D[] m_vertices;
        private SUPoint3D[] m_uvsFront;
        private SUPoint3D[] m_uvsBack;
        private SUVector3D[] m_normals;
        private int[] m_triangles;
        private SkpFace m_face;

        #endregion

        #region public properties

        public SUPoint3D[] Vertices
        {
            set
            {
                m_vertices = value;
            }
            get
            {
                return m_vertices;
            }
        }

        public SUPoint3D[] UVsFront
        {
            set
            {
                m_uvsFront = value;
            }
            get
            {
                return m_uvsFront;
            }
        }

        public SUPoint3D[] UVsBack
        {
            set
            {
                m_uvsBack = value;
            }
            get
            {
                return m_uvsBack;
            }
        }


        public int[] Triangles
        {
            set
            {
                m_triangles = value;
            }
            get
            {
                return m_triangles;
            }
        }

        public SkpFace Face
        {
            get
            {
                return m_face;
            }
        }

        public SUVector3D[] Normals
        {
            set
            {
                m_normals = value;
            }
            get
            {
                return  m_normals;
            }
        }

        #endregion

        #region constructors

        /// <summary>
        /// 构造函数
        /// </summary>
        public SkpFaceMesh(SkpFace p_face)
        {
            m_face = p_face;
            m_vertices = new SUPoint3D[0];
            m_uvsFront = new SUPoint3D[0];
            m_uvsBack = new SUPoint3D[0];
            m_normals = new SUVector3D[0];
            m_triangles = new int[0];
        }

        #endregion

        #region public functions

        public void Load(SUFaceRef face)
        {
            SUMeshHelperRef helper = default(SUMeshHelperRef);
            SKPCExport.SUMeshHelperCreate(ref helper, face);
            long vCount = 0;
            SKPCExport.SUMeshHelperGetNumVertices(helper, ref vCount);
            if (vCount > 0)
            {
                m_vertices = new SUPoint3D[vCount];
                SKPCExport.SUMeshHelperGetVertices(helper, vCount, m_vertices, ref vCount);

                for (int i = 0; i < vCount; i++)
                {
                    m_vertices[i].x *= 0.0254;
                    m_vertices[i].y *= 0.0254;
                    m_vertices[i].z *= 0.0254;
                }
            }

            long fCount = 0;
            long ret = 0;
            SKPCExport.SUMeshHelperGetNumTriangles(helper, ref fCount);
            if (fCount > 0)
            {
                long[] fs = new long[3 * fCount];
                m_triangles = new int[3 * fCount];
                SKPCExport.SUMeshHelperGetVertexIndices(helper, 3 * fCount, fs, ref ret);

                for (long j = 0; j < 3 * fCount; j++)
                {
                    m_triangles[j] = (int)fs[j];
                }
            }

            long frontUVCount = 0;
            SKPCExport.SUMeshHelperGetNumVertices(helper, ref frontUVCount);
            if (frontUVCount > 0)
            {
                m_uvsFront = new SUPoint3D[frontUVCount];
                SKPCExport.SUMeshHelperGetFrontSTQCoords(helper, frontUVCount, m_uvsFront, ref frontUVCount);
            }

            long backUVCount = 0;
            SKPCExport.SUMeshHelperGetNumVertices(helper, ref backUVCount);
            if (backUVCount > 0)
            {
                m_uvsBack = new SUPoint3D[backUVCount];
                SKPCExport.SUMeshHelperGetBackSTQCoords(helper, backUVCount, m_uvsBack, ref backUVCount);
            }

            long normalCount = 0;
            SKPCExport.SUMeshHelperGetNumVertices(helper, ref normalCount);
            if (backUVCount > 0)
            {
                m_normals = new SUVector3D[normalCount];
                SKPCExport.SUMeshHelperGetNormals(helper, normalCount, m_normals, ref normalCount);
            }

            SKPCExport.SUMeshHelperRelease(ref helper);
        }

        public Mesh GenerateMesh(Mesh mesh)
        {
            if (mesh == null)
            {
                mesh = new Mesh();
            }
            // 神奇操作要上演
            // 1、sketchup右手，所以坐标需要yz对换
            // 2、坐标系对换得直接后果是三角面得描述需要反向
            mesh.vertices = m_vertices.Select(p => new Vector3((float)p.x, (float)p.z, (float)p.y)).ToArray();

            mesh.uv = m_uvsFront.Select(p => p.ToVector2()).ToArray();
            List<int> triangles = new List<int>();
            for (int i = 0; i < m_triangles.Length / 3; i++)
            {
                triangles.Add(m_triangles[i * 3]);
                triangles.Add(m_triangles[i * 3 + 2]);
                triangles.Add(m_triangles[i * 3 + 1]);
            }
            mesh.triangles = triangles.ToArray();

            mesh.RecalculateBounds();
            mesh.RecalculateNormals();
            mesh.RecalculateTangents();

            return mesh;
        }

        public Tuple<Vector3[], Vector2[], Vector3[], int[]> GenerateFrontMeshData()
        {
            // 神奇操作要上演
            // 1、sketchup右手，所以坐标需要yz对换
            // 2、坐标系对换得直接后果是三角面得描述需要反向
            var vertices = m_vertices.Select(p => new Vector3((float)p.x, (float)p.z, (float)p.y)).ToArray();
            var uv = m_uvsFront.Select(p => p.ToVector2()).ToArray();
            var normals = m_normals.Select(p => new Vector3((float)p.x, (float)p.z, (float)p.y)).ToArray();
            List<int> triangles = new List<int>();
            for (int i = 0; i < m_triangles.Length / 3; i++)
            {
                triangles.Add(m_triangles[i * 3]);
                triangles.Add(m_triangles[i * 3 + 2]);
                triangles.Add(m_triangles[i * 3 + 1]);
            }
            var tris = triangles.ToArray();

            return new Tuple<Vector3[], Vector2[], Vector3[], int[]>(vertices, uv, normals, tris);
        }

        /// <summary>
        /// 生成背面
        /// </summary>
        /// <returns></returns>
        public Tuple<Vector3[], Vector2[], Vector3[], int[]> GenerateBackMeshData()
        {
            // 神奇操作要上演
            // 1、sketchup右手，所以坐标需要yz对换
            // 2、坐标系对换得直接后果是三角面得描述需要反向
            var vertices = m_vertices.Select(p => new Vector3((float)p.x, (float)p.z, (float)p.y)).ToArray();
            var uv = m_uvsBack.Select(p => p.ToVector2()).ToArray();
            var normals = m_normals.Select(p => new Vector3((float)-p.x, (float)-p.z, (float)-p.y)).ToArray();
            List<int> triangles = new List<int>();
            for (int i = 0; i < m_triangles.Length / 3; i++)
            {
                triangles.Add(m_triangles[i * 3]);
                triangles.Add(m_triangles[i * 3 + 1]);
                triangles.Add(m_triangles[i * 3 + 2]);

            }
            var tris = triangles.ToArray();

            return new Tuple<Vector3[], Vector2[], Vector3[], int[]>(vertices, uv, normals, tris);
        }

        public void Dispose()
        {
            m_vertices = null;
            m_uvsFront = null;
            m_uvsBack = null;
            m_normals = null;
            m_triangles = null;
            m_face = null;
        }

        #endregion
    }
}
