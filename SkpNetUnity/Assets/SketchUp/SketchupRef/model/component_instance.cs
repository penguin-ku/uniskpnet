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
    /// References a component instance, i.e. an instance of a component definition.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUComponentInstanceRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// component_instance
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Converts from an SUComponentInstanceRef to an SUEntityRef.
        /// This is essentially an upcast operation.
        /// </summary>
        /// <param name="instance">[in] The given component instance reference.</param>
        /// <returns>
        /// The converted SUEntityRef if instance is a valid component instance. If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUEntityRef SUComponentInstanceToEntity(SUComponentInstanceRef instance);

        /// <summary>
        /// Converts from an SUEntityRef to an SUComponentInstanceRef.
        /// This is essentially a downcast operation so the given entity must be
        /// convertible to a component instance.
        /// </summary>
        /// <param name="entity">[in] The given entity reference.</param>
        /// <returns>
        /// The converted SUComponentInstanceRef if the downcast operation succeeds.
        /// If not, the returned reference will be invalid.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUComponentInstanceRef SUComponentInstanceFromEntity(SUEntityRef entity);

        /// <summary>
        /// Converts from an SUComponentInstanceRef to an SUDrawingElementRef. This is essentially an upcast operation.
        /// </summary>
        /// <param name="instance">[in] The given component instance reference.</param>
        /// <returns>
        /// The converted SUEntityRef if instance is a valid component instance.
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUDrawingElementRef SUComponentInstanceToDrawingElement(SUComponentInstanceRef instance);

        /// <summary>
        /// Converts from an SUDrawingElementRef to an \ref
        /// SUComponentInstanceRef. This is essentially a downcast operation so the
        /// given element must be convertible to a component instance.
        /// </summary>
        /// <param name="drawing_elem">[in] The given drawing element reference.</param>
        /// <returns>
        /// The converted SUComponentInstanceRef if the downcast operation succeeds.
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUComponentInstanceRef SUComponentInstanceFromDrawingElement(SUDrawingElementRef drawing_elem);

        /// <summary>
        /// Sets the name of a component instance object.
        /// </summary>
        /// <param name="instance">[in] The component instance object.</param>
        /// <param name="name">[in] The name string to set the component instance object. Assumed to be UTF-8 encoded.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if instance is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if name is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentInstanceSetName(SUComponentInstanceRef instance, string name);

        /// <summary>
        /// Deallocates a component instance object created with SUComponentDefinitionCreateInstance.
        /// </summary>
        /// <param name="instance">[in] The component instance object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if instance is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentInstanceRelease(ref SUComponentInstanceRef instance);


        /// <summary>
        /// Retrieves the name of a component instance object.
        /// </summary>
        /// <param name="instance">[in] The component instance object.</param>
        /// <param name="name">[out] The name retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if instance is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if name is NULL
        /// SU_ERROR_INVALID_OUTPUT if name does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentInstanceGetName(SUComponentInstanceRef instance, ref SUStringRef name);

        /// <summary>
        /// Sets the globally unique identifier (guid) string of a instance object.
        /// </summary>
        /// <param name="instance">[in] The component instance object.</param>
        /// <param name="guid">[out] The utf-8 formatted guid string.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if instance is not a valid object
        /// SU_ERROR_INVALID_INPUT if guid is NULL or invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentInstanceSetGuid(SUComponentInstanceRef instance, string guid);

        /// <summary>
        /// Retrieves the globally unique identifier (guid) string of a instance object.
        /// </summary>
        /// <param name="instance">[in] The component instance object.</param>
        /// <param name="guid">[out] The guid retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if instance is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if guid is NULL
        /// SU_ERROR_INVALID_OUTPUT if guid does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentInstanceGetGuid(SUComponentInstanceRef instance, ref SUStringRef guid);

        /// <summary>
        /// Sets the transform of a component instance object.
        /// The transform is relative to the parent component. If the parent component is
        /// the root component of a model, then the transform is relative to absolute
        /// coordinates.
        /// </summary>
        /// <param name="instance">[in] The component instance object.</param>
        /// <param name="transform">[in] The affine transform to set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if instance is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if transform is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentInstanceSetTransform(SUComponentInstanceRef instance, ref SUTransformation transform);

        /// <summary>
        /// Retrieves the transform of a component instance object.
        /// </summary>
        /// <param name="instance">[in] The component instance object.</param>
        /// <param name="transform">[out] The transform retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if instance is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if transform is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentInstanceGetTransform(SUComponentInstanceRef instance, ref SUTransformation transform);

        /// <summary>
        /// Retrieves the component definition of a component instance object.
        /// </summary>
        /// <param name="instance">[in] The component instance object.</param>
        /// <param name="component">[out] The component definition retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if instance is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if component is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentInstanceGetDefinition(SUComponentInstanceRef instance, ref SUComponentDefinitionRef component);

        /// <summary>
        /// Locks the instance if is_locked is true, otherwise unlocks the instance.
        /// </summary>
        /// <param name="instance">[in] The instance object.</param>
        /// <param name="is_lock">[in] if true lock the instance, otherwise unlock it.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if instance is invalid
        /// SU_ERROR_NULL_POINTER_OUTPUT if is_locked is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentInstanceSetLocked(SUComponentInstanceRef instance, bool is_lock);

        /// <summary>
        /// Retrieves a boolean indicating whether tne instance is locked.
        /// </summary>
        /// <param name="instance">[in] The instance object.</param>
        /// <param name="is_locked">[out] returns true if the instance is locked</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if instance is invalid
        /// SU_ERROR_NULL_POINTER_OUTPUT if is_locked is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentInstanceIsLocked(SUComponentInstanceRef instance, ref bool is_locked);

        /// <summary>
        /// Saves the component instance data to a file.
        /// </summary>
        /// <param name="instance">[in] The component instance object.</param>
        /// <param name="file_path">[in] The file path destination of the serialization operation. Assumed to be UTF-8 encoded.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if instance is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if file_path is NULL
        /// SU_ERROR_SERIALIZATION if the serialization operation itself fails
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentInstanceSaveAs(SUComponentInstanceRef instance, string file_path);

        /// <summary>
        /// Computes the volume of the component instance.
        /// </summary>
        /// <param name="instance">[in] The component instance object.</param>
        /// <param name="transform">[in]
        /// A transformation to be applied to the component instance.
        /// If set to NULL, the volume will be computed based on the
        /// instance's transformation. Note that in this case if the
        /// instance is contained within another instance or group,
        /// the parent transformation is not factored in.
        /// </param>
        /// <param name="volume">[in] The volume of the component instance in cubic inches.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if component instance is not a valid object
        /// SU_ERROR_NO_DATA if component instance is not manifold.
        /// SU_ERROR_NULL_POINTER_OUTPUT if volume is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentInstanceComputeVolume(SUComponentInstanceRef instance, ref SUTransformation transform, out double volume);

        /// <summary>
        /// Creates a SUDynamicComponentInfoRef object.
        /// </summary>
        /// <param name="instance">[in] The component instance object.</param>
        /// <param name="dc_info">[out] The dynamic component info object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if instance is not a valid object
        /// SU_ERROR_NO_DATA if instance is not a dynamic component
        /// SU_ERROR_NULL_POINTER_OUTPUT if dc_info is NULL
        /// SU_ERROR_OVERWRITE_VALID if dc_info is a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentInstanceCreateDCInfo(SUComponentInstanceRef instance, ref SUDynamicComponentInfoRef dc_info);

        /// <summary>
        /// Creates a SUClassificationInfoRef object.
        /// </summary>
        /// <param name="instance">[in] The component instance object.</param>
        /// <param name="classification_info">[out] The classification info object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if instance is not a valid object
        /// SU_ERROR_NO_DATA if instance is not a classified object
        /// SU_ERROR_NULL_POINTER_OUTPUT if classification_info is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentInstanceCreateClassificationInfo(SUComponentInstanceRef instance, ref SUClassificationInfoRef classification_info);

        /// <summary>
        /// Retrieves the number of attached component instances.
        /// </summary>
        /// <param name="instance">[in] The component instance object.</param>
        /// <param name="count">[out] The number of attached instances.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if instance is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentInstanceGetNumAttachedInstances(SUComponentInstanceRef instance, ref size_t count);

        /// <summary>
        /// Retrieves the attached component instances.
        /// </summary>
        /// <param name="instance">[in] The component instance object.</param>
        /// <param name="len">[in] The number of instances to retrieve.</param>
        /// <param name="instances">[out] The attached instances retrieved. These may be instances or groups.</param>
        /// <param name="count">[out] The number of instances retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if instance is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if instances or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentInstanceGetAttachedInstances(SUComponentInstanceRef instance, long len, ref SUComponentInstanceRef[] instances, ref size_t count);

        /// <summary>
        /// Retrieves the number of drawing element this instance is attached to.
        /// </summary>
        /// <param name="instance">[in] The component instance object.</param>
        /// <param name="count">[out] The number of drawing elements this component instance is attached to.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if instance is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentInstanceGetNumAttachedToDrawingElements(SUComponentInstanceRef instance, ref size_t count);

        /// <summary>
        /// Retrieves the drawing elements this instance is attached to.
        /// </summary>
        /// <param name="instance">[in] The component instance object.</param>
        /// <param name="len">[in] The number of instances to retrieve.</param>
        /// <param name="elements">[out] The drawing elements retrieved. These may be instances, groups or faces.</param>
        /// <param name="count">[out] The number of drawing elements retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if instance is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if instances or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentInstanceGetAttachedToDrawingElements(SUComponentInstanceRef instance, long len, ref SUDrawingElementRef[] elements, ref size_t count);
    }
}
