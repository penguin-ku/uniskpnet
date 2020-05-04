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
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUAttributeDictionaryRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// attribute_dictionary
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Creates an attributes dictionary object.
        /// </summary>
        /// <param name="dictionary">[out] The attributes dictionary object created.</param>
        /// <param name="name">[in] The name of the attribute dictionary. Assumed to be UTF-8 encoded.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if name is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if dictionary is NULL
        /// SU_ERROR_OVERWRITE_VALID if dictionary already references a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUAttributeDictionaryCreate(ref SUAttributeDictionaryRef dictionary, string name);

        /// <summary>
        /// Releases an attributes dictionary object and its associated attributes. If this dictionary has a parent, it will be removed from it.
        /// </summary>
        /// <param name="dictionary">[in, out] The attributes dictionary object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if dictionary is NULL
        /// SU_ERROR_INVALID_INPUT if dictionary does not reference a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUAttributeDictionaryRelease(ref SUAttributeDictionaryRef dictionary);

        /// <summary>
        /// Converts from an SUAttributeDictionaryRef to an SUEntityRef. This is essentially an upcast operation.
        /// </summary>
        /// <param name="dictionary">[in] The attribute dictionary object.</param>
        /// <returns>
        /// The converted SUEntityRef if dictionary is a valid object
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUEntityRef SUAttributeDictionaryToEntity(SUAttributeDictionaryRef dictionary);

        /// <summary>
        /// Converts from an SUEntityRef to an SUAttributeDictionaryRef. This is essentially a downcast operation so the given SUEntityRef must be convertible to an SUAttributeDictionaryRef.
        /// </summary>
        /// <param name="entity">[in] The given entity reference.</param>
        /// <returns>
        /// The converted SUAttributeDictionaryRef if the downcast operation succeeds
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUAttributeDictionaryRef SUAttributeDictionaryFromEntity(SUEntityRef entity);

        /// <summary>
        /// Retrieves the name of an attribute dictionary object.
        /// </summary>
        /// <param name="dictionary">[in] The attribute dictionary object.</param>
        /// <param name="name">[out] The name retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dictionary is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if name is NULL
        /// SU_ERROR_INVALID_OUTPUT if name does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUAttributeDictionaryGetName(SUAttributeDictionaryRef dictionary, ref SUStringRef name);

        /// <summary>
        /// Inserts a key-value pair into an attribute dictionary object.
        /// </summary>
        /// <param name="dictionary">[in] The attribute dictionary object.</param>
        /// <param name="key">[in] The key of the key-value pair. Assumed to be UTF-8 encoded.</param>
        /// <param name="value_in">[in] The value of the key-value pair.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dictionary or value_in is an invalid object.
        /// SU_ERROR_NULL_POINTER_INPUT if key is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUAttributeDictionarySetValue(SUAttributeDictionaryRef dictionary, string key, SUTypedValueRef value_in);

        /// <summary>
        /// Retrieves the value associated with a given key from an attribute dictionary.
        /// </summary>
        /// <param name="dictionary">[in] The attribute dictionary object.</param>
        /// <param name="key">[in] The key of the key-value pair. Assumed to be UTF-8 encoded.</param>
        /// <param name="value_out">[out] The value retrieved. Must be a valid object, i.e. must have been allocated via SUTypedValueCreate.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dictionary is an invalid object
        /// SU_ERROR_NULL_POINTER_INPUT if key is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if value_out is NULL
        /// SU_ERROR_INVALID_OUTPUT if value_out is an invalid object
        /// SU_ERROR_NO_DATA if there is no value associated with the given key in the dictionary
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUAttributeDictionaryGetValue(SUAttributeDictionaryRef dictionary, string key, ref SUTypedValueRef value_out);

        /// <summary>
        /// Retrieves the number of keys in an attribute dictionary object.
        /// </summary>
        /// <param name="dictionary">[in] The attribute dictionary object.</param>
        /// <param name="count">[out] The number of keys.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dictionary is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUAttributeDictionaryGetNumKeys(SUAttributeDictionaryRef dictionary, ref size_t count);

        /// <summary>
        /// Retrieves the array of keys of an attribute dictionary object.
        /// </summary>
        /// <param name="dictionary">[in] The attribute dictionary object.</param>
        /// <param name="len">[in] The number of keys to retrieve.</param>
        /// <param name="keys">[out] The keys retrieved.</param>
        /// <param name="count">[out] The number of keys retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dictionary is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if keys or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUAttributeDictionaryGetKeys(SUAttributeDictionaryRef dictionary, size_t len, SUStringRef[] keys, ref size_t count);

    }
}
