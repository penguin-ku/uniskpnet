using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PgSkpDK.SketchupWrapper
{
    /// <summary>
    /// 面簇，多个面形成一个物体
    /// </summary>
    public class SkpFaceCluster : IDisposable
    {
        #region private members

        private string m_clusterID;
        private string m_materialIdentity;
        private SkpModel m_model;
        Vector3[] m_vertices;
        Vector2[] m_uvs;
        Vector3[] m_normals;
        int[] m_tris;

        #endregion

        #region publicproperties

        public string ClusterID
        {
            get
            {
                return m_clusterID;
            }
        }

        #endregion

        #region constructors

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="p_faceArray"></param>
        /// <param name="p_layerIdentity"></param>
        /// <param name="p_materialIdentity"></param>
        /// <param name="p_mesh"></param>
        public SkpFaceCluster(List<Tuple<SkpFace, bool>> p_faceArray, string p_materialIdentity, List<Tuple<Vector3[], Vector2[], Vector3[], int[]>> p_mesh, SkpModel p_model)
        {
            m_clusterID = $"{p_materialIdentity}";
            m_materialIdentity = p_materialIdentity;
            m_model = p_model;

            List<Vector3> vertices = new List<Vector3>();
            List<Vector2> uvs = new List<Vector2>();
            List<Vector3> normals = new List<Vector3>();
            List<int> tris = new List<int>();

            foreach (var itemMesh in p_mesh)
            {
                int verticesCount = vertices.Count;
                
                vertices.AddRange(itemMesh.Item1);
                uvs.AddRange(itemMesh.Item2);
                normals.AddRange(itemMesh.Item3);
                tris.AddRange(itemMesh.Item4.Select(p => p + verticesCount));
            }

            m_vertices = vertices.ToArray();
            m_uvs = uvs.ToArray();
            m_normals = normals.ToArray();
            m_tris = tris.ToArray();
        }

        #endregion

        #region public functions

        public void GenerateGameObject(Transform transform)
        {
            string materialName = m_materialIdentity;
            if (string.IsNullOrEmpty(materialName) && !m_model.Materials.ContainsKey(materialName))
            {
                materialName = m_model.DefaultMaterialName;
            }

            var skpMaterial = m_model.GetMaterial(materialName);
            Material material = skpMaterial.UnityMaterial;// 重置默认材质

            Mesh mesh = new Mesh();
            mesh.indexFormat = m_tris.Length >= 65535 ? UnityEngine.Rendering.IndexFormat.UInt32 : UnityEngine.Rendering.IndexFormat.UInt16;
            mesh.vertices = m_vertices.ToArray();
            mesh.uv = m_uvs.ToArray();
            mesh.triangles = m_tris.ToArray();
            mesh.normals = m_normals.ToArray();
            mesh.RecalculateBounds();
            mesh.RecalculateTangents();
            GameObject gObject = new GameObject($"{m_clusterID}");
            gObject.AddComponent<MeshFilter>().mesh = mesh;

            var meshRenderer = gObject.AddComponent<MeshRenderer>();
            meshRenderer.sharedMaterial = material;
            gObject.transform.SetParent(transform);
            gObject.transform.localRotation = Quaternion.identity;
            gObject.transform.localPosition = Vector3.zero;
            gObject.transform.localScale = Vector3.one;

            gObject.name = $"{(m_materialIdentity == m_model.DefaultMaterialName ? m_model.DefaultMaterialName : m_model.Materials[m_materialIdentity].Name)}";
        }

        #endregion

        #region public static functions

        public static Dictionary<string, SkpFaceCluster> Load(IEnumerable<SkpFace> p_faces, SkpModel p_model)
        {
            if (p_faces == null || p_faces.Count() == 0)
            {
                return new Dictionary<string, SkpFaceCluster>();
            }

            Dictionary<string, Tuple<List<Tuple<Vector3[], Vector2[], Vector3[], int[]>>, List<Tuple<SkpFace, bool>>>> objectDatas = new Dictionary<string, Tuple<List<Tuple<Vector3[], Vector2[], Vector3[], int[]>>, List<Tuple<SkpFace, bool>>>>();

            foreach (var item in p_faces)
            {
                string frontMaterialIdentity = string.IsNullOrEmpty(item.FrontMaterialIdentity) ? p_model .DefaultMaterialName: item.FrontMaterialIdentity;
                Tuple<Vector3[], Vector2[], Vector3[], int[]> frontMeshdata = item.FaceMesh.GenerateFrontMeshData();
                if (!objectDatas.ContainsKey(frontMaterialIdentity))
                {
                    objectDatas[frontMaterialIdentity] = new Tuple<List<Tuple<Vector3[], Vector2[], Vector3[], int[]>>, List<Tuple<SkpFace, bool>>>(new List<Tuple<Vector3[], Vector2[], Vector3[], int[]>>(), new List<Tuple<SkpFace, bool>>());
                }
                objectDatas[frontMaterialIdentity].Item1.Add(frontMeshdata);
                objectDatas[frontMaterialIdentity].Item2.Add(new Tuple<SkpFace, bool>(item, true));

                string backMaterialIdentity = string.IsNullOrEmpty(item.BackMaterialIdentity) ? p_model.DefaultMaterialName : item.BackMaterialIdentity;
                Tuple<Vector3[], Vector2[], Vector3[], int[]> backMeshdata = item.FaceMesh.GenerateBackMeshData();
                if (!objectDatas.ContainsKey(backMaterialIdentity))
                {
                    objectDatas[backMaterialIdentity] = new Tuple<List<Tuple<Vector3[], Vector2[], Vector3[], int[]>>, List<Tuple<SkpFace, bool>>>(new List<Tuple<Vector3[], Vector2[], Vector3[], int[]>>(), new List<Tuple<SkpFace, bool>>());
                }
                objectDatas[backMaterialIdentity].Item1.Add(backMeshdata);
                objectDatas[backMaterialIdentity].Item2.Add(new Tuple<SkpFace, bool>(item, false));
            }

            Dictionary<string, SkpFaceCluster> clusters = new Dictionary<string, SkpFaceCluster>();
            foreach (var materialIdentity in objectDatas.Keys)
            {
                List<Tuple<Vector3[], Vector2[], Vector3[], int[]>> meshDatas = objectDatas[materialIdentity].Item1;
                List<Tuple<SkpFace, bool>> faces = objectDatas[materialIdentity].Item2;

                SkpFaceCluster cluster = new SkpFaceCluster(faces, materialIdentity, meshDatas, p_model);
                clusters.Add(cluster.m_clusterID, cluster);
            }

            return clusters;
        }

        public void Dispose()
        {
            m_clusterID = null;
            m_materialIdentity = null;
            m_model = null;
            m_vertices = null;
            m_uvs = null;
            m_normals = null;
            m_tris = null;
        }

        #endregion
    }
}
