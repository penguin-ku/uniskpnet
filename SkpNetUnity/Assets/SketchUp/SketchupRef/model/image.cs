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
    /// An Image object represents a raster image placed in the Model.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUImageRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// image
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Converts from an SUImageRef to an SUEntityRef.
        /// This is essentially an upcast operation.
        /// </summary>
        /// <param name="image">[in] The given image reference.</param>
        /// <returns>
        /// The converted SUEntityRef if image is a valid image
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUEntityRef SUImageToEntity(SUImageRef image);

        /// <summary>
        /// Converts from an SUEntityRef to an SUImageRef.
        /// This is essentially a downcast operation so the given entity must be
        /// convertible to an SUImageRef.
        /// </summary>
        /// <param name="entity">[in] The given entity reference.</param>
        /// <returns>
        /// The converted SUImageRef if the downcast operation succeeds
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUImageRef SUImageFromEntity(SUEntityRef entity);

        /// <summary>
        /// Converts from an SUImageRef to an SUDrawingElementRef.
        /// This is essentially an upcast operation.
        /// </summary>
        /// <param name="image">[in] The given image reference.</param>
        /// <returns>
        /// The converted SUEntityRef if image is a valid image
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUDrawingElementRef SUImageToDrawingElement(SUImageRef image);

        /// <summary>
        /// Converts from an SUDrawingElementRef to an SUImageRef.
        /// This is essentially a downcast operation so the given entity must be
        /// convertible to an SUImageRef.
        /// </summary>
        /// <param name="drawing_elem">[in] The given entity reference.</param>
        /// <returns>
        /// The converted SUImageRef if the downcast operation succeeds
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUImageRef SUImageFromDrawingElement(SUDrawingElementRef drawing_elem);

        /// <summary>
        /// Creates a new image object from an image file specified by a path.
        /// The created image must be subsequently added to the Entities of a model,
        /// component definition or a group.
        /// </summary>
        /// <param name="image">[out] The image object created.</param>
        /// <param name="file_path">[in] The file path of the source image file. Assumed to be UTF-8 encoded.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if file_path is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if image is NULL
        /// SU_ERROR_OVERWRITE_VALID if image already references a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUImageCreateFromFile(ref SUImageRef image, string file_path);

        /// <summary>
        /// Creates a new SketchUp model image object from an image representation
        /// object. The created image must be subsequently added to the Entities of
        /// a model, component definition or a group.
        /// </summary>
        /// <param name="image">[out] The image object created.</param>
        /// <param name="image_rep">[in] The basic image object retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if image is NULL
        ///  SU_ERROR_OVERWRITE_VALID if image already references a valid object
        /// SU_ERROR_INVALID_INPUT if image_rep is not a valid object
        /// SU_ERROR_NO_DATA if the image_rep contains no data
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUImageCreateFromImageRep(ref SUImageRef image, SUImageRepRef image_rep);

        /// <summary>
        /// Retrieves a basic image from a SketchUp model image.  The given image
        /// representation object must have been constructed using one of the
        /// SUImageRepCreate* functions. It must be released using \ref
        /// SUImageRepRelease.
        /// </summary>
        /// <param name="image">[in] The texture object.</param>
        /// <param name="image_rep">[out] The basic image object retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if image is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if image_rep is NULL
        /// SU_ERROR_INVALID_OUTPUT if image_rep does not point to a valid SUImageRepRef object
        /// SU_ERROR_NO_DATA if there was no image data
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUImageGetImageRep(SUImageRef image, ref SUImageRepRef image_rep);

        /// <summary>
        /// Retrieves the name of an image object.
        /// </summary>
        /// <param name="image">[in] The image object.</param>
        /// <param name="name">[out] The name retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if image is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if name is NULL
        /// SU_ERROR_INVALID_OUTPUT if name does not point to a valid \ref
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUImageGetName(SUImageRef image, ref SUStringRef name);

        /// <summary>
        /// Sets the name of an image object.
        /// </summary>
        /// <param name="image">[in] The image object.</param>
        /// <param name="name">[in] The name to set. Assumed to be UTF-8 encoded.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if image is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if name is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern  SU_RESULT SUImageSetName(SUImageRef image, string name);

        /// <summary>
        /// Retrieves the transform of an image object.
        /// </summary>
        /// <param name="image">[in] The image object.</param>
        /// <param name="transform">[out] The transform retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if image is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if transform is NULL
        /// SU_ERROR_INVALID_OUTPUT if transform does not point to a valid \ref
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUImageGetTransform(SUImageRef image, ref SUTransformation transform);

        /// <summary>
        /// Sets the transform of an image object.
        /// </summary>
        /// <param name="image">[in] The image object.</param>
        /// <param name="transform">[in] The transform to set. Assumed to be UTF-8 encoded.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if image is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if transform is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUImageSetTransform(SUImageRef image, ref SUTransformation transform);

        /// <summary>
        /// Retrieves the image file name of an image object.
        /// </summary>
        /// <param name="image">[in] The image object.</param>
        /// <param name="file_name">[out] The image file name retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if image is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if file_name is NULL
        /// SU_ERROR_INVALID_OUTPUT if file_name does not point to a valid \ref
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUImageGetFileName(SUImageRef image, ref SUStringRef file_name);

        /// <summary>
        /// Retrieves the world dimensions of an image object.
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
        public static extern SU_RESULT SUImageGetDimensions(SUImageRef image, ref double width, ref double height);



    }
}
