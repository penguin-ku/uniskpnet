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
    /// References a loop object, which can be either the outer loop or an inner loop (hole) of a face.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SULoopRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// Indicates loop orientation.
    /// </summary>
    public enum SULoopWinding
    {
        SULoopWinding_CCW,
        SULoopWinding_CW
    }

    /// <summary>
    /// loop
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Converts from an SULoopRef to an SUEntityRef.
        /// This is essentially an upcast operation.
        /// </summary>
        /// <param name="loop">[in] The given loop reference.</param>
        /// <returns>
        /// The converted SUEntityRef if loop is a valid loop
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUEntityRef SULoopToEntity(SULoopRef loop);

        /// <summary>
        /// Converts from an SUEntityRef to an SULoopRef.
        /// This is essentially a downcast operation so the given entity must be
        /// convertible to an SULoopRef.
        /// </summary>
        /// <param name="entity">[in] The given entity reference.</param>
        /// <returns>
        /// The converted SULoopRef if the downcast operation succeeds
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SULoopRef SULoopFromEntity(SUEntityRef entity);

        /// <summary>
        /// Retrieves the number of vertices of a face loop.
        /// </summary>
        /// <param name="loop">[in] The loop object.</param>
        /// <param name="count">[out] The number of vertices.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if loop is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULoopGetNumVertices(SULoopRef loop, ref size_t count);

        /// <summary>
        /// Retrieves the vertices of a face loop object.
        /// </summary>
        /// <param name="loop">[in] The loop object.</param>
        /// <param name="len">[in] The number of vertices to retrieve.</param>
        /// <param name="vertices">[out] The vertices retrieved.</param>
        /// <param name="count">[out] The number of vertices retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if loop is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if vertices or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULoopGetVertices(SULoopRef loop, size_t len, SUVertexRef[] vertices, ref size_t count);

        /// <summary>
        /// Retrieves the edges of a loop object.
        /// </summary>
        /// <param name="loop">[in] The loop object.</param>
        /// <param name="len">[in] The number of vertices to retrieve.</param>
        /// <param name="edges">[out] The edges retrieved.</param>
        /// <param name="count">[out] The number of edges retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if loop is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if edges or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULoopGetEdges(SULoopRef loop, size_t len, SUEdgeRef[] edges, ref size_t count);

        /// <summary>
        /// Retrieves the  winding of a loop object with respect to a vector.
        /// </summary>
        /// <param name="loop">[in] The loop object.</param>
        /// <param name="vector3d">[in] The 3D vector.</param>
        /// <param name="orientation">[out] The orientation retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if loop is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if vector3d is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if orientation is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULoopGetWinding(SULoopRef loop, ref SUVector3D vector3d, ref SULoopWinding orientation);

        /// <summary>
        /// Retrieves a flag indicating the orientation of the given edge relative to a loop object.
        /// </summary>
        /// <param name="loop">[in] The loop object.</param>
        /// <param name="edge">[in] The edge object.</param>
        /// <param name="reversed">[out] The flag retrieved. A return value of true indicates that the given edge is oriented opposite of the loop object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if loop or edge is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if reversed is NULL
        /// SU_ERROR_GENERIC if edge is not a part of loop
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULoopIsEdgeReversed(SULoopRef loop, SUEdgeRef edge, ref bool reversed);

        /// <summary>
        /// Retrieves the parent face of a loop object.
        /// </summary>
        /// <param name="loop">[in] The loop object.</param>
        /// <param name="face">[out] The face retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if loop is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if face is NULL
        /// SU_ERROR_OVERWRITE_VALID if face references a valid face object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULoopGetFace(SULoopRef loop, ref SUFaceRef face);

        /// <summary>
        /// Retrieves a flag indicating the whether the loop is convex.
        /// </summary>
        /// <param name="loop">[in] The loop object.</param>
        /// <param name="convex">[out] The flag retrieved. A return value of true indicates the loop is convex.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if loop is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if convex is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULoopIsConvex(SULoopRef loop, ref bool convex);

        /// <summary>
        /// Retrieves a flag indicating the whether the loop is the outer loop on its associated face.
        /// </summary>
        /// <param name="loop">[in] The loop object.</param>
        /// <param name="outer_loop">[out] The flag retrieved. A return value of true indicates the loop is the outer loop.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if loop is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if outer_loop is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULoopIsOuterLoop(SULoopRef loop, ref bool outer_loop);

        /// <summary>
        /// Retrieves the edge use objects of a loop.
        /// </summary>
        /// <param name="loop">[in] The loop object.</param>
        /// <param name="len">[in] The number of edge uses to retrieve.</param>
        /// <param name="edge_uses">[out] The edge uses retrieved.</param>
        /// <param name="count">[out] The number of edge uses retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if loop is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if edge_uses or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULoopGetEdgeUses(SULoopRef loop, size_t len, SUEdgeUseRef[] edge_uses, ref size_t count);




    }
}
