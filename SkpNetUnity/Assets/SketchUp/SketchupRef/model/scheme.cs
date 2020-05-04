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
    /// Used to manage a Schema object
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUSchemaRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// schema
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Gets a schema type from a schema.
        /// </summary>
        /// <param name="schema_ref">[in] The schema object.</param>
        /// <param name="schema_type_name">[in]  The name of the schema type to get.</param>
        /// <param name="schema_type_ref">[out] The schema type retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if schema_ref is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if schema_type_name is NULL
        /// SU_ERROR_INVALID_INPUT if schema_type_name is not a type from this schema
        /// SU_ERROR_NULL_POINTER_OUTPUT if schema_type_ref is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSchemaGetSchemaType(SUSchemaRef schema_ref, string schema_type_name, ref SUSchemaTypeRef schema_type_ref);
    }
}
