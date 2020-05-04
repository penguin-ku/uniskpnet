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
    /// Stores a RGBA color with 8 bit channels.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUColor
    {
        public byte red;
        public byte green;
        public byte blue;
        public byte alpha;
    }

    /// <summary>
    /// color
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        ///  The blend method is used to blend two colors. The blended color will be the result of taking 
        ///  (1 - weight) * sucolor1 + weight* sucolor2.
        /// </summary>
        /// <param name="color1">[in] A SUColor to blend color2 with.</param>
        /// <param name="color2">[in] A SUColor to blend color1 with.</param>
        /// <param name="weight">[in] A value that determines the weight</param>
        /// <param name="blended_color">[out] blended_color The blended SUColor.</param>
        /// <returns></returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUColorBlend(SUColor color1, SUColor color2, double weight, ref SUColor blended_color);

        /// <summary>
        /// Retrieves the number of color names recognized by SketchUp.
        /// </summary>
        /// <param name="size">[out] The number of color names.</param>
        /// <returns>SU_ERROR_NONE on success, SU_ERROR_NULL_POINTER_OUTPUT if size is NULL</returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUColorGetNumNames(ref long size);

        /// <summary>
        /// Retrives all the color names recognized by SketchUp.
        /// </summary>
        /// <param name="names">[out] An array of all the SketchUp Color names.</param>
        /// <param name="size">[in] The size of the array.</param>
        /// <returns></returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUColorGetNames(ref IntPtr[] names, long size);

        /// <summary>
        /// Sets the color represented by the name.
        /// </summary>
        /// <param name="color">[out] The struct representing the color.</param>
        /// <param name="name">[in] The string representing the color.</param>
        /// <returns></returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUColorSetByName(IntPtr pCcolor, string name);

        /// <summary>
        /// Sets the color with the provided value. The passed in value can either be integer or hexadecimal. 
        /// Alpha will always be 255 but RGB. For example: if the value is 0x66ccff, rgb will be (102, 204, 255) respectively.
        /// </summary>
        /// <param name="color">[out] The struct representing the color.</param>
        /// <param name="value">[in] A value that represents the color.</param>
        /// <returns></returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUColorSetByValue(IntPtr pColor, long value);
    }
}
