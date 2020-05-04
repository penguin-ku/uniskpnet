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
    public struct SUInstancePathRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// instancepath
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Creates an instance path object.
        /// </summary>
        /// <param name="instance_path">[out] The instance path object created.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if instance_path is NULL
        /// SU_ERROR_OVERWRITE_VALID if *instance_path refers to a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUInstancePathCreate(ref SUInstancePathRef instance_path);

        /// <summary>
        /// Creates a copy of an instance path object.
        /// </summary>
        /// <param name="instance_path">[out] The copy of instance path object.</param>
        /// <param name="source_path">[in] The instance path to be copied.</param>
        /// <returns></returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUInstancePathCreateCopy(ref SUInstancePathRef instance_path, SUInstancePathRef source_path);

        /// <summary>
        /// Releases an instance path object.
        /// </summary>
        /// <param name="instance_path">[in] The instance path being released.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if instance_path is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUInstancePathRelease(ref SUInstancePathRef instance_path);

        /// <summary>
        /// Pushes a SUComponentInstanceRef to an SUInstancePathRef.
        /// </summary>
        /// <param name="instance_path">[in] The instance path object.</param>
        /// <param name="component_instance">[in] The component instance object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if instance_path or component_instance is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUInstancePathPushInstance(SUInstancePathRef instance_path, SUComponentInstanceRef component_instance);

        /// <summary>
        /// Pops the last SUComponentInstanceRef from an SUInstancePathRef.
        /// </summary>
        /// <param name="instance_path">[in] The instance path object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if instance_path is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUInstancePathPopInstance(SUInstancePathRef instance_path);

        /// <summary>
        /// Sets a SUEntityRef to an SUInstancePathRef.
        /// </summary>
        /// <param name="instance_path">[in] The instance path object.</param>
        /// <param name="entity">[in] The the entity to be set as a leaf in instance path.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if instance_path is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUInstancePathSetLeaf(SUInstancePathRef instance_path, SUEntityRef entity);

        /// <summary>
        /// Gets a path depth for SUInstancePathRef.
        /// It only counts the component instances in the path, so the leaf node is
        /// not counted.
        /// </summary>
        /// <param name="instance_path">[in] The instance path object.</param>
        /// <param name="depth">[out] The depth of instance path object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if instance_path is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if depth is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUInstancePathGetPathDepth(SUInstancePathRef instance_path, ref size_t depth);

        /// <summary>
        /// Gets the full path depth (including the leaf) for SUInstancePathRef.
        /// </summary>
        /// <param name="instance_path">[in] The instance path object.</param>
        /// <param name="full_depth">[out] The depth of instance path object including the leaf (if it exists).</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if instance_path is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if full_depth is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUInstancePathGetFullDepth(SUInstancePathRef instance_path, ref size_t full_depth);

        /// <summary>
        /// Gets the transform for SUInstancePathRef.
        /// </summary>
        /// <param name="instance_path">[in] The instance path object.</param>
        /// <param name="transform">[out] The transform from instance path.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if instance_path is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if transform is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUInstancePathGetTransform(SUInstancePathRef instance_path, ref SUTransformation transform);

        /// <summary>
        /// Gets the transform up to depth level for SUInstancePathRef.
        /// </summary>
        /// <param name="instance_path">[in] The instance path object.</param>
        /// <param name="depth">[in] The depth for getting transforms up to.</param>
        /// <param name="transform">[out] The transform from instance path.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if instance_path is not a valid object
        /// SU_ERROR_OUT_OF_RANGE if depth exceeds the depth of instance_path
        /// SU_ERROR_NULL_POINTER_OUTPUT if transform is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUInstancePathGetTransformAtDepth(SUInstancePathRef instance_path, size_t depth, ref SUTransformation transform);

        /// <summary>
        /// Gets the component instance up to depth level for SUInstancePathRef.
        /// </summary>
        /// <param name="instance_path">[in] The instance path object.</param>
        /// <param name="depth">[in] The depth for getting transforms up to.</param>
        /// <param name="instance">[out] The component instance from instance path.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if instance_path is not a valid object
        /// SU_ERROR_OUT_OF_RANGE if depth exceeds the depth of instance_path
        /// SU_ERROR_NULL_POINTER_OUTPUT if component instance is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUInstancePathGetInstanceAtDepth(SUInstancePathRef instance_path, size_t depth, ref SUComponentInstanceRef instance);

        /// <summary>
        /// Gets a leaf from an instance path as an entity object.
        /// </summary>
        /// <param name="instance_path">[in] The instance path object.</param>
        /// <param name="entity">[out] The leaf from an instance path.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if instance_path is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if entity is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUInstancePathGetLeafAsEntity(SUInstancePathRef instance_path, ref SUEntityRef entity);

        /// <summary>
        /// Gets a leaf from an instance path as an entity object.
        /// </summary>
        /// <param name="instance_path">[in] The instance path object.</param>
        /// <param name="drawing_element">[out] The leaf from an instance path.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if instance_path is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if drawing_element is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUInstancePathGetLeaf(SUInstancePathRef instance_path, ref SUDrawingElementRef drawing_element);

        /// <summary>
        /// Validates an instance path.
        /// </summary>
        /// <param name="instance_path">[in] The instance path object.</param>
        /// <param name="valid">[out] Whether the instance path is valid or not.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if instance_path is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if valid is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUInstancePathIsValid(SUInstancePathRef instance_path, ref bool valid);

        /// <summary>
        /// Checks if an instance path is empty.
        /// </summary>
        /// <param name="instance_path">[in] The instance path object.</param>
        /// <param name="empty">[out] Whether the instance path is empty or not.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if instance_path is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if empty is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUInstancePathIsEmpty(SUInstancePathRef instance_path, ref bool empty);

        /// <summary>
        /// Checks if instance path contains a particular entity.
        /// </summary>
        /// <param name="instance_path">[in] The instance path object.</param>
        /// <param name="entity">[in] The entity object.</param>
        /// <param name="contains">[out] Whether the instance path contains the entity or not.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if instance_path_ref or entity_ref is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if contains is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUInstancePathIsEmpty(SUInstancePathRef instance_path, SUEntityRef entity, ref bool contains);

        /// <summary>
        /// Retrieves the full persistent id for a given instance path.
        /// </summary>
        /// <param name="instance_path">[in] The instance path object.</param>
        /// <param name="pid">[out] The persistent id.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_UNSUPPORTED if persistent id functionality is unsupported
        /// SU_ERROR_INVALID_INPUT if instance_path is not a valid object
        /// SU_ERROR_INVALID_OUTPUT if pid is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if pid is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUInstancePathIsEmpty(SUInstancePathRef instance_path, ref SUStringRef pid);

        /// <summary>
        /// Retrieves the persistent id of an entity up to depth level in a given instance path.
        /// </summary>
        /// <param name="instance_path">[in] The instance path object.</param>
        /// <param name="depth">[in] The depth for getting persistent id up to.</param>
        /// <param name="pid">[out] The persistent id.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_UNSUPPORTED if persistent id functionality is unsupported
        /// SU_ERROR_INVALID_INPUT if instance_path is not a valid object
        /// SU_ERROR_OUT_OF_RANGE if depth exceeds the depth of instance_path
        /// SU_ERROR_INVALID_OUTPUT if pid is not a valid objectsss
        /// SU_ERROR_NULL_POINTER_OUTPUT if pid is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUInstancePathGetPersistentIDAtDepth(SUInstancePathRef instance_path, size_t depth, ref SUStringRef pid);


    }
}
