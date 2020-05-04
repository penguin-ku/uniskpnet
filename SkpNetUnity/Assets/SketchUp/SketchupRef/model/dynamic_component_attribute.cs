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
    /// References attribute data about a dynamic component.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUDynamicComponentAttributeRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// dynamic_component_attribute
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Gets the name of the attribute.
        /// </summary>
        /// <param name="attribute">[in] The dynamic component attribute object.</param>
        /// <param name="name">[out] The internal name of the attribute.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if attribute is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if name is NULL
        /// SU_ERROR_INVALID_OUTPUT if name does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDynamicComponentAttributeGetName(SUDynamicComponentAttributeRef attribute,ref SUStringRef name);

        /// <summary>
        /// Gets the display name of the attribute.
        /// </summary>
        /// <param name="attribute">[in] The dynamic component attribute object.</param>
        /// <param name="display_name">[out] The attribute name as it should be displayed to the user.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if attribute is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if display_name is NULL
        /// SU_ERROR_INVALID_OUTPUT if display_name does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDynamicComponentAttributeGetDisplayName(SUDynamicComponentAttributeRef attribute,ref SUStringRef display_name);

        /// <summary>
        /// Gets the visibility setting of the attribute.
        /// </summary>
        /// <param name="attribute">[in] The dynamic component attribute object.</param>
        /// <param name="visible">[out] Set to true if the attribute is visible to users and false if it is not.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if attribute is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if visible is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDynamicComponentAttributeGetVisibility(SUDynamicComponentAttributeRef attribute,ref bool visible);

        /// <summary>
        /// Gets the display value of the attribute.
        /// </summary>
        /// <param name="attribute">[in] The dynamic component attribute object.</param>
        /// <param name="display_value">[out] The value data for the attribute converted to a string formatted as it should be displayed to the user.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if attribute is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if display_value is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDynamicComponentAttributeGetDisplayValue(SUDynamicComponentAttributeRef attribute, ref SUStringRef display_value);

    }
}
