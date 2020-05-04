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

namespace PgSkpDK.SketchupRef
{
    /// <summary>
    /// Variant object used to represent the value of a key-value attribute pair.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUTypedValueRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// The set of types that a SUTypedValueRef can represent.
    /// </summary>
    public enum SUTypedValueType
    {
        SUTypedValueType_Empty = 0,
        SUTypedValueType_Byte,
        SUTypedValueType_Short,
        SUTypedValueType_Int32,
        SUTypedValueType_Float,
        SUTypedValueType_Double,
        SUTypedValueType_Bool,
        SUTypedValueType_Color,
        SUTypedValueType_Time,
        SUTypedValueType_String,
        SUTypedValueType_Vector3D,
        SUTypedValueType_Array
    }

    /// <summary>
    /// type_value
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Creates a typed value object.  The created object must be released with SUTypedValueRelease.
        /// </summary>
        /// <param name="typed_value">[out] The created typed value object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if typed_value is NULL
        /// SU_ERROR_OVERWRITE_VALID if typed_value references a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTypedValueCreate(ref SUTypedValueRef typed_value);

        /// <summary>
        /// Releases a typed value object that was previously created withSUTypedValueCreate.
        /// </summary>
        /// <param name="typed_value">[in] The typed value object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if typed_value is NULL
        /// SU_ERROR_INVALID_INPUT if typed_value references an invalid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTypedValueRelease(ref SUTypedValueRef typed_value);

        /// <summary>
        /// Retrieves the type information of a typed value object.
        /// </summary>
        /// <param name="typed_value">[in] The typed value object.</param>
        /// <param name="type">[out] The type information retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if type_value is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if type is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTypedValueGetType(SUTypedValueRef typed_value, ref SUTypedValueType type);

        /// <summary>
        /// Retrieves the byte value of a typed value object.
        /// </summary>
        /// <param name="typed_value">[in] The typed value object.</param>
        /// <param name="byte_value">[out] The byte value retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if typed_value is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if byte_value is NULL
        /// SU_ERROR_NO_DATA if typed_value is not of the requested type
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTypedValueGetByte(SUTypedValueRef typed_value, ref byte byte_value);

        /// <summary>
        /// Sets the byte value of a typed value object.
        /// </summary>
        /// <param name="typed_value">[in] The typed value object.</param>
        /// <param name="byte_value">[in] The byte value that is assigned.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if typed_value is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTypedValueSetByte(SUTypedValueRef typed_value, byte byte_value);

        /// <summary>
        /// Retrieves the int16 value of a typed value object.
        /// </summary>
        /// <param name="typed_value">[in] The typed value object.</param>
        /// <param name="int16_value">[out] The value retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if typed_value is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if int16_value is NULL
        /// SU_ERROR_NO_DATA if typed_value is not of the requested type
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTypedValueGetInt16(SUTypedValueRef typed_value, ref int16_t int16_value);

        /// <summary>
        /// Sets the int16 value of a typed value object.
        /// </summary>
        /// <param name="typed_value">[in] The typed value object.</param>
        /// <param name="int16_value">[in] The value that is assigned.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if typed_value is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTypedValueSetInt16(SUTypedValueRef typed_value, int16_t int16_value);

        /// <summary>
        /// Retrieves the int32 value of a typed value object.
        /// </summary>
        /// <param name="typed_value">[in] The typed value object.</param>
        /// <param name="int32_value">[out] The value retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if typed_value is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if int32_value is NULL
        /// SU_ERROR_NO_DATA if typed_value is not of the requested type
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTypedValueGetInt32(SUTypedValueRef typed_value, ref int32_t int32_value);

        /// <summary>
        /// Sets the int32 value of a typed value object.
        /// </summary>
        /// <param name="typed_value">[in] The typed value object.</param>
        /// <param name="int32_value">[in] The value that is assigned.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if typed_value is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTypedValueSetInt32(SUTypedValueRef typed_value, int32_t int32_value);

        /// <summary>
        /// Retrieves the float value of a typed value object.
        /// </summary>
        /// <param name="typed_value">[in] The typed value object.</param>
        /// <param name="float_value">[out] The value retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if typed_value is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if float_value is NULL
        /// SU_ERROR_NO_DATA if typed_value is not of the requested type
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTypedValueGetFloat(SUTypedValueRef typed_value, ref float float_value);

        /// <summary>
        /// Sets the float value of a typed value object.
        /// </summary>
        /// <param name="typed_value">[in] The typed value object.</param>
        /// <param name="float_value">[in] The value that is assigned.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if typed_value is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTypedValueSetFloat(SUTypedValueRef typed_value, float float_value);

        /// <summary>
        /// Retrieves the double value of a typed value object.
        /// </summary>
        /// <param name="typed_value">[in] The typed value object.</param>
        /// <param name="double_value">[out] The value retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if typed_value is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if double_value is NULL
        /// SU_ERROR_NO_DATA if typed_value is not of the requested type
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTypedValueGetDouble(SUTypedValueRef typed_value, ref double double_value);

        /// <summary>
        /// Sets the double value of a typed value object.
        /// </summary>
        /// <param name="typed_value">[in] The typed value object.</param>
        /// <param name="double_value">[in] The value that is assigned.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if typed_value is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTypedValueSetDouble(SUTypedValueRef typed_value, double double_value);

