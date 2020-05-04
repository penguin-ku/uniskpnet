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
    /// This is the edition of SketchUp currently running.
    /// </summary>
    public enum SUEdition
    {
        SUEdition_Unknown,
        SUEdition_Make,     ///< SketchUp Make
        SUEdition_Pro       ///< SketchUp Pro
    }

    /// <summary>
    /// sketchup_info
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Returns the version string for the current SketchUp version. This is exported only by the SketchUp executable. It is not part of the standalone SDK.
        /// </summary>
        /// <param name="length">[in] Length of the string buffer passed in including null terminator.</param>
        /// <param name="version">[out] The UTF-8 encoded version string. This must be large enough to hold the version string including null terminator.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if version is NULL
        /// SU_ERROR_INSUFFICIENT_SIZE if length is too small
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGetVersionStringUtf8(size_t length, string version);

        /// <summary>
        /// Returns the SketchUp edition (Pro or Make). This is only exported by the SketchUp executable. It is not part of the standalone SDK.
        /// </summary>
        /// <param name="edition">[out] The edition of Sketchup</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if edition is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGetEdition(out SUEdition edition);
    }
}
