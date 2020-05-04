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
using uint32_t = System.UInt32;
using int16_t = System.Int16;

namespace PgSkpDK.SketchupRef
{
    /// <summary>
    ///  A vertex type that has a position and is associated with other geometry like edges, faces, and loops.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUVertexRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// vertex
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Converts from an SUVertexRef to an SUEntityRef.
        /// This is essentially an upcast operation.
        /// </summary>
        /// <param name="vertex">[in] The given vertex reference.</param>
        /// <returns>
        /// The converted SUEntityRef if vertex is a valid vertex
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUEntityRef SUVertexToEntity(SUVertexRef vertex);

        /// <summary>
        /// Converts from an SUEntityRef to an SUVertexRef.
        /// This is essentially a downcast operation so the given entity must be
        /// convertible to an SUVertexRef.
        /// </summary>
        /// <param name="entity">[in] The given entity reference.</param>
        /// <returns>
        /// The converted SUVertexRef if the downcast operation succeeds
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUVertexRef SUVertexFromEntity(SUEntityRef entity);

        /// <summary>
        /// Retrieves the position of a vertex object.
        /// </summary>
        /// <param name="vertex">[in] The vertex object.</param>
        /// <param name="position">[out] The vertex position.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if vertex is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if position is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUVertexGetPosition(SUVertexRef vertex, ref SUPoint3D position);

        /// <summary>
        /// Sets the position of a vertex object.
        /// </summary>
        /// <param name="vertex">[in] The vertex object.</param>
        /// <param name="position">[in] The value used to set the vertex position.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if vertex is an invalid object
        /// SU_ERROR_NULL_POINTER_INPUT if position is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUVertexSetPosition(SUVertexRef vertex, ref SUPoint3D position);

        /// <summary>
        /// Retrieves the number of edges that the vertex is associated with.
        /// </summary>
        /// <param name="vertex">[in] The vertex object.</param>
        /// <param name="count">[out] The number of edges.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if vertex is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUVertexGetNumEdges(SUVertexRef vertex, ref size_t count);

        /// <summary>
        /// Retrieves the edge objects associated with a vertex object.
        /// </summary>
        /// <param name="vertex">[in] The vertex object.</param>
        /// <param name="len">[in] The number of edges to retrieve.</param>
        /// <param name="edges">[out] The edges retrieved.</param>
        /// <param name="count">[out] The number of edges retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if vertex is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if edges or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUVertexGetEdges(SUVertexRef vertex, size_t len, SUEdgeRef[] edges, ref size_t count);

        /// <summary>
        /// Retrieves the number of faces that the vertex is associated with.
        /// </summary>
        /// <param name="vertex">[in] The vertex object.</param>
        /// <param name="count">[out] The number of faces.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if vertex is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUVertexGetNumFaces(SUVertexRef vertex, ref size_t count);

        /// <summary>
        /// Retrieves the edge objects associated with a vertex object.
        /// </summary>
        /// <param name="vertex">[in] The vertex object.</param>
        /// <param name="len">[in] The number of faces to retrieve.</param>
        /// <param name="faces">[out] The faces retrieved.</param>
        /// <param name="count">[out] The number of faces retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if vertex is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if faces or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUVertexGetFaces(SUVertexRef vertex, size_t len, SUFaceRef[] faces, ref size_t count);

        /// <summary>
        /// Retrieves the number of loops that the vertex is associated with.
        /// </summary>
        /// <param name="vertex">[in] The vertex object.</param>
        /// <param name="count">[out] The number of loops.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if vertex is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUVertexGetNumLoops(SUVertexRef vertex, ref size_t count);

        /// <summary>
        /// Retrieves the edge objects associated with a vertex object.
        /// </summary>
        /// <param name="vertex">[in] The vertex object.</param>
        /// <param name="len">[in] The number of loops to retrieve.</param>
        /// <param name="loops">[out] The loops retrieved.</param>
        /// <param name="count">[out] The number of loops retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if vertex is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if loops or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUVertexGetLoops(SUVertexRef vertex, size_t len, SULoopRef[] loops, ref size_t count);
    }
}
