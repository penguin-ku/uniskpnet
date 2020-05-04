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
    /// Represents a point in 3-dimensional space.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUVector3D
    {
        public double x;
        public double y;
        public double z;
    }

    /// <summary>
    /// vertcor3d
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
        public static extern SU_RESULT SUVector3DCreate(ref SUVector3D vector, ref SUPoint3D from, ref SUPoint3D to);

        /// <summary>
        /// Determines if a vector is valid. A vector is invalid if its length is zero.
        /// </summary>
        /// <param name="vector">[in] The vector object.</param>
        /// <param name="valid">[out] Whether the vector is valid.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if vector is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if valid is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUVector3DIsValid(ref SUVector3D vector, ref bool valid);

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
        public static extern SU_RESULT SUVector3DIsParallelTo(ref SUVector3D vector1, ref SUVector3D vector2, ref bool parallel);

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
        public static extern SU_RESULT SUVector3DIsPerpendicularTo(ref SUVector3D vector1, ref SUVector3D vector2, ref bool perpendicular);

        /// <summary>
        /// Determines if two vectors are parallel and pointing the same direction.
        /// </summary>
        /// <param name="vector1">[in] The first vector object.</param>
        /// <param name="vector2">[in] The second vector object.</param>
        /// <param name="same_direction">[out] Whether the vectors are pointing in the same direction.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if vector1 or vector2 is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if same_direction is NULL
        /// SU_ERROR_INVALID_ARGUMENT if vector1 or vector2 is not a valid vector
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUVector3DIsSameDirectionAs(ref SUVector3D vector1, ref SUVector3D vector2, ref bool same_direction);

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
        public static extern SU_RESULT SUVector3DIsEqual(ref SUVector3D vector1, ref SUVector3D vector2, ref bool equal);

        /// <summary>
        /// Determines if vector1 is less than vector2.
        /// </summary>
        /// <param name="vector1">[in] The first vector object.</param>
        /// <param name="vector2">[in] The second vector object.</param>
        /// <param name="less_than">[out] Whether vector1 is less than vector2.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if vector1 or vector2 is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if less_than is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUVector3DLessThan(ref SUVector3D vector1, ref SUVector3D vector2, ref bool less_than);

        /// <summary>
        /// Normalizes a vector.
        /// </summary>
        /// <param name="vector">[in,out] The vector object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if vector is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUVector3DNormalize(ref SUVector3D vector);

        /// <summary>
        /// Reverses a vector.
        /// </summary>
        /// <param name="vector">[in,out] The vector object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if vector is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUVector3DReverse(ref SUVector3D vector);

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
        public static extern SU_RESULT SUVector3DDot(ref SUVector3D vector1, ref SUVector3D vector2, ref double dot);

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
        public static extern SU_RESULT SUVector3DCross(ref SUVector3D vector1, ref SUVector3D vector2, ref SUVector3D cross);

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
        public static extern SU_RESULT SUVector3DIsUnitVector(ref SUVector3D vector, ref bool is_unit_vector);

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
        public static extern SU_RESULT SUVector3DGetLength(ref SUVector3D vector, ref double length);

        /// <summary>
        /// Sets the length of a vector.
        /// </summary>
        /// <param name="vector">[in, out] The vector object.</param>
        /// <param name="length">[out] The new length the vector should be.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if vector is NULL
        /// SU_ERROR_INVALID_ARGUMENT if vector is not a valid vector
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUVector3DSetLength(ref SUVector3D vector, double length);

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
        public static extern SU_RESULT SUVector3DAngleBetween(ref SUVector3D vector1, ref SUVector3D vector2, ref double angle);

        /// <summary>
        /// Get arbitrary axes perpendicular to this vector. This method uses the
        /// arbitrary axis algorithm to calculate the x and y vectors.
        /// </summary>
        /// <param name="z_axis">[in] The vector to use as the z axis.</param>
        /// <param name="x_axis">[in] The computed x axis vector.</param>
        /// <param name="y_axis">[out] The computed y axis vector.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if z_axis is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if x_axis or y_axis is NULL
        /// SU_ERROR_INVALID_ARGUMENT if z_axis is not a valid vector
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUVector3DGetArbitraryAxes(ref SUVector3D z_axis, out SUVector3D x_axis, ref SUVector3D y_axis);

        /// <summary>
        /// Transforms the provided 3D vector by applying the provided 3D transformation.
        /// </summary>
        /// <param name="transform">[in] transform The transformation to be applied.</param>
        /// <param name="vector">[in, out] The vector to be transformed.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if transform is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if vector is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUVector3DTransform(ref SUTransformation transform, ref SUVector3D vector);

        /// <summary>
        /// Creates a new vector as a linear combination of other vectors. This method is generally used to get a vector at some percentage between two vectors.
        /// </summary>
        /// <param name="vectors">[in] An array of vectors. Must be size of 2 or 3.</param>
        /// <param name="weights">[in] An array of weights that correspond to the percentage. Mustbe the same size as vectors.</param>
        /// <param name="size">[in] The size of the vectors and weights array.</param>
        /// <param name="vector">[out] The new computed vector.</param>
        /// <returns></returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUVector3DLinearCombination(ref SUVector3D[] vectors,ref double[] weights, ref long size, ref SUVector3D vector);
    }
}
