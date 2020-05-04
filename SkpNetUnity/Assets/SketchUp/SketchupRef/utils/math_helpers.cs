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
    /// math_helper
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Converts a value from degrees to radians.
        /// </summary>
        /// <param name="value">[in] A value in degrees.</param>
        /// <returns>The value converted to radians.</returns>
        [DllImport("SketchUpAPI")]
        public static extern double SUDegreesToRadians(double value);

        /// <summary>
        /// Converts a value from radians to degrees.
        /// </summary>
        /// <param name="value">[in] A value in radians.</param>
        /// <returns>The value converted to degrees.</returns>
        [DllImport("SketchUpAPI")]
        public static extern double SURadiansToDegrees(double value);

        /// <summary>
        /// Compares two values for equality with a tolerance.
        /// </summary>
        /// <param name="val1">[in] The first value.</param>
        /// <param name="val2">[in] The second value.</param>
        /// <returns>True if the values are equal.</returns>
        [DllImport("SketchUpAPI")]
        public static extern bool SUEquals(double val1, double val2);

        /// <summary>
        /// Compares two values with a tolerance to see if val1 is less than val2.
        /// </summary>
        /// <param name="val1">[in] The first value.</param>
        /// <param name="val2">[in] The second value.</param>
        /// <returns>True if val1 is less than val2.</returns>
        [DllImport("SketchUpAPI")]
        public static extern bool SULessThan(double val1, double val2);

        /// <summary>
        /// Compares two values with a tolerance to see if val1 is less than or equal to val2.
        /// </summary>
        /// <param name="val1">[in] The first value.</param>
        /// <param name="val2">[in] The second value.</param>
        /// <returns>True if val1 is less than or equal to val2.</returns>
        [DllImport("SketchUpAPI")]
        public static extern bool SULessThanOrEqual(double val1, double val2);

        /// <summary>
        ///  Compares two values with a tolerance to see if val1 is greater than val2.
        /// </summary>
        /// <param name="val1">[in] The first value.</param>
        /// <param name="val2">[in] The second value.</param>
        /// <returns>True if val1 is greater than val2.</returns>
        [DllImport("SketchUpAPI")]
        public static extern bool SUGreaterThan(double val1, double val2);

        /// <summary>
        /// Compares two values with a tolerance to see if val1 is greater than or equal to val2.
        /// </summary>
        /// <param name="val1">[in] The first value.</param>
        /// <param name="val2">[in] The second value.</param>
        /// <returns>True if val1 is greater than or equal to val2.</returns>
        [DllImport("SketchUpAPI")]
        public static extern bool SUGreaterThanOrEqual(double val1, double val2);
    }
}
