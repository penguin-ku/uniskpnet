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
    public struct SUPoint2D
    {
        public double x;
        public double y;
    }
    
    public static partial class SKPCExport
    {
        /// <summary>
        /// Creates a vector between two point objects.
        /// </summary>
        /// <param name="point1">[in] The first point object.</param>
        /// <param name="point2">[in] The second point object.</param>
        /// <param name="vector">[out] The vector from point1 to point2.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if point1 or point2 is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if vector is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        [Obsolete("The functionality is replaced by SUVector2DCreate.", true)]
        public static extern SU_RESULT SUPoint2DToSUPoint2D(ref SUPoint2D point1, ref SUPoint2D point2, out SUVector2D vector);

        /// <summary>
        /// Determines if two points are equal.
        /// </summary>
        /// <param name="point1">[in] The first point object.</param>
        /// <param name="point2">[in] The second point object.</param>
        /// <param name="equal">[out] Whether the two points are the same.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if point1 or point2 is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if equal is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUPoint2DGetEqual(ref SUPoint2D point1, ref SUPoint2D point2, ref bool equal);

        /// <summary>
        /// Creates a new point that is offset from another point.
        /// </summary>
        /// <param name="point1">[in] The point object.</param>
        /// <param name="vector">[in] The offset vector object.</param>
        /// <param name="point2">[out] The new point.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if point1 or vector is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if point2 is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUPoint2DOffset(ref SUPoint2D point1, ref SUVector2D vector, ref SUPoint2D point2);

        /// <summary>
        ///  Gets the distance between two point objects.
        /// </summary>
        /// <param name="point1">[in] The first point object.</param>
        /// <param name="point2">[in] The second point object.</param>
        /// <param name="distance">[out] The distance between the two points.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if point1 or point2 is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if distance is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUPoint2DDistanceToSUPoint2D(ref SUPoint2D point1, ref SUPoint2D point2, ref double distance);

        /// <summary>
        /// Transforms a point by applying a 2D transformation.
        /// </summary>
        /// <param name="transform">[in] The transformation to be applied.</param>
        /// <param name="point">[in,out] The point to be transformed.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if transform is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if point is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUPoint2DTransform(ref SUTransformation2D transform, ref SUPoint2D point);

    }
}
