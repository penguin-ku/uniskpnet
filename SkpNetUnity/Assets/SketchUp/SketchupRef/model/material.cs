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
    /// References a material object.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUMaterialRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// Indicates material type.
    /// </summary>
    public enum SUMaterialType
    {
        /// <summary>
        /// Colored material
        /// </summary>
        SUMaterialType_Colored = 0,
        /// <summary>
        /// Textured material
        /// </summary>
        SUMaterialType_Textured,
        /// <summary>
        /// Colored and textured material
        /// </summary>
        SUMaterialType_ColorizedTexture
    }

    /// <summary>
    /// Indicates material owner type.
    /// </summary>
    public enum SUMaterialOwnerType
    {
        /// <summary>
        /// not owned
        /// </summary>
        SUMaterialOwnerType_None = 0,
        /// <summary>
        /// Can be applied to SUDrawingElements
        /// </summary>
        SUMaterialOwnerType_DrawingElement,
        /// <summary>
        /// Owned exclusively by an Image
        /// </summary>
        SUMaterialOwnerType_Image,
        /// <summary>
        /// Owned exclusively by a Layer
        /// </summary>
        SUMaterialOwnerType_Layer
    }

    /// <summary>
    /// Indicates material type.
    /// </summary>
    public enum SUMaterialColorizeType
    {
        /// <summary>
        /// Shifts the texture's Hue
        /// </summary>
        SUMaterialColorizeType_Shift = 0,
        /// <summary>
        /// Colorize the texture
        /// </summary>
        SUMaterialColorizeType_Tint,
    }


    /// <summary>
    /// material
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Converts from an SUMaterialRef to an SUEntityRef.
        /// This is essentially an upcast operation.
        /// </summary>
        /// <param name="material">[in] The given material reference.</param>
        /// <returns>
        /// The converted SUEntityRef if material is a valid material
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUEntityRef SUMaterialToEntity(SUMaterialRef material);

        /// <summary>
        /// Converts from an SUEntityRef to an SULoSUMaterialRefopRef.
        /// This is essentially a downcast operation so the given entity must be
        /// convertible to an SUMaterialRef.
        /// </summary>
        /// <param name="entity">[in] The given entity reference.</param>
        /// <returns>
        /// The converted SUMaterialRef if the downcast operation succeeds
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUMaterialRef SUMaterialFromEntity(SUEntityRef entity);

        /// <summary>
        /// Creates a material.
        /// If the material is not associated with any face, it must be deallocated with
        /// SUMaterialRelease.
        /// </summary>
        /// <param name="material">[out] The material created.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_OUTPUT if the input parameter is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUMaterialCreate(ref SUMaterialRef material);

        /// <summary>
        /// Releases a material and its resources.
        /// The material must not be associated with a parent object such as a face.
        /// </summary>
        /// <param name="material">[in] The material to be released.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT material is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if material is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUMaterialRelease(ref SUMaterialRef material);

        /// <summary>
        /// Sets the name of a material object.
        /// </summary>
        /// <param name="material">[in] The material object.</param>
        /// <param name="name">[in] The name to set the material name. Assumed to be UTF-8 encoded.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if material is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if name is NULL
        /// SU_ERROR_INVALID_ARGUMENT if material is managed and name is not unique
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUMaterialSetName(SUMaterialRef material, string name);

        /// <summary>
        /// Retrieves the internal name of a material object. The internal name is the unprocessed identifier string stored with the material.
        /// </summary>
        /// <param name="material">[in] The material object.</param>
        /// <param name="name">[out] The name retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if material is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if name is NULL
        /// SU_ERROR_INVALID_OUTPUT if name does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUMaterialGetName(SUMaterialRef material, ref SUStringRef name);

        /// <summary>
        /// Sets the name of a material object.
        /// </summary>
        /// <param name="material">[in] The material object.</param>
        /// <param name="color">[in] The color value to set the material color.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if material is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if color is NULL
        /// SU_ERROR_INVALID_ARGUMENT if material is managed and color is not unique
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUMaterialSetColor(SUMaterialRef material, ref SUColor color);

        /// <summary>
        /// Retrieves the color value of a material object.
        /// </summary>
        /// <param name="material">[in] The material object.</param>
        /// <param name="color">[out] The color retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if material is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if color is NULL
        /// SU_ERROR_INVALID_OUTPUT if color does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUMaterialGetColor(SUMaterialRef material, ref SUColor color);

        /// <summary>
        /// Sets the texture of a material object. Materials take ownership of their assigned textures, so textures should not be shared accross different materials.
        /// </summary>
        /// <param name="material">[in] The material object.</param>
        /// <param name="texture">[in] The texture object to set the material texture.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if material or texture is not a valid object
        /// SU_ERROR_GENERIC if texture contains invalid image data
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUMaterialSetTexture(SUMaterialRef material, SUTextureRef texture);

        /// <summary>
        /// Retrieves the color value of a material object.
        /// </summary>
        /// <param name="material">[in] The material object.</param>
        /// <param name="texture">[out] The texture retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if material is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if texture is NULL
        /// SU_ERROR_INVALID_OUTPUT if texture is not a valid object
        /// SU_ERROR_NO_DATA if the material object does not have a texture
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUMaterialGetTexture(SUMaterialRef material, ref SUTextureRef texture);

        /// <summary>
        /// Sets the alpha value of a material object.
        /// </summary>
        /// <param name="material">[in] The material object.</param>
        /// <param name="alpha">[in] The alpha value to set. Must be within range [0.0, 1.0].</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if material is not a valid object
        /// SU_ERROR_OUT_OF_RANGE if alpha is not within the acceptable range
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUMaterialSetOpacity(SUMaterialRef material, double alpha);

        /// <summary>
        /// Retrieves the alpha value (0.0 - 1.0) of a material object.
        /// </summary>
        /// <param name="material">[in] The material object.</param>
        /// <param name="alpha">[out] The alpha value retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if material is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if alpha is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUMaterialGetOpacity(SUMaterialRef material, ref double alpha);

        /// <summary>
        /// Sets the flag indicating whether alpha values are used on a material object.
        /// </summary>
        /// <param name="material">[in] The material object.</param>
        /// <param name="use_opacity">[in] The flag boolean value to set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if material is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUMaterialSetUseOpacity(SUMaterialRef material, bool use_opacity);

        /// <summary>
        /// Retrieves the flag indicating whether alpha values are used from a material object.
        /// </summary>
        /// <param name="material">[in] The material object.</param>
        /// <param name="use_opacity">[out] The flag retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if material is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if use_opacity is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUMaterialGetUseOpacity(SUMaterialRef material, ref bool use_opacity);

        /// <summary>
        /// Sets the type of a material object.
        /// </summary>
        /// <param name="material">[in] The material object.</param>
        /// <param name="type">[in] The type to set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if material is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUMaterialSetType(SUMaterialRef material, SUMaterialType type);

        /// <summary>
        /// Retrieves the type of a material object.
        /// </summary>
        /// <param name="material">[in] The material object.</param>
        /// <param name="use_opacity">[out] The type retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if material is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if type is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUMaterialGetType(SUMaterialRef material, ref SUMaterialType type);

        /// <summary>
        /// Retrieves the flag indicating whether the material is drawn with transparency.
        /// </summary>
        /// <param name="material">[in] The material object.</param>
        /// <param name="transparency">[out] The flag retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if material is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if transparency is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUMaterialIsDrawnTransparent(SUMaterialRef material, ref bool transparency);

        /// <summary>
        /// Retrieves the owner type of a material object.
        /// </summary>
        /// <param name="material">[in] The material object.</param>
        /// <param name="use_opacity">[out] The type retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if material is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if type is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUMaterialGetOwnerType(SUMaterialRef material, ref SUMaterialOwnerType type);

        /// <summary>
        /// Sets the colorization type of a material object. This is used when the
        /// material's color is set to a custom value. Call this function after
        /// calling SUMaterialSetColor as otherwise the colorize type will be reset.
        /// </summary>
        /// <param name="material">[in] The material object.</param>
        /// <param name="type">[in] The type to set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if material is not a valid object
        /// SU_ERROR_INVALID_ARGUMENT if type is not a valid value
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUMaterialSetColorizeType(SUMaterialRef material, SUMaterialColorizeType type);

        /// <summary>
        /// Retrieves the colorization type of a material object.
        /// </summary>
        /// <param name="material">[in] The material object.</param>
        /// <param name="type">[out] The type retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if material is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if type is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUMaterialGetColorizeType(SUMaterialRef material, ref SUMaterialColorizeType type);

        /// <summary>
        /// The colorize_deltas method retrieves the HLS deltas for colorized materials.
        /// </summary>
        /// <param name="material">[in] The material object.</param>
        /// <param name="hue">[out] The Hue delta.</param>
        /// <param name="saturation">[out] The saturation delta.</param>
        /// <param name="lightness">[out] The lightness delta.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if material is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if either hue, saturation or lightness is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUMaterialGetColorizeDeltas(SUMaterialRef material, ref double hue, ref double saturation, ref double lightness);
    }
}
