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
    /// References an opening object, which is a hole in a face created by an attached component instance or group.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUOpeningRef
    {
        public IntPtr ptr;
    }

    public static partial class SKPCExport
    {
        /// <summary>
        /// Retrieves the number of points of an opening.
        /// </summary>
        /// <param name="opening">[in] The opening object.</param>
        /// <param name="count">[out] The number of points.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if opening is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUOpeningGetNumPoints(SUOpeningRef opening, ref size_t count);

        /// <summary>
        /// Retrieves the points of an opening object.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="len">[in] The number of points to retrieve.</param>
        /// <param name="fonts">[out] The points retrieved.</param>
        /// <param name="count">[out] The number of points retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if opening or camera is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if points or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUOpeningGetPoints(SUOpeningRef opening, size_t len, SUPoint3D[] points, ref size_t count);

        /// <summary>
        /// Release an opening object.
        /// </summary>
        /// <param name="opening">[in] The opening object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if opening is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if points or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUOpeningRelease(ref SUOpeningRef opening);
    }
}
