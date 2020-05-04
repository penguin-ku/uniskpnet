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

namespace PgSkpDK.SketchupRef
{
    /// <summary>
    /// A radial dimension entity reference.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUDimensionStyleRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// dimension_style
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Retrieves the font of a dimension style object.
        /// </summary>
        /// <param name="style">[in] The dimension style object.</param>
        /// <param name="font">[out] The font retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if style is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if font is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionStyleGetFont(SUDimensionStyleRef style, ref SUFontRef font);

        /// <summary>
        /// Retrieves whether the dimension style has 3D text.
        /// </summary>
        /// <param name="style">[in] The dimension style object.</param>
        /// <param name="has_3d">[out] The flag value retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if style is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if has_3d is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionStyleGet3D(SUDimensionStyleRef style, ref bool has_3d);

        /// <summary>
        /// Retrieves a enum value indicating the arrow type specified by the
        /// dimension style.
        /// </summary>
        /// <param name="style">[in] The dimension style object.</param>
        /// <param name="type">[out] The arrow type enum value retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if style is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if type is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionStyleGetArrowType(SUDimensionStyleRef style, ref SUArrowType type);

        /// <summary>
        /// Retrieves the arrow size specified by the dimension style.
        /// dimension style.
        /// </summary>
        /// <param name="style">[in] The dimension style object.</param>
        /// <param name="size">[out] The size retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if style is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if size is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionStyleGetArrowSize(SUDimensionStyleRef style, ref size_t size);

        /// <summary>
        /// Retrieves the color specified by the dimension style.
        /// dimension style.
        /// </summary>
        /// <param name="style">[in] The dimension style object.</param>
        /// <param name="color">[out] The color retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if style is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if color is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionStyleGetColor(SUDimensionStyleRef style, ref SUColor color);

        /// <summary>
        /// Retrieves the text color specified by the dimension style.
        /// dimension style.
        /// </summary>
        /// <param name="style">[in] The dimension style object.</param>
        /// <param name="color">[out] The color retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if style is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if color is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionStyleGetTextColor(SUDimensionStyleRef style, ref SUColor color);

        /// <summary>
        /// Retrieves the dimension style's extension line offset. The offset
        /// specifies the gap between the connection points' locations and the
        /// dimension leader lines.
        /// dimension style.
        /// </summary>
        /// <param name="style">[in] The dimension style object.</param>
        /// <param name="offset">[out] The offset retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if style is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if offset is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionStyleGetExtensionLineOffset(SUDimensionStyleRef style, ref size_t offset);

        /// <summary>
        /// Retrieves the dimension style's extension line overshoot. The overshoot
        /// specifies distance that the dimension leader lines overshoot the point
        /// where they connect with the arrows.
        /// dimension style.
        /// </summary>
        /// <param name="style">[in] The dimension style object.</param>
        /// <param name="overshoot">[out] The overshoot retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if style is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if overshoot is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionStyleGetExtensionLineOvershoot(SUDimensionStyleRef style, ref size_t overshoot);

        /// <summary>
        /// Retrieves the line weight specified by the dimension style.
        /// </summary>
        /// <param name="style">[in] The dimension style object.</param>
        /// <param name="weight">[out] The weight retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if style is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if weight is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionStyleGetLineWeight(SUDimensionStyleRef style, ref size_t weight);

        /// <summary>
        /// Retrieves whether the dimension style specifies non-associative
        /// dimensions(including edited text) be highlighted in a color which can
        /// be retrieved with SUDimensionStyleGetHighlightNonAssociativeDimensionsColor
        /// </summary>
        /// <param name="style">[in] The dimension style object.</param>
        /// <param name="highlight">[out] The flag value retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if style is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if highlight is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionStyleGetHighlightNonAssociativeDimensions(SUDimensionStyleRef style, ref bool highlight);

        /// <summary>
        /// Retrieves the non-associative dimensions highlight color specified by the dimension style.
         /// </summary>
         /// <param name="style">[in] The dimension style object.</param>
         /// <param name="color">[out] The color retrieved.</param>
         /// <returns>
         /// SU_ERROR_NONE on success
         /// SU_ERROR_INVALID_INPUT if style is not a valid object
         /// SU_ERROR_NULL_POINTER_OUTPUT if color is NULL
         /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionStyleGetHighlightNonAssociativeDimensionsColor(SUDimensionStyleRef style, ref SUColor color);

        /// <summary>
        /// Retrieves whether the dimension style specifies that radius/diameter
        /// prefixes be displayed on radial dimensions.
        /// </summary>
        /// <param name="style">[in] The dimension style object.</param>
        /// <param name="show">[out] The flag value retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if style is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if show is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionStyleGetShowRadialPrefix(SUDimensionStyleRef style, ref bool show);

        /// <summary>
        /// Retrieves whether the dimension style specifies that out of plane
        /// dimensions(dimensions which are not parallel to the view plane) be
        /// hidden.
        /// </summary>
        /// <param name="style">[in] The dimension style object.</param>
        /// <param name="hide">[out] The flag value retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if style is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if hide is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionStyleGetHideOutOfPlane(SUDimensionStyleRef style, ref bool hide);

        /// <summary>
        /// Retrieves the dimension style's parameter specifying out of plane tolerance for hiding dimensions.
        /// </summary>
        /// <param name="style">[in] The dimension style object.</param>
        /// <param name="tolerance">[out] The value retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if style is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if tolerance is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionStyleGetHideOutOfPlaneValue(SUDimensionStyleRef style, ref double tolerance);

        /// <summary>
        /// Retrieves whether the dimension style specifies that small dimensions be hidden.
         /// </summary>
         /// <param name="style">[in] The dimension style object.</param>
         /// <param name="hide">[out] The value retrieved.</param>
         /// <returns>
         /// SU_ERROR_NONE on success
         /// SU_ERROR_INVALID_INPUT if style is not a valid object
         /// SU_ERROR_NULL_POINTER_OUTPUT if hide is NULL
         /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionStyleGetHideSmall(SUDimensionStyleRef style, ref bool hide);

        /// <summary>
        /// Retrieves the minimum size under which dimensions will be hidden if SUDimensionStyleGetHideSmall returns true.
        /// </summary>
        /// <param name="style">[in] The dimension style object.</param>
        /// <param name="tolerance">[out] The value retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if style is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if tolerance is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionStyleGetHideSmall(SUDimensionStyleRef style, ref double tolerance);
    }
}
