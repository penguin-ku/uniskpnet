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
    /// References a curve.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUCurveRef
    {
        IntPtr ptr;
    }

    /// <summary>
    /// Defines curve types that can be represented by SUCurveRef.
    /// </summary>
    public enum SUCurveType
    {
        SUCurveType_Simple = 0,
        SUCurveType_Arc
    }

    /// <summary>
    /// curve
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Converts from an SUCurveRef to an SUEntityRef.
        /// This is essentially an upcast operation.
        /// </summary>
        /// <param name="curve">[in] The given curve reference.</param>
        /// <returns>
        /// The converted SUEntityRef if curve is a valid object.
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUEntityRef SUCurveToEntity(SUCurveRef curve);

        /// <summary>
        /// Converts from an SUEntityRef to an SUCurveRef.
        /// This is essentially a downcast operation so the given SUEntityRef
        /// must be convertible to an SUCurveRef.
        /// </summary>
        /// <param name="entity">[in] The given entity reference.</param>
        /// <returns>
        /// The converted SUCurveRef if the downcast operation succeeds.
        /// If not, the returned reference will be invalid.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUCurveRef SUCurveFromEntity(SUEntityRef entity);

        /// <summary>
        /// Creates a curve object with the given array of edges that is not
        /// connected to any face object.  The array of N edges is sorted such that
        /// for each edge in the range[0, N] the start position of each edge is the
        /// same as the end position of the previous edge in the array.Each
        /// element of the array of edges is subsequently associated with the
        /// created curve object and must not be deallocated via SUEdgeRelease.
        /// </summary>
        /// <param name="curve">[out] The curve object created.</param>
        /// <param name="edges">[in] The array of edge objects.</param>
        /// <param name="len">[in] The number of edge objects in the array.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if edges is NULL
        /// SU_ERROR_OUT_OF_RANGE if len is 0
        /// SU_ERROR_NULL_POINTER_OUTPUT if curve is NULL
        /// SU_ERROR_OVERWRITE_VALID if curve already references a valid object
        /// SU_ERROR_GENERIC if edge array contains an invalid edge, if the edges in the array are not connected, 
        /// if any of the edges are associated with a face  object, or the edges describe a loop
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUCurveCreateWithEdges(ref SUCurveRef curve, ref SUEdgeRef[] edges, size_t len);

        /// <summary>
        /// Releases a curve object and its associated edge objects.
        /// </summary>
        /// <param name="curve">[in] The curve object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if curve is NULL
        /// SU_ERROR_INVALID_INPUT if curve does not reference a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUCurveRelease(ref SUCurveRef curve);

        /// <summary>
        /// Retrieves the curve type of a curve object.
        /// </summary>
        /// <param name="curve">[in] The curve object.</param>
        /// <param name="type">[out] The curve type retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if curve is not a valid curve object
        /// SU_ERROR_NULL_POINTER_OUTPUT if type is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUCurveGetType(SUCurveRef curve, ref SUCurveType type);

        /// <summary>
        /// Retrieves the number of edges that belong to a curve object.
        /// </summary>
        /// <param name="curve">[in] The curve object.</param>
        /// <param name="count">[out] The number of edges.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if curve is not a valid curve object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUCurveGetNumEdges(SUCurveRef curve, ref size_t count);

        /// <summary>
        /// Retrieves the edges of a curve object. Provides access to all edges in
        /// the curve.The first edge is the first element of the edges array and
        /// the last edge is the last element if all edges were retrieved.
        /// </summary>
        /// <param name="curve">[in] The curve object.</param>
        /// <param name="len">[in] The number of edges to retrieve.</param>
        /// <param name="edges">[out] The edges retrieved.</param>
        /// <param name="count">[out] The number of edges retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if curve is not a valid curve object
        /// SU_ERROR_NULL_POINTER_OUTPUT if edges or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUCurveGetEdges(SUCurveRef curve, size_t len, ref SUEdgeRef[] edges, out size_t count);
    }
}
