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
    /// references a length formatter object. Length formatters are used to
    /// generate formatted strings(optionally with units) from length, area,
    /// and volume values.Additionally length formatters can be used to
    /// translate a formatted length/area/volume string into a value. Accessors
    /// and setters are exposed for some of the key formatting properties,
    /// facilitating customization of the formater.In cases when users want the
    /// formatter to reflect the properties of a model, SUModelGetLengthFormatter
    /// should be used to more efficiently extract/copy the relevant properties
    /// from the model to the formatter.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SULengthFormatterRef
    {
        public byte red;
        public byte green;
        public byte blue;
        public byte alpha;
    }

    /// <summary>
    /// Indicates the different supported length string formatting types
    /// </summary>
    public enum SULengthFormatType
    {
        SU_LFORMAT_DECIMAL,
        SU_LFORMAT_ARCHITECTURAL,
        SU_LFORMAT_ENGINEERING,
        SU_LFORMAT_FRACTIONAL
    }

    /// <summary>
    ///  Indicates the different supported length string formatting units
    /// </summary>
    public enum SULengthUnitType
    {
        SU_LUNIT_INCHES,
        SU_LUNIT_FEET,
        SU_LUNIT_MILLIMETER,
        SU_LUNIT_CENTIMETER,
        SU_LUNIT_METER
    }

    /// <summary>
    /// Indicates the different supported area string formatting units
    /// </summary>
    public enum SUAreaUnitType
    {
        SU_AUNIT_SQUARE_INCHES,
        SU_AUNIT_SQUARE_FEET,
        SU_AUNIT_SQUARE_MILLIMETER,
        SU_AUNIT_SQUARE_CENTIMETER,
        SU_AUNIT_SQUARE_METER
    }

    /// <summary>
    /// Indicates the different supported volume string formatting units
    /// </summary>
    public enum SUVolumeUnitType
    {
        SU_VUNIT_CUBIC_INCHES,
        SU_VUNIT_CUBIC_FEET,
        SU_VUNIT_CUBIC_MILLIMETER,
        SU_VUNIT_CUBIC_CENTIMETER,
        SU_VUNIT_CUBIC_METER
    }

    /// <summary>
    /// length_formatter
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Creates a new length formatter with default properties.
        /// </summary>
        /// <param name="formatter">[out] The formatter object created.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if formatter is NULL
        /// SU_ERROR_OVERWRITE_VALID if formatter already references a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULengthFormatterCreate(ref SULengthFormatterRef formatter);

        /// <summary>
        /// Releases a length formatter object.
        /// </summary>
        /// <param name="formatter">[in] The formatter object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if formatter is an invalid object
        /// SU_ERROR_NULL_POINTER_INPUT if formatter is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULengthFormatterRelease(ref SULengthFormatterRef formatter);

        /// <summary>
        /// Retrieves the precision of a length formatter.
        /// </summary>
        /// <param name="formatter">[in] The formatter object.</param>
        /// <param name="precision">[out] The precision retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if formatter is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if precision is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULengthFormatterGetPrecision(SULengthFormatterRef formatter, ref size_t precision);

        /// <summary>
        /// Sets the precision of a length formatter.
        /// </summary>
        /// <param name="formatter">[in] The formatter object.</param>
        /// <param name="precision">[in] The precision to be set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if formatter is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULengthFormatterSetPrecision(SULengthFormatterRef formatter, size_t precision);

        /// <summary>
        /// Retrieves the format of a length formatter.
        /// </summary>
        /// <param name="formatter">[in] The formatter object.</param>
        /// <param name="format">[out] The format retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if formatter is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if format is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULengthFormatterGetFormat(SULengthFormatterRef formatter, ref SULengthFormatType format);

        /// <summary>
        /// Sets the format of a length formatter.
        /// </summary>
        /// <param name="formatter">[in] The formatter object.</param>
        /// <param name="format">[in] The format to be set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if formatter is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULengthFormatterSetFormat(SULengthFormatterRef formatter, SULengthFormatType format);

        /// <summary>
        /// Retrieves the units of a length formatter.
        /// </summary>
        /// <param name="formatter">[in] The formatter object.</param>
        /// <param name="units">[out] The units retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if formatter is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if units is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULengthFormatterGetUnits(SULengthFormatterRef formatter, ref SULengthUnitType units);

        /// <summary>
        /// Sets the units of a length formatter.
        /// </summary>
        /// <param name="formatter">[in] The formatter object.</param>
        /// <param name="units">[in] The units to be set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if formatter is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULengthFormatterSetUnits(SULengthFormatterRef formatter, SULengthUnitType units);

        /// <summary>
        /// Retrieves whether units are suppressed.
        /// </summary>
        /// <param name="formatter">[in] The formatter object.</param>
        /// <param name="suppress">[out] The unit suppression flag retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if formatter is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if suppress is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULengthFormatterGetSuppressUnits(SULengthFormatterRef formatter, out bool suppress);

        /// <summary>
        /// Sets whether units are suppressed.
        /// </summary>
        /// <param name="formatter">[in] The formatter object.</param>
        /// <param name="suppress">[in] The unit suppression flag to be set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if formatter is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULengthFormatterSetSuppressUnits(SULengthFormatterRef formatter, bool suppress);

        /// <summary>
        /// Retrieves a formatted length string from the provided length value.
        /// </summary>
        /// <param name="formatter">[in] The formatter object.</param>
        /// <param name="length">[in] The length value.</param>
        /// <param name="strip">[in] Whether to strip trailing zeros, leading ~, and decimal point if it is the last character.</param>
        /// <param name="string_value">[out] The formatted string retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if formatter is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if suppress is string
        /// SU_ERROR_INVALID_OUTPUT if *string is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULengthFormatterGetLengthString(SULengthFormatterRef formatter, double length, bool strip, ref SUStringRef string_value);

        /// <summary>
        /// Retrieves a formatted area string from the provided area value.
        /// </summary>
        /// <param name="formatter">[in] The formatter object.</param>
        /// <param name="area">[in] The area value.</param>
        /// <param name="string_value">[out] The formatted string retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if formatter is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if suppress is string
        /// SU_ERROR_INVALID_OUTPUT if *string is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULengthFormatterGetAreaString(SULengthFormatterRef formatter, double area, ref SUStringRef string_value);

        /// <summary>
        /// Retrieves a formatted volume string from the provided volume value.
        /// </summary>
        /// <param name="formatter">[in] The formatter object.</param>
        /// <param name="volume">[in] The volume value.</param>
        /// <param name="string_value">[out] The formatted string retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if formatter is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if suppress is string
        /// SU_ERROR_INVALID_OUTPUT if *string is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULengthFormatterGetVolumeString(SULengthFormatterRef formatter, double volume, ref SUStringRef string_value);

        /// <summary>
        /// Parses a formatted length string getting the numeric value.
        /// </summary>
        /// <param name="formatter">[in] The formatter object.</param>
        /// <param name="string_value">[in] The formatted string.</param>
        /// <param name="value">[out] The numeric value retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if formatter or string are not a valid objects
        /// SU_ERROR_NULL_POINTER_OUTPUT if value is NULL
        /// SU_ERROR_INVALID_ARGUMENT if the string could not be parsed
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULengthFormatterParseString(SULengthFormatterRef formatter, SUStringRef string_value, ref double value);

        /// <summary>
        /// Retrieves the area units of a length formatter.
        /// </summary>
        /// <param name="formatter">[in] The formatter object.</param>
        /// <param name="units">[out] The unit type retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if formatter is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if units is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULengthFormatterGetAreaUnits(SULengthFormatterRef formatter, ref SUAreaUnitType units);


        /// <summary>
        /// Retrieves the area units of a length formatter.
        /// </summary>
        /// <param name="formatter">[in] The formatter object.</param>
        /// <param name="units">[out] The unit type retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if formatter is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if units is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULengthFormatterGetVolumeUnits(SULengthFormatterRef formatter, ref SUVolumeUnitType units);

        /// <summary>
        /// Sets the area units of a length formatter.
        /// </summary>
        /// <param name="formatter">[in] The formatter object.</param>
        /// <param name="units">[in] The unit type to be set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if formatter is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if units is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULengthFormatterSetAreaUnits(SULengthFormatterRef formatter, SUAreaUnitType units);


        /// <summary>
        /// Sets the volume units of a length formatter.
        /// </summary>
        /// <param name="formatter">[in] The formatter object.</param>
        /// <param name="units">[out] The unit type  to be set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if formatter is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if units is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULengthFormatterSetVolumeUnits(SULengthFormatterRef formatter, SUVolumeUnitType units);

        /// <summary>
        /// Force the display of Architectural inches even if the value is zero.
        /// </summary>
        /// <param name="formatter">[in] The formatter object.</param>
        /// <param name="force_inch">[in] The boolean value to force inch display.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if formatter is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULengthFormatterSetForceInchDisplay(SULengthFormatterRef formatter, bool force_inch);

        /// <summary>
        /// Determine if Architectural inches will display even if the value is zero.
        /// </summary>
        /// <param name="formatter">[in] The formatter object.</param>
        /// <param name="force_inch">[out] The boolean value to force inch display.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if formatter is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if value is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULengthFormatterGetForceInchDisplay(SULengthFormatterRef formatter, ref bool force_inch);
    }
}
