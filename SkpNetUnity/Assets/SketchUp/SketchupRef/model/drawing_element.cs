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
    /// A font entity reference.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUDrawingElementRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// drawing_element
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Converts from an SUDrawingElementRef to an SUEntityRef.
        /// This is essentially an upcast operation.
        /// </summary>
        /// <param name="elem">[in] The given drawing element reference.</param>
        /// <returns>
        /// The converted SUEntityRef if elem is a valid drawing element.
        /// If not, the returned reference will be invalid.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUEntityRef SUDrawingElementToEntity(SUDrawingElementRef elem);

        /// <summary>
        /// Converts from an SUEntityRef to an SUDrawingElementRef.
        /// This is essentially a downcast operation so the given entity must be
        /// convertible to a drawing element.
        /// </summary>
        /// <param name="entity">[in] The given entity reference.</param>
        /// <returns>
        /// The converted SUDrawingElementRef if the downcast operation succeeds.
        /// If not, the returned reference will be invalid.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUDrawingElementRef SUDrawingElementFromEntity(SUEntityRef entity);

        /// <summary>
        /// Returns the concrete type of the given drawing element.
        /// </summary>
        /// <param name="elem">[in] The drawing element.</param>
        /// <returns>
        /// The concrete type of the given drawing element reference.
        /// SURefType_Unknown if entity is not a valid drawing element.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SURefType SUDrawingElementGetType(SUDrawingElementRef elem);

        /// <summary>
        /// Retrieves the bounding box of a drawing element.
        /// </summary>
        /// <param name="elem">[in] The drawing element.</param>
        /// <param name="bbox">[out] The bounding box retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if elem is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if bbox is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDrawingElementGetBoundingBox(SUDrawingElementRef elem, ref SUBoundingBox3D bbox);

        /// <summary>
        /// Retrieves the material object of a drawing element.
        /// </summary>
        /// <param name="elem">[in] The drawing element.</param>
        /// <param name="material">[out] The drawing element retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if elem is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if material is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDrawingElementGetMaterial(SUDrawingElementRef elem, ref SUMaterialRef material);

        /// <summary>
        /// Sets the material of a drawing element.
        /// The material object must not be subsequently deallocated while associated with
        /// the drawing element.
        /// </summary>
        /// <param name="elem">[in] The drawing element.</param>
        /// <param name="material">[in] The material object to set. If an invalid reference isgiven, then the material of the element will be removed. </param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if elem is invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDrawingElementSetMaterial(SUDrawingElementRef elem, SUMaterialRef material);

        /// <summary>
        /// Retrieves the layer object associated with a drawing element.
        /// </summary>
        /// <param name="elem">[in] The drawing element.</param>
        /// <param name="layer">[out] The drawing element retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if elem is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if layer is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDrawingElementGetLayer(SUDrawingElementRef elem, ref SULayerRef layer);

        /// <summary>
        /// Sets the layer object to be associated with a drawing element.
        /// The layer object must not be subsequently deallocated while associated with
        /// the drawing element.
        /// </summary>
        /// <param name="elem">[in] The drawing element.</param>
        /// <param name="layer">[in] The layer object to set. If an invalid reference isgiven, then the layer of the element will be removed. </param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if elem is invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDrawingElementSetLayer(SUDrawingElementRef elem, SULayerRef layer);

        /// <summary>
        ///  Retrieves the hide flag of a drawing element.
        /// </summary>
        /// <param name="elem">[in] The drawing element.</param>
        /// <param name="hide_flag">[out] The hide flag retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if elem is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if hide_flag is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDrawingElementGetHidden(SUDrawingElementRef elem, ref bool hide_flag);

        /// <summary>
        /// Sets the hide flag of a drawing element.
        /// </summary>
        /// <param name="elem">[in] The drawing element.</param>
        /// <param name="hide_flag">[in] The hide flag to set. </param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if elem is invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDrawingElementSetHidden(SUDrawingElementRef elem, bool hide_flag);

        /// <summary>
        ///  Retrieves the casts shadows flag of a drawing element.
        /// </summary>
        /// <param name="elem">[in] The drawing element.</param>
        /// <param name="casts_shadows_flag">[out] The casts shadows flag retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if elem is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if casts_shadows_flag is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDrawingElementGetCastsShadows(SUDrawingElementRef elem, ref bool casts_shadows_flag);

        /// <summary>
        /// Sets the casts shadows flag of a drawing element.
        /// </summary>
        /// <param name="elem">[in] The drawing element.</param>
        /// <param name="casts_shadows_flag">[in] The casts shadows flag to set. </param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if elem is invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDrawingElementSetCastsShadows(SUDrawingElementRef elem, bool casts_shadows_flag);

        /// <summary>
        ///  Retrieves the receives shadows flag of a drawing element.
        /// </summary>
        /// <param name="elem">[in] The drawing element.</param>
        /// <param name="receives_shadows_flag">[out] The receives shadows flag retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if elem is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if receives_shadows_flag is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDrawingElementGetReceivesShadows(SUDrawingElementRef elem, ref bool receives_shadows_flag);

        /// <summary>
        /// Sets the receives shadows flag of a drawing element.
        /// </summary>
        /// <param name="elem">[in] The drawing element.</param>
        /// <param name="receives_shadows_flag">[in] The receives shadows flag to set. </param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if elem is invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUDrawingElementSetReceivesShadows(SUDrawingElementRef elem, bool receives_shadows_flag);
    }
}
