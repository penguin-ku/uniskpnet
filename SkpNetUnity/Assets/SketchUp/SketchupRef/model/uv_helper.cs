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
    ///  Used to compute UV texture coordinates for a particular face.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUUVHelperRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// Stores UV texture coordinates.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUUVQ
    {
        public double u;
        public double v;
        public double q;
    };

    /// <summary>
    /// uv_helper
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Releases a UVHelper object that was obtained from a face.
        /// </summary>
        /// <param name="uvhelper">[in] The UV helper object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if uvhelper is NULL
        /// SU_ERROR_INVALID_INPUT if uvhelper is an invalid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUUVHelperRelease(ref SUUVHelperRef uvhelper);

        /// <summary>
        /// Retrieves the UVQ point at the given point for the front of the face.
        /// </summary>
        /// <param name="uvhelper">[in] The UV helper object.</param>
        /// <param name="point">[in] The point where the coordinates are to be computed.</param>
        /// <param name="uvq">[out] The coordinates retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if uvhelper is an invalid object
        /// SU_ERROR_NULL_POINTER_INPUT if point is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if uvq is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUUVHelperGetFrontUVQ(SUUVHelperRef uvhelper, ref SUPoint3D point, ref SUUVQ uvq);

        /// <summary>
        /// Retrieves the UVQ point at the given point for the back of the face.
        /// </summary>
        /// <param name="uvhelper">[in] The UV helper object.</param>
        /// <param name="point">[in] The point where the coordinates are to be computed.</param>
        /// <param name="uvq">[out] The coordinates retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if uvhelper is an invalid object
        /// SU_ERROR_NULL_POINTER_INPUT if point is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if uvq is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUUVHelperGetBackUVQ(SUUVHelperRef uvhelper, ref SUPoint3D point, ref SUUVQ uvq);
    }
}
