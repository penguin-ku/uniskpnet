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
    /// References an object with information about a dynamic component.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUDynamicComponentInfoRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// dynamic_component_info
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// References an object with information about a dynamic component.
        /// </summary>
        /// <param name="dc_info">[in,out] The dynamic component info object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if dc_info is NULL
        /// SU_ERROR_INVALID_INPUT if dc_info is not a valid object
        /// </returns>
        /// <remarks>
        /// Releases the DC info. DC info objects are created from component instance
        /// using SUComponentInstanceCreateDCInfo, and must be released using
        /// this function.This function also invalidates the given DC info.
        /// </remarks>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDynamicComponentInfoRelease(ref SUDynamicComponentInfoRef dc_info);

        /// <summary>
        /// Retrieves the number of dynamic component attributes.
        /// </summary>
        /// <param name="dc_info">[in] The dynamic component info object.</param>
        /// <param name="count">[out] The number of attributes.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dc_info is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDynamicComponentInfoGetNumDCAttributes(SUDynamicComponentInfoRef dc_info, ref size_t count);

        /// <summary>
        /// Retrieves the dynamic component attributes.
        /// </summary>
        /// <param name="dc_info">[in] The dynamic component info object.</param>
        /// <param name="len">[in] The number of attributes to retrieve.</param>
        /// <param name="attributes">[out] The attributes retrieved.</param>
        /// <param name="count">[out] The number of attributes retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dc_info is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if attributes or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDynamicComponentInfoGetDCAttributes(SUDynamicComponentInfoRef dc_info, size_t len,SUDynamicComponentAttributeRef[] attributes, ref size_t count);
    }
}
