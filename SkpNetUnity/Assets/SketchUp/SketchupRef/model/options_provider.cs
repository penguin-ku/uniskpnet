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
    /// Provides ability to get and set options on an options provider object. Available options providers 
    /// are: PageOptions, SlideshowOptions, UnitsOptions, NamedOptions, and PrintOptions.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUOptionsProviderRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// options_provider
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Gets the number of available option keys.
        /// </summary>
        /// <param name="options_provider">[in] The options provider object.</param>
        /// <param name="count">[out] The number of keys available.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if options_provider is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUOptionsProviderGetNumKeys(SUOptionsProviderRef options_provider, ref size_t count);

        /// <summary>
        /// Retrieves options providers associated with the options manager.
        /// </summary>
        /// <param name="options_provider">[in] The options provider object.</param>
        /// <param name="len">[in] The number of keys to retrieve.</param>
        /// <param name="keys">[out] The keys retrieved.</param>
        /// <param name="count">[out] The number of keys retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if options_provider is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if keys or count is NULL
        /// SU_ERROR_INVALID_OUTPUT if any of the strings in the keys array are invalid.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUOptionsProviderGetKeys(SUOptionsProviderRef options_provider, size_t len, SUStringRef[] keys, ref size_t count);

        /// <summary>
        /// Gets the value of the given option.
        /// </summary>
        /// <param name="options_provider">[in] The options provider object.</param>
        /// <param name="key">[in] The key that indicates which option to get.</param>
        /// <param name="value">[out] The value to get the current option setting.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if options_provider is not valid
        /// SU_ERROR_NULL_POINTER_INPUT if key is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if value is NULL
        /// SU_ERROR_INVALID_OUTPUT if value is invalid
        /// </returns>
        /// <remarks>
        /// The breakdown of options and value types for each options provider is shown
        /// in the table below.
        /// 
        /// Options Provider | Option               | Value Type              | Meaning
        /// ---------------- | -------------------- | ----------------------- | -------
        /// NamedOptions     | &nbsp;               | &nbsp;                  | Provides ability to save arbitrary named option values.There are no default options for this provider.
        /// PageOptions      | &nbsp;               | &nbsp;                  | Options for the Scene
        /// &nbsp;           | ShowTransition       | SUTypedValueType_Bool   | Show scene transitions
        /// &nbsp;           | TransitionTime       | SUTypedValueType_Double | Number of seconds between each scene transition
        /// SlideshowOptions | &nbsp;               | &nbsp;                  | Options for the slideshow
        /// &nbsp;           | LoopSlideshow        | SUTypedValueType_Bool   | Causes the slideshow to loop
        /// &nbsp;           | SlideTime            | SUTypedValueType_Double | Number of seconds that each slide is shown
        /// UnitsOptions     | &nbsp;               | &nbsp;                  | Options for units display in the model
        /// &nbsp;           | LengthPrecision      | SUTypedValueType_Int32  | Number of decimal places of precision shown for length
        /// &nbsp;           | LengthFormat         | SUTypedValueType_Int32  | Default units format for the model
        /// &nbsp;           | LengthUnit           | SUTypedValueType_Int32  | Units format for the model
        /// &nbsp;           | LengthSnapEnabled    | SUTypedValueType_Bool   | Indicates whether length snapping is enabled
        /// &nbsp;           | LengthSnapLength     | SUTypedValueType_Double | Controls the snapping length size increment
        /// &nbsp;           | AnglePrecision       | SUTypedValueType_Int32  | Number of decimal places of precision shown for angles
        /// &nbsp;           | AngleSnapEnabled     | SUTypedValueType_Bool   | Indicates whether angle snapping is enabled
        /// &nbsp;           | SnapAngle            | SUTypedValueType_Double | Controls the angle snapping size increment
        /// &nbsp;           | SuppressUnitsDisplay | SUTypedValueType_Bool   | Display the units format if LengthFormat is Decimal or Fractional
        /// &nbsp;           | ForceInchDisplay     | SUTypedValueType_Bool   | Force displaying 0" if LengthFormat is Architectural
        /// 
        /// Some of the options map to enumerated values, as shown in the table below.
        /// 
        /// Option       | Value | Meaning
        /// ------------ | ----- | -------
        /// LengthFormat | 0:    | Decimal
        /// &nbsp;       | 1:    | Architectural
        /// &nbsp;       | 2:    | Engineering
        /// &nbsp;       | 3:    | Fractional
        /// LengthUnit   | 0:    | Inches
        /// &nbsp;       | 1:    | Feet
        /// &nbsp;       | 2:    | Millimeter
        /// &nbsp;       | 3:    | Centimeter
        /// &nbsp;       | 4:    | Meter
        /// 
        /// Note that LengthUnit will be overridden by LengthFormat if LengthFormat is not
        /// set to Decimal.Architectural defaults to inches, Engineering defaults to feet,
        /// and Fractional defaults to inches.
        /// </remarks>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUOptionsProviderGetValue(SUOptionsProviderRef options_provider, string key, ref SUTypedValueRef value);

        /// <summary>
        /// Sets the value of the given option.
        /// </summary>
        /// <param name="options_provider">[in] The options provider object.</param>
        /// <param name="key">[in] The key that indicates which option to set.</param>
        /// <param name="value">[in] The value to set the option to.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if options_provider or value is not valid
        /// SU_ERROR_NULL_POINTER_INPUT if key is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUOptionsProviderSetValue(SUOptionsProviderRef options_provider, string key, SUTypedValueRef value);

        /// <summary>
        /// Retrieves the name of the options provider.
        /// </summary>
        /// <param name="options_provider">[in] The options provider object.</param>
        /// <param name="name">[out] The name retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if options_provider or value is not valid
        /// SU_ERROR_NULL_POINTER_OUTPUT if name is NULL
        /// SU_ERROR_INVALID_OUTPUT if name does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUOptionsProviderGetName(SUOptionsProviderRef options_provider, ref SUStringRef name);
    }
}
