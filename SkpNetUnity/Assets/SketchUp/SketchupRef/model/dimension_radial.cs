using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SU_RESULT = PgSkpDK.SketchupRef.SUResult;
using size_t = System.Int64;
using int32_t = System.Int32;
using int64_t = System.Int64;
using System.Runtime.InteropServices;

namespace PgSkpDK.SketchupRef
{
    /// <summary>
    /// A radial dimension entity reference.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUDimensionRadialRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// dimension_radial
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Converts from an SUDimensionRadialRef to an SUDimensionRef.
        /// This is essentially an upcast operation.
        /// </summary>
        /// <param name="dimension">[in] The given dimension reference.</param>
        /// <returns>
        /// The converted SUDimensionRef if dimension is a valid object
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUDimensionRef SUDimensionRadialToDimension(SUDimensionRadialRef dimension);

        /// <summary>
        /// Converts from an SUDimensionRef to an SUDimensionRadialRef.
        /// This is essentially a downcast operation so the given
        /// SUDimensionRef must be convertible to an SUDimensionRadialRef.
        /// </summary>
        /// <param name="dimension">[in] The given dimension reference.</param>
        /// <returns>
        /// The converted SUDimensionRadialRef if the downcast operation succeeds
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUDimensionRadialRef SUDimensionRadialFromDimension(SUDimensionRef dimension);

        /// <summary>
        /// Creates a new radial dimension for measuring the provided arccurve.
        /// </summary>
        /// <param name="dimension">[in,out] The dimension object created.</param>
        /// <param name="path">[in] The and instance path to the arccurve to be measured.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if dimension is NULL
        /// SU_ERROR_OVERWRITE_VALID if dimension already references a valid object
        /// SU_ERROR_INVALID_INPUT if path is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionRadialCreate(ref SUDimensionRadialRef dimension, SUInstancePathRef path);

        /// <summary>
        /// Releases a dimension object.
        /// </summary>
        /// <param name="dimension">[in] The dimension object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dimension is an invalid object
        /// SU_ERROR_NULL_POINTER_INPUT if dimension is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionRadialRelease(ref SUDimensionRadialRef dimension);

        /// <summary>
        /// Retrieves the arccurve instance being mesured by a dimension object. The
        /// given instance path object either must have been constructed using one
        /// of the SUInstancePathCreate* functions or it will be generated on the
        /// fly if it is invalid.It must be released using \ref
        /// SUInstancePathRelease when it is no longer needed.
        /// </summary>
        /// <param name="dimension">[in] The dimension object.</param>
        /// <param name="path">[out] The instance path retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dimension is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if path is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionRadialGetCurveInstancePath(SUDimensionRadialRef dimension, ref SUInstancePathRef path);

        /// <summary>
        /// Sets which arccurve instance is measured by the radial dimension. The
        /// instance path's leaf entity must be an arccurve for this method to
        /// succeed.
        /// </summary>
        /// <param name="dimension">[in] The dimension object modified.</param>
        /// <param name="path">[in] The and instance path to the arccurve to be measured.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dimension or path are not valid objects
        /// SU_ERROR_INVALID_ARGUMENT if path is valid but refers to an invalid instance path
        /// SU_ERROR_GENERIC if path refers to a valid instance path but the path's leaf is not an arccurve
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionRadialSetCurveInstancePath(SUDimensionRadialRef dimension, SUInstancePathRef path);

        /// <summary>
        /// Retrieves whether the dimension is a diameter.  Radial dimensions can be used to measure either diameter or radius.
        /// </summary>
        /// <param name="dimension">[in] The dimension object.</param>
        /// <param name="is_diameter">[out] The flag value retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dimension is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if is_diameter is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionRadialGetDiameter(SUDimensionRadialRef dimension, ref bool is_diameter);

        /// <summary>
        ///  Sets whether the dimension measures diameter or radius.
        /// </summary>
        /// <param name="dimension">[in] The dimension object modified.</param>
        /// <param name="is_diameter">[in] The flag specifying if the dimension measures diameter.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dimension is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionRadialSetDiameter(SUDimensionRadialRef dimension, bool is_diameter);

        /// <summary>
        /// Gets the radial dimension's leader line break point. The leader line
        /// break point is the point where the leader line bends towards the
        /// dimension label.
        /// </summary>
        /// <param name="dimension">[in] The dimension object.</param>
        /// <param name="point">[out] The point retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dimension is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if point is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionRadialGetLeaderBreakPoint(SUDimensionRadialRef dimension, ref SUPoint3D point);

        /// <summary>
        ///  Sets the radial dimension's leader break point
        /// </summary>
        /// <param name="dimension">[in] The dimension object modified.</param>
        /// <param name="point">[in] The point to setted.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dimension is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if point is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionRadialSetLeaderBreakPoint(SUDimensionRadialRef dimension, ref SUPoint3D point);

        /// <summary>
        /// Retrieves the a dimension object's leader points.  The three returned
        /// pointe are[0] the point at which the dimension's text touches the
        /// leader line, [1] the point at which the dimension's arrow attaches to
        /// the dimensioned curve, [2] the point on the dimensioned curve's full
        /// circle opposite of point[1].
        /// </summary>
        /// <param name="dimension">[in] The dimension object.</param>
        /// <param name="points">[out] The array of 3 3d points retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dimension is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if points is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionRadialGetLeaderPoints(SUDimensionRadialRef dimension, SUPoint3D[] points);
    }
}
