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
using SUByte = System.Byte;
using uint32_t = System.UInt32;
using int16_t = System.Int16;

namespace PgSkpDK.SketchupRef
{
    /// <summary>
    /// SUTransformation2D Represents a 2D (2x3) affine transformation matrix. The matrix is stored in column-major format:
    /// </summary>
    /// <remarks>
    /// m11 m21 tx
    /// m12 m22 ty
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUTransformation2D
    {
        double m11;
        double m12;
        double m21;
        double m22;
        double tx;
        double ty;
    }

    public static partial class SKPCExport
    {
        /// <summary>
        /// Creates a translation transformation using the given vector.
        /// </summary>
        /// <param name="transform">[out] The transformation to be set.</param>
        /// <param name="vector">[in] The 2D vector specifying the translation for the transformation.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if transform is NULL
        /// SU_ERROR_NULL_POINTER_INPUT if vector is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTransformation2DTranslation(ref SUTransformation2D transform, ref SUVector2D vector);

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
        public static extern SU_RESULT SUTransformation2DScale(ref SUTransformation2D transform,  double scale);

        /// <summary>
        /// Creates a scale transformation using the given scale values.
        /// </summary>
        /// <param name="transform">[out] The transformation to be set.</param>
        /// <param name="x_scale">[in] The x-axis scale value for the transformation.</param>
        /// <param name="y_scale">[in] The y-axis scale value for the transformation.</param>
        /// <returns></returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTransformation2DNonUniformScale(ref SUTransformation2D transform, double x_scale, double y_scale);

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
        public static extern SU_RESULT SUTransformation2DScaleAboutPoint(ref SUTransformation2D transform, ref SUPoint2D point, double scale);

        /// <summary>
        /// Creates a scale transformation using the given scale values and origin.
        /// </summary>
        /// <param name="transform">[out] The transformation to be set.</param>
        /// <param name="point">[in] The point specifying the translation component of the transformation.</param>
        /// <param name="x_scale">[in] The x-axis scale value for the transformation.</param>
        /// <param name="y_scale">[in] The y-axis scale value for the transformation.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if transform is NULL
        /// SU_ERROR_NULL_POINTER_INPUT if point, x_scale, or y_scale are NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTransformation2DNonUniformScaleAboutPoint(ref SUTransformation2D transform,ref SUPoint2D point,double x_scale,double y_scale);

        /// <summary>
        /// Creates a transformation given a point and angle.
        /// </summary>
        /// <param name="transform">[out] The calculated transformation.</param>
        /// <param name="point">[in] The point specifying the translation component of the transformation.</param>
        /// <param name="angle">[in] The rotation in radians for the transformation.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if transform is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if is_identity is NULL
        /// SU_ERROR_OUT_OF_RANGE if weight is not between 0.0 and 1.0
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTransformation2DRotation(ref SUTransformation2D transform, ref SUPoint2D point, double angle);

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
        public static extern SU_RESULT SUTransformation2DIsIdentity(ref SUTransformation2D transform, ref bool is_identity);

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
        public static extern SU_RESULT SUTransformation2DGetInverse(ref SUTransformation2D transform, ref SUTransformation2D inverse);

        /// <summary>
        /// Multiplies a transformation by another transformation.
        /// </summary>
        /// <param name="transform1">[in] The transformation object to be multiplied.</param>
        /// <param name="transform2">[in] The transformation object to multiply by.</param>
        /// <param name="out_transform">[out] The result of the matrix multiplication [transform1 * transform2].</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if out_transform is NULL
        /// SU_ERROR_NULL_POINTER_INPUT if transform1 or transform2 are NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTransformation2DMultiply(ref SUTransformation2D transform1, ref SUTransformation2D transform2, ref SUTransformation2D out_transform);
    }
}
