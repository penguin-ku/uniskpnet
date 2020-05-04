using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using SU_RESULT = PgSkpDK.SketchupRef.SUResult;
using size_t = System.Int64;
using int32_t = System.Int32;
using int64_t = System.Int64;

namespace PgSkpDK.SketchupRef
{
    /// <summary>
    /// A font entity reference.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUFontRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// font
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Retrieves the face name of a font object.
        /// </summary>
        /// <param name="font">[in] The font object.</param>
        /// <param name="name">[out] The name retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if font is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if name is NULL
        /// SU_ERROR_INVALID_OUTPUT if name does not point to a valid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUFontGetFaceName(SUFontRef font, ref SUStringRef name);

        /// <summary>
        /// Retrieves a font's point size.
        /// </summary>
        /// <param name="font">[in] The font object.</param>
        /// <param name="size">[out] The returned font size.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if font is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if size is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUFontGetPointSize(SUFontRef font, ref size_t size);

        /// <summary>
        /// Retrieves a boolean indicating whether the font is bold.
        /// </summary>
        /// <param name="font">[in] The font object.</param>
        /// <param name="is_bold">[out] The boolean retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if font is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if is_bold is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUFontGetBold(SUFontRef font, ref bool is_bold);

        /// <summary>
        /// Retrieves a boolean indicating whether the font is italic.
        /// </summary>
        /// <param name="font">[in] The font object.</param>
        /// <param name="is_italic">[out] The boolean retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if font is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if is_italic is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUFontGetItalic(SUFontRef font, ref bool is_italic);

        /// <summary>
        /// Retrieves a boolean indicating whether the size of the font is defined
        /// as a height in world space.A false value indicates that the font size
        /// is defined in points (i.e. in screen space).
        /// </summary>
        /// <param name="font">[in] The font object.</param>
        /// <param name="use_world_size">[out] The boolean retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if font is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if use_world_size is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUFontGetUseWorldSize(SUFontRef font, ref bool use_world_size);

        /// <summary>
        /// Retrieves the height of the font in inches when the font size is defined
        /// as a height in world space.That is, when SUFontGetUseWorldSize
        /// returns true.
        /// </summary>
        /// <param name="font">[in] The font object.</param>
        /// <param name="world_size">[out] The returned world size factor.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if font is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if world_size is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUFontGetWorldSize(SUFontRef font, ref double world_size);

        /// <summary>
        /// Converts from an SUFontRef to an SUEntityRef. This is essentially an upcast operation.
        /// </summary>
        /// <param name="font">[in] The given font reference.</param>
        /// <returns>
        /// The converted SUEntityRef if font is a valid font.
        /// If not, the returned reference will be invalid.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUEntityRef SUFontToEntity(SUFontRef font);

        /// <summary>
        /// Converts from an SUEntityRef to an \ref SUFontRef.
        /// This is essentially a downcast operation so the given entity must be
        /// convertible to an SUFontRef.
        /// </summary>
        /// <param name="entity">[in] The given entity reference.</param>
        /// <returns>
        /// The converted SUFontRef if the downcast operation succeeds
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUFontRef SUFontFromEntity(SUEntityRef entity);
    }
}
