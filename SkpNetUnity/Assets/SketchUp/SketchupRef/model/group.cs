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
    /// References a group object.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUGroupRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// group
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Converts from an SUGroupRef to an SUEntityRef.
        /// This is essentially an upcast operation.
        /// </summary>
        /// <param name="group">[in] The given group reference.</param>
        /// <returns>
        /// The converted SUEntityRef if group is a valid group
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUEntityRef SUGroupToEntity(SUGroupRef group);

        /// <summary>
        /// Converts from an SUEntityRef to an SUGroupRef.
        /// This is essentially a downcast operation so the given entity must be
        /// convertible to an SUGroupRef.
        /// </summary>
        /// <param name="entity">[in] The given entity reference.</param>
        /// <returns>
        /// The converted SUGroupRef if the downcast operation succeeds
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUGroupRef SUGroupFromEntity(SUEntityRef entity);

        /// <summary>
        /// Converts from an SUGroupRef to an SUDrawingElementRef.
        /// This is essentially an upcast operation.
        /// </summary>
        /// <param name="group">[in] The given group reference.</param>
        /// <returns>
        /// The converted SUEntityRef if group is a valid group
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUDrawingElementRef SUGroupToDrawingElement(SUGroupRef group);

        /// <summary>
        /// Converts from an SUDrawingElementRef to an SUGroupRef.
        /// This is essentially a downcast operation so the given entity must be
        /// convertible to an SUGroupRef.
        /// </summary>
        /// <param name="drawing_elem">[in] The given entity reference.</param>
        /// <returns>
        /// The converted SUGroupRef if the downcast operation succeeds
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUGroupRef SUGroupFromDrawingElement(SUDrawingElementRef drawing_elem);

        /// <summary>
        /// Converts from an SUGroupRef to an SUComponentInstanceRef.
        /// This is essentially an upcast operation.
        /// </summary>
        /// <param name="group">[in] The given group reference.</param>
        /// <returns>
        /// The converted SUEntityRef if group is a valid group
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUComponentInstanceRef SUGroupToComponentInstance(SUGroupRef group);

        /// <summary>
        /// Converts from an SUComponentInstanceRef to an SUGroupRef.
        /// This is essentially a downcast operation so the given entity must be
        /// convertible to an SUGroupRef.
        /// </summary>
        /// <param name="component_inst">[in] The given component instance reference.</param>
        /// <returns>
        /// The converted SUGroupRef if the downcast operation succeeds
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUGroupRef SUGroupFromComponentInstance(SUComponentInstanceRef component_inst);

        /// <summary>
        /// Creates a new group object.
        /// The created group must be subsequently added to the Entities of a model,
        /// component definition or a group.
        /// </summary>
        /// <param name="group">[out] The group object created.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if group is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGroupCreate(ref SUGroupRef group);

        /// <summary>
        /// Sets the name of a group object.
        /// </summary>
        /// <param name="group">[in] The group object.</param>
        /// <param name="name">[in] The name string to set the group object. Assumed to be UTF-8 encoded.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if group is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if name is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGroupSetName(SUGroupRef group, string name);

        /// <summary>
        /// Retrieves the name of a group object.
        /// </summary>
        /// <param name="group">[in] The group object.</param>
        /// <param name="name">[out] The name retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if group is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if name is NULL
        /// SU_ERROR_INVALID_OUTPUT if name does not point to a valid \ref
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGroupGetName(SUGroupRef group, ref SUStringRef name);

        /// <summary>
        /// Sets the globally unique identifier (guid) string of a group object.
        /// </summary>
        /// <param name="group">[in] The group object.</param>
        /// <param name="guid">[in] The utf-8 formatted guid string. Assumed to be UTF-8 encoded.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if group is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if guid is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGroupSetGuid(SUGroupRef group, string guid);

        /// <summary>
        /// Retrieves the globally unique identifier (guid) string of a group object.
        /// </summary>
        /// <param name="group">[in] The group object.</param>
        /// <param name="guid">[out] The guid retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if group is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if guid is NULL
        /// SU_ERROR_INVALID_OUTPUT if guid does not point to a valid \ref
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGroupGetGuid(SUGroupRef group, ref SUStringRef guid);

        /// <summary>
        /// Sets the transform of a group object.
        /// </summary>
        /// <param name="group">[in] The group object.</param>
        /// <param name="transform">[in] The affine transform to set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if group is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if transform is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGroupSetTransform(SUGroupRef group, ref SUTransformation transform);

        /// <summary>
        /// Retrieves the transform of a group object.
        /// </summary>
        /// <param name="group">[in] The group object.</param>
        /// <param name="transform">[out] The transform retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if group is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if guid is NULL
        /// SU_ERROR_INVALID_OUTPUT if transform does not point to a valid \ref
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGroupGetTransform(SUGroupRef group, ref SUTransformation transform);

        /// <summary>
        /// Retrieves the entities of a group object.
        /// </summary>
        /// <param name="group">[in] The group object.</param>
        /// <param name="entities">[out] The entities retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if group is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if entities is NULL
        /// SU_ERROR_INVALID_OUTPUT if entities does not point to a valid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGroupGetEntities(SUGroupRef group, ref SUEntitiesRef entities);

        /// <summary>
        /// Retrieves the component definition of a group object.
        /// </summary>
        /// <param name="group">[in] The group object.</param>
        /// <param name="component">[out] The component definition retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if group is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if component is NULL
        /// SU_ERROR_INVALID_OUTPUT if component does not point to a valid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGroupGetDefinition(SUGroupRef group, ref SUComponentDefinitionRef component);
    }
}
