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
    /// References an edge.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUEdgeRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// egde
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Converts from an SUEdgeRef to an SUEntityRef.
        /// This is essentially an upcast operation.
        /// </summary>
        /// <param name="edge">[in] The given edge reference.</param>
        /// <returns>
        /// The converted SUEntityRef if edge is a valid edge
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUEntityRef SUEdgeToEntity(SUEdgeRef edge);

        /// <summary>
        /// Converts from an SUEntityRef to an SUEdgeRef.
        /// This is essentially a downcast operation so the given entity must be
        /// convertible to an SUEdgeRef.
        /// </summary>
        /// <param name="entity">[in] The given entity reference.</param>
        /// <returns>
        /// The converted SUEdgeRef if the downcast operation succeeds
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUEdgeRef SUEdgeFromEntity(SUEntityRef entity);

        /// <summary>
        /// Converts from an SUEdgeRef to an SUDrawingElementRef.
        /// This is essentially an upcast operation.
        /// </summary>
        /// <param name="edge">[in] The given edge reference.</param>
        /// <returns>
        /// The converted SUEntityRef if edge is a valid edge
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUDrawingElementRef SUEdgeToDrawingElement(SUEdgeRef edge);

        /// <summary>
        /// Converts from an SUDrawingElementRef to an SUEdgeRef.
        /// This is essentially a downcast operation so the given element must be
        /// convertible to an SUEdgeRef.
        /// </summary>
        /// <param name="drawing_elem">[in] The given element reference.</param>
        /// <returns>
        /// The converted SUEdgeRef if the downcast operation succeeds
        /// If not, the returned reference will be invalid.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUEdgeRef SUEdgeFromDrawingElement(SUDrawingElementRef drawing_elem);

        /// <summary>
        /// Creates a new edge object.
        /// The edge object must be subsequently deallocated with SUEdgeRelease unless
        /// the edge object is associated with a parent object.
        /// </summary>
        /// <param name="edge">[out] The edge object.</param>
        /// <param name="start">[in] The start position of the edge object.</param>
        /// <param name="end">[in] The end position of the edge object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if start or end is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if edge is NULL
        /// SU_ERROR_GENERIC if start and end specify the same position.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEdgeCreate(ref SUEdgeRef edge, ref SUPoint3D start, ref SUPoint3D end);

        /// <summary>
        /// Releases an edge object.
        /// The edge object must have been created with SUEdgeCreate and not
        /// subsequently associated with a parent object (e.g. SUEntitiesAddEdges).
        /// </summary>
        /// <param name="edge">[in] The edge object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if edge does not reference a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if edge is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEdgeRelease(ref SUEdgeRef edge);

        /// <summary>
        /// Retrieves the associated curve object of an edge object.
        /// </summary>
        /// <param name="edge">[in] The edge object.</param>
        /// <param name="curve">[out] The curve object retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if curve is NULL
        /// SU_ERROR_NO_DATA if the edge object is not associated with a curve object.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEdgeGetCurve(SUEdgeRef edge, ref SUCurveRef curve);

        /// <summary>
        /// Retrieves the starting vertex of an edge object.
        /// </summary>
        /// <param name="edge">[in] The edge object.</param>
        /// <param name="vertex">[out] The vertex object retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success.
        /// SU_ERROR_INVALID_INPUT if edge is an invalid edge object
        /// SU_ERROR_NULL_POINTER_OUTPUT if vertex is NULL.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEdgeGetStartVertex(SUEdgeRef edge, ref SUVertexRef vertex);

        /// <summary>
        /// Retrieves the ending vertex of an edge object.
        /// </summary>
        /// <param name="edge">[in] The edge object.</param>
        /// <param name="vertex">[out] The vertex object retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success.
        /// SU_ERROR_INVALID_INPUT if edge is an invalid edge object
        /// SU_ERROR_NULL_POINTER_OUTPUT if vertex is NULL.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEdgeGetEndVertex(SUEdgeRef edge, ref SUVertexRef vertex);

        /// <summary>
        /// Sets the soft flag of an edge object.
        /// </summary>
        /// <param name="edge">[in] The edge object.</param>
        /// <param name="soft_flag">[in] The soft flag to set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if edge is an invalid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEdgeSetSoft(SUEdgeRef edge, bool soft_flag);

        /// <summary>
        /// Retrieves the soft flag of an edge object.
        /// </summary>
        /// <param name="edge">[in] The edge object.</param>
        /// <param name="soft_flag">[out] The soft flag retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if edge is an invalid object.
        /// SU_ERROR_NULL_POINTER_OUTPUT if soft_flag is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEdgeGetSoft(SUEdgeRef edge, ref bool soft_flag);

        /// <summary>
        /// Sets the smooth flag of an edge object.
        /// </summary>
        /// <param name="edge">[in] The edge object.</param>
        /// <param name="smooth_flag">[in] The smooth flag to set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if edge is an invalid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEdgeSetSmooth(SUEdgeRef edge, bool smooth_flag);

        /// <summary>
        /// Retrieves the smooth flag of an edge object.
        /// </summary>
        /// <param name="edge">[in] The edge object.</param>
        /// <param name="smooth_flag">[out] The smooth flag retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if edge is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if smooth_flag is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEdgeGetSmooth(SUEdgeRef edge, ref bool smooth_flag);

        /// <summary>
        /// Retrieves the number of faces that the edge is associated with.
        /// </summary>
        /// <param name="edge">[in] The edge object.</param>
        /// <param name="count">[out] The number of faces.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if edge is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEdgeGetNumFaces(SUEdgeRef edge, ref size_t count);

        /// <summary>
        /// Retrieves the face objects associated with an edge object.
        /// </summary>
        /// <param name="edge">[in] The edge object.</param>
        /// <param name="len">[in] The number of faces to retrieve.</param>
        /// <param name="faces">[out] The faces retrieved.</param>
        /// <param name="count">[out] The number of face objects retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if edge is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if faces or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEdgeGetFaces(SUEdgeRef edge, size_t len, SUFaceRef[] faces, ref size_t count);

        /// <summary>
        /// Retrieves the color of an edge object.
        /// </summary>
        /// <param name="edge">[in] The edge object.</param>
        /// <param name="color">[out] The color retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if edge is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if color is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEdgeGetColor(SUEdgeRef edge, ref SUColor color);

        /// <summary>
        /// Computes the length of the edge with the provided transformation applied.
        /// </summary>
        /// <param name="edge">[in] The edge object.</param>
        /// <param name="transform">[in] A transformation to be appllied to the edge.</param>
        /// <param name="length">[out] The length retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if edge is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if color is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEdgeGetLengthWithTransform(SUEdgeRef edge, ref SUTransformation transform, ref double length);

        /// <summary>
        /// Sets the color of an edge object.
        /// </summary>
        /// <param name="edge">[in] The edge object.</param>
        /// <param name="color">[in] The color object to set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if edge is an invalid object.
        /// SU_ERROR_NULL_POINTER_INPUT if color is NULL.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEdgeSetColor(SUEdgeRef edge, ref SUColor color);

    }
}
