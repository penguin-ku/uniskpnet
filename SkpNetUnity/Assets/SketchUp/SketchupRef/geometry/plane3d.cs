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
    /// Represents a 3D plane by the parameters a, b, c, d. 
    /// For any point on the plane, ax + by + cz + d = 0.
    /// The coeficients are normalized so that a*a + b*b + c*c = 1.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUPlane3D
    {
        public double a;
        public double b;
        public double c;
        public double d;
    }

    /// <summary>
    /// plan3d
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Sets the plane using three points.
        /// </summary>
        /// <param name="plane">[out] The plane defined by the three points.</param>
        /// <param name="point1">[in] The first point.</param>
        /// <param name="point2">[in] The second point.</param>
        /// <param name="point3">[in] The third point.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if plane is NULL
        /// SU_ERROR_NULL_POINTER_INPUT if point1, point2, or point3 are NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUPlane3DSetWithPoints(ref SUPlane3D plane, ref SUPoint3D point1, ref SUPoint3D point2, ref SUPoint3D point3);

        /// <summary>
        /// Sets the plane using a point and normal vector.
        /// </summary>
        /// <param name="plane">[out] The plane defined by the point and normal.</param>
        /// <param name="point">[in] The point.</param>
        /// <param name="normal">[in] The normal vector.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if plane is NULL
        /// SU_ERROR_NULL_POINTER_INPUT if point or normal are NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUPlane3DSetWithPointAndNormal(ref SUPlane3D plane, ref SUPoint3D point, ref SUVector3D normal);

        /// <summary>
        /// Sets the plane using equation coefficients.
        /// </summary>
        /// <param name="plane">[out] The plane defined by the coefficients.</param>
        /// <param name="a">[in] The first coefficient.</param>
        /// <param name="b">[in] The second coefficient.</param>
        /// <param name="c">[in] The third coefficient.</param>
        /// <param name="d">[in] The fourth coefficient.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if plane is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUPlane3DSetWithCoefficients(ref SUPlane3D plane, double a, double b, double c, double d);

        /// <summary>
        /// Gets the position on the plane closest to the origin.
        /// </summary>
        /// <param name="plane">[in] The plane from which to get the position.</param>
        /// <param name="position">[out] The 3D point struct retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if plane is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if position is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUPlane3DGetPosition(ref SUPlane3D plane, ref SUPoint3D position);

        /// <summary>
        /// Gets the plane's unit normal vector.
        /// </summary>
        /// <param name="plane">[in] The plane from which to get the normal.</param>
        /// <param name="normal">[out] The 3D vector struct retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if plane is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if normal is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUPlane3DGetNormal(ref SUPlane3D plane, ref SUVector3D normal);

        /// <summary>
        /// Gets whether or not the point is on the plane.
        /// </summary>
        /// <param name="plane">[in] The plane</param>
        /// <param name="point">[in] The 3D point</param>
        /// <param name="is_on">[out] Whether or not the point is on the plane</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if plane or point are NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if is_on is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUPlane3DIsOn(ref SUPlane3D plane, ref SUPoint3D point, ref bool is_on);

        /// <summary>
        /// Gets the distance from the point to the nearest point on the plane.
        /// </summary>
        /// <param name="plane">[in] The plane</param>
        /// <param name="point">[in] The 3D point</param>
        /// <param name="distance">[out] The distance between the plane and point</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if plane or point are NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if distance is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUPlane3DDistanceTo(ref SUPlane3D plane, ref SUPoint3D point, ref double distance);

        /// <summary>
        /// Projects a point onto the plane.
        /// </summary>
        /// <param name="plane">[in] The plane.</param>
        /// <param name="point">[in] The 3D point to project onto the plane.</param>
        /// <param name="projected_point">[out] The point resulting from the projection.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if plane or point are NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if projected_point is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUPlane3DProjectTo(ref SUPlane3D plane, ref SUPoint3D point, ref SUPoint3D projected_point);

        /// <summary>
        /// Transforms the provided 3D plane by applying the provided 3D transformation.
        /// </summary>
        /// <param name="transform">[in] transform The transformation to be applied.</param>
        /// <param name="plane">[in,out] The plane to be transformed.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if transform is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if plane is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUPlane3DTransform(ref SUTransformation transform, ref SUPlane3D plane);
    }
}
