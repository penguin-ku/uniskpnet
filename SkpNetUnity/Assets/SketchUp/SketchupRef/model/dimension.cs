using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SU_RESULT = PgSkpDK.SketchupRef.SUResult;
using size_t = System.Int64;
using int32_t = System.Int32;
using int64_t = System.Int64;
using System.Runtime.InteropServices;

namespace PgSkpDK.SketchupRef
{
    /// <summary>
    /// A dimension entity reference.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUDimensionRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// Indicates the supported dimension types
    /// </summary>
    public enum SUDimensionType
    {
        SUDimensionType_Invalid = 0,
        SUDimensionType_Linear,
        SUDimensionType_Radial
    }

    /// <summary>
    /// demesion
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Converts from an SUEntityRef to an SUDimensionRef. This is essentially a downcast operation so the given SUEntityRef must be convertible to an SUDimensionRef.
        /// </summary>
        /// <param name="entity">[in] The given dimension reference.</param>
        /// <returns>
        /// The converted SUEntityRef if dimension is a valid object
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUDimensionRef SUDimensionFromEntity(SUEntityRef entity);

        /// <summary>
        /// Converts from an SUDimensionRef to an SUDrawingElementRef. This is essentially an upcast operation.
        /// </summary>
        /// <param name="dimension">[in] The given entity reference.</param>
        /// <returns>
        /// The converted SUDimensionRef if the downcast operation succeeds
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUDrawingElementRef SUDimensionToDrawingElement(SUDimensionRef dimension);

        /// <summary>
        /// Converts from an SUDrawingElementRef to an SUDimensionRef. This is essentially a downcast operation so the given SUDrawingElementRef must be convertible to an SUDimensionRef.
        /// </summary>
        /// <param name="element">[in] The given drawing element reference.</param>
        /// <returns>
        /// The converted SUDimensionRef if the downcast operation succeeds
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUDimensionRef SUDimensionFromDrawingElement(SUDrawingElementRef element);

        /// <summary>
        /// Retrieves an enum value indicating the dimension type (linear or radial).
        /// </summary>
        /// <param name="dimension">[in] The dimension object.</param>
        /// <param name="type">[out] The dimension type enum value retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dimension is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if type is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionGetType(SUDimensionRef dimension, ref SUDimensionType type);

        /// <summary>
        /// Retrieves the text of a dimension object.
        /// </summary>
        /// <param name="dimension">[in] The dimension object.</param>
        /// <param name="text">[out] The name retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dimension is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if text is NULL
        /// SU_ERROR_INVALID_OUTPUT if text does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionGetText(SUDimensionRef dimension, ref SUStringRef text);

        /// <summary>
        /// Sets the text of a dimension object.
        /// </summary>
        /// <param name="dimension">[in] The dimension object.</param>
        /// <param name="is_text_3d">[in] The text to be set. Assumed to be UTF-8 encoded.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dimension is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if text is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionSetText(SUDimensionRef dimension, string text);

        /// <summary>
        /// Retrieves the plane of a dimension object.
        /// </summary>
        /// <param name="dimension">[in] The dimension object.</param>
        /// <param name="plane">[out] The 3d plane retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dimension is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if plane is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionGetPlane(SUDimensionRef dimension, ref SUPlane3D plane);

        /// <summary>
        /// Retrieves a boolean indicating if the dimension text is 3D.
        /// </summary>
        /// <param name="dimension">[in] The dimension object.</param>
        /// <param name="is_text_3d">[out] The flag value retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dimension is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if is_text_3d is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionGetText3D(SUDimensionRef dimension, ref bool is_text_3d);

        /// <summary>
        /// Sets a boolean indicating whether the dimension text is 3D.
        /// </summary>
        /// <param name="dimension">[in] The dimension object.</param>
        /// <param name="is_text_3d">[in] The flag to be set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dimension is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionSetText3D(SUDimensionRef dimension, bool is_text_3d);

        /// <summary>
        /// Retrieves an enum value indicating the dimension's arrow type.
        /// </summary>
        /// <param name="dimension">[in] The dimension object.</param>
        /// <param name="type">[out] The arrow type enum value retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dimension is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if type is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionGetArrowType(SUDimensionRef dimension, ref SUArrowType type);

        /// <summary>
        /// Sets the dimension's arrow type.
        /// </summary>
        /// <param name="dimension">[in] The dimension object.</param>
        /// <param name="type">[in] The arrow type to be set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dimension is not a valid object
        /// SU_ERROR_OUT_OF_RANGE if type is not a supported value
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionSetArrowType(SUDimensionRef dimension, SUArrowType type);

        /// <summary>
        /// Get the dimension's font reference.
        /// </summary>
        /// <param name="dimension">[in] The dimension object.</param>
        /// <param name="font">[out] The font retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dimension is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if font is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionGetFont(SUDimensionRef dimension, ref SUFontRef font);

        /// <summary>
        /// Sets the dimension's font from a font reference.
        /// </summary>
        /// <param name="dimension">[in] The dimension object.</param>
        /// <param name="font">[in] The font to be set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if dimension or font is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if font is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDimensionSetFont(SUDimensionRef dimension, SUFontRef font);
    }
}
