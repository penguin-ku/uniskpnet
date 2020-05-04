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
    /// Represents a 3D axis-aligned bounding box represented by the extreme
    /// diagonal corner points with minimum and maximum x,y,z coordinates.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUBoundingBox3D
    {
        public SUPoint3D min_point;
        public SUPoint3D max_point;
    }

    /// <summary>
    /// boundingbox
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Gets the mid point from the given bounding box.
        /// </summary>
        /// <param name="bounding_box">[in] The bounding box to calculate the mid point from.</param>
        /// <param name="mid_point">[out] The mid point to be returned.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if bounding_box is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if mid_point NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUBoundingBox3DGetMidPoint(ref SUBoundingBox3D bounding_box, ref SUPoint3D mid_point);
    }
}
