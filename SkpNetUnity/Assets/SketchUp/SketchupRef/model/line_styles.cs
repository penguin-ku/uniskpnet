using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SU_RESULT = PgSkpDK.SketchupRef.SUResult;
using size_t = System.Int64;
using int32_t = System.Int32;
using int64_t = System.Int64;
using System.Runtime.InteropServices;
using SUByte = System.Byte;

namespace PgSkpDK.SketchupRef
{
    /// <summary>
    /// Provides access to the different line style objects in the model.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SULineStylesRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// line_styles
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Gets the number of line styles.
        /// </summary>
        /// <param name="line_styles">[in] The line_styles manager object.</param>
        /// <param name="count">[out] The number of line styles available.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if line_style_manager is not valid
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULineStylesGetNumLineStyles(SULineStylesRef line_styles, ref size_t count);

        /// <summary>
        /// Retrieves line styles associated with the line styles manager.
        /// </summary>
        /// <param name="line_styles">[in] The line_styles manager object.</param>
        /// <param name="len">[in] The number of line style names to retrieve.</param>
        /// <param name="line_styles_provider_names">[out] The line_style names retrieved.</param>
        /// <param name="count">[out] The number of line style names</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if line_style_manager is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if line_styles_providers or count is NULL
        /// SU_ERROR_INVALID_OUTPUT if any of the strings in line_styles_provider_names are invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULineStylesGetLineStyleNames(SULineStylesRef line_styles, size_t len, SUStringRef[] line_styles_provider_names, ref size_t count);

        /// <summary>
        /// Retrieves the line styles provider given a name.
        /// </summary>
        /// <param name="line_styles">[in] The line_styles manager object.</param>
        /// <param name="name">[in] The name of the line_styles provider object to get. Assumed to be UTF-8 encoded.</param>
        /// <param name="line_style">[out] The line_styles_provider object retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if line_styles is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if name is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if line_style is NULL
        /// SU_ERROR_NO_DATA if the requested line_styles provider object does not exist
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULineStylesGetLineStyleByName(SULineStylesRef line_styles, string name, ref SULineStyleRef line_style);
    }
}
