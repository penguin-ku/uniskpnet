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
    /// Represents a 3D (4x4) geometric transformation matrix.
    /// </summary>
    /// <remarks>
    /// Matrix values are in column-major order.
    /// The transformation is stored as:
    /// @code
    ///     -     -
    ///     | R T |
    /// M = | 0 w |
    ///     -     -
    /// @endcode
    /// where:
    /// M is a 4x4 matrix
    /// R is a 3x3 sub-matrix.It is the rotation part
    /// T is a 3x1 sub-matrix.It is the translation part
    /// w is a scalar.         It is 1/scale.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUTransformation
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        public double[] values;
    }

    public static partial class SKPCExport
    {
        /// <summary>
        /// Sets the transformation based on the provided point and z-axis vector.
        /// The resulting transformation transforms points/vectors to a new
        /// coordinate system where the provided point is the new origin and the
        /// vector is the new z-axis. The other two axes in the transformed space
        /// are computed using the "Arbitrary axis algorithm".
        /// </summary>
        /// <param name="transform">[out] The transformation to be set.</param>
        /// <param name="point">[in] The point specifying the translation component of the transformation.</param>
        /// <param name="normal">[in] The 3D vector specifying the rotation component of 
        /// the transformation.This is treated as a unit vector, so any scaling will be ignored.
        /// </param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if transform is NULL
        /// SU_ERROR_NULL_POINTER_INPUT if point or normal are NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTransformationSetFromPointAndNormal(ref SUTransformation transform, ref SUPoint3D point, ref SUVector3D normal);

        /// <summary>
        /// Sets the transformation based on the provided origin and axes.
        /// </summary>
        /// <param name="transform">[out] The transformation to be set.</param>
        /// <param name="point">[in] The point specifying the translation component of the transformation.</param>
        /// <param name="x_axis">[in] The 3D vector specifying the x-axis for the transformation. This is treated as a unit vector, so any scaling will be ignored.</param>
        /// <param name="y_axis">[in] The 3D vector specifying the y-axis for the transformation. This is treated as a unit vector, so any scaling will be ignored.</param>
        /// <param name="z_axis">[in] The 3D vector specifying the z-axis for the transformation. This is treated as a unit vector, so any scaling will be ignored.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if transform is NULL
        /// SU_ERROR_NULL_POINTER_INPUT if point, x_axis, y_axis, or z_axis are NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTransformationSetFromPointAndAxes(ref SUTransformation transform, ref SUPoint3D point, ref SUVector3D x_axis, ref SUVector3D y_axis, ref SUVector3D z_axis);

        /// <summary>
        /// Creates a translation transformation using the given vector.
        /// </summary>
        /// <param name="transform">[out] The transformation to be set.</param>
        /// <param name="vector">[in] The 3D vector specifying the translation for the transformation.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if transform is NULL
        /// SU_ERROR_NULL_POINTER_INPUT if vector is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTransformationTranslation(ref SUTransformation transform, ref SUVector3D vector);

        /// <summary>
        /// Creates a scale transformation using the given scale value.
        /// </summary>
        /// <param name="transform">[out] The transformation to be set.</param>
        /// <param name="scale">[in] The scale value for the transformation.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if transform is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTransformationScale(ref SUTransformation transform, double scale);

        /// <summary>
        /// Creates a scale transformation using the given scale values.
        /// </summary>
        /// <param name="transform">[out] The transformation to be set.</param>
        /// <param name="x_scale">[in] The x-axis scale value for the transformation.</param>
        /// <param name="y_scale">[in] The y-axis scale value for the transformation.</param>
        /// <param name="z_scale">[in] The z-axis scale value for the transformation.</param>
        /// <returns></returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTransformationNonUniformScale(ref SUTransformation transform, double x_scale, double y_scale, double z_scale);

        /// <summary>
        /// Creates a scale transformation using the given scale value and origin.
        /// </summary>
        /// <param name="transform">[out] The transformation to be set.</param>
        /// <param name="point">[in] The point specifying the translation component of the transformation.</param>
        /// <param name="scale">[in] The scale value for the transformation.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if transform is NULL
        /// SU_ERROR_NULL_POINTER_INPUT if point or scale are NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTransformationScaleAboutPoint(ref SUTransformation transform, ref SUPoint3D point, double scale);

        /// <summary>
        /// Creates a scale transformation using the given scale values and origin.
        /// </summary>
        /// <param name="transform">[out] The transformation to be set.</param>
        /// <param name="point">[in] The point specifying the translation component of the transformation.</param>
        /// <param name="x_scale">[in] The x-axis scale value for the transformation.</param>
        /// <param name="y_scale">[in] The y-axis scale value for the transformation.</param>
        /// <param name="z_scale">[in] The z-axis scale value for the transformation.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if transform is NULL
        /// SU_ERROR_NULL_POINTER_INPUT if point, x_scale, y_scale, or z_scale are
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTransformationNonUniformScaleAboutPoint(ref SUTransformation transform, ref SUPoint3D point, double x_scale, double y_scale, double z_scale);

        /// <summary>
        /// Creates a transformation given an origin, vector of rotation, and angle.
        /// </summary>
        /// <param name="transform">[out] The calculated transformation.</param>
        /// <param name="point">[in] The point specifying the translation component of the transformation.</param>
        /// <param name="vector">[in] The vector about which rotation will occur.</param>
        /// <param name="angle">[in] The rotation in radians for the transformation.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if transform is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if is_identity is NULL
        /// SU_ERROR_OUT_OF_RANGE if weight is not between 0.0 and 1.0
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTransformationRotation(ref SUTransformation transform, ref SUPoint3D point, ref SUVector3D vector, double angle);

        /// <summary>
        /// Performs an interpolation between two transformations. The weight
        /// determines the amount of interpolation. A weight of 0.0 would return
        /// a transformation of t1, while a weight of 1.0 would return a
        /// transformation of t2.
        /// </summary>
        /// <param name="transform">[out] The result of the interpolation.</param>
        /// <param name="t1">[in] The first transformation object.</param>
        /// <param name="t2">[in] The second transformation object.</param>
        /// <param name="weight">[in] The weight determines the amount of interpolation from t1 to t2.</param>
        /// <returns></returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTransformationInterpolate(ref SUTransformation transform, ref SUTransformation t1, ref SUTransformation t2, double weight);

        /// <summary>
        /// Gets whether the transformation is an identity transformation.
        /// </summary>
        /// <param name="transform">[in] The transformation object.</param>
        /// <param name="is_identity">[out] Whether the transformation is identity.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if transform is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if is_identity is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTransformationIsIdentity(ref SUTransformation transform, ref bool is_identity);

        /// <summary>
        /// Gets the inverse transformation of the given transformation object.
        /// </summary>
        /// <param name="transform">[in] The transformation object.</param>
        /// <param name="inverse">[out] The inverse transformation object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if transform is NULL
        /// SU_ERROR_NULL_POINTER_INPUT if inverse is NULL
        /// SU_ERROR_INVALID_ARGUMENT if the transform cannot be inverted
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTransformationGetInverse(ref SUTransformation transform, ref SUTransformation inverse);

        /// <summary>
        /// Gets the origin point of the given transformation object.
        /// </summary>
        /// <param name="transform">[in] The transformation object.</param>
        /// <param name="origin">[out] The origin point to be retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if transform is NULL
        /// SU_ERROR_NULL_POINTER_INPUT if origin is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTransformationGetOrigin(ref SUTransformation transform, ref SUPoint3D origin);

        /// <summary>
        /// Gets the x axis vector of the given transformation object.
        /// </summary>
        /// <param name="transform">[in] The transformation object.</param>
        /// <param name="x_axis">[out] The x axis vector to be retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if transform is NULL
        /// SU_ERROR_NULL_POINTER_INPUT if x_axis is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTransformationGetXAxis(ref SUTransformation transform, ref SUVector3D x_axis);

        /// <summary>
        /// Gets the y axis vector of the given transformation object.
        /// </summary>
        /// <param name="transform">[in] The transformation object.</param>
        /// <param name="y_axis">[out] The y axis vector to be retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if transform is NULL
        /// SU_ERROR_NULL_POINTER_INPUT if y_axis is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTransformationGetYAxis(ref SUTransformation transform, ref SUVector3D y_axis);

        /// <summary>
        /// Gets the z_axis vector of the given transformation object.
        /// </summary>
        /// <param name="transform">[in] The transformation object.</param>
        /// <param name="z_axis">[out] The z_axis vector to be retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if transform is NULL
        /// SU_ERROR_NULL_POINTER_INPUT if z_axis is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTransformationGetZAxis(ref SUTransformation transform, ref SUVector3D z_axis);

        /// <summary>
        /// Gets the rotation about the z axis from the given transformation object.
        /// </summary>
        /// <param name="transform">[in] The transformation object.</param>
        /// <param name="z_rotation">[out] The rotation to be retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if transform is NULL
        /// SU_ERROR_NULL_POINTER_INPUT if z_rotation is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTransformationGetZRotation(ref SUTransformation transform, ref double z_rotation);

        /// <summary>
        /// Multiplies a transformation by another transformation.
        /// </summary>
        /// <param name="transform1">[in] The transformation object to be multiplied.</param>
        /// <param name="transform2">[in] The transformation object to multiply by.</param>
        /// <param name="out_transform">[out] The result of the matrix multiplication [transform1 * transform2].</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if transform is NULL
        /// SU_ERROR_NULL_POINTER_INPUT if in_transform is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTransformationMultiply(ref SUTransformation transform1, ref SUTransformation transform2, ref SUTransformation out_transform);

        /// <summary>
        /// Returns true if transformation has been mirrored.
        /// </summary>
        /// <param name="transform">[in] The transform object.</param>
        /// <param name="is_mirrored">[out] Indicates if mirrored.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if is_mirrored is NULL
        /// SU_ERROR_NULL_POINTER_INPUT if transform is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTransformationIsMirrored(ref SUTransformation transform, ref bool is_mirrored);
    }
}
