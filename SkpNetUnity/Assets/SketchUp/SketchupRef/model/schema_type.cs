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
    /// Used to manage a SchemaType object
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUSchemaTypeRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// scheme_type
    /// </summary>
    public static partial class SKPCExport
    {
    }
}
