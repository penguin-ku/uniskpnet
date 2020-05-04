using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SU_RESULT = PgSkpDK.SketchupRef.SUResult;
using size_t = System.Int64;
using int32_t = System.Int32;
using int64_t = System.Int64;
using System.Runtime.InteropServices;

namespace PgSkpDK.SketchupRef
{
    /// <summary>
    /// SUEdgeUseRef objects are used to retrieve the topology of the edges of
    /// a polygon. The geometry of the polygon being represented by \ref
    /// SULoopRef that is already associated with a face object. The typical use
    /// of EdgeUse object is to retrieve them from a face object's loop, and then
    /// read the topology values from them.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUEdgeUseRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// edge_use
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Converts from an SUEdgeUseRef to an SUEntityRef.
        /// This is essentially an upcast operation.
        /// </summary>
        /// <param name="edgeuse">[in] The given edge use reference.</param>
        /// <returns>
        /// The converted SUEntityRef if edgeuse is a valid edge use.
        /// If not, the returned reference will be invalid.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUEntityRef SUEdgeUseToEntity(SUEdgeUseRef edgeuse);

        /// <summary>
        /// Converts from an SUEntityRef to an SUEdgeUseRef.
        /// This is essentially a downcast operation so the given SUEntityRef
        /// must be convertible to an SUEdgeUseRef.
        /// </summary>
        /// <param name="entity">[in] The given entity reference.</param>
        /// <returns>
        /// The converted SUEdgeUseRef if the downcast operation succeeds.
        /// If not, the returned reference will be invalid.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUEdgeUseRef SUEdgeUseFromEntity(SUEntityRef entity);

        /// <summary>
        /// Retrieves the edge object the EdgeUse object belongs to.
        /// </summary>
        /// <param name="edgeuse">[in] The EdgeUse object.</param>
        /// <param name="edge">[out] The edge object retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if edgeuse is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if edge is NULL.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEdgeUseGetEdge(SUEdgeUseRef edgeuse, ref SUEdgeRef edge);

        /// <summary>
        /// Retrieves the loop object the EdgeUse object is associated with.
        /// </summary>
        /// <param name="edgeuse">[in] The EdgeUse object.</param>
        /// <param name="loop">[out] The loop object retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if edgeuse is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if loop is NULL.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEdgeUseGetLoop(SUEdgeUseRef edgeuse, ref SULoopRef loop);

        /// <summary>
        /// Retrieves the face object the EdgeUse object is associated with.
        /// </summary>
        /// <param name="edgeuse">[in] The EdgeUse object.</param>
        /// <param name="face">[out] The face object retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if edgeuse is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if face is NULL.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEdgeUseGetFace(SUEdgeUseRef edgeuse, ref SUFaceRef face);

        /// <summary>
        /// Retrieves the number of EdgeUse objects that are linked to the EdgeUse object.
        /// </summary>
        /// <param name="edgeuse">[in] The EdgeUse object.</param>
        /// <param name="count">[out] The number of partners.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if edgeuse is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEdgeUseGetNumPartners(SUEdgeUseRef edgeuse, ref size_t count);

        /// <summary>
        /// Retrieves the EdgeUse objects that are linked to the EdgeUse object.
        /// </summary>
        /// <param name="edgeuse">[in] The EdgeUse object.</param>
        /// <param name="len">[in] The number of partners to retrieve.</param>
        /// <param name="partners">[out] The partners retrieved.</param>
        /// <param name="count">[out] The number of partners retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if edgeuse is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if partners or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEdgeUseGetPartners(SUEdgeUseRef edgeuse, size_t len, SUEdgeUseRef[] partners, ref size_t count);

        /// <summary>
        /// Retrieves a flag indicating whether this EdgeUse is traversed in the
        /// opposite direction as its corresponding edge.
        /// </summary>
        /// <param name="edgeuse">[in] The EdgeUse object.</param>
        /// <param name="reversed">[out] The retrieved flag.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if edgeuse is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if reversed is NULL.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEdgeUseIsReversed(SUEdgeUseRef edgeuse, ref bool reversed);

        /// <summary>
        /// Retrieves the EdgeUse object just preceding an EdgeUse object in the collection of linked EdgeUses.
        /// </summary>
        /// <param name="edgeuse">[in] The EdgeUse object.</param>
        /// <param name="prev_edgeuse">[out] The EdgeUse retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if edgeuse is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if prev_edgeuse is NULL.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEdgeUseGetPrevious(SUEdgeUseRef edgeuse, ref SUEdgeUseRef prev_edgeuse);

        /// <summary>
        /// Retrieves the EdgeUse object just following an EdgeUse object in the collection of linked EdgeUses.
        /// </summary>
        /// <param name="edgeuse">[in] The EdgeUse object.</param>
        /// <param name="next_edgeuse">[out] The EdgeUse retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if edgeuse is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if next_edgeuse is NULL.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEdgeUseGetNext(SUEdgeUseRef edgeuse, ref SUEdgeUseRef next_edgeuse);

        /// <summary>
        /// Retrieves the start vertex of an EdgeUse object. The start vertex of the
        /// EdgeUse object may not be the same as the start vertex of the
        /// corresponding edge of the EdgeUse object. An EdgeUse object is part of a
        /// face loop whose direction may be the reverse of the direction of the
        /// edge.
        /// </summary>
        /// <param name="edgeuse">[in] The EdgeUse object.</param>
        /// <param name="vertex">[out] The vertex object retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if edge is not a valid EdgeUse object
        /// SU_ERROR_NULL_POINTER_OUTPUT if vertex is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEdgeUseGetStartVertex(SUEdgeUseRef edgeuse, ref SUVertexRef vertex);

        /// <summary>
        /// Retrieves the end vertex of an EdgeUse object. The end vertex of the
        /// EdgeUse object may not be the same as the end vertex of the
        /// corresponding edge of the EdgeUse object. An EdgeUse object is part of a
        /// face loop whose direction may be the reverse of the direction of the
        /// edge.
        /// </summary>
        /// <param name="edgeuse">[in] The EdgeUse object.</param>
        /// <param name="vertex">[out] The vertex object retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if edge is not a valid EdgeUse object
        /// SU_ERROR_NULL_POINTER_OUTPUT if vertex is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEdgeUseGetEndVertex(SUEdgeUseRef edgeuse, ref SUVertexRef vertex);

        /// <summary>
        /// Retrieves the normal vector at the start vertex of an EdgeUse object.
        /// </summary>
        /// <param name="edgeuse">[in] The EdgeUse object.</param>
        /// <param name="normal">[out] The normal vector retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if edge is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if normal is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEdgeUseGetStartVertexNormal(SUEdgeUseRef edgeuse, ref SUVector3D normal);

        /// <summary>
        /// Retrieves the normal vector at the end vertex of an EdgeUse object.
        /// </summary>
        /// <param name="edgeuse">[in] The EdgeUse object.</param>
        /// <param name="normal">[out] The normal vector retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if edge is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if normal is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEdgeUseGetEndVertexNormal(SUEdgeUseRef edgeuse, ref SUVector3D normal);
    }
}
