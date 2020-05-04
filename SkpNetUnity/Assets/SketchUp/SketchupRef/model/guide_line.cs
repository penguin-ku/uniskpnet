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
    public struct SUGuideLineRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// guide_line
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Converts from an SUGuideLineRef to an SUEntityRef.
        /// This is essentially an upcast operation.
        /// </summary>
        /// <param name="guide_line">[in] The guide line object.</param>
        /// <returns>
        /// The converted SUEntityRef if group is a valid group
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUEntityRef SUGuideLineToEntity(SUGuideLineRef guide_line);

        /// <summary>
        /// Converts from an SUEntityRef to an SUGuideLineRef.
        /// This is essentially a downcast operation so the given entity must be
        /// convertible to an SUGuideLineRef.
        /// </summary>
        /// <param name="entity">[in] The given entity reference.</param>
        /// <returns>
        /// The converted SUGuideLineRef if the downcast operation succeeds
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUGuideLineRef SUGuideLineFromEntity(SUEntityRef entity);

        /// <summary>
        /// Converts from an SUGuideLineRef to an SUDrawingElementRef.
        /// This is essentially an upcast operation.
        /// </summary>
        /// <param name="guide_line">[in] The guide line object.</param>
        /// <returns>
        /// The converted SUDrawingElementRef if group is a valid group
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUDrawingElementRef SUGuideLineToDrawingElement(SUGuideLineRef guide_line);

        /// <summary>
        /// Converts from an SUDrawingElementRef to an SUGuideLineRef.
        /// This is essentially a downcast operation so the given entity must be
        /// convertible to an SUGuideLineRef.
        /// </summary>
        /// <param name="drawing_elem">[in] The given entity reference.</param>
        /// <returns>
        /// The converted SUGuideLineRef if the downcast operation succeeds
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUGuideLineRef SUGuideLineFromDrawingElement(SUEntityRef drawing_elem);

        /// <summary>
        /// Creates a finite guide line object. The guide line object must be
        /// subsequently deallocated with SUGuideLineRelease unless it is
        /// associated with a parent object.  The generated line will be a segment
        ///  with start and end points.  The end point can be obtained by adding the
        ///  direction vector to the start point.
        /// </summary>
        /// <param name="guide_line">[out] The guide line object.</param>
        /// <param name="start">[in] The guide line start position.</param>
        /// <param name="end">[in] The guide line end position.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if guide_line is NULL
        /// SU_ERROR_OVERWRITE_VALID if guide_line references a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if start or end is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGuideLineCreateFinite(ref SUGuideLineRef guide_line, ref SUPoint3D start, ref SUPoint3D end);

        /// <summary>
        /// Creates a infinite guide line object. The guide line object must be
        /// subsequently deallocated with SUGuideLineRelease unless it is
        /// associated with a parent object.  The generated line will be a segment
        ///  with start and end points.  The end point can be obtained by adding the
        ///  direction vector to the start point.
        /// </summary>
        /// <param name="guide_line">[out] The guide line object.</param>
        /// <param name="start">[in] The guide line start position.</param>
        /// <param name="direction">[in] The guide line direction vector.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if guide_line is NULL
        /// SU_ERROR_OVERWRITE_VALID if guide_line references a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if start or end is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGuideLineCreateInfinite(ref SUGuideLineRef guide_line, ref SUPoint3D start, ref SUPoint3D direction);

        /// <summary>
        /// Releases a guide line object. The guide line object must have been
        /// created with SUGuideLineCreateFinite or \ref
        /// SUGuideLineCreateInfinite and not subsequently associated with a parent
        /// object (e.g. SUEntitiesRef).
        /// </summary>
        /// <param name="guide_line">[in] The guide line object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if guide_line is NULL
        /// SU_ERROR_INVALID_INPUT if guide_line does not reference a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGuideLineRelease(ref SUGuideLineRef guide_line);

        /// <summary>
        /// Retrieves the data defining the line (a point, a direction vector, and a
        /// boolean flagging if the line is infinite).  For finite lines @param
        /// start is the start point, and the end point can be obtained by adding
        /// the direction vector(@param direction) to the start point(@param
        /// start).  For infinite lines @param start is simply a point on the guide
        /// line, and @param direction is always a unit vector.
        /// </summary>
        /// <param name="guide_line">[in] The guide line object.</param>
        /// <param name="start">[out] A point on the guide line.</param>
        /// <param name="direction">[out] The guide line direction.</param>
        /// <param name="isinfinite">[out] returns true if infinite otherwise returns false</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if guide line is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if start, direction, or isinfinite is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGuideLineGetData(SUGuideLineRef guide_line, ref SUPoint3D start, ref SUVector3D direction, ref bool isinfinite);

    }
}
