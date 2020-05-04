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
    public struct SUClassificationInfoRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// classification_info
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Releases the classification info. Classification info objects are created from component 
        /// instance using SUComponentInstanceCreateClassificationInfo, and must be released using
        /// this function. This function also invalidates the given SUClassificationInfoRef.
        /// </summary>
        /// <param name="classification_info">[in,out] The classification info object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if classification_info is NULL
        /// SU_ERROR_INVALID_INPUT if classification_info is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUClassificationInfoRelease(ref SUClassificationInfoRef classification_info);

        /// <summary>
        /// Retrieves the number of schemas that have been applied to the component instance.
        /// </summary>
        /// <param name="classification_info">[in] The classification info object.</param>
        /// <param name="count">[out] The number of classifications.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if classification_info is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUClassificationInfoGetNumSchemas(SUClassificationInfoRef classification_info, ref size_t count);

        /// <summary>
        /// Retrieves the schema name for the classification at the given index.
        /// </summary>
        /// <param name="classification_info">[in] The classification info object.</param>
        /// <param name="index">[in] The classification index.</param>
        /// <param name="schema_name">[out] The name of the schema.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if classification_info is an invalid object
        /// SU_ERROR_OUT_OF_RANGE if index is larger than the number of schemas
        /// SU_ERROR_NULL_POINTER_OUTPUT if schema_name is NULL
        /// SU_ERROR_INVALID_OUTPUT if *schema_name is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUClassificationInfoGetSchemaName(SUClassificationInfoRef classification_info, size_t index, ref SUStringRef schema_name);

        /// <summary>
        /// Retrieves the schema type for the classification at the given index.
        /// </summary>
        /// <param name="classification_info">[in] The classification info object.</param>
        /// <param name="index">[in] The classification index.</param>
        /// <param name="schema_type">[out] The applied type from the schema.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if classification_info is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if schema_type is NULL
        /// SU_ERROR_OUT_OF_RANGE if index is larger than the number of schemas
        /// SU_ERROR_INVALID_OUTPUT if *schema_type is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUClassificationInfoGetSchemaType(SUClassificationInfoRef classification_info, size_t index, ref SUStringRef schema_type);

        /// <summary>
        /// Retrieves the classification attribute for the classification at the given index.
        /// </summary>
        /// <param name="classification_info">[in] The classification info object.</param>
        /// <param name="index">[in] The classification index.</param>
        /// <param name="attribute">[out] The attribute retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if classification_info is an invalid object
        /// SU_ERROR_OUT_OF_RANGE if index is larger than the number of schemas
        /// SU_ERROR_NULL_POINTER_OUTPUT if attribute is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUClassificationInfoGetSchemaAttribute(SUClassificationInfoRef classification_info, size_t index, ref SUClassificationAttributeRef attribute);

        /// <summary>
        /// Retrieves the classification attribute with the given path.
        /// </summary>
        /// <param name="classification_info">[in] The classification info object.</param>
        /// <param name="path">[in] The path of the classification attribute to get.</param>
        /// <param name="attribute">[out] The attribute retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if classification_info is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if attribute is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUClassificationInfoGetSchemaAttributeByPath(SUClassificationInfoRef classification_info, SUStringRef path, out SUClassificationAttributeRef attribute);
    }
}
