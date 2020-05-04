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
    /// Provides access to the different options provider objects in the model. Available options providers are: 
    /// PageOptions, SlideshowOptions, UnitsOptions, NamedOptions, and PrintOptions.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUOptionsManagerRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// options_manager
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Gets the number of available options providers.
        /// </summary>
        /// <param name="opening">[in] The options manager object.</param>
        /// <param name="count">[out] The number of options available.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if options_manager is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUOptionsManagerGetNumOptionsProviders(SUOptionsManagerRef options_manager, ref size_t count);

        /// <summary>
        /// Retrieves options providers associated with the options manager.
        /// </summary>
        /// <param name="options_manager">[in] The options manager object.</param>
        /// <param name="len">[in] The number of options provider names to retrieve.</param>
        /// <param name="options_provider_names">[out] The options provider names retrieved.</param>
        /// <param name="count">[out] The number of options provider names retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if options_manager is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if options_providers or count is NULL
        /// SU_ERROR_INVALID_OUTPUT if any of the strings in options_provider_names
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUOptionsManagerGetOptionsProviderNames(SUOptionsManagerRef options_manager, size_t len, SUStringRef[] options_provider_names, ref size_t count);

        /// <summary>
        /// Retrieves the options provider given a name.
        /// </summary>
        /// <param name="options_manager">[in] The options manager object.</param>
        /// <param name="name">[in] The name of the options provider object to get. Assumed to be UTF-8 encoded.</param>
        /// <param name="options_provider">[out] The options_provider object retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if options_manager is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if name is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if options_providers is NULL
        /// SU_ERROR_NO_DATA if the requested options provider object does not exist
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUOptionsManagerGetOptionsProviderByName(SUOptionsManagerRef options_manager, string name, ref SUOptionsProviderRef options_provider);
    }
}
