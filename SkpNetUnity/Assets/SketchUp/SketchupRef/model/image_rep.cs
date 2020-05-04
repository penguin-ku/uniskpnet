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
    /// an image representation object.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUImageRepRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// A simple struct with four indices indicating the ordering of color data
    /// within 32-bit bitmap images. 32-bit bitmap images have 4 channels per
    /// pixel: red, green, blue, and alpha where the alpha channel indicates the
    /// transparency of the pixel.SketchUpAPI expects the channels to be in
    /// different orders on Windows vs.Mac OS. Bitmap data is exposed in BGRA
    /// and RGBA byte orders on Windows and Mac OS, respectively.The color
    /// order indices facilitate platform independent code when it is necessary
    /// to manipulate image pixel data. The struct's data also applies to 24-bit
    /// bitmap images except that such images don't have an alpha channel so the
    ///  alpha_index varaible can be ignored.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUColorOrder
    {
        /// <summary>
        /// Indicates the position of the red byte within a single pixel's data.
        /// </summary>
        public short red_index;
        /// <summary>
        /// Indicates the position of the green byte within a single pixel's data.
        /// </summary>
        public short green_index;
        /// <summary>
        /// Indicates the position of the blue byte within a single pixel's data.
        /// </summary>
        public short blue_index;
        /// <summary>
        /// Indicates the position of the alpha byte within a single pixel's data.
        /// </summary>
        public short alpha_index;
    }

    /// <summary>
    /// image_rep
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Retrieves a SUColorOrder indicating the order of color bytes within 32-bit images' pixel data.
        /// </summary>
        /// <returns>a SUColorOrder indicating the pixel color ordering of 32bit images.</returns>
        [DllImport("SketchUpAPI")]
        public static extern SUColorOrder SUGetColorOrder();

        /// <summary>
        /// Creates a new image object with no image data. Image data can be set
        /// using any of SUImageRepCopy, SUImageRepSetData, SUImageRepLoadFile.
        /// </summary>
        /// <param name="image">[out] The image object created.</param>
        /// <returns></returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUImageRepCreate(ref SUImageRepRef image);

        /// <summary>
        /// Releases an image object.
        /// </summary>
        /// <param name="image">[in] The image object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if image is an invalid object
        /// SU_ERROR_NULL_POINTER_INPUT if image is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUImageRepRelease(ref SUImageRepRef image);

        /// <summary>
        /// Copies data from the copy_image to image.
        /// </summary>
        /// <param name="image">[in,out] The image object to be altered.</param>
        /// <param name="copy_image">[in] The original image to copy from.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if image or copy_image are not a valid objects
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUImageRepCopy(SUImageRepRef image, SUImageRepRef copy_image);

        /// <summary>
        /// Sets the image data for the given image. Makes a copy of the data rather than taking ownership.
        /// </summary>
        /// <param name="image">[in] The image object used to load the data.</param>
        /// <param name="width">[in] The width of the image in pixels.</param>
        /// <param name="height">[in] The height of the image in pixels.</param>
        /// <param name="bits_per_pixel">[in] The number of bits per pixel.</param>
        /// <param name="row_padding">[in] The size in Bytes of row padding in each row of pixel_data.</param>
        /// <param name="pixel_data">[in] The raw image data.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if image is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if pixel_data is NULL
        /// SU_ERROR_OUT_OF_RANGE if width or height are 0
        /// SU_ERROR_OUT_OF_RANGE if bits per pixel is not 8, 24, or 32
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUImageRepSetData(SUImageRepRef image, size_t width, size_t height, size_t bits_per_pixel, size_t row_padding, SUByte[] pixel_data);

        /// <summary>
        /// Loads image data from the specified file into the provided image.
        /// </summary>
        /// <param name="image">[in,out] The image object used to load the file.</param>
        /// <param name="">[in] The file path of the source image file. Assumed to be UTF-8 encoded.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if image is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if file_path is NULL
        /// SU_ERROR_SERIALIZATION if the load operation fails
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUImageRepLoadFile(SUImageRepRef image, string file_path);

        /// <summary>
        /// Saves an image object to an image file specified by a path.
        /// </summary>
        /// <param name="image">[in] The image object.</param>
        /// <param name="file_path">[in] The file path of the destination image file. Assumed to be UTF-8 encoded.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if image is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if file_path is NULL
        /// SU_ERROR_NO_DATA if image contains no data
        /// SU_ERROR_SERIALIZATION if the save operation fails
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUImageRepSaveToFile(SUImageRepRef image, string file_path);

        /// <summary>
        /// Retrieves the width and height dimensions of an image object in pixels.
        /// </summary>
        /// <param name="image">[in] The image object.</param>
        /// <param name="width">[out] The width dimension retrieved.</param>
        /// <param name="height">[out] The height dimension retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if image is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if width or height is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUImageRepGetPixelDimensions(SUImageRepRef image, ref size_t width, ref size_t height);

        /// <summary>
        /// Retrieves the size of the row padding of an image, in bytes.
        /// </summary>
        /// <param name="image">[in] The image object.</param>
        /// <param name="row_padding">[out] The row padding retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if image is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if row_padding is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUImageRepGetRowPadding(SUImageRepRef image, ref size_t row_padding);

        /// <summary>
        /// Resizes the dimensions of an image object to the given width and height in pixels.
        /// </summary>
        /// <param name="image">[in] The image object.</param>
        /// <param name="width">[in] The new width.</param>
        /// <param name="height">[in] The new height.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if image is not a valid object
        /// SU_ERROR_OUT_OF_RANGE if width or height are 0
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUImageRepResize(SUImageRepRef image, size_t width, size_t height);

        /// <summary>
        /// Converts an image object to be 32 bits per pixel.
        /// </summary>
        /// <param name="image">[in] The image object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if image is not a valid object
        /// SU_ERROR_NO_DATA if image contains no data
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUImageRepConvertTo32BitsPerPixel(SUImageRepRef image);

        /// <summary>
        /// Returns the total size and bits-per-pixel value of an image. This 
        /// function is useful to determine the size of the buffer necessary to be
        /// passed into SUImageRepGetData.The returned data can be used along
        /// with the returned bits-per-pixel value and the image dimensions to
        /// compute RGBA values at individual pixels of the image.
        /// </summary>
        /// <param name="image">[in] The image object.</param>
        /// <param name="data_size">[out] The total size of the image data in bytes.</param>
        /// <param name="bits_per_pixel">[out] The number of bits per pixel of the image data.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if image is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if data_size or bits_per_pixel is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUImageRepGetDataSize(SUImageRepRef image, ref size_t data_size, ref size_t bits_per_pixel);

        /// <summary>
        /// Returns the pixel data for an image. The given array must be large
        /// enough to hold the image's data. This size can be obtained by calling
        /// SUImageRepGetDataSize.
        /// </summary>
        /// <param name="image">[in] The image object.</param>
        /// <param name="data_size">[in] The size of the byte array.</param>
        /// <param name="pixel_data">[out] The image data retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if image is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if pixel_data is NULL
        /// SU_ERROR_INSUFFICIENT_SIZE if data_size is insufficient for the image
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUImageRepGetData(SUImageRepRef image, size_t data_size, SUByte[] pixel_data);

        /// <summary>
        /// Returns the color data of an image in a SUColor array.
        /// </summary>
        /// <param name="image">[in] The image object.</param>
        /// <param name="color_data">[out] The SUColor data retrieved.</param>
        /// <returns></returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUImageRepGetDataAsColors(SUImageRepRef image, SUColor[] color_data);

        /// <summary>
        /// Returns the color data given by the UV texture coordinates.
        /// </summary>
        /// <param name="image">[in] The image object.</param>
        /// <param name="u">[in] The U texture coordinate.</param>
        /// <param name="v">[in] The V texture coordinate.</param>
        /// <param name="bilinear">[in] The flag to set bilinear texture filtering. This interpolates the colors instead of picking the nearest neighbor.</param>
        /// <param name="color">[out] The returned color.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if image is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if color is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUImageRepGetColorAtUV(SUImageRepRef image, double u, double v, bool bilinear, ref SUColor color);
    }
}
