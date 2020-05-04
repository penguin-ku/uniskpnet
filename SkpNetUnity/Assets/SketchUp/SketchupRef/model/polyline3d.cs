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
    /// A polyline3d object. These are curve-like entities that do not generate inference snaps or affect geometry in any way.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUPolyline3dRef
    {
        public IntPtr ptr;
    }

    public static partial class SKPCExport
    {
        /// <summary>
        /// Converts from an SUPolyline3dRef to an SUEntityRef.
        /// This is essentially an upcast operation.
        /// </summary>
        /// <param name="line">[in] The given line reference.</param>
        /// <returns>
        /// The converted SUEntityRef if line is a valid line.
        /// If not, the returned reference will be invalid.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUEntityRef SUPolyline3dToEntity(SUPolyline3dRef line);

        /// <summary>
        /// Converts from an SUEntityRef to an SUPolyline3dRef.
        /// This is essentially a downcast operation so the given entity must be
        /// convertible to an SUPolyline3dRef.
        /// </summary>
        /// <param name="entity">[in] The given entity reference.</param>
        /// <returns>
        /// The converted SUPolyline3dRef if the downcast operation succeeds
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUPolyline3dRef SUPolyline3dFromEntity(SUEntityRef entity);

        /// <summary>
        /// Converts from an SUPolyline3dRef to an SUDrawingElementRef.
        /// This is essentially an upcast operation.
        /// </summary>
        /// <param name="line">[in] The given line reference.</param>
        /// <returns>
        /// The converted SUDrawingElementRef if line is a valid line.
        /// If not, the returned reference will be invalid.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUDrawingElementRef SUPolyline3dToDrawingElement(SUPolyline3dRef line);

        /// <summary>
        /// Converts from an SUDrawingElementRef to an SUPolyline3dRef.
        /// This is essentially a downcast operation so the given entity must be
        /// convertible to an SUPolyline3dRef.
        /// </summary>
        /// <param name="entity">[in] The given entity reference.</param>
        /// <returns>
        /// The converted SUPolyline3dRef if the downcast operation succeeds
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUPolyline3dRef SUPolyline3dFromDrawingElement(SUDrawingElementRef entity);

        /// <summary>
        /// Creates a new polyline3d object. The polyline3d object must be
        /// subsequently deallocated with SUPolyline3dRelease unless it is
        /// associated with a parent object.
        /// </summary>
        /// <param name="polyline">[out] The polyline object created.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if polyline is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUPolyline3dCreate(ref SUPolyline3dRef polyline);

        /// <summary>
        /// Releases a new polyline3d object. The polyline3d object must not be associated with a parent object.
        /// </summary>
        /// <param name="polyline">[in] The polyline object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if polyline points to an NULL
        /// SU_ERROR_INVALID_INPUT if the polyline object is not a valid object.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUPolyline3dRelease(ref SUPolyline3dRef polyline);

        /// <summary>
        /// Adds points to a polyline3d object.
        /// </summary>
        /// <param name="polyline">[in] The polyline3d object.</param>
        /// <param name="num_points">[in] Number of points being added.</param>
        /// <param name="points">[in] Array of points to add.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if polyline is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if points is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUPolyline3dAddPoints(SUPolyline3dRef polyline, size_t num_points, ref SUPoint3D[] points);

        /// <summary>
        /// Retrieves the number of points contained by a polyline3d.
        /// </summary>
        /// <param name="line">[in] The polyline3d object.</param>
        /// <param name="count">[out] The number of points available.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if line is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUPolyline3dGetNumPoints(SUPolyline3dRef line, ref size_t count);

        /// <summary>
        /// Retrieves the points in the polyline3d object.
        /// </summary>
        /// <param name="line">[in] The polyline3d object.</param>
        /// <param name="len">[in] The maximum number of points to retrieve.</param>
        /// <param name="points">[out] The points retrieved.</param>
        /// <param name="count">[out] The number of points retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if line is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if points or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUPolyline3dGetPoints(SUPolyline3dRef line, size_t len, SUPoint3D[] points, ref size_t count);
    }
}
