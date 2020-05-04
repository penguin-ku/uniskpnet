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
    /// Represents a 3D ray defined by a point and normal vector.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SURay3D
    {
        public SUPoint3D point;
        public SUPoint3D normal;
    }

    /// <summary>
    /// ray3d
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Gets whether or not the point is on the ray.
        /// </summary>
        /// <param name="ray">[in] The ray.</param>
        /// <param name="point">[in] The 3D point.</param>
        /// <param name="is_on">[out] Whether or not the point is on the ray.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if ray or point are NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if is_on is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SURay3DIsOn(ref SURay3D ray, ref SUPoint3D point, ref bool is_on);

        /// <summary>
        /// Gets the distance from the point to the ray.
        /// </summary>
        /// <param name="ray">[in] The ray.</param>
        /// <param name="point">[in] The 3D point.</param>
        /// <param name="distance">[out] The distance between the ray and point.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if ray or point are NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if distance is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SURay3DDistanceTo(ref SURay3D ray, ref SUPoint3D point, ref double distance);

        /// <summary>
        /// Projects a point onto the ray.
        /// </summary>
        /// <param name="ray">[in] The ray.</param>
        /// <param name="point">[in] The 3D point to project onto the ray.</param>
        /// <param name="projected_point">[out] The point resulting from the projection.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if ray or point are NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if projected_point is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SURay3DProjectTo(ref SURay3D ray, ref SUPoint3D point, ref SUPoint3D projected_point);
    }
}
