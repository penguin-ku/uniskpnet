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
    /// References an entity, which is an abstract base type for most API types.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUFaceRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// face
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Converts from an SUFaceRef to an SUEntityRef.
        /// This is essentially an upcast operation.
        /// </summary>
        /// <param name="face">[in] The given face reference.</param>
        /// <returns>
        /// The converted SUEntityRef if face is a valid face.
        /// If not, the returned reference will be invalid.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUEntityRef SUFaceToEntity(SUFaceRef face);

        /// <summary>
        /// Converts from an SUEntityRef to an SUFaceRef.
        /// This is essentially a downcast operation so the given entity must be
        /// convertible to an SUFaceRef.
        /// </summary>
        /// <param name="entity">[in] The given entity reference.</param>
        /// <returns>
        /// The converted SUFaceRef if the downcast operation succeeds
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUFaceRef SUFaceFromEntity(SUEntityRef entity);

        /// <summary>
        /// Converts from an SUFaceRef to an SUDrawingElementRef.
        /// This is essentially an upcast operation.
        /// </summary>
        /// <param name="face">[in] The given face reference.</param>
        /// <returns>
        /// The converted SUDrawingElementRef if face is a valid face.
        /// If not, the returned reference will be invalid.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUDrawingElementRef SUFaceToDrawingElement(SUFaceRef face);

        /// <summary>
        /// Converts from an SUDrawingElementRef to an SUFaceRef.
        /// This is essentially a downcast operation so the given entity must be
        /// convertible to an SUFaceRef.
        /// </summary>
        /// <param name="entity">[in] The given entity reference.</param>
        /// <returns>
        /// The converted SUFaceRef if the downcast operation succeeds
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUFaceRef SUFaceFromDrawingElement(SUDrawingElementRef entity);

        /// <summary>
        /// Creates a face without holes.
        /// </summary>
        /// <param name="face">[out] The face object created.</param>
        /// <param name="vertices3d">[in] The array of vertices that make the face.</param>
        /// <param name="outer_loop">[in] The loop input that describes the outer loop of the face. 
        /// If the function is successful, the new face will take ownership of the loop and this reference will be
        /// invalidated.
        /// </param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if vertices3d or outer_loop is NULL
        /// SU_ERROR_INVALID_INPUT if outer_loop contains invalid input data
        /// SU_ERROR_GENERIC if the the points specified by outer_loop do not lie on a plane within 1.0e-3 tolerance
        /// SU_ERROR_NULL_POINTER_OUTPUT if face is NULL
        /// SU_ERROR_OVERWRITE_VALID if face already refers to a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUFaceCreate(ref SUFaceRef face, ref SUPoint3D[] vertices3d, ref SULoopInputRef outer_loop);

        /// <summary>
        /// Creates a simple face without holes from an array of vertices.
        /// </summary>
        /// <param name="face">[out] The face object created.</param>
        /// <param name="vertices3d">[in] The array of vertices of the face.</param>
        /// <param name="len">[in] The length of the array of vertices.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if vertices3d is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if face is NULL
        /// SU_ERROR_GENERIC if the specified vertices do not lie on a plane within 1.0e-3 tolerance
        /// SU_ERROR_OVERWRITE_VALID if face already refers to a valid face object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUFaceCreateSimple(ref SUFaceRef face, ref SUPoint3D[] vertices3d, size_t len);

        /// <summary>
        /// Retrieves the normal vector of a face object.
        /// </summary>
        /// <param name="face">[in] The face object.</param>
        /// <param name="normal">[out] The 3d normal vector retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if face is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if normal is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUFaceGetNormal(SUFaceRef face, ref SUVector3D normal);

        /// <summary>
        /// Releases a face object and its associated resources.
        /// </summary>
        /// <param name="face">[in] The face object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if face points to an NULL
        /// SU_ERROR_INVALID_INPUT if the face object is not a valid object.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUFaceRelease(ref SUFaceRef face);

        /// <summary>
        /// Retrieves the number of edges in a face.
        /// </summary>
        /// <param name="face">[in] The face object.</param>
        /// <param name="count">[out] The number of edges.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if the face is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUFaceGetNumEdges(SUFaceRef face, ref size_t count);

        /// <summary>
        /// Retrieves the edges in the face.
        /// </summary>
        /// <param name="face">[in] The face object.</param>
        /// <param name="len">[in] The number of edges to retrieve.</param>
        /// <param name="edges">[out] The edges retrieved.</param>
        /// <param name="count">[out] The number of edges retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if face is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if edges or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUFaceGetEdges(SUFaceRef face, size_t len, SUEdgeRef[] edges, ref size_t count);

        /// <summary>
        /// Retrieves the number of edge uses in a face.
        /// </summary>
        /// <param name="face">[in] The face object.</param>
        /// <param name="count">[out] The number of edge uses.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if the face is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUFaceGetNumEdgeUses(SUFaceRef face, ref size_t count);

        /// <summary>
        /// Retrieves the edge uses in the face.
        /// </summary>
        /// <param name="face">[in] The face object.</param>
        /// <param name="len">[in] The number of edge uses to retrieve.</param>
        /// <param name="edges">[out] The edge uses retrieved.</param>
        /// <param name="count">[out] The number of edge uses retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if face is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if edges or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUFaceGetEdgeUses(SUFaceRef face, size_t len, SUEdgeUseRef[] edges, ref size_t count);

        /// <summary>
        /// Retrieves the plane of the face.
        /// </summary>
        /// <param name="face">[in] The face object.</param>
        /// <param name="plane">[out] The 3d plane retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if face is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if plane is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUFaceGetPlane(SUFaceRef face, ref SUPlane3D plane);

        /// <summary>
        /// Retrieves the number of vertices in a face.
        /// </summary>
        /// <param name="face">[in] The face object.</param>
        /// <param name="count">[out] The number of vertices.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if the face is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUFaceGetNumVertices(SUFaceRef face, ref size_t count);

        /// <summary>
        /// Retrieves the vertex objects associated with a face object
        /// </summary>
        /// <param name="face">[in] The face object.</param>
        /// <param name="len">[in] The number of vertices to retrieve.</param>
        /// <param name="vertices">[out] The vertices retrieved.</param>
        /// <param name="count">[out] The number of vertices retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if face is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if vertices or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUFaceGetVertices(SUFaceRef face, size_t len, SUVertexRef[] vertices, ref size_t count);

        /// <summary>
        /// Retrieves the outer loop of a face object.
        /// </summary>
        /// <param name="face">[in] The face object.</param>
        /// <param name="loop">[out] The loop object retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if face is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if loop is NULL
        /// SU_ERROR_OVERWRITE_VALID if loop already refers to a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUFaceGetOuterLoop(SUFaceRef face, ref SULoopRef loop);

        /// <summary>
        /// Retrieves the number of loops in a face.
        /// </summary>
        /// <param name="face">[in] The face object.</param>
        /// <param name="count">[out] The number of inner loops.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if the face is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUFaceGetNumInnerLoops(SUFaceRef face, ref size_t count);

        /// <summary>
        /// Retrieves the loops in the face.
        /// </summary>
        /// <param name="face">[in] The face object.</param>
        /// <param name="len">[in] The number of loops to retrieve.</param>
        /// <param name="loops">[out] The inner loops retrieved.</param>
        /// <param name="count">[out] The number of inner loops retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if face object is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if loops or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUFaceGetInnerLoops(SUFaceRef face, size_t len, SULoopRef[] loops, ref size_t count);

        /// <summary>
        /// Adds a hole to the face. The face object must be associated with a parent component.
        /// </summary>
        /// <param name="face">[in] The face object.</param>
        /// <param name="vertices3d">[in] The array of vertices references by the added loop.</param>
        /// <param name="loop">[in] The loop input that describes the inner loop. If the function is successful, 
        /// the new face will take ownership of the loop and this reference will be invalidated.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if vertices3d or loop is NULL
        /// SU_ERROR_INVALID_INPUT if loop contains invalid input data
        /// SU_ERROR_GENERIC if the face object is not associated with a parent component.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUFaceAddInnerLoop(SUFaceRef face, SUPoint3D[] vertices3d, ref SULoopInputRef loop);

        /// <summary>
        /// Retrieves the number of openings in a face.
        /// </summary>
        /// <param name="face">[in] The face object.</param>
        /// <param name="count">[out] The number of openings.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if the face is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUFaceGetNumOpenings(SUFaceRef face, out size_t count);

        /// <summary>
        /// Retrieves the openings in the face. The retrieved SUOpeningRef objects
        /// must be manually released by calling SUOpeningRelease on each one.
        /// </summary>
        /// <param name="face">[in] The face object.</param>
        /// <param name="len">[in] The number of openings to retrieve.</param>
        /// <param name="openings">[out] The openings retrieved.</param>
        /// <param name="count">[out] The number of openings retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if face is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if openings or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUFaceGetOpenings(SUFaceRef face, size_t len, SUOpeningRef[] openings, out size_t count);

        /// <summary>
        /// Retrieves the front material associated with a face object.
        /// </summary>
        /// <param name="face">[in] The face object.</param>
        /// <param name="material">[out] The material object retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if face is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if material is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUFaceGetFrontMaterial(SUFaceRef face, ref SUMaterialRef material);

        /// <summary>
        /// Sets the front material of a face object.
        /// </summary>
        /// <param name="face">[in] The face object.</param>
        /// <param name="material">[in] The material object to set. If invalid, this will set the material to the default material.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if face is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUFaceSetFrontMaterial(SUFaceRef face, SUMaterialRef material);

        /// <summary>
        /// Retrieves the back material associated with a face object.
        /// </summary>
        /// <param name="face">[in] The face object.</param>
        /// <param name="material">[out] The material object retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if face is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if material is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUFaceGetBackMaterial(SUFaceRef face, ref SUMaterialRef material);

        /// <summary>
        /// Sets the back material of a face object.
        /// </summary>
        /// <param name="face">[in] The face object.</param>
        /// <param name="material">[in] The material object to set. If invalid, this will set the material to the default material.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if face is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUFaceSetBackMaterial(SUFaceRef face, SUMaterialRef material);

        /// <summary>
        /// Retrieves the flag indicating whether a face object has an affine texture applied to its front.
        /// </summary>
        /// <param name="face">[in] The face object.</param>
        /// <param name="is_affine">[out] The flag retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if face is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if is_affine is NULL
        /// SU_ERROR_NO_DATA if face does not have a textured material applied to its front
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUFaceIsFrontMaterialAffine(SUFaceRef face, ref bool is_affine);

        /// <summary>
        /// Retrieves the flag indicating whether a face object has an affine texture applied to its back.
        /// </summary>
        /// <param name="face">[in] The face object.</param>
        /// <param name="is_affine">[out] The flag retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if face is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if is_affine is NULL
        /// SU_ERROR_NO_DATA if face does not have a textured material applied to its front
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUFaceIsBackMaterialAffine(SUFaceRef face, ref bool is_affine);

        /// <summary>
        /// Computes the area of the face, taking into account all the inner loops  and cuts from openings.
        /// </summary>
        /// <param name="face">[in] The face object.</param>
        /// <param name="area">[out] The area retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if face is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if area is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUFaceGetArea(SUFaceRef face, ref double area);

        /// <summary>
        /// Computes the area of the face with the provided transformation applied.
        /// </summary>
        /// <param name="face">The face object.</param>
        /// <param name="transform">[in] A transformation to be appllied to the face.</param>
        /// <param name="area">[out] The area retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if face is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if transformation is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if area is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUFaceGetAreaWithTransform(SUFaceRef face, ref SUTransformation transform, ref double area);

        /// <summary>
        /// Retrieves a flag indicating whether the face is complex, i.e. contains either inner loops or openings cut by attached component instances or attached groups.
        /// </summary>
        /// <param name="face">[in] The face object.</param>
        /// <param name="is_complex">[out] The flag retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if face is not a valid face object
        /// SU_ERROR_NULL_POINTER_OUTPUT if is_complex is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUFaceIsComplex(SUFaceRef face, ref bool is_complex);

        /// <summary>
        /// Creates a UV helper for the face.
        /// </summary>
        /// <param name="face">[in] The face object.</param>
        /// <param name="front">[in] Flag indicating whether to compute the UV coordinates for the front of the face.</param>
        /// <param name="back">[in] Flag indicating whether to compute the UV coordinates for the back of the face.</param>
        /// <param name="texture_writer">[in] An optional texture writer to aid in texture coordinate calculations for non-affine textures.</param>
        /// <param name="uv_helper">[out]  The UV helper object created. Must be deallocated via SUUVHelperRelease.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if face is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if uv_celper is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUFaceGetUVHelper(SUFaceRef face, bool front, bool back, SUTextureWriterRef texture_writer, ref SUUVHelperRef uv_helper);

        /// <summary>
        /// Creates a UV helper for the face given a specific texture handle.
        /// </summary>
        /// <param name="face">[in] The face object.</param>
        /// <param name="front">[in] Flag indicating whether to compute the UV coordinates for the front of the face.</param>
        /// <param name="back">[in] Flag indicating whether to compute the UV coordinates for the back of the face.</param>
        /// <param name="texture_writer">[in] An optional texture writer to aid in texture coordinate calculations for non-affine textures.</param>
        /// <param name="textureHandle">[in] The handle of the image that should be mapped to the face.</param>
        /// <param name="uv_helper">[out] The UV helper object created. Must be deallocated via SUUVHelperRelease.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if face is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if uv_celper is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUFaceGetUVHelperWithTextureHandle(SUFaceRef face,bool front,bool back,SUTextureWriterRef texture_writer,long textureHandle, ref SUUVHelperRef uv_helper);

        /// <summary>
        /// Retrieves the number of attached drawing elements in a face.
        /// </summary>
        /// <param name="face">[in] The face object.</param>
        /// <param name="count">[out] The number of attached drawing elements.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if the face is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUFaceGetNumAttachedDrawingElements(SUFaceRef face, out size_t count);

        /// <summary>
        /// Retrieves the attached drawing elements in the face.
        /// </summary>
        /// <param name="face">[in] The face object.</param>
        /// <param name="len">[in] The number of attached drawing elements to retrieve.</param>
        /// <param name="elems">[out] The attached drawing elements retrieved.</param>
        /// <param name="count">[out] The number of attached drawing elements retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if face is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if elems or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUFaceGetAttachedDrawingElements(SUFaceRef face,size_t len,SUDrawingElementRef[] elems, ref size_t count);

        /// <summary>
        /// Reverses a face object.
        /// </summary>
        /// <param name="face">[in] The face object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if face is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUFaceReverse(SUFaceRef face);


    }
}
