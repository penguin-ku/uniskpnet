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
    /// References a group object.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUGuidePointRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// guide_point
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Converts from an SUGuidePointRef to an SUEntityRef.
        /// This is essentially an upcast operation.
        /// </summary>
        /// <param name="guide_point">[in] The guide point object.</param>
        /// <returns>
        /// The converted SUEntityRef if group is a valid group
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUEntityRef SUGuidePointToEntity(SUGuidePointRef guide_point);

        /// <summary>
        /// Converts from an SUEntityRef to an SUGuidePointRef.
        /// This is essentially a downcast operation so the given entity must be
        /// convertible to an SUGuidePointRef.
        /// </summary>
        /// <param name="entity">[in] The given entity reference.</param>
        /// <returns>
        /// The converted SUGuidePointRef if the downcast operation succeeds
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUGuidePointRef SUGuidePointFromEntity(SUEntityRef entity);

        /// <summary>
        /// Converts from an SUGuidePointRef to an SUDrawingElementRef.
        /// This is essentially an upcast operation.
        /// </summary>
        /// <param name="guide_point">[in] The guide point object.</param>
        /// <returns>
        /// The converted SUDrawingElementRef if group is a valid group
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUDrawingElementRef SUGuidePointToDrawingElement(SUGuidePointRef guide_point);

        /// <summary>
        /// Converts from an SUDrawingElementRef to an SUGuidePointRef.
        /// This is essentially a downcast operation so the given entity must be
        /// convertible to an SUGuidePointRef.
        /// </summary>
        /// <param name="drawing_elem">[in] The given entity reference.</param>
        /// <returns>
        /// The converted SUGuidePointRef if the downcast operation succeeds
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUGuidePointRef SUGuidePointFromDrawingElement(SUEntityRef drawing_elem);

        /// <summary>
        /// Creates a guide point object. The guide point object must be subsequently
        /// deallocated with SUGuidePointRelease unless it is associated with a
        /// parent object.
        /// </summary>
        /// <param name="guide_point">[out] The guide point object.</param>
        /// <param name="position">[in] The guide point position.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if guide_point is NULL
        /// SU_ERROR_OVERWRITE_VALID if guide_point references a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if position is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUGuidePointRef SUGuidePointCreate(ref SUGuidePointRef guide_point, ref SUPoint3D position);

        /// <summary>
        /// Releases a guide point object. The guide point object must have been
        /// created with SUGuidePointCreate and not subsequently associated with
        /// a parent object (e.g. SUEntitiesAddGuidePoints).
        /// </summary>
        /// <param name="guide_point">[in] The guide point object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if guide_point is NULL
        /// SU_ERROR_INVALID_INPUT if guide_point does not reference a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGuidePointRelease(ref SUGuidePointRef guide_point);

        /// <summary>
        /// Retrieves the position of a guide point object.
        /// </summary>
        /// <param name="guide_point">[in] The guide point object.</param>
        /// <param name="position">[out] The guide point position.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if guide point is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if position is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGuidePointGetPosition(SUGuidePointRef guide_point, ref SUPoint3D position);

        /// <summary>
        /// Retrieves the anchor position of a guide point object. If the point was
        /// created in SketchUp then the anchor is the position that was first
        /// clicked during the point creation.If the point was created with \ref
        /// SUGuidePointCreate the anchor is the origin.
        /// </summary>
        /// <param name="guide_point">[in] The guide point object.</param>
        /// <param name="position">[out] The guide point position.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if guide point is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if position is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGuidePointGetFromPosition(SUGuidePointRef guide_point, ref SUPoint3D position);

        /// <summary>
        /// Retrieves the boolean indicating if the point should be displayed as a line.
        /// </summary>
        /// <param name="guide_point">[in] The guide point object.</param>
        /// <param name="as_line">[out] Return true if the point is set to be displayed as a line.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if guide point is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if as_line is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGuidePointGetDisplayAsLine(SUGuidePointRef guide_point, ref bool as_line);

    }
}
