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
    /// Used to write out textures of various SketchUp model elements to local
    /// disk.  For face objects texture writer modifies non-affine textures on
    /// write so that the resulting texture image can be mapped with
    /// 2-dimensional texture coordinates.  The modified UV coordinates are
    /// retrieved from a mesh object created with \ref
    /// SUMeshHelperCreateWithTextureWriter.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUTextureWriterRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// texture_writer
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Creates a new texture writer object. The texture writer must be
        /// subsequently deallocated with SUTextureWriterRelease.
        /// </summary>
        /// <param name="writer">[out] The created texture writer object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if writer is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextureWriterCreate(ref SUTextureWriterRef writer);

        /// <summary>
        /// Deallocates a texture writer object.
        /// </summary>
        /// <param name="writer">[in] The created texture writer object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if writer does not reference a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if writer is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextureWriterRelease(ref SUTextureWriterRef writer);

        /// <summary>
        /// Loads an entity to a texture writer object in order to have its texture
        /// written to disk. Acceptable entity types are:
        /// SUComponentInstanceRef, SUImageRef, SUGroupRef and SULayerRef
        /// </summary>
        /// <param name="writer">[in] The texture writer object.</param>
        /// <param name="entity">[in] The entity object.</param>
        /// <param name="texture_id">[out] The id of the texture.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if writer or entity is not a valid object
        /// SU_ERROR_GENERIC if entity is not one of the acceptable types or there is no texture to write
        /// SU_ERROR_NULL_POINTER_OUTPUT if texture_id is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextureWriterLoadEntity(SUTextureWriterRef writer, SUEntityRef entity, ref long texture_id);

        /// <summary>
        /// Loads a face object to a texture writer object in order to have its
        /// front and/or back texture written to local disk.
        /// </summary>
        /// <param name="writer">[in] The texture writer object.</param>
        /// <param name="face">[in] The face object.</param>
        /// <param name="front_texture_id">[out] The texture ID of the front texture.</param>
        /// <param name="back_texture_id">[out] The texture ID of the back texture.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if writer or face is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if the face object has a front face texture to write, and front_texture_id is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if the face object has a back face texture to write, and back_texture_id is NULL
        /// SU_ERROR_GENERIC if the face object does not a texture to write
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextureWriterLoadEntity(SUTextureWriterRef writer, SUFaceRef face, ref long front_texture_id, ref long back_texture_id);

        /// <summary>
        /// Retrieves the total number of textures that are loaded into the texture writer object.
        /// </summary>
        /// <param name="writer">[in] The texture writer object.</param>
        /// <param name="count">[out] The number of textures.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if writer is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextureWriterGetNumTextures(SUTextureWriterRef writer, ref size_t count);

        /// <summary>
        /// Writes a texture to a file on disk.
        /// </summary>
        /// <param name="writer">[in] The texture writer object.</param>
        /// <param name="texture_id">[in] The id of the texture.</param>
        /// <param name="path">[in] The file location on disk to write the texture. If a file is present at the location it is overwritten. 
        /// The file extension of the file path is indicates the file format. The extension must be one of "jpg", "bmp", "tif", or "png". Assumed to be UTF-8 encoded.</param>
        /// <param name="reduce_size">[in] Indicates whether the texture image should be reduced in size through scaling.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if writer is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if path is NULL
        /// SU_ERROR_SERIALIZATION if a file could not be written to the specified location, or if an invalid file format was specified
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextureWriterWriteTexture(SUTextureWriterRef writer, long texture_id, string path, bool reduce_size);

        /// <summary>
        /// Retrieves an image from the given texture_id. The given image
        /// representation object must have been constructed using one of the
        /// SUImageRepCreate* functions. It must be released using 
        /// SUImageRepRelease.
        /// </summary>
        /// <param name="writer">[in] The texture writer object.</param>
        /// <param name="texture_id">[in] The id of the texture.</param>
        /// <param name="image">[out] The image object retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if writer is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if image is NULL
        /// SU_ERROR_INVALID_OUTPUT if image is not a valid object.
        /// SU_ERROR_NO_DATA if there is no texture in the given texture_id.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextureWriterGetImageRep(SUTextureWriterRef writer, long texture_id, ref SUImageRepRef image);

        /// <summary>
        /// Writes out all the textures loaded into a texture writer object. The file names and formats are those of the image file used to create the
        /// texture.  Preexisting files are overwritten.
        /// </summary>
        /// <param name="writer">[in] The texture writer object.</param>
        /// <param name="directory">[in] The directory on disk to write the textures. Assumed to be UTF-8 encoded.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if writer is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if directory is NULL
        /// SU_ERROR_INVALID_INPUT if directory is not a object
        /// SU_ERROR_SERIALIZATION if the textures could not be written to disk
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextureWriterWriteAllTextures(SUTextureWriterRef writer, string directory);

        /// <summary>
        /// Retrieves a flag indicating whether a texture object loaded into a
        /// texture writer object is linearly interpolated (affine) or perspective corrected.
        /// </summary>
        /// <param name="writer">[in] The texture writer object.</param>
        /// <param name="texture_id">[in] The id of the texture.</param>
        /// <param name="is_affine">[out] The affine flag retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if writer is not a valid object
        /// SU_ERROR_NO_DATA if texture_id is not a handle to a loaded texture object
        /// SU_ERROR_NULL_POINTER_OUTPUT if is_affine is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextureWriterIsTextureAffine(SUTextureWriterRef writer, long texture_id, out bool is_affine);

        /// <summary>
        /// Retrieves the file path from a texture image written using SUTextureWriterWriteAllTextures.
        /// </summary>
        /// <param name="writer">[in] The texture writer object.</param>
        /// <param name="texture_id">[in] The id of the texture.</param>
        /// <param name="file_path">[out] The file path retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if writer is not a valid object
        /// SU_ERROR_NO_DATA if texture_id is not a handle to a loaded texture object
        /// SU_ERROR_NULL_POINTER_OUTPUT if file_path is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextureWriterGetTextureFilePath(SUTextureWriterRef writer, size_t texture_id, ref SUStringRef file_path);

        /// <summary>
        /// Given an array of vertex positions, retrieves the corresponding UV coordinates of the front face texture of a face object that has been loaded into the given texture writer object.
        /// </summary>
        /// <param name="writer">[in] The texture writer object.</param>
        /// <param name="face">[in] The face object.</param>
        /// <param name="len">[in] The number of vertex positions.</param>
        /// <param name="points">[in] The vertex positions.</param>
        /// <param name="uv_coords">[out] The UV coordinates retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if writer or face is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if uv_coords is NULL
        /// SU_ERROR_NO_DATA if the face object does not have a front face texture
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextureWriterGetFrontFaceUVCoords(SUTextureWriterRef writer, SUFaceRef face, size_t len, SUPoint3D[] points, SUPoint2D[] uv_coords);

        /// <summary>
        /// Given an array of vertex positions, retrieves the corresponding UV coordinates of the back face texture of a face object that has been loaded into the given texture writer object.
        /// </summary>
        /// <param name="writer">[in] The texture writer object.</param>
        /// <param name="face">[in] The face object.</param>
        /// <param name="len">[in] The number of vertex positions.</param>
        /// <param name="points">[in] The vertex positions.</param>
        /// <param name="uv_coords">[out] The UV coordinates retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if writer or face is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if uv_coords is NULL
        /// SU_ERROR_NO_DATA if the face object does not have a back face texture
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextureWriterGetBackFaceUVCoords(SUTextureWriterRef writer, SUFaceRef face, size_t len, SUPoint3D[] points, SUPoint2D[] uv_coords);

        /// <summary>
        /// Gets the texture id of a previously loaded entity. Acceptable entity
        /// types are: SUComponentInstanceRef, SUImageRef, SUGroupRef
        /// and SULayerRef.
        /// </summary>
        /// <param name="writer">[in] The texture writer object.</param>
        /// <param name="entity">[in] The entity object.</param>
        /// <param name="texture_id">[out] The texture id retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if writer or face is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if texture_id is NULL
        /// SU_ERROR_GENERIC if the entity is not one of the acceptable types or it does not have a previously written texture_id
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextureWriterGetTextureIdForEntity(SUTextureWriterRef writer, SUEntityRef entity, ref size_t texture_id);

        /// <summary>
        /// Gets the texture id of a previously loaded face.
        /// </summary>
        /// <param name="writer">[in] The texture writer object.</param>
        /// <param name="face">[in] The face object.</param>
        /// <param name="front">[in] The side of the face we are interested in. True if we want texture for the front face, false if we want the texture for the back face.</param>
        /// <param name="texture_id">[out] The texture id retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if writer or face is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if the face object has a texture, and texture_id is NULL
        /// SU_ERROR_GENERIC if the face object does not have a previously written texture_id
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextureWriterGetTextureIdForFace(SUTextureWriterRef writer, SUFaceRef face, bool front, out long texture_id);
    }
}
