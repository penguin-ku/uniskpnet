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
    /// References an arccurve.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUArcCurveRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// arccurve
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Converts from an SUArcCurveRef to an  SUEntityRef.
        /// </summary>
        /// <param name="arccurve">[in] The given arccurve reference.</param>
        /// <returns>
        /// The converted SUEntityRef if curve is a valid object
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUEntityRef SUArcCurveToEntity(SUArcCurveRef arccurve);

        /// <summary>
        /// Converts from an SUEntityRef to an SUArcCurveRef.
        /// This is essentially a downcast operation so the given SUEntityRef
        /// must be convertible to an SUArcCurveRef.
        /// </summary>
        /// <param name="entity">[in] The given entity reference.</param>
        /// <returns>
        /// The converted SUArcCurveRef if the downcast operation succeeds
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUArcCurveRef SUArcCurveFromEntity(SUEntityRef entity);

        /// <summary>
        /// Converts from an SUArcCurveRef to an SUCurveRef. This is essentially an upcast operation.
        /// </summary>
        /// <param name="arccurve">[in] The given arccurve reference.</param>
        /// <returns>
        /// The converted SUCurveRef if arccurve is a valid arccurve object
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUCurveRef SUArcCurveToCurve(SUArcCurveRef arccurve);

        /// <summary>
        /// Converts from an SUCurveRef to an SUArcCurveRef.
        /// This is essentially a downcast operation so the given SUCurveRef
        /// must be convertible to an SUArcCurveRef.
        /// </summary>
        /// <param name="curve">[in] The given curve reference.</param>
        /// <returns>
        /// The converted SUArcCurveRef if the downcast operation succeeds
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUArcCurveRef SUArcCurveFromCurve(SUCurveRef curve);

        /// <summary>
        /// Creates an arccurve object. If the start and end points are the same a full circle will be generated.
        /// </summary>
        /// <param name="arccurve">[out] The arccurve object created.</param>
        /// <param name="center">[in] The point at the center of the arc.</param>
        /// <param name="start_point">[in] The point at the start of the arc.</param>
        /// <param name="end_point">[in] The point at the end of the arc.</param>
        /// <param name="normal">[in] The vector normal to the arc plane.</param>
        /// <param name="num_edges">[in] The number of edges for the arc.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if arccurve is NULL
        /// SU_ERROR_OVERWRITE_VALID if arccurve already references a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if center, start_point, end_point, or normal are NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUArcCurveCreate(ref SUArcCurveRef arccurve, ref SUPoint3D center, ref SUPoint3D start_point, ref SUPoint3D end_point, ref SUVector3D normal, long num_edges);

        /// <summary>
        /// Releases an arccurve object and its associated edge objects.
        /// </summary>
        /// <param name="arccurve">[in, out] arccurve The arccurve object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if arccurve is NULL
        /// SU_ERROR_INVALID_INPUT if arccurve does not reference a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUArcCurveRelease(ref SUArcCurveRef arccurve);

        /// <summary>
        /// Retrieves the raduis.
        /// </summary>
        /// <param name="arccurve">[in] The arccurve object.</param>
        /// <param name="radius">[out] The arccurve radius.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if arccurve is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if radius is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUArcCurveGetRadius(SUArcCurveRef arccurve, ref double radius);

        /// <summary>
        /// Retrieves the starting point.
        /// </summary>
        /// <param name="arccurve">[in] The arccurve object.</param>
        /// <param name="point">[out] The arccurve starting point.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if arccurve is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if point is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUArcCurveGetStartPoint(SUArcCurveRef arccurve, ref SUPoint3D point);

        /// <summary>
        /// Retrieves the ending point.
        /// </summary>
        /// <param name="arccurve">[in] The arccurve object.</param>
        /// <param name="point">[out] The arccurve ending point.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if arccurve is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if point is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUArcCurveGetEndPoint(SUArcCurveRef arccurve, ref SUPoint3D point);

        /// <summary>
        /// Retrieves the x-axis.
        /// </summary>
        /// <param name="arccurve">The arccurve object.</param>
        /// <param name="axis">The arccurve x-axis.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if arccurve is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if axis is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUArcCurveGetXAxis(SUArcCurveRef arccurve, out SUVector3D axis);

        /// <summary>
        /// Retrieves the y-axis.
        /// </summary>
        /// <param name="arccurve">The arccurve object.</param>
        /// <param name="axis">The arccurve y-axis.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if arccurve is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if axis is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUArcCurveGetYAxis(SUArcCurveRef arccurve, out SUVector3D axis);

        /// <summary>
        /// Retrieves the center point.
        /// </summary>
        /// <param name="arccurve">The arccurve object.</param>
        /// <param name="point">The arccurve center point.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if arccurve is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if point is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUArcCurveGetCenter(SUArcCurveRef arccurve, out SUPoint3D point);

        /// <summary>
        /// Retrieves the center point.
        /// </summary>
        /// <param name="arccurve">The arccurve object.</param>
        /// <param name="normal">The arccurve normal point.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if arccurve is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if normal is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUArcCurveGetNormal(SUArcCurveRef arccurve, out SUVector3D normal);

        /// <summary>
        /// Retrieves the start angle.
        /// </summary>
        /// <param name="arccurve">The arccurve object.</param>
        /// <param name="angle">The arccurve start angle.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if arccurve is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if angle is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUArcCurveGetStartAngle(SUArcCurveRef arccurve, out double angle);

        /// <summary>
        /// Retrieves the end angle.
        /// </summary>
        /// <param name="arccurve">[in] The arccurve object.</param>
        /// <param name="angle">[out] The arccurve end angle.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if arccurve is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if angle is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUArcCurveGetEndAngle(SUArcCurveRef arccurve, out double angle);

        /// <summary>
        /// a boolean indicating if the arccurve is a full circle.
        /// </summary>
        /// <param name="arccurve">[in] The arccurve object.</param>
        /// <param name="is_full">[out] Returns true if the arccurve is a full corcle.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if arccurve is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if is_full is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUArcCurveGetIsFullCircle(SUArcCurveRef arccurve, ref bool is_full);
    }
}
