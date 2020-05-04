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
    /// Used to get and set a scene's camera views, using the SUCameraRef object.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUSceneRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// SUSceneFlags Flags for SUSceneGetFlags and SUSceneSetFlags 
    /// Flags for SUSceneGetFlags and SUSceneSetFlags. These are combined
    /// </summary>
    public enum SCENE_FLAG
    {
        FLAG_USE_CAMERA = 0x0001,
        FLAG_USE_RENDERING_OPTIONS = 0x0002,
        FLAG_USE_SHADOWINFO = 0x0004,
        FLAG_USE_AXES = 0x0008,
        FLAG_USE_cIDDEN = 0x0010,
        FLAG_USE_LAYER_VISIBILITY = 0x0020,
        FLAG_USE_SECTION_PLANES = 0x0040,

        FLAG_USE_ALL = 0x0fff,
        FLAG_NO_CAMERA = 0x0ffe,
    }

    /// <summary>
    /// scene
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Converts from an SUSceneRef to an SUEntityRef.
        /// This is essentially an upcast operation.
        /// </summary>
        /// <param name="scene">[in] The given scene reference.</param>
        /// <returns>
        /// The converted SUEntityRef if scene is a valid scene.
        /// If not, the returned reference will be invalid.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUEntityRef SUSceneToEntity(SUSceneRef scene);

        /// <summary>
        /// Converts from an SUEntityRef to an SUSceneRef.
        /// This is essentially a downcast operation so the given entity must be
        /// convertible to an SUSceneRef.
        /// </summary>
        /// <param name="entity">[in] The given entity reference.</param>
        /// <returns>
        /// The converted SUSceneRef if the downcast operation succeeds
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUSceneRef SUSceneFromEntity(SUEntityRef entity);

        /// <summary>
        /// Creates an empty scene object.
        /// </summary>
        /// <param name="scene">[out] The scene object created.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if scene is NULL
        /// SU_ERROR_OVERWRITE_VALID if face already refers to a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneCreate(ref SUSceneRef scene);

        /// <summary>
        /// Releases a scene object.
        /// </summary>
        /// <param name="scene">[in, out] The scene object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if scene is NULL
        /// SU_ERROR_OVERWRITE_VALID if face already refers to a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneRelease(ref SUSceneRef scene);

        /// <summary>
        /// Retrieves the "use camera" setting of a scene object.
        /// </summary>
        /// <param name="scene">[in] The scene object.</param>
        /// <param name="use_camera">[out] The setting retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if scene is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if use_camera is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneGetUseCamera(SUSceneRef scene,ref bool use_camera);

        /// <summary>
        /// Sets the "use camera" setting of a scene object.
        /// </summary>
        /// <param name="scene">[in] The scene object.</param>
        /// <param name="use_camera">[in] The current setting for whether or not the camera is used.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if scene is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneSetUseCamera(SUSceneRef scene, bool use_camera);

        /// <summary>
        /// Retrieves the camera of a scene object. The returned camera object points to scene's internal camera. So the camera must not be released
        /// via SUCameraRelease.
        /// </summary>
        /// <param name="scene">[in] The scene object.</param>
        /// <param name="camera">[out] The camera object retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if scene is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if camera is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneGetUseCamera(SUSceneRef scene, ref SUCameraRef camera);

        /// <summary>
        /// Sets a given scene's camera object.  The scene does not take ownership
        /// of the provided camera, it just copies the properties to the scene's
        /// owned camera.  If the input camera was created using \ref
        /// SUCameraCreate it must be released using SUCameraRelease.
        /// </summary>
        /// <param name="scene">[in] The scene object.</param>
        /// <param name="camera">[in] The camera object to be set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if camera is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneSetUseCamera(SUSceneRef scene, SUCameraRef camera);

        /// <summary>
        /// Retrieves the "include in animation" setting of a scene object.
        /// </summary>
        /// <param name="scene">[in] The scene object.</param>
        /// <param name="include_in_animation">[out] The current setting for whether or not to  include in animation.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if scene is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if include_in_animation is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneGetIncludeInAnimation(SUSceneRef scene, ref bool include_in_animation);

        /// <summary>
        /// Sets the "include in animation" setting of a scene object.
        /// </summary>
        /// <param name="scene">[in] The scene object.</param>
        /// <param name="include_in_animation">[in] The new setting for whether or not to include in animation.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if include_in_animation is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneSetIncludeInAnimation(SUSceneRef scene, bool include_in_animation);

        /// <summary>
        /// Retrieves the name of a scene object.
        /// </summary>
        /// <param name="scene">[in] The scene object.</param>
        /// <param name="name">[out] The name retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if scene is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if name is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneGetName(SUSceneRef scene, ref SUStringRef name);

        /// <summary>
        /// Sets the name of a scene object.
        /// </summary>
        /// <param name="scene">[in] The scene object.</param>
        /// <param name="name">[in] The name of the scene object. Assumed to be UTF-8 encoded.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if include_in_animation is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if scene_name is NULL
        /// SU_ERROR_INVALID_ARGUMENT if the name already exists in the scene's model
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneSetName(SUSceneRef scene, string name);

        /// <summary>
        /// Retrieves the rendering options for the scene object.
        /// </summary>
        /// <param name="scene">[in] The scene object.</param>
        /// <param name="options">[out] The options retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if scene is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if options is NULL
        /// SU_ERROR_NO_DATA if the scene does not use rendering options
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneGetRenderingOptions(SUSceneRef scene, ref SURenderingOptionsRef options);

        /// <summary>
        /// Retrieves the shadow info of a scene.
        /// </summary>
        /// <param name="scene">[in] The scene object.</param>
        /// <param name="shadow_info">[out] The shadow info retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if scene is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if shadow_info is NULL
        /// SU_ERROR_NO_DATA if the scene does not use shadow_info
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneGetShadowInfo(SUSceneRef scene, ref SUShadowInfoRef shadow_info);

        /// <summary>
        /// Retrieves the "use shadow info" setting of a scene object.
        /// </summary>
        /// <param name="scene">[in] The scene object.</param>
        /// <param name="use_shadow_info">[out] The current setting for whether or not shadow info is used.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if scene is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if use_shadow_info is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneGetUseShadowInfo(SUSceneRef scene, ref bool use_shadow_info);

        /// <summary>
        /// Sets the "use shadow info" setting of a scene object.
        /// </summary>
        /// <param name="scene">[in] The scene object.</param>
        /// <param name="use_shadow_info">[in] The new setting for whether or not shadow info is used.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if use_shadow_info is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneSetUseShadowInfo(SUSceneRef scene, bool use_shadow_info);

        /// <summary>
        /// Retrieves the "use rendering options" setting of a scene object.
        /// </summary>
        /// <param name="scene">[in] The scene object.</param>
        /// <param name="use_rendering_options">[out] The current setting for whether or not rendering options are used.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if scene is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if use_rendering_options is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneGetUseRenderingOptions(SUSceneRef scene, ref bool use_rendering_options);

        /// <summary>
        /// Sets the "use rendering options" setting of a scene object.
        /// </summary>
        /// <param name="scene">[in] The scene object.</param>
        /// <param name="use_rendering_options">[in] The new setting for whether or not rendering options is used.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if use_rendering_options is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneSetUseRenderingOptions(SUSceneRef scene, bool use_rendering_options);

        /// <summary>
        /// Gets whether the scene uses the hidden properties of entities.
        /// </summary>
        /// <param name="scene">[in] The scene object.</param>
        /// <param name="use_cidden">[out] The current setting for whether or not the hidden property of entities is used.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if scene is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if use_cidden is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneGetUseHidden(SUSceneRef scene, ref bool use_cidden);

        /// <summary>
        /// Sets whether the scene uses the hidden properties of entities.
        /// </summary>
        /// <param name="scene">[in] The scene object.</param>
        /// <param name="use_cidden">[in] The new setting for whether or not the hidden property of entities is used.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if use_cidden is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneSetUseHidden(SUSceneRef scene, bool use_cidden);

        /// <summary>
        /// Retrieves the "use hidden layers" setting of a scene object.
        /// </summary>
        /// <param name="scene">[in] The scene object.</param>
        /// <param name="use_cidden_layers">[out] The current setting for whether or not hidden layer are used.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if scene is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if use_cidden_layers is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneGetUseHiddenLayers(SUSceneRef scene, ref bool use_cidden_layers);

        /// <summary>
        /// Sets the "use hidden layers" setting of a scene object.
        /// </summary>
        /// <param name="scene">[in] The scene object.</param>
        /// <param name="use_cidden_layers">[in] The new setting for whether or not hidden layers are used.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if use_cidden_layers is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneSetUseHiddenLayers(SUSceneRef scene, bool use_cidden_layers);

        /// <summary>
        /// Gets whether the scene uses section planes.
        /// </summary>
        /// <param name="scene">[in] The scene object.</param>
        /// <param name="use_section_planes">[out] The current setting for whether or not section planes property are used.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if scene is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if use_section_planes is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneGetUseSectionPlanes(SUSceneRef scene, ref bool use_section_planes);

        /// <summary>
        /// Sets whether the scene uses section planes.
        /// </summary>
        /// <param name="scene">[in] The scene object.</param>
        /// <param name="use_section_planes">[in] The new setting for whether or not section planes property are used.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if use_section_planes is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneGetUseSectionPlanes(SUSceneRef scene, bool use_section_planes);

        /// <summary>
        /// Retrieves the number of layers in the scene object.
        /// </summary>
        /// <param name="scene">[in] The scene object.</param>
        /// <param name="count">[out] The number of layers.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if scene is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneGetNumLayers(SUSceneRef scene, ref size_t count);

        /// <summary>
        /// Retrieves the layers in the scene object.
        /// </summary>
        /// <param name="scene">[in] The scene object.</param>
        /// <param name="len">[in] The number of layers to retrieve.</param>
        /// <param name="layers">[out] The layers retrieved.</param>
        /// <param name="count">[out] The number of layers retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if scene is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if layers or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneGetLayers(SUSceneRef scene, size_t len, SULayerRef[] layers, ref size_t count);

        /// <summary>
        /// Adds the specified layer to the provided scene. This function does not take ownership of the specified layer.
        /// </summary>
        /// <param name="scene">[in] The scene object.</param>
        /// <param name="layer">[in] The new layer to be added to the scene.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if scene or layer is not a valid object
        /// SU_ERROR_NO_DATA if the scene is not owned by a valid model
        /// SU_ERROR_GENERIC if the scene's model does not contain the layer
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneAddLayer(SUSceneRef scene, SULayerRef layer);

        /// <summary>
        /// Removes the specified layer from the provided scene. Scenes do not own their layers so removing them doesn't release them.
        /// </summary>
        /// <param name="scene">[in] The scene object.</param>
        /// <param name="layer">[in] The new layer to be added to the scene.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if scene or layer is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneRemoveLayer(SUSceneRef scene, SULayerRef layer);

        /// <summary>
        /// Clears out the provided scene's layers vector. Scenes do not own their layers so removing them does not release them.
        /// </summary>
        /// <param name="scene">[in] The scene object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if scene or layer is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneClearLayers(SUSceneRef scene);

        /// <summary>
        /// Retrieves the axes of a scene object.
        /// </summary>
        /// <param name="scene">[in] The scene object.</param>
        /// <param name="axes">[out] The axes object retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if scene or layer is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneGetAxes(SUSceneRef scene, ref SUAxesRef axes);

        /// <summary>
        /// Retrieves the "use axes" setting of a scene object.
        /// </summary>
        /// <param name="scene">[in] The scene object.</param>
        /// <param name="use_axes">[out] The setting retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if scene is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if use_axes is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneGetUseAxes(SUSceneRef scene, ref bool use_axes);

        /// <summary>
        /// Sets the "use axes" setting of a scene object.
        /// </summary>
        /// <param name="scene">[in] The scene object.</param>
        /// <param name="use_axes">[in] The new setting for whether or not the axes is used.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if use_axes is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneSetUseAxes(SUSceneRef scene, bool use_axes);

        /// <summary>
        /// Retrieves the number of hidden entities in the scene object.
        /// </summary>
        /// <param name="scene">[in] The scene object.</param>
        /// <param name="count">[out] The number of hidden entities.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if scene is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneGetNumHiddenEntities(SUSceneRef scene, ref size_t count);

        /// <summary>
        /// Retrieves the hidden entities in the scene object.
        /// </summary>
        /// <param name="scene">[in] The scene object.</param>
        /// <param name="len">[in] The number of hidden entities to retrieve.</param>
        /// <param name="entities">[out] The hidden entities retrieved.</param>
        /// <param name="count">[out] The number of hidden entities retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if scene is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if entities or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneGetHiddenEntities(SUSceneRef scene, size_t len, SUEntityRef[] entities, ref size_t count);

        /// <summary>
        /// Retrieves the flags in the scene object.
        /// </summary>
        /// <param name="scene">[in] The scene object.</param>
        /// <param name="flags">[out] The setting retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if scene is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneGetFlags(SUSceneRef scene, ref uint32_t flags);

        /// <summary>
        /// Sets the flags for a scene object.
        /// </summary>
        /// <param name="scene">[in] The scene object.</param>
        /// <param name="flags">[in] The new setting for whether or not the axes is used.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneSetFlags(SUSceneRef scene, uint32_t flags);

        /// <summary>
        /// Retrieves the "sketch axes displayed" setting of a scene object.
        /// </summary>
        /// <param name="scene">[in] The scene object.</param>
        /// <param name="displayed">[out] The setting retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if scene is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if displayed is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneGetSketchAxesDisplayed(SUSceneRef scene, ref bool displayed);

        /// <summary>
        /// Sets the "sketch axes displayed" setting of a scene object.
        /// </summary>
        /// <param name="scene">[in] The scene object.</param>
        /// <param name="displayed">[in] The new setting for whether or not sketch axes should be displayed.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if scene is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneSetSketchAxesDisplayed(SUSceneRef scene, bool displayed);

        /// <summary>
        /// Clears the provided scene's photo match image.
        /// </summary>
        /// <param name="scene">[in] The scene object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if scene is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneClearPhotoMatchImage(SUSceneRef scene);

        /// <summary>
        /// Retrieves the scene's style.
        /// </summary>
        /// <param name="scene">[in] The scene object.</param>
        /// <param name="style">[out] The style object retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if scene is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if style is NULL
        /// SU_ERROR_NO_DATA if the scene does not have a style
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneGetSketchAxesDisplayed(SUSceneRef scene, ref SUStyleRef style);

        /// <summary>
        /// Copies the data from copy_scene to scene.
        /// </summary>
        /// <param name="scene">[in] The scene object to be altered.</param>
        /// <param name="copy_scene">[in] The scene to be copied.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if scene or copy_scene are not a valid objects
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneCopy(SUSceneRef scene, SUSceneRef copy_scene);

        /// <summary>
        /// Activates the provided scene.
        /// </summary>
        /// <param name="scene">[in] The scene object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if scene is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSceneActivate(SUSceneRef scene);
    }
}
