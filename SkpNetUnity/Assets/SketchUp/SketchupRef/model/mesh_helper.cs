using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SU_RESULT = PgSkpDK.SketchupRef.SUResult;
using size_t = System.Int64;
using int32_t = System.Int32;
using int64_t = System.Int64;
using System.Runtime.InteropServices;
using SUByte = System.Byte;

namespace PgSkpDK.SketchupRef
{
    /// <summary>
    /// A helper class that will tessellate a SUFaceRef object into triangles, and then provide the vertices, normals, and STQ coordinates of those triangles.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUMeshHelperRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// mesh_helper
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Creates a tessellated polygon mesh object from a face object.
        /// </summary>
        /// <param name="mesh_ref">[out] The mesh object created.</param>
        /// <param name="face_ref">[in] The face object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if mesh_ref is NULL
        /// SU_ERROR_OVERWRITE_VALID if mesh_ref already references a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUMeshHelperCreate(ref SUMeshHelperRef mesh_ref, SUFaceRef face_ref);

        /// <summary>
        /// Creates a tessellated polygon mesh object from a face object and the
        /// texture writer object used to write the material texture(s) of the face
        /// object.
        /// </summary>
        /// <param name="mesh_ref">[out] The mesh object created.</param>
        /// <param name="face_ref">[in] The face object.</param>
        /// <param name="texture_writer_ref">[in] The texture writer object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if face_ref or texture_writer_ref is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if mesh_ref is NULL
        /// SU_ERROR_OVERWRITE_VALID if mesh_ref already references a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUMeshHelperCreateWithTextureWriter(ref SUMeshHelperRef mesh_ref, SUFaceRef face_ref, SUTextureWriterRef texture_writer_ref);

        /// <summary>
        /// Creates a tessellated polygon mesh object from a face and a UV helper associated with the face.
        /// </summary>
        /// <param name="mesh_ref">[out] The mesh object created.</param>
        /// <param name="face_ref">[in] The face object.</param>
        /// <param name="uv_celper_ref">[in] The UV helper object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if face_ref or uv_celper_ref is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if mesh_ref is NULL
        /// SU_ERROR_OVERWRITE_VALID if mesh_ref already references a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUMeshHelperCreateWithTextureWriter(ref SUMeshHelperRef mesh_ref, SUFaceRef face_ref, SUUVHelperRef uv_celper_ref);

        /// <summary>
        /// Deallocates a polygon mesh object.
        /// </summary>
        /// <param name="mesh_ref">[in] The mesh object to deallocate.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if mesh_ref is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUMeshHelperRelease(ref SUMeshHelperRef mesh_ref);

        /// <summary>
        /// Retrieves the total number of polygons in the mesh.
        /// </summary>
        /// <param name="mesh_ref">[in] The mesh object.</param>
        /// <param name="count">[out] The number of polygons available.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if mesh_ref is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUMeshHelperGetNumTriangles(SUMeshHelperRef mesh_ref, ref size_t count);

        /// <summary>
        /// Retrieves the total number of vertices in the polygon mesh object.
        /// </summary>
        /// <param name="mesh_ref">[in] The mesh object.</param>
        /// <param name="count">[out] The number of vertices available.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if mesh_ref is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUMeshHelperGetNumVertices(SUMeshHelperRef mesh_ref, ref size_t count);

        /// <summary>
        /// Retrieves the array of indices of the vertices of a triangle mesh
        /// object. The each element indexes into the arrays retrieved with \ref
        /// SUMeshHelperGetVertices, SUMeshHelperGetFrontSTQCoords, \ref
        /// SUMeshHelperGetBackSTQCoords and SUMeshHelperGetNormals.The
        /// elements are sorted so that every three elements (i.e., stride of three)
        /// compose the indices to the three vertices of a triangle.
        /// </summary>
        /// <param name="mesh_ref">[in] The mesh object.</param>
        /// <param name="len">[in] The number of indices to retrieve.</param>
        /// <param name="indices">[out] The indices retrieved.</param>
        /// <param name="count">[out] The number of indices retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if indices or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUMeshHelperGetVertexIndices(SUMeshHelperRef mesh_ref, size_t len, size_t[] indices, ref size_t count);

        /// <summary>
        /// Retrieves the front stq texture coordinates of a triangle mesh object.
        /// </summary>
        /// <param name="mesh_ref">[in] The mesh object.</param>
        /// <param name="len">[in] The number of stq to retrieve.</param>
        /// <param name="stq">[out] The indices retrieved.</param>
        /// <param name="count">[out] The number of stq retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if stq or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUMeshHelperGetVertices(SUMeshHelperRef mesh_ref, size_t len, SUPoint3D[] stq, ref size_t count);

        /// <summary>
        /// Retrieves the front stq texture coordinates of a triangle mesh object.
        /// </summary>
        /// <param name="mesh_ref">[in] The mesh object.</param>
        /// <param name="len">T[in] he number of stq to retrieve.</param>
        /// <param name="stq">[out] The indices retrieved.</param>
        /// <param name="count">[out] The number of stq retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if stq or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUMeshHelperGetFrontSTQCoords(SUMeshHelperRef mesh_ref, size_t len, SUPoint3D[] stq, ref size_t count);

        /// <summary>
        /// Retrieves the back stq texture coordinates of a triangle mesh object.
        /// </summary>
        /// <param name="mesh_ref">[in] The mesh object.</param>
        /// <param name="len">[in] The number of stq to retrieve.</param>
        /// <param name="stq">[out] The indices retrieved.</param>
        /// <param name="count">[out] The number of stq retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if stq or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUMeshHelperGetBackSTQCoords(SUMeshHelperRef mesh_ref, size_t len, SUPoint3D[] stq, ref size_t count);

        /// <summary>
        /// Retrieves the vertex normal vectors of a triangle mesh object.
        /// </summary>
        /// <param name="mesh_ref">[in] The mesh object.</param>
        /// <param name="len">[in] The number of stq to retrieve.</param>
        /// <param name="normals">[out] The vertex normal vectors retrieved.</param>
        /// <param name="count">[out] The number of stq retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if stq or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUMeshHelperGetNormals(SUMeshHelperRef mesh_ref, size_t len, SUVector3D[] normals, ref size_t count);
    }
}
