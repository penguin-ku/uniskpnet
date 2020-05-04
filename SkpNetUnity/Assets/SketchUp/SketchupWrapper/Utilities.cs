using PgSkpDK.SketchupRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;


namespace PgSkpDK.SketchupWrapper
{
    public static class Utilities
    {
        public static string GetString(SUStringRef name)
        {
            long length = default(long);
            SKPCExport.SUStringGetUTF8Length(name, ref length);
            byte[] bytes = new byte[length];
            SKPCExport.SUStringGetUTF8(name, length, bytes, ref length);
            string text = System.Text.Encoding.UTF8.GetString(bytes.Take((int)length).ToArray());
            return text;
        }
        public static string GetString2(SUStringRef name)
        {
            long length = default(long);
            SKPCExport.SUStringGetUTF16Length(name, ref length);
            ushort[] bytes = new ushort[length];
            SKPCExport.SUStringGetUTF16(name, length, bytes, ref length);
            return "";
        }

        public static byte[] ToString(string name)
        {
            return System.Text.Encoding.UTF8.GetBytes(name);
        }
    }
}
