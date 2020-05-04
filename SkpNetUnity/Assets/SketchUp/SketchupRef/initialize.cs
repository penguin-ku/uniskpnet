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
    /// initialize
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Initializes the slapi interface. Must be called before calling any other API function.
        /// </summary>
        [DllImport("SketchUpAPI")]
        public static extern void SUInitialize();

        /// <summary>
        /// Signals termination of use of the slapi interface. Must be called when done using API functions.
        /// </summary>
        [DllImport("SketchUpAPI")]
        public static extern void SUTerminate();

        /// <summary>
        /// Returns the major and minor API version numbers.
        /// </summary>
        /// <param name="major">[out] The major version number retrieved.</param>
        /// <param name="minor">[out] The minor version number retrieved.</param>
        [DllImport("SketchUpAPI")]
        public static extern void SUGetAPIVersion(out size_t major, out size_t minor);
    }
}
