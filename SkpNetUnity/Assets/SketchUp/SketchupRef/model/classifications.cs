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
    /// Used to manage a Classifications object
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUClassificationsRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// classifications
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Loads a schema into a classification object.
        /// </summary>
        /// <param name="classifications">[in] The classification object.</param>
        /// <param name="schema_file_name">[in] The full path of the schema to load.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if classifications is not a valid object
        /// SU_ERROR_INVALID_INPUT if schema_file_name is not a valid path to a schema or is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUClassificationsLoadSchema(SUClassificationsRef classifications, string schema_file_name);

        /// <summary>
        /// Gets a schema from a classification object.
        /// </summary>
        /// <param name="classifications">[in] The classification object.</param>
        /// <param name="schema_name">[in] The name of the schema to get.</param>
        /// <param name="schema_ref">[out] The schema retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if classifications is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if schema_name is NULL
        /// SU_ERROR_INVALID_INPUT if schema_name is not a loaded schema
        /// SU_ERROR_NULL_POINTER_OUTPUT if schema_ref is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUClassificationsGetSchema(SUClassificationsRef classifications, string schema_name, ref SUSchemaRef schema_ref);
    }
}
