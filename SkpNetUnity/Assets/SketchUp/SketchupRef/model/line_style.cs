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
    /// An instance path type that provides a wrapping of a data structure of component instances.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SULineStyleRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// line_style
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Retrieves the name of a line style object.
        /// </summary>
        /// <param name="line_style">[in] The line style object.</param>
        /// <param name="name">[out] The name retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if line_style is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if name is NULL
        /// SU_ERROR_INVALID_OUTPUT if name does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULineStyleGetName(SULineStyleRef line_style, ref SUStringRef name);
    }
}
