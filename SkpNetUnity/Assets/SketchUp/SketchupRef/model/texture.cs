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

namespace PgSkpDK.SketchupRef
{
    /// <summary>
    /// Used to manage image data that can be associated with any SUEntityRef
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUTextureRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// texture
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Converts from an SUTextureRef to an SUEntityRef.
        /// This is essentially an upcast operation.
        /// </summary>
        /// <param name="line">[in] The given line reference.</param>
        /// <returns>
        /// The converted SUEntityRef if line is a valid line.
        /// If not, the returned reference will be invalid.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUEntityRef SUTextureToEntity(SUTextureRef line);

        /// <summary>
        /// Converts from an SUEntityRef to an SUTextureRef.
        /// This is essentially a downcast operation so the given entity must be
        /// convertible to an SUTextureRef.
        /// </summary>
        /// <param name="entity">[in] The given entity reference.</param>
        /// <returns>
        /// The converted SUTextureRef if the downcast operation succeeds
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUTextureRef SUTextureFromEntity(SUEntityRef entity);

        /// <summary>
        /// Creates a new texture object with the specified image data.  If the
        /// texture object is not subsequently associated with a parent object (e.g.
        /// material), then the texture object must be deallocated with \ref
        /// SUTextureRelease.
        /// </summary>
        /// <param name="texture">[out] The texture object created.</param>
        /// <param name="width">[in] The width in pixels of the texture data.</param>
        /// <param name="height">[in] The height in pixels of the texture data.</param>
        /// <param name="bits_per_pixel">[in] The number of bits per pixel of the image data.</param>
        /// <param name="pixel_data">[in] The source of the pixel data.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if pixels is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT texture is NULL
        /// SU_ERROR_OVERWRITE_VALID if texture already references a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextureCreateFromImageData(ref SUTextureRef texture, size_t width, size_t height, size_t bits_per_pixel, SUByte[] pixel_data);

        /// <summary>
        /// Returns the total size and bits-per-pixel value of a texture's image
        /// data. This function is useful to determine the size of the buffer
        /// necessary to be passed into \ref SUTextureGetImageData. The returned
        /// data can be used along with the returned bits-per-pixel value and the
        /// texture dimensions to compute RGBA values at individual pixels of the
        /// texture image.
        /// </summary>
        /// <param name="texture">[in] The texture object.</param>
        /// <param name="data_size">[out] The total size of the image data in bytes.</param>
        /// <param name="bits_per_pixel">[out] The number of bits per pixel of the image data.</param>
        /// <returns></returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextureGetImageDataSize(SUTextureRef texture,ref size_t data_size,ref size_t bits_per_pixel);

        /// <summary>
        /// Returns the texture's image data. The given array must be large enough
        /// to hold the texture's image data. This size can be obtained by calling SUTextureGetImageDataSize.
        /// </summary>
        /// <param name="texture">[in] The texture object.</param>
        /// <param name="data_size">[in] The size of the byte array.</param>
        /// <param name="pixel_data">[out] The image data retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if texture is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if pixel_data is NULL
        /// SU_ERROR_INSUFFICIENT_SIZE if data_size is insufficient for the image
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextureGetImageData(SUTextureRef texture, size_t data_size,SUByte[] pixel_data);

        /// <summary>
        /// Creates a new texture object from an image representation object.
        /// </summary>
        /// <param name="texture">[out] The texture object created.</param>
        /// <param name="image">[in] The image retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if texture is NULL
        /// SU_ERROR_OVERWRITE_VALID if texture already references a valid object
        /// SU_ERROR_INVALID_INPUT if image is not a valid object
        /// SU_ERROR_NO_DATA if the image contains no data
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextureCreateFromImageRep(ref SUTextureRef texture, SUImageRepRef image);

        /// <summary>
        /// Creates a new texture object from an image file specified by a path.
        /// If the texture object is not subsequently associated with a parent
        /// object (e.g. material), then the texture object must be deallocated with
        /// SUTextureRelease.
        /// </summary>
        /// <param name="texture">[out] The texture object created.</param>
        /// <param name="file_path">[in] The file path of the source image file. Assumed to be UTF-8 encoded.</param>
        /// <param name="s_scale">[in] The scale factor for s coordinate value.</param>
        /// <param name="t_scale">[in] The scale factor for t coordinate value.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if file_path is NULL
        /// SU_ERROR_SERIALIZATION if the image file could not be opened
        /// SU_ERROR_GENERIC if a texture could not be created from the image file
        /// SU_ERROR_NULL_POINTER_OUTPUT if texture is NULL
        /// SU_ERROR_OVERWRITE_VALID is texture already references a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextureCreateFromFile(ref SUTextureRef texture, string file_path, double s_scale, double t_scale);

        /// <summary>
        /// Deallocates a texture object and its resources. If the texture object
        /// is associated with a parent object (e.g.material) the parent object
        /// handles the deallocation of the resources of the texture object and the
        /// texture object must not be explicitly deallocated.
        /// </summary>
        /// <param name="texture">[in] The texture object to deallocate.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if texture is NULL
        /// SU_ERROR_INVALID_INPUT if texture does not refer to a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextureRelease(ref SUTextureRef texture);

