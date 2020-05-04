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
    /// References a component definition.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUComponentDefinitionRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// Describes how the component instance is placed when it is first
    /// instantiated in the rendering scene.For example a window component
    /// instance should snap to a vertical plane when instantiated in the
    /// rendering scene.
    /// </summary>
    public enum SUSnapToBehavior
    {
        SUSnapToBehavior_None = 0,
        SUSnapToBehavior_Any,
        SUSnapToBehavior_corizontal,
        SUSnapToBehavior_Vertical,
        SUSnapToBehavior_Sloped
    };

    /// <summary>
    /// Describes how the component behaves in the SketchUp rendering scene.
    /// </summary>
    public struct SUComponentBehavior
    {
        /// <summary>
        /// how the component instance is placed when it is first instantiated in the rendering scene.
        /// </summary>
        public SUSnapToBehavior component_snap;
        /// <summary>
        /// Whether the component creates an opening when placed on a surface, e.g. a window frame component.
        /// </summary>
        public bool component_cuts_opening;
        /// <summary>
        /// Whether the component behaves like a  billboard, where the component always presents a 2D surface perpendicular  to the direction of camera.
        /// </summary>
        public bool component_always_face_camera;
        /// <summary>
        /// Whether the component always casts a  shadow as if it were facing the  direction of the sun.  </summary>
        public bool component_shadows_face_sun;
        /// <summary>
        /// Bitmask where set bits indicate which
        /// scale tool handles are hidden on a given
        /// Bit0: disable scale along X axis,
        /// Bit1: disable scale along Y axis,
        /// Bit2: disable scale along Z axis,
        /// Bit3: disable scale in X + Z plane,
        /// Bit4: disable scale in Y + Z plane,
        /// Bit5: disable scale in X + Y plane,
        /// Bit6: disable scale uniform (XYZ)
        /// Prior to SketchUp 2018, API 6.0 this
        /// variable existed but was never used.
        /// </summary>
        public long component_no_scale_mask; 
    };


    /// <summary>
    /// Indicates the type of the component.
    /// </summary>
    public enum SUComponentType
    {
        /// <summary>
        /// Regular component definition
        /// </summary>
        SUComponentType_Normal,
        /// <summary>
        /// Group definition
        /// </summary>
        SUComponentType_Group
    };

    /// <summary>
    /// component_definition
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Converts from an SUComponentDefinitionRef to an SUEntityRef.
        /// This is essentially an upcast operation.
        /// </summary>
        /// <param name="comp_def">[in] The given component definition reference.</param>
        /// <returns>
        /// The converted SUEntityRef if comp_def is a valid component
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUEntityRef SUComponentDefinitionToEntity(SUComponentDefinitionRef comp_def);

        /// <summary>
        /// Converts from an SUEntityRef to an SUComponentDefinitionRef.
        /// This is essentially a downcast operation so the given entity must be
        /// convertible to an SUComponentDefinitionRef.
        /// </summary>
        /// <param name="entity">[in] The given entity reference.</param>
        /// <returns>
        /// The converted SUComponentDefinitionRef if the downcast operation succeeds
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUComponentDefinitionRef SUComponentDefinitionFromEntity(SUEntityRef entity);

        /// <summary>
        /// Converts from an SUComponentDefinitionRef to an \ref
        /// SUDrawingElementRef. This is essentially an upcast operation.
        /// </summary>
        /// <param name="comp_def">[in]  The given component definition reference.</param>
        /// <returns>
        /// The converted SUEntityRef if comp_def is a valid component
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUDrawingElementRef SUComponentDefinitionToDrawingElement(SUComponentDefinitionRef comp_def);

        /// <summary>
        /// Converts from an SUDrawingElementRef to an \ref
        /// SUComponentDefinitionRef. This is essentially a downcast operation so the
        /// given element must be convertible to an SUComponentDefinitionRef.
        /// </summary>
        /// <param name="drawing_elem">[in] The given element reference.</param>
        /// <returns>
        /// The converted SUComponentDefinitionRef if the downcast operation succeeds
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUComponentDefinitionRef SUComponentDefinitionFromDrawingElement(SUDrawingElementRef drawing_elem);

        /// <summary>
        /// Creates a new component definition. The created definition must be released with SUComponentDefinitionRelease, or attached to either a parent component 
        /// or parent model. Add the new component definition to model using SUModelAddComponentDefinitions before making any modifications to it.
        /// </summary>
        /// <param name="comp_def">[out] The component object created.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if comp_def is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentDefinitionCreate(ref SUComponentDefinitionRef comp_def);

        /// <summary>
        /// Releases a component definition object and its associated resources. If the provided definition was contained by a model, 
        /// the definition and all instances will be removed from the model.
        /// </summary>
        /// <param name="comp_def">[in] The component definition object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if comp_def is NULL
        /// SU_ERROR_INVALID_OUTPUT if comp_def points to an invalid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentDefinitionRelease(ref SUComponentDefinitionRef comp_def);

        /// <summary>
        /// Retrieves the name of a component definition.
        /// </summary>
        /// <param name="comp_def">[in] The component definition object.</param>
        /// <param name="name">[out] The name retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if comp_def is invalid
        /// SU_ERROR_NULL_POINTER_OUTPUT if name is NULL
        /// SU_ERROR_INVALID_OUTPUT if name does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentDefinitionGetName(SUComponentDefinitionRef comp_def, ref SUStringRef name);

        /// <summary>
        /// Sets the name of a component definition.
        /// </summary>
        /// <param name="comp_def">[in] The component definition object.</param>
        /// <param name="name">[in] The name of the component definition. Assumed to be UTF-8 encoded.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if comp_def is invalid
        /// SU_ERROR_NULL_POINTER_INPUT if name is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentDefinitionSetName(SUComponentDefinitionRef comp_def, byte[] name);

        /// <summary>
        /// Retrieves the globally unique identifier (guid) string of a component definition.
        /// </summary>
        /// <param name="comp_def">[in] The component definition object.</param>
        /// <param name="guid_ref">[out] The guid retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if comp_def is invalid
        /// SU_ERROR_NULL_POINTER_OUTPUT if guid is NULL
        /// SU_ERROR_INVALID_OUTPUT if guid does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentDefinitionGetGuid(SUComponentDefinitionRef comp_def, ref SUStringRef guid_ref);

        /// <summary>
        /// Retrieves the entities of the component definition.
        /// </summary>
        /// <param name="comp_def">[in] The component definition object.</param>
        /// <param name="entities">[out] The entities retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if comp_def is invalid
        /// SU_ERROR_NULL_POINTER_OUTPUT if entities is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentDefinitionGetEntities(SUComponentDefinitionRef comp_def, ref SUEntitiesRef entities);

        /// <summary>
        /// Retrieves the description of the component definition.
        /// </summary>
        /// <param name="comp_def">[in] The component definition object.</param>
        /// <param name="desc">[out] The description retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if comp_def is invalid
        /// SU_ERROR_NULL_POINTER_OUTPUT if desc is NULL
        /// SU_ERROR_INVALID_OUTPUT if desc does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentDefinitionGetDescription(SUComponentDefinitionRef comp_def, ref SUStringRef desc);

        /// <summary>
        /// Sets the description of the component definition.
        /// </summary>
        /// <param name="comp_def">[in] The component definition object.</param>
        /// <param name="desc">[in] The description to be set. Assumed to be UTF-8 encoded.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if comp_def is invalid
        /// SU_ERROR_NULL_POINTER_INPUT if desc is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentDefinitionSetDescription(SUComponentDefinitionRef comp_def, string desc);

        /// <summary>
        /// Create an instance of a component definition.
        /// </summary>
        /// <param name="comp_def">[in] The component definition object.</param>
        /// <param name="instance">[out] The instance created.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if comp_def is invalid
        /// SU_ERROR_NULL_POINTER_OUTPUT if instance is NULL
        /// SU_ERROR_GENERIC if comp_def is not the definition of a type that can be instantiated
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentDefinitionCreateInstance(SUComponentDefinitionRef comp_def, out SUComponentInstanceRef instance);

        /// <summary>
        /// Retrieves the total number of instances of the provided definition.
        /// This method takes into account the full hierarchy of the model.
        /// Therefore, the count is influenced by adding/removing instances of other
        /// definitions which contain an instance of this definition. Users should
        /// not use this function to determine the count to be passed to \ref
        /// SUComponentDefinitionGetInstances specifying the number of instances to
        /// be retrieved.
        /// </summary>
        /// <param name="comp_def">[in] The component definition object.</param>
        /// <param name="count">[out] The number of instances of the definition.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if comp_def is invalid
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentDefinitionGetNumUsedInstances(SUComponentDefinitionRef comp_def, out long count);

        /// <summary>
        /// Retrieves the number of unique instances of the provided definition. The
        /// returned count represents the number of instances of this definition in
        /// the model's root plus the number instances of this definition contained
        /// in other definitions.
        /// </summary>
        /// <param name="comp_def">[in] The component definition object.</param>
        /// <param name="count">[out] The number of instances of the definition.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if comp_def is invalid
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentDefinitionGetNumInstances(SUComponentDefinitionRef comp_def, out long count);

        /// <summary>
        /// Retrieves the instances of the definition.
        /// </summary>
        /// <param name="comp_def">[in] The component definition object.</param>
        /// <param name="len">[in] The number of component instances to retrieve.</param>
        /// <param name="instances">[out] The component instances retrieved.</param>
        /// <param name="count">[out] The number of component instances retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if comp_def is invalid
        /// SU_ERROR_NULL_POINTER_OUTPUT if instances or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentDefinitionGetInstances(SUComponentDefinitionRef comp_def, long len, ref SUComponentInstanceRef[] instances, ref size_t count);

        /// <summary>
        /// Retrieves the behavior of a component definition.
        /// </summary>
        /// <param name="comp_def">[in] The component definition object.</param>
        /// <param name="behavior">[out] The behavior retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if comp_def is invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentDefinitionGetBehavior(SUComponentDefinitionRef comp_def, ref SUComponentBehavior behavior);

        /// <summary>
        /// Sets the component behavior of a component definition.
        /// </summary>
        /// <param name="comp_def">[in] The component definition object.</param>
        /// <param name="behavior">[in] The behavior to set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if comp_def is invalid
        /// SU_ERROR_NULL_POINTER_INPUT if behavior is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentDefinitionSetBehavior(SUComponentDefinitionRef comp_def, ref SUComponentBehavior behavior);

        /// <summary>
        /// Applies a schema type from a schema to a component definition.
        /// </summary>
        /// <param name="comp_def">[in] The component definition object.</param>
        /// <param name="schema_ref">[in] The schema that owns the schema type to apply.</param>
        /// <param name="schema_type_ref">[in] The schema type to apply.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if comp_def is invalid
        /// SU_ERROR_INVALID_INPUT if schema_ref is not a valid object
        /// SU_ERROR_INVALID_INPUT if schema_type_ref is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentDefinitionApplySchemaType(SUComponentDefinitionRef comp_def, SUSchemaRef schema_ref, SUSchemaTypeRef schema_type_ref);

        /// <summary>
        /// Retrieves a flag indicating whether the component definition was created
        /// inside the current SketchUp model or whether it was added from another
        /// SKP file.
        /// </summary>
        /// <param name="comp_def">[in] The component definition object.</param>
        /// <param name="is_internal">[out] The bool value retrieved.</param>
        /// <returns></returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentDefinitionIsInternal(SUComponentDefinitionRef comp_def, ref bool is_internal);

        /// <summary>
        /// Retrieves the path where the component definition was loaded from.
        /// </summary>
        /// <param name="comp_def">[in] The component definition object.</param>
        /// <param name="path">[out] A valid path if successful.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if comp_def is invalid
        /// SU_ERROR_NULL_POINTER_OUTPUT if path is NULL
        /// SU_ERROR_INVALID_OUTPUT if path does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentDefinitionGetPath(SUComponentDefinitionRef comp_def, ref SUStringRef path);

        /// <summary>
        /// Gets the load time of the component definition. For an internal component
        /// definition, this is the time that it was created. For an external
        /// component definition, this is the time that it was added to the model.
        /// </summary>
        /// <param name="comp_def">[in] The component definition object.</param>
        /// <param name="load_time">[out] The time value retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if comp_def is invalid
        /// SU_ERROR_NULL_POINTER_OUTPUT if load_time is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentDefinitionGetLoadTime(SUComponentDefinitionRef comp_def, ref tm load_time);

        /// <summary>
        /// Retrieves the number of openings from the component definition.
        /// </summary>
        /// <param name="comp_def">[in] The component definition object.</param>
        /// <param name="count">[out] The number of openings.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if comp_def is invalid
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentDefinitionGetNumOpenings(SUComponentDefinitionRef comp_def, ref long count);

        /// <summary>
        /// Retrieves the openings from the component definition. The openings
        /// retrieved must be released with SUOpeningRelease.
        /// </summary>
        /// <param name="comp_def">[in] The component definition object.</param>
        /// <param name="len">[in] The number of openings to retrieve.</param>
        /// <param name="openings">[out] The SUOpeningRef objects retrieved.</param>
        /// <param name="count">[out] The number of openings retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if comp_def is invalid
        /// SU_ERROR_NULL_POINTER_OUTPUT if openings or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentDefinitionGetOpenings(SUComponentDefinitionRef comp_def, size_t len, SUOpeningRef[] openings, ref long count);

        /// <summary>
        /// Retrieves the insertion point from the component definition.
        /// </summary>
        /// <param name="comp_def">[in] The component definition object.</param>
        /// <param name="point">[out] The insertion point retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if comp_def is invalid
        /// SU_ERROR_NULL_POINTER_OUTPUT if point is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentDefinitionGetInsertPoint(SUComponentDefinitionRef comp_def, ref SUPoint3D point);

        /// <summary>
        /// Retrieves the SUComponentType from the component definition.
        /// </summary>
        /// <param name="comp_def">[in] The component definition object.</param>
        /// <param name="type">[out] The SUComponentType retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if comp_def is invalid
        /// SU_ERROR_NULL_POINTER_OUTPUT if type is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentDefinitionGetType(SUComponentDefinitionRef comp_def, ref SUComponentType type);

        /// <summary>
        /// Updates the faces in the component definition so that they are oriented consistently.
        /// </summary>
        /// <param name="comp_def">[in] The component definition object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if comp_def is invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentDefinitionOrientFacesConsistently(SUComponentDefinitionRef comp_def);

        /// <summary>
        /// Sets the insertion point for the component definition.
        /// </summary>
        /// <param name="comp_def">[in] The component definition object.</param>
        /// <param name="point">[in] The SUPoint3D to use.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if comp_def is invalid
        /// SU_ERROR_NULL_POINTER_INPUT if point is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentDefinitionSetInsertPoint(SUComponentDefinitionRef comp_def, ref SUPoint3D point);

        /// <summary>
        /// Sets the axes of the component definition.
        /// </summary>
        /// <param name="comp_def">[in] The component definition object.</param>
        /// <param name="axes">[in] The SUAxesRef to use.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if comp_def or axes are invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUComponentDefinitionSetAxes(SUComponentDefinitionRef comp_def, SUAxesRef axes);
    }
}
