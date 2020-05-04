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
    /// An instance path type that provides a wrapping of a data structure of component instances.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SULayerRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// layer
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Converts from an SULayerRef to an SUEntityRef.
        /// This is essentially an upcast operation.
        /// </summary>
        /// <param name="layer">[in] The given layer reference.</param>
        /// <returns>
        /// The converted SUEntityRef if layer is a valid layer
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUEntityRef SULayerToEntity(SULayerRef layer);

        /// <summary>
        /// Converts from an SUEntityRef to an SULayerRef.
        /// This is essentially a downcast operation so the given entity must be
        /// convertible to an SULayerRef.
        /// </summary>
        /// <param name="entity">[in] The given entity reference.</param>
        /// <returns>
        /// The converted SULayerRef if the downcast operation succeeds
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SULayerRef SULayerFromEntity(SUEntityRef entity);

        /// <summary>
        /// Creates a new layer object.
        /// Layers associated with a SketchUp model must not be explicitly deallocated.
        /// Layers that are not associated with a SketchUp model must be deallocated with
        /// SULayerRelease.
        /// </summary>
        /// <param name="layer">[out] The layer object created.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if layer is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULayerCreate(ref SULayerRef layer);

        /// <summary>
        /// Deallocates a layer object.
        /// The layer object to be deallocated must not be associated with a SketchUp model.
        /// </summary>
        /// <param name="layer">[in] The layer object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if layer points to an invalid object
        /// SU_ERROR_NULL_POINTER_INPUT if layer is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULayerRelease(ref SULayerRef layer);

        /// <summary>
        /// Retrieves the name of a layer object.
        /// </summary>
        /// <param name="layer">[in] The layer object.</param>
        /// <param name="name">[out] The name retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if layer is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if name is NULL
        /// SU_ERROR_INVALID_OUTPUT if name does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULayerGetName(SULayerRef layer, ref SUStringRef name);

        /// <summary>
        /// Assigns the name of a layer object.
        /// </summary>
        /// <param name="layer">[in] The layer object.</param>
        /// <param name="name">[in] The new name of the layer object. Assumed to be UTF-8 encoded.</param>
        /// <returns>
        /// SU_ERROR_NONE if layer is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if name is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULayerSetName(SULayerRef layer, string name);

        /// <summary>
        /// Retrieves the material of a layer object.
        /// </summary>
        /// <param name="layer">[in] The layer object.</param>
        /// <param name="material">[out] The material retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if layer is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if material is NULL
        /// SU_ERROR_INVALID_OUTPUT if material does not point to a valid SUMaterialRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULayerGetMaterial(SULayerRef layer, ref SUMaterialRef material);

        /// <summary>
        /// Retrieves the boolean flag indicating whether a layer object is visible.
        /// </summary>
        /// <param name="layer">[in] The layer object.</param>
        /// <param name="visible">[out] The visibility flag retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if layer is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if material is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULayerGetMaterial(SULayerRef layer, ref bool visible);

        /// <summary>
        /// Retrieves the boolean flag indicating whether a layer object is visible.
        /// </summary>
        /// <param name="layer">[in] The layer object.</param>
        /// <param name="visible">[out] The visibility flag retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if layer is not a valid object.
        /// SU_ERROR_NULL_POINTER_OUTPUT if visibility is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULayerGetVisibility(SULayerRef layer, ref bool visible);

        /// <summary>
        /// Sets the boolean flag indicating whether a layer object is visible.
        /// </summary>
        /// <param name="layer">[in] The layer object.</param>
        /// <param name="visible">[in] The visibility flag to set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if layer is not a valid object.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULayerSetVisibility(SULayerRef layer, bool visible);

    }
}
