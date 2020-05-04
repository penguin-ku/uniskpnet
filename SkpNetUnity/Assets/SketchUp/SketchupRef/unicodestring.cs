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
using unichar = System.UInt16;

namespace PgSkpDK.SketchupRef
{
    /// <summary>
    /// Stores a Unicode string for use as output string parameters in the API.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUStringRef
    {
        public IntPtr ptr;
    }

    public static partial class SKPCExport
    {
        /// <summary>
        /// Creates an empty string.
        /// Constructs a string and initializes it to "", an empty string.
        /// You must use SUStringRelease() on this string object to free its memory.
        /// </summary>
        /// <param name="out_string_ref">[out] The string object to be created.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if out_string_ref is NULL
        /// SU_ERROR_OVERWRITE_VALID if *out_string_ref does not refer to an invalid object.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStringCreate(ref SUStringRef out_string_ref);

        /// <summary>
        /// Deletes a string object.
        /// You must use SUStringRelease when a SUStringRef object is no longer in use.
        /// *string_ref is deleted and the reference is made invalid. (Calling
        /// SUIsInvalid(* string_ref) would evaluate true.)
        /// </summary>
        /// <param name="string_ref">[in] The string object to be deleted.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if string_ref is NULL
        /// SU_ERROR_INVALID_INPUT if *string_ref does not refer to a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStringRelease(ref SUStringRef string_ref);

        /// <summary>
        /// Creates a string from a UTF-8 string.
        /// Constructs a string and initializes it to a copy of the provided string,
        /// which is provided by a '\0' (null) terminated array of 8-bit characters.
        /// This string is interpreted as UTF-8.
        /// You must use SUStringRelease() on this string object to free its memory.
        /// </summary>
        /// <param name="out_string_ref">[in] The string object to be created</param>
        /// <param name="char_array">[out] A null-terminated UTF-8 (or ASCII) string that initializes the string.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if char_array is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if out_string_ref is NULL
        /// SU_ERROR_OVERWRITE_VALID if *out_string_ref does not refer to an invalid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStringCreateFromUTF8(ref SUStringRef out_string_ref, string char_array);

        /// <summary>
        /// Creates a string from a UTF-8 string.
        /// Constructs a string and initializes it to a copy of the provided string,
        /// which is provided by a 0 (null) terminated array of 16-bit characters.
        /// This string is interpreted as UTF-16.
        /// You must use SUStringRelease() on this string object to free its memory.
        /// </summary>
        /// <param name="out_string_ref">[in] The string object to be created</param>
        /// <param name="char_array">[in] A null-terminated UTF-8 (or ASCII) string that initializes the string.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if char_array is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if out_string_ref is NULL
        /// SU_ERROR_OVERWRITE_VALID if *out_string_ref does not refer to an invalid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStringCreateFromUTF16(out SUStringRef out_string_ref, unichar[] char_array);

        /// <summary>
        /// Get the number of 8-bit characters required to store this string.
        /// Gives you the length of the string when encoded in UTF-8. This may be
        /// larger than the number of glyphs when multiple bytes are required.
        /// This value does not include the space for a '\0' (null) terminator value
        /// at the end of the string. It is a good idea when using this function with
        /// SUStringGetUTF8() to add one to out_length.
        /// </summary>
        /// <param name="string_ref">[in] The string object.</param>
        /// <param name="out_length">[out] The length returned.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if string_ref does not refer to a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if out_length is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStringGetUTF8Length(SUStringRef string_ref, ref size_t out_length);

        /// <summary>
        /// Get the number of 16-bit characters required to store this string.
        /// Gives you the length of the string when encoded in UTF-16. This may be
        /// larger than the number of glyphs when multiple bytes are required.
        /// This value does not include the space for a '\0' (null) terminator value
        /// at the end of the string. It is a good idea when using this function with
        /// SUStringGetUTF16() to add one to out_length.
        /// </summary>
        /// <param name="string_ref">[in] The string object.</param>
        /// <param name="out_length">[out] The length returned.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if string_ref does not refer to a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if out_length is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStringGetUTF16Length(SUStringRef string_ref, ref size_t out_length);

        /// <summary>
        /// Trim leading white spaces from the string.
        /// </summary>
        /// <param name="string_ref">[in,out] The string object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if string_ref does not refer to a valid string
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStringTrimLeft(SUStringRef string_ref);

        /// <summary>
        /// Trim tailing white spaces from the string.
        /// </summary>
        /// <param name="string_ref">[in,out] The string object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if string_ref does not refer to a valid string
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStringTrimRight(SUStringRef string_ref);

        /// <summary>
        /// Compares two strings.
        /// </summary>
        /// <param name="a">[in] The first string object.</param>
        /// <param name="b">[in] The second string object.</param>
        /// <param name="result">[out] The comparison result. 0 for equal, -1 for less than, 1 forgreater than. </param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if string_a or string_b do not refer to a valid string
        /// SU_ERROR_NULL_POINTER_OUTPUT if result is NULL 
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStringCompare(SUStringRef a, SUStringRef b, ref int result);

        /// <summary>
        /// Sets the value of a string from a NULL-terminated UTF-8 character array.
        /// </summary>
        /// <param name="string_ref">[in] The string object.</param>
        /// <param name="char_array">[in] The character array to be set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if string_ref does not refer to a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if char_array is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStringSetUTF8(SUStringRef string_ref, string char_array);

        /// <summary>
        /// Sets the value of a string from a NULL-terminated UTF-16 character array.
        /// </summary>
        /// <param name="string_ref">[in] The string object.</param>
        /// <param name="char_array">[in] The character array to be set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if string_ref does not refer to a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if char_array is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStringSetUTF16(SUStringRef string_ref, unichar[] char_array);

        /// <summary>
        /// Writes the contents of the string into the provided character array.
        /// This function does not allocate memory. You must provide an array of sufficient
        /// length to get the entire string. The output string will be NULL terminated.
        /// </summary>
        /// <param name="string_ref">[in] The string object.</param>
        /// <param name="char_array_length">[in] The length of the given character array.</param>
        /// <param name="out_char_array">[out] The character array to be filled in.</param>
        /// <param name="out_number_of_chars_copied">[out] The number of characters returned.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if string_ref does not refer to a valid string
        /// SU_ERROR_NULL_POINTER_OUTPUT : out_char_array or out_number_of_chars_copied is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStringGetUTF8(SUStringRef string_ref, size_t char_array_length, byte[] out_char_array, ref size_t out_number_of_chars_copied);

        /// <summary>
        /// Writes the contents of the string into the provided wide character array.
        /// This function does not allocate memory.You must provide an array of sufficient
        /// length to get the entire string. The output string will be NULL terminated.
        /// </summary>
        /// <param name="string_ref">[in] The string object.</param>
        /// <param name="char_array_length">[in] The length of the given character array.</param>
        /// <param name="out_char_array">[out] The character array to be filled in.</param>
        /// <param name="out_number_of_chars_copied">[out] The number of characters returned.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if string_ref does not refer to a valid string
        /// SU_ERROR_NULL_POINTER_OUTPUT : out_char_array or out_number_of_chars_copied is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStringGetUTF16(SUStringRef string_ref, size_t char_array_length, unichar[] out_char_array, ref size_t out_number_of_chars_copied);

    }
}
