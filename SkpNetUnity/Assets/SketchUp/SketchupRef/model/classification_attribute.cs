using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SU_RESULT = PgSkpDK.SketchupRef.SUResult;
using size_t = System.Int64;
using int32_t = System.Int32;
using int64_t = System.Int64;
using System.Runtime.InteropServices;

namespace PgSkpDK.SketchupRef
{
    /// <summary>
    /// References attribute data about a classified component.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUClassificationAttributeRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// classification_attribute
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// References attribute data about a classified component.
        /// </summary>
        /// <param name="attribute">[in] The classification attribute object.</param>
        /// <param name="value">[out] The value of the attribute.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if attribute is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if value is NULL
        /// SU_ERROR_INVALID_OUTPUT if value does not point to a valid SUTypedValueRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUClassificationAttributeGetValue(SUClassificationAttributeRef attribute, ref SUTypedValueRef value);

        /// <summary>
        /// Retrieves the path to the attribute.
        /// </summary>
        /// <param name="attribute">[in] The classification attribute object.</param>
        /// <param name="path">[out] The attribute name as it should be displayed to the user.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if attribute is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if path is NULL
        /// SU_ERROR_INVALID_OUTPUT if path does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUClassificationAttributeGetPath(SUClassificationAttributeRef attribute, ref SUStringRef path);

        /// <summary>
        /// Retrieves the number of children setting of the attribute.
        /// </summary>
        /// <param name="attribute">[in] The classification attribute object.</param>
        /// <param name="count">[out] The number of children this attribute contains.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if attribute is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUClassificationAttributeGetNumChildren(SUClassificationAttributeRef attribute, ref size_t count);

        /// <summary>
        /// Retrieves the child attribute at the given index.
        /// </summary>
        /// <param name="attribute">[in] The classification attribute object.</param>
        /// <param name="index">[in] The index of the child attribute to get.</param>
        /// <param name="child">[out] The child attribute retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if attribute is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if child is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUClassificationAttributeGetChild(SUClassificationAttributeRef attribute, size_t index, ref SUClassificationAttributeRef child);
    }
}
