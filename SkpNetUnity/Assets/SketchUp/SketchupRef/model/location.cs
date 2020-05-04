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
    /// References a type that contains location information of a model
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SULocationRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// location
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Retrieves the latitude and longitude of a location object.
        /// </summary>
        /// <param name="location">[in] The location object.</param>
        /// <param name="latitude">[out] The latitude value retrieved.</param>
        /// <param name="longitude">[out] The longitude value retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if location is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if latitude or longitude is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULocationGetLatLong(SULocationRef location, ref double latitude, ref double longitude);

        /// <summary>
        /// Assigns the latitude and longitude values of a location object.
        /// </summary>
        /// <param name="location">[in] The location object.</param>
        /// <param name="latitude">[in] The latitude value to assign.</param>
        /// <param name="longitude">[in] The longitude value to assign.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if location is not a valid object or if the latitude is out of range [-90, 90] or if longitude is out of range [-180, 180]
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULocationSetLatLong(SULocationRef location, double latitude, double longitude);

        /// <summary>
        /// Assigns the north angle values of a location object.
        /// </summary>
        /// <param name="location">[in] The location object.</param>
        /// <param name="north_angle">[in] The north angle value to assign.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if location is not a valid object or if north angle is out of range [0, 360]
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULocationSetNorthAngle(SULocationRef location, double north_angle);
    }
}