        /// <summary>
        /// Retrieves the boolean value of a typed value object.
        /// </summary>
        /// <param name="typed_value">[in] The typed value object.</param>
        /// <param name="bool_value">[out] The value retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if typed_value is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if double_value is NULL
        /// SU_ERROR_NO_DATA if typed_value is not of the requested type
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTypedValueGetBool(SUTypedValueRef typed_value, ref bool bool_value);

        /// <summary>
        /// Sets the boolean value of a typed value object.
        /// </summary>
        /// <param name="typed_value">[in] The typed value object.</param>
        /// <param name="bool_value">[in] The value that is assigned.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if typed_value is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTypedValueSetBool(SUTypedValueRef typed_value, bool bool_value);

        /// <summary>
        /// Retrieves the color value of a typed value object.
        /// </summary>
        /// <param name="typed_value">[in] The typed value object.</param>
        /// <param name="color">[out] The value retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if typed_value is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if double_value is NULL
        /// SU_ERROR_NO_DATA if typed_value is not of the requested type
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTypedValueGetColor(SUTypedValueRef typed_value, ref SUColor color);

        /// <summary>
        /// Sets the color value of a typed value object.
        /// </summary>
        /// <param name="typed_value">[in] The typed value object.</param>
        /// <param name="color">[in] The value that is assigned.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if typed_value is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTypedValueSetColor(SUTypedValueRef typed_value, ref SUColor color);

        /// <summary>
        /// Retrieves the time value of a typed value object. The time value is in seconds since January 1, 1970.
        /// </summary>
        /// <param name="typed_value">[in] The typed value object.</param>
        /// <param name="time_value">[out] The value retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if typed_value is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if double_value is NULL
        /// SU_ERROR_NO_DATA if typed_value is not of the requested type
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTypedValueGetTime(SUTypedValueRef typed_value, ref int64_t time_value);

        /// <summary>
        /// Sets the time value of a typed value object. The time value is in seconds since January 1, 1970.
        /// </summary>
        /// <param name="typed_value">[in] The typed value object.</param>
        /// <param name="time_value">[in] The value that is assigned.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if typed_value is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTypedValueSetTime(SUTypedValueRef typed_value, int64_t time_value);

        /// <summary>
        /// Retrieves the string value of a typed value object.
        /// </summary>
        /// <param name="typed_value">[in] The typed value object.</param>
        /// <param name="string_value">[out] The value retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if typed_value is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if double_value is NULL
        /// SU_ERROR_NO_DATA if typed_value is not of the requested type
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTypedValueGetString(SUTypedValueRef typed_value, ref SUStringRef string_valueZ);

        /// <summary>
        /// Sets the string value of a typed value object.
        /// </summary>
        /// <param name="typed_value">[in] The typed value object.</param>
        /// <param name="string_value">[in] The value that is assigned.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if typed_value is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTypedValueSetString(SUTypedValueRef typed_value, string string_value);

        /// <summary>
        /// Retrieves the vector3d value of a typed value object.
        /// </summary>
        /// <param name="typed_value">[in] The typed value object.</param>
        /// <param name="vector3d_value">[out] The value retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if typed_value is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if double_value is NULL
        /// SU_ERROR_NO_DATA if typed_value is not of the requested type
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTypedValueGetVector3d(SUTypedValueRef typed_value, double[] vector3d_value);

        /// <summary>
        /// Sets the vector3d value of a typed value object.
        /// </summary>
        /// <param name="typed_value">[in] The typed value object.</param>
        /// <param name="vector3d_value">[in] The value that is assigned.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if typed_value is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTypedValueSetVector3d(SUTypedValueRef typed_value, double[] vector3d_value);

        /// <summary>
        /// Sets the 3D unit vector value of a typed value object.
        /// </summary>
        /// <param name="typed_value">[in] The typed value object.</param>
        /// <param name="vector3d_value">[in] The value that is assigned.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if typed_value is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTypedValueSetUnitVector3d(SUTypedValueRef typed_value, double[] vector3d_value);

        /// <summary>
        /// Retrieves the number of typed value objects of a typed value object.
        /// </summary>
        /// <param name="typed_value">[in] The typed value object.</param>
        /// <param name="count">[out] The number of typed value objects in the array.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if typed_value is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// SU_ERROR_NO_DATA if typed_value is not of the requested type
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTypedValueGetNumArrayItems(SUTypedValueRef typed_value, ref size_t count);

        /// <summary>
        /// Retrieve the array of typed value objects of a type value object.
        /// </summary>
        /// <param name="typed_value">[in] The typed value object.</param>
        /// <param name="len">[in] The length of the array to retrieve.</param>
        /// <param name="values">[out] The typed value objects retrieved.</param>
        /// <param name="count">[out] The actual number of typed value objects retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if typed_value is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if values or count is NULL
        /// SU_ERROR_NO_DATA if typed_value is not of the requested type
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTypedValueGetArrayItems(SUTypedValueRef typed_value, size_t len, SUTypedValueRef[] values, ref size_t count);

        /// <summary>
        /// Sets the array of typed value objects of a typed value object. The elements of the given array are copied to the type value object.
        /// </summary>
        /// <param name="typed_value">[in] The typed value object.</param>
        /// <param name="len">[in] The number of typed value objects to set.</param>
        /// <param name="values">[in] The array of typed value objects to set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if typed_value is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if values is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTypedValueSetArrayItems(SUTypedValueRef typed_value, size_t len, SUTypedValueRef[] values);
    }
}
