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

namespace PgSkpDK.SketchupRef
{    
    /// <summary>
     /// Used to get and set values in a shadow info object.
     /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUShadowInfoRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// shadow_info
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Gets the number of available shadow info keys.
        /// </summary>
        /// <param name="shadow_info">[in] The shadow_info object.</param>
        /// <param name="count">[out] The number of layers.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if shadow_info is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUShadowInfoGetNumKeys(SUShadowInfoRef shadow_info, ref size_t count);

        /// <summary>
        /// Retrieves keys associated with the shadow options object.
        /// </summary>
        /// <param name="shadow_info">[in] The shadow info object.</param>
        /// <param name="len">[in] The number of keys to retrieve.</param>
        /// <param name="keys">[out] The keys retrieved.</param>
        /// <param name="count">[out] The number of keys retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if shadow_info is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if keys or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUShadowInfoGetKeys(SUShadowInfoRef shadow_info, size_t len, SUStringRef[] keys, out size_t count);

        /// <summary>
        /// Retrieves a value from a shadow info object.
        /// </summary>
        /// <param name="shadow_info">[in] The shadow info object.</param>
        /// <param name="key">[in] The key. Assumed to be UTF-8 encoded.</param>
        /// <param name="value_out">[out] The value retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if shadow_info is an invalid object
        /// SU_ERROR_NULL_POINTER_INPUT if key is NULL
        /// SU_ERROR_INVALID_OUTPUT if value_out is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if value_out is NULL
        /// SU_ERROR_NO_DATA if the key does not exist
        /// </returns>
        /// <remarks>
        /// The list of shadow information keys is shown below.
        /// City(in Model Info > Geo-location > Set Manual Location...) Note that 'City' is called 'Location' in the UI
        /// Country(in Model Info > Geo-location > Set Manual Location...)
        /// Dark(in Window > Shadows)
        /// DayOfYear
        /// DaylightSavings
        /// DisplayNorth(in View > Toolbars > Solar North) Note that 'Toolbar' is called 'Tool Palettes' on Mac
        /// DisplayOnAllFaces(in Window > Shadows)
        /// DisplayOnGroundPlane(in Window > Shadows)
        /// DisplayShadows(in Window > Shadows)
        /// EdgesCastShadows(in Window > Shadows)
        /// Latitude(in Model Info > Geo-location > Set Manual Location...)
        /// Light(in Window > Shadows)
        /// Longitude(in Model Info > Geo-location > Set Manual Location...)
        /// NorthAngle(in View > Toolbars > Solar North) Note that 'Toolbar' is called 'Tool Palettes' on Mac
        /// ShadowTime(in Window > Shadows)
        /// ShadowTime_time_t(ShadowTime in Epoch time)
        /// SunDirection(Generated based on ShadowTime)
        /// SunRise(Generated based on ShadowTime)
        /// SunRise_time_t(SunRise in Epoch time)
        /// SunSet(Generated based on ShadowTime)
        /// SunSet_time_t(SunSet in Epoch time)
        /// TZOffset(in Window > Shadows)
        /// UseSunForAllShading(in Window > Shadows)
        /// </remarks>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUShadowInfoGetValue(SUShadowInfoRef shadow_info,string key, ref  SUTypedValueRef value_out);

        /// <summary>
        /// Sets a value on a shadow info object.
        /// </summary>
        /// <param name="shadow_info">[in] The shadow info object.</param>
        /// <param name="key">[in] The key. Assumed to be UTF-8 encoded.</param>
        /// <param name="value_in">[in] The value used to set the shadow info option is set to.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if shadow_info is an invalid object
        /// SU_ERROR_NULL_POINTER_INPUT if key is NULL
        /// SU_ERROR_NO_DATA if the key does not exist
        /// </returns>
        /// <remarks>
        /// The list of shadow information keys is shown below.
        /// City(in Model Info > Geo-location > Set Manual Location...) Note that 'City' is called 'Location' in the UI
        /// Country(in Model Info > Geo-location > Set Manual Location...)
        /// Dark(in Window > Shadows)
        /// DayOfYear
        /// DaylightSavings
        /// DisplayNorth(in View > Toolbars > Solar North) Note that 'Toolbar' is called 'Tool Palettes' on Mac
        /// DisplayOnAllFaces(in Window > Shadows)
        /// DisplayOnGroundPlane(in Window > Shadows)
        /// DisplayShadows(in Window > Shadows)
        /// EdgesCastShadows(in Window > Shadows)
        /// Latitude(in Model Info > Geo-location > Set Manual Location...)
        /// Light(in Window > Shadows)
        /// Longitude(in Model Info > Geo-location > Set Manual Location...)
        /// NorthAngle(in View > Toolbars > Solar North) Note that 'Toolbar' is called 'Tool Palettes' on Mac
        /// ShadowTime(in Window > Shadows)
        /// ShadowTime_time_t(ShadowTime in Epoch time)
        /// SunDirection(Generated based on ShadowTime)
        /// SunRise(Generated based on ShadowTime)
        /// SunRise_time_t(SunRise in Epoch time)
        /// SunSet(Generated based on ShadowTime)
        /// SunSet_time_t(SunSet in Epoch time)
        /// TZOffset(in Window > Shadows)
        /// UseSunForAllShading(in Window > Shadows)
        /// </remarks>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUShadowInfoSetValue(SUShadowInfoRef shadow_info, string key, SUTypedValueRef value_in);
    }
}
