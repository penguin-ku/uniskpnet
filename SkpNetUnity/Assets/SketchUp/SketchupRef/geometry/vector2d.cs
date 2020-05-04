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
    /// Represents a point in 2-dimensional space.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUVector2D
    {
        public double x;
        public double y;
    }

    /// <summary>
    /// vertor2d
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Creates a vector between two point objects.
        /// </summary>
        /// <param name="vector">[out] The vector from from to to.</param>
        /// <param name="from">[in] The first point object.</param>
        /// <param name="to">[in] The second point object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if from or to is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if vector is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUVector2DCreate(ref SUVector2D vector, ref SUPoint2D from, ref SUPoint2D to);

        /// <summary>
        /// Determines if a vector is valid. A vector is invalid if its length is zero.
        /// </summary>
        /// <param name="vector">[in] vector The vector object.</param>
        /// <param name="valid">[out] valid  Whether the vector is valid.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if vector is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if valid is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUVector2DIsValid(ref SUVector2D vector, ref bool valid);

        /// <summary>
        /// Determines if two vectors are parallel.
        /// </summary>
        /// <param name="vector1">[in] The first vector object.</param>
        /// <param name="vector2">[in] The second vector object.</param>
        /// <param name="parallel">[out] Whether the vectors are parallel.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if vector1 or vector2 is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if parallel is NULL
        /// SU_ERROR_INVALID_ARGUMENT if vector1 or vector2 is not a valid vector
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUVector2DIsParallelTo(ref SUVector2D vector1, ref SUVector2D vector2, ref bool parallel);

        /// <summary>
        /// Determines if two vectors are perpendicular.
        /// </summary>
        /// <param name="vector1">[in] The first vector object.</param>
        /// <param name="vector2">[in] The second vector object.</param>
        /// <param name="perpendicular">[out] Whether the vectors are perpendicular.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if vector1 or vector2 is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if perpendicular is NULL
        /// SU_ERROR_INVALID_ARGUMENT if vector1 or vector2 is not a valid vector
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUVector2DIsPerpendicularTo(ref SUVector2D vector1, ref SUVector2D vector2, ref bool perpendicular);

        /// <summary>
        /// Determines if two vectors are parallel and pointing the same direction.
        /// </summary>
        /// <param name="vector1">[in] The first vector object.</param>
        /// <param name="vector2">[in] The second vector object.</param>
        /// <param name="same_direction">[out] Whether the vectors are pointing in the same direction.</param>
        /// <returns></returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUVector2DIsSameDirectionAs(ref SUVector2D vector1, ref SUVector2D vector2, ref bool same_direction);

        /// <summary>
        /// Determines if two vectors are equal.
        /// </summary>
        /// <param name="vector1">[in] The first vector object.</param>
        /// <param name="vector2">[in] The second vector object.</param>
        /// <param name="equal">[out] Whether the vectors are equal.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if vector1 or vector2 is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if equal is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUVector2DIsEqual(ref SUVector2D vector1, ref SUVector2D vector2, ref bool equal);

        /// <summary>
        /// Normalizes a vector.
        /// </summary>
        /// <param name="vector">[in,out] The vector object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if vector is NULL
        /// SU_ERROR_INVALID_ARGUMENT if vector is not a valid vector
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUVector2DNormalize(ref SUVector2D vector);

        /// <summary>
        /// Reverses a vector.
        /// </summary>
        /// <param name="vector">[in,out] The vector object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if vector is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUVector2DReverse(ref SUVector2D vector);

        /// <summary>
        /// Computes the dot product of two vectors.
        /// </summary>
        /// <param name="vector1">[in] The first vector object.</param>
        /// <param name="vector2">[in] The second vector object.</param>
        /// <param name="dot">[out] The value of the dot product.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if vector1 or vector2 is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if dot is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUVector2DDot(ref SUVector2D vector1, ref SUVector2D vector2, ref double dot);

        /// <summary>
        /// Computes the cross product of two vectors.
        /// </summary>
        /// <param name="vector1">[in] The first vector object.</param>
        /// <param name="vector2">[in] The second vector object.</param>
        /// <param name="cross">[out] The value of the cross product.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if vector1 or vector2 is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if cross is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUVector2DCross(ref SUVector2D vector1, ref SUVector2D vector2, ref double cross);

        /// <summary>
        /// Determines if a vector has a length of one.
        /// </summary>
        /// <param name="vector">[in] The vector object.</param>
        /// <param name="is_unit_vector">[out] Whether the vector has a length of one.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if vector is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if is_unit_vector is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUVector2DIsUnitVector(ref SUVector2D vector, ref bool is_unit_vector);

        /// <summary>
        /// Gets the length of a vector.
        /// </summary>
        /// <param name="vector">[in] The vector object.</param>
        /// <param name="length">[out] The length of the vector.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if vector is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if length is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUVector2DGetLength(ref SUVector2D vector, ref double length);

        /// <summary>
        /// Sets the length of a vector.
        /// </summary>
        /// <param name="vector">[in] The vector object.</param>
        /// <param name="length">[in] The new length the vector should be.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if vector is NULL
        /// SU_ERROR_OUT_OF_RANGE if length is zero
        /// SU_ERROR_INVALID_ARGUMENT if vector is not a valid vector
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUVector2DSetLength(ref SUVector2D vector, double length);

        /// <summary>
        /// Gets the angle between two vectors.
        /// </summary>
        /// <param name="vector1">[in] The first vector object.</param>
        /// <param name="vector2">[in] The second vector object.</param>
        /// <param name="angle">[out] The angle between the vectors.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if vector1 or vector2 is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if angle is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUVector2DAngleBetween(ref SUVector2D vector1, ref SUVector2D vector2, ref double angle);

        /// <summary>
        /// Transforms a vector by applying a 2D transformation.
        /// </summary>
        /// <param name="transform">[in] The transformation to be applied.</param>
        /// <param name="vector">[in,out] The vector to be transformed.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if transform is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if vector is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUVector2DTransform(ref SUTransformation2D transform, ref SUVector2D vector);

    }
}