        /// <summary>
        /// Retrieves the pixel width, height, and scale factors of the texture.
        /// The s_scale and t_scale values are useful when a face doesn't have a
        /// material applied directly, but instead inherit from a parent group or
        /// component instance.Then you want use these values to multiply the
        /// result of SUMeshHelperGetFrontSTQCoords or
        /// SUUVHelperGetFrontUVQ.If the material is applied directly then
        /// this would not be needed.
        /// </summary>
        /// <param name="texture">[in] The texture object whose dimensions are retrieved.</param>
        /// <param name="width">[out] The width in pixels.</param>
        /// <param name="height">[out] The height in pixels.</param>
        /// <param name="s_scale">[out] The s coordinate scale factor to map a pixel into model coordinates.</param>
        /// <param name="t_scale">[out] The t coordinate scale factor to map a pixel into model coordinates.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if texture is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if width, height, s_scale, or t_scale is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextureGetDimensions(SUTextureRef texture, ref size_t width, ref size_t height, ref double s_scale, ref double t_scale);

        /// <summary>
        /// Retrieves a texture's image.  The given image object must have been
        /// constructed using one of the SUImageRepCreate* functions.It must be
        /// released using SUImageRepRelease.The difference between this
        /// function and SUTextureGetColorizedImageRep is that
        /// SUTextureGetColorizedImageRep will retrieve the colorized image rep,
        /// if the material has been colorized.
        /// </summary>
        /// <param name="texture">[in] The texture object.</param>
        /// <param name="image">[out] The image object retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if texture is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if image is NULL
        /// SU_ERROR_INVALID_OUTPUT if image does not point to a valid SUImageRepRef object
        /// SU_ERROR_NO_DATA if no image was created
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextureGetImageRep(SUTextureRef texture, ref SUImageRepRef image);

        /// <summary>
        /// Writes a texture object as an image to disk.
        /// </summary>
        /// <param name="texture">[in] The texture object.</param>
        /// <param name="file_path">[in] The file path destination of the texture image. Assumed to be UTF-8 encoded.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if texture is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if file_path is NULL
        /// SU_ERROR_SERIALIZATION if image file could not be written to disk
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextureWriteToFile(SUTextureRef texture, string file_path);

        /// <summary>
        /// Sets the image file name string associated with the texture object. If
        /// the input texture was constructed using SUTextureCreateFromFile the
        /// name will already be set, so calling this function will override the
        /// texture's file name string.
        /// </summary>
        /// <param name="texture">[in] The texture object.</param>
        /// <param name="name">[in] The name string to set as the file name. Assumed to be UTF-8 encoded.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if texture is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if name is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextureSetFileName(SUTextureRef texture, string name);

        /// <summary>
        /// Retrieves the image file name of a texture object. A full path may be stored with the texture, but this method will always return a file name string with no path.
        /// </summary>
        /// <param name="texture">[in] The texture object.</param>
        /// <param name="file_name">[out] The file name retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if texture is not a valid object
        /// SU_ERROR_GENERIC if the texture is an unknown file type
        /// SU_ERROR_NULL_POINTER_OUTPUT if file_name is NULL
        /// SU_ERROR_INVALID_OUTPUT if file_name does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextureGetFileName(SUTextureRef texture,  ref SUStringRef file_name);

        /// <summary>
        /// Retrieves the value of the flag that indicates whether a texture object uses the alpha channel.
        /// </summary>
        /// <param name="texture">[in] The texture object.</param>
        /// <param name="alpha_channel_used">[out] The destination of the retrieved value.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if texture is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if alpha_channel_used is NULL
        /// SU_ERROR_NO_DATA if the flag value could not be retrieved
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextureGetUseAlphaChannel(SUTextureRef texture, ref bool alpha_channel_used);

        /// <summary>
        /// Retrieves the average color for the texture.
        /// </summary>
        /// <param name="texture">[in] The texture object</param>
        /// <param name="color_val">[out] The color object</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if texture is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if color_val is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextureGetAverageColor(SUTextureRef texture, ref SUColor color_val);

        /// <summary>
        /// Retrieves the image rep object of a colorized texture. If a
        /// non-colorized texture is used, then the original image rep will be
        /// retrieved.The difference between this function and 
        /// SUTextureGetImageRep is that SUTextureGetImageRep will always
        ///  retrieve the original image rep.
        /// </summary>
        /// <param name="texture">[in] The texture object.</param>
        /// <param name="image_rep">[out] The retrieved image rep.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if texture is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if image_rep is NULL
        /// SU_ERROR_NO_DATA if no data was retrieved from the texture
        /// SU_ERROR_OUT_OF_RANGE if the pixel data is out of range
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextureGetColorizedImageRep(SUTextureRef texture, ref SUImageRepRef image_rep);

        /// <summary>
        /// Writes a texture object as an image to disk without any colorization.
        /// If the texture was created from a file on disk this will write out the
        /// original file data if the provided file extension matches.This will be
        /// the fastest way to extract the original texture from the model.
        /// Use SUTextureGetFilename to obtain the original file format.
        /// </summary>
        /// <param name="texture">[in] The texture object.</param>
        /// <param name="file_path">[in] The file path destination of the texture image. Assumed to be UTF-8 encoded.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if texture is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if file_path is NULL
        /// SU_ERROR_SERIALIZATION if image file could not be written to disk
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextureWriteOriginalToFile(SUTextureRef texture, string file_path);

    }
}
