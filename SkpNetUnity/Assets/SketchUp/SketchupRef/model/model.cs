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
    /// A SketchUp model.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUModelRef
    {
        public IntPtr ptr;
    }

    public enum SUEntityType
    {
        SUEntityType_Edge = 0,
        SUEntityType_Face,
        SUEntityType_ComponentInstance,
        SUEntityType_Group,
        SUEntityType_Image,
        SUEntityType_ComponentDefinition,
        SUEntityType_Layer,
        SUEntityType_Material,
        SUNumEntityTypes
    }

    /// <summary>
    /// Contains an array of entity counts that can be indexed per entity type.
    /// </summary>
    public struct SUModelStatistics
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        int[] entity_counts;
    }

    /// <summary>
    /// Units options settings
    /// </summary>
    public enum SUModelUnits
    {
        SUModelUnits_Inches,
        SUModelUnits_Feet,
        SUModelUnits_Millimeters,
        SUModelUnits_Centimeters,
        SUModelUnits_Meters
    }

    /// <summary>
    /// SketchUp model file format version
    /// </summary>
    public enum SUModelVersion
    {
        SUModelVersion_SU3,
        SUModelVersion_SU4,
        SUModelVersion_SU5,
        SUModelVersion_SU6,
        SUModelVersion_SU7,
        SUModelVersion_SU8,
        SUModelVersion_SU2013,
        SUModelVersion_SU2014,
        SUModelVersion_SU2015,
        SUModelVersion_SU2016,
        SUModelVersion_SU2017,
        SUModelVersion_SU2018,
        SUModelVersion_SU2019
    }


    /// <summary>
    /// model
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Creates an empty model object for the purposes of writing a SketchUp
        /// document. This model object must be released with SUModelRelease.
        /// </summary>
        /// <param name="model">[out] The model object created.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if model is NULL
        /// SU_ERROR_OVERWRITE_VALID if model is already a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelCreate(ref SUModelRef model);

        /// <summary>
        /// Creates a model from a SketchUp file on local disk. This model object must be released with SUModelRelease.
        /// </summary>
        /// <param name="model">[out] The model object created.</param>
        /// <param name="file_path">[in] The source file path of the SketchUp file. Assumed to be UTF-8 encoded.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if file_path is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if model is NULL
        /// SU_ERROR_OVERWRITE_VALID if model is already a valid object
        /// SU_ERROR_SERIALIZATION if an error occurs during reading of the file
        /// SU_ERROR_MODEL_INVALID if the file specified by file_path is an invalid model. (since SketchUp 2014, API 2.0)
        /// SU_ERROR_MODEL_VERSION if the file has objects that have a newer version than is supported by the current build of slapi. (since SketchUp 2014, API 2.0)
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelCreateFromFile(ref SUModelRef model, string file_path);

        /// <summary>
        /// Creates a model from a SketchUp skp file buffer. This model object must be released with SUModelRelease.
        /// </summary>
        /// <param name="model">[out] The model object created.</param>
        /// <param name="buffer">[in] The SketchUp file buffer.</param>
        /// <param name="buffer_size">[in] The SketchUp file buffer size.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if buffer is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if model is NULL
        /// SU_ERROR_OVERWRITE_VALID if model is already a valid object
        /// SU_ERROR_SERIALIZATION if an error occurs during reading of the file
        /// SU_ERROR_MODEL_INVALID if the file specified by buffer is an invalid model. (since SketchUp 2014, API 2.0)
        /// SU_ERROR_MODEL_VERSION if the file has objects that have a newer version than is supported by the current build of slapi. (since SketchUp 2014, API 2.0)
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelCreateFromBuffer(ref SUModelRef model, byte[] buffer, size_t buffer_size);

        /// <summary>
        /// Releases a model object and its associated resources. The root component
        /// of the model object and all its child objects must not be released explicitly.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is an invalid object
        /// SU_ERROR_NULL_POINTER_INPUT if model is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelRelease(ref SUModelRef model);

        /// <summary>
        /// Retrieves model entities.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="entities">[out] The entities retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if entities is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetEntities(SUModelRef model, ref SUEntitiesRef entities);

        /// <summary>
        /// Retrieves the number of materials in a model object.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="count">[out] The number of material objects available.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetNumMaterials(SUModelRef model, ref size_t count);

        /// <summary>
        /// Retrieves all the materials associated with a model object.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="len">[in] The number of material objects to retrieve.</param>
        /// <param name="materials">[out] The material objects retrieved.</param>
        /// <param name="count">[out] The number of material objects retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if materials or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetMaterials(SUModelRef model, size_t len, SUMaterialRef[] materials, ref size_t count);

        /// <summary>
        /// Adds materials to a model object.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="len">[in] The number of material objects to add.</param>
        /// <param name="materials">[in] The array of material objects to add.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if materials is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelAddMaterials(SUModelRef model, size_t len,SUMaterialRef[] materials);

        /// <summary>
        /// Retrieves the number of components associated with a model.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="count">[out] count The number of components available.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetNumComponentDefinitions(SUModelRef model, ref size_t count);

        /// <summary>
        /// Retrieves the component definitions that define component instances but not groups.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="len">[in] The number of component definitions objects to retrieve.</param>
        /// <param name="definitions">[out] The component definitions retrieved.</param>
        /// <param name="count">[out] The number of component definitions objects retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if definitions or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetComponentDefinitions(SUModelRef model, size_t len, SUComponentDefinitionRef[] definitions, ref size_t count);

        /// <summary>
        /// Retrieves the number of component definitions that define groups.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="count">[out] count The number of components available.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetNumGroupDefinitions(SUModelRef model, ref size_t count);

        /// <summary>
        /// Retrieves the component definitions that define groups.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="len">[in] The number of component definitions objects to retrieve.</param>
        /// <param name="definitions">[out] The component definitions retrieved.</param>
        /// <param name="count">[out] The number of component definitions objects retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if definitions or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetGroupDefinitions(SUModelRef model, size_t len, SUComponentDefinitionRef[] definitions, ref size_t count);

        /// <summary>
        /// Retrieves the number of component definitions that define images.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="count">[out] count The number of components available.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetNumImageDefinitions(SUModelRef model, ref size_t count);

        /// <summary>
        /// Retrieves the component definitions that define images.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="len">[in] The number of component definitions objects to retrieve.</param>
        /// <param name="definitions">[out] The component definitions retrieved.</param>
        /// <param name="count">[out] The number of component definitions objects retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if definitions or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetImageDefinitions(SUModelRef model, size_t len, SUComponentDefinitionRef[] definitions, ref size_t count);


        /// <summary>
        /// Adds component definitions to a model object.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="len">[in] The number of component definitions to add.</param>
        /// <param name="components">[in] The array of component definitions to add.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if components is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelAddComponentDefinitions(SUModelRef model, size_t len, SUComponentDefinitionRef[] components);

        /// <summary>
        /// Remove definitions of components, images, and groups from a model object. 
        /// All component definitions, their geometry, and attached instances will be
        /// released.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="len">[in] The number of component definitions to remove.</param>
        /// <param name="components">[in] The array of component definitions to remove.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// SU_ERROR_OUT_OF_RANGE if the number of components is less than one
        /// SU_ERROR_NULL_POINTER_INPUT if components is NULL
        /// SU_ERROR_PARTIAL_SUCCESS if removing a component definition fails mid-process
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelRemoveComponentDefinitions(SUModelRef model, size_t len, SUComponentDefinitionRef[] components);

        /// <summary>
        /// Saves the model to a file.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="file_path">[in] The file path destination of the serialization operation. Assumed to be UTF-8 encoded.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if file_path is NULL
        /// SU_ERROR_SERIALIZATION if the serialization operation itself fails
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelSaveToFile(SUModelRef model,string file_path);

        /// <summary>
        /// Saves the model to a file using a specific SketchUp version format.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="file_path">[in] The file path destination of the serialization operation. Assumed to be UTF-8 encoded.</param>
        /// <param name="version">[in] The SKP file format version to use when saving.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// SU_ERROR_MODEL_VERSION if version is invalid
        /// SU_ERROR_NULL_POINTER_INPUT if file_path is NULL
        /// SU_ERROR_SERIALIZATION if the serialization operation itself fails
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelSaveToFileWithVersion(SUModelRef model, string file_path, SUModelVersion version);

        /// <summary>
        /// Retrieves the camera of a model object. The returned camera object
        /// points to model's internal camera. So it must not be released via SUCameraRelease.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="camera">[out] The camera object retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if camera is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetCamera(SUModelRef model, ref SUCameraRef camera);

        /// <summary>
        /// Sets the current camera of a model object.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="camera">[in] The camera object. This reference will become invalid when this function returns.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// SU_ERROR_INVALID_INPUT if camera is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if camera is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelSetCamera(SUModelRef model, ref SUCameraRef camera);

        /// <summary>
        /// Retrieves the number of scene cameras of a model object.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="num_scenes">[out] The number of scenes available.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if num_scenes is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetNumScenes(SUModelRef model, ref size_t num_scenes);

        /// <summary>
        /// Retrieves the number of scene layers of a model object.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="count">[out] The number of layers available.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetNumLayers(SUModelRef model, ref size_t count);

        /// <summary>
        /// Retrieves the layers in a model object.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="len">[in] The number of layers to retrieve.</param>
        /// <param name="layers">[out] The layers retrieved.</param>
        /// <param name="count">[out] The number of layers retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT of model is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if layers or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetLayers(SUModelRef model, size_t len, SULayerRef[] layers, ref size_t count);

        /// <summary>
        /// Adds layer objects to a model object.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="len">[in] The number of layers to add.</param>
        /// <param name="layers">[in] The layers to add.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT of model is not a valid object
        /// SU_ERROR_INVALID_INPUT if any item in layers is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelAddLayers(SUModelRef model, size_t len, SULayerRef[] layers);

        /// <summary>
        /// Removes all layers provided in the array. The default layer cannot be removed. 
        /// All entities on the deleted layers will be moved to the default layer.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="len">[in] The length of the array.</param>
        /// <param name="layers">[in] The layers to be deleted.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if layers is NULL
        /// SU_ERROR_OUT_OF_RANGE if len is less than one.
        /// SU_ERROR_PARTIAL_SUCCESS if removing the layers failed mid-process
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelRemoveLayers(SUModelRef model, size_t len, SULayerRef[] layers);

        /// <summary>
        /// Retrieves the default layer object of a model object.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="layer">[out] The layer object retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if layer is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetDefaultLayer(SUModelRef model, ref SULayerRef layer);

        /// <summary>
        /// Retrieves the version of a model object.  The version consists of three
        /// numbers: major version number, minor version number, and the build number.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="major">[in] The major version number retrieved.</param>
        /// <param name="minor">[out] The minor version number retrieved.</param>
        /// <param name="build">[out] The build version number retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if major, minor, or build is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetDefaultLayer(SUModelRef model, out int major, out int minor, out int build);

        /// <summary>
        /// Retrieves the version of a model object.  The version consists of three
        /// numbers: major version number, minor version number, and the build number.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="major">[out] The major version number retrieved.</param>
        /// <param name="minor">[out] The minor version number retrieved.</param>
        /// <param name="build">[out] The build version number retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT of model is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if major, minor, or build is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetVersion(SUModelRef model, ref int major, ref int minor, ref int build);

        /// <summary>
        /// Retrieves the number of attribute dictionaries of a model object.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="count">[out] The number of attribute dictionaries available.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetNumAttributeDictionaries(SUModelRef model, ref size_t count);

        /// <summary>
        /// Retrieves the attribute dictionaries of a model object.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="len">[in] The number of dictionaries to retrieve.</param>
        /// <param name="dictionaries">[out] The dictionaries retrieved.</param>
        /// <param name="count">[out] The number of dictionaries retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT of model is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if dictionaries or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetAttributeDictionaries(SUModelRef model, size_t len, SULayerRef[] dictionaries, out size_t count);

        /// <summary>
        /// Retrieves the attribute dictionary of a model object that has the given
        /// name. If a dictionary with the given name does not exist, one is added
        /// to the model object.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="name">[in] The name of the attribute dictionary to retrieve. Assumed to be UTF-8 encoded.</param>
        /// <param name="dictionary">[out] The dictionary object retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT of model is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if name is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if dictionary is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetAttributeDictionary(SUModelRef model, string name, ref SUAttributeDictionaryRef dictionary);

        /// <summary>
        /// Retrieves whether the model is georeferenced.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="is_geo_ref">[out] The flag retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if is_used is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelIsGeoReferenced(SUModelRef model, ref bool is_geo_ref);

        /// <summary>
        /// Retrieves the location information of a given model.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="location">[out] The location retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if location is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetLocation(SUModelRef model, ref SULocationRef location);

        /// <summary>
        /// Calculates the sum of all entities by type in the model.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="statistics">[out] The SUModelStatistics struct that will be populated with the number of each entity type in the model.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if statistics is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetStatistics(SUModelRef model, ref SUModelStatistics statistics);

        /// <summary>
        /// Georeferences the model.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="latitude">[in] Latitude of the model.</param>
        /// <param name="longitude">[in] Longitude of the model.</param>
        /// <param name="altitude">[in] Altitude of the model.</param>
        /// <param name="is_z_value_centered">[in] Indicates if z value should be centered.</param>
        /// <param name="is_on_ocean_floor">[in] Indicates whether the model is on the ocean floor.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object or if latitude or longitude does not lie within a valid range
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelSetGeoReference(SUModelRef model, double latitude, double longitude, double altitude,  bool is_z_value_centered, bool is_on_ocean_floor);

        /// <summary>
        /// Retrieves the rendering options of a model object.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="rendering_options">[out] The rendering options object retrieved. This object is owned by the model and must not be explicitly released.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if rendering_options is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetRenderingOptions(SUModelRef model, ref SURenderingOptionsRef rendering_options);

        /// <summary>
        /// Retrieves the shadow info of a model object.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="shadow_info">[out] The shadow info object retrieved. This object is owned by the model and must not be explicitly released.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if shadow_info is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetShadowInfo(SUModelRef model, ref SUShadowInfoRef shadow_info);

        /// <summary>
        /// Retrieves options manager associated with the model.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="options_manager">[out] The options manager object retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if options_manager is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetOptionsManager(SUModelRef model, ref SUOptionsManagerRef options_manager);

        /// <summary>
        /// Retrieves the angle which will rotate the north direction to the y-axis for a given model.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="north_correction">[out] The north correction angle retrieved (in degrees).</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if north_correction is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetNorthCorrection(SUModelRef model, ref double north_correction);

        /// <summary>
        /// Merges all adjacent, coplanar faces in the model.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelMergeCoplanarFaces(SUModelRef model);

        /// <summary>
        /// Retrieves all the scenes associated with a model object.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="len">[in] The number of scenes to retrieve.</param>
        /// <param name="scenes">[out] The scenes retrieved.</param>
        /// <param name="count">[out] The number of scenes retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT of model is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if scenes or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetScenes(SUModelRef model, size_t len, SUSceneRef[] scenes, ref size_t count);

        /// <summary>
        /// Retrieves the scenes with the given name associated with a model object.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="name">[in] The name of the scene object to retrieve. Assumed to be UTF-8 encoded.</param>
        /// <param name="scene">[out] The scene object retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT of model is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if name is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if dictionary is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetSceneWithName(SUModelRef model, string name, ref SUSceneRef scene);

        /// <summary>
        /// Adds scenes to a model object.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="len">[in] The number of scene objects to add.</param>
        /// <param name="scenes">[in] The array of scene objects to add.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if scenes is NULL
        /// SU_ERROR_INVALID_ARGUMENT if the names of the given scenes are not unique among themselves or among existing scenes
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelAddScenes(SUModelRef model, size_t len, ref SUSceneRef[] scenes);

        /// <summary>
        /// Adds scenes to a model object.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="index">[in] Where in the list to add the scene. -1 to place at the end.</param>
        /// <param name="scene">[in] The scene object to add.</param>
        /// <param name="out_index">[out] The index that the scene was added at.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model or scene are not a valid object
        /// SU_ERROR_INVALID_ARGUMENT if a scene with the same name already exists
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelAddScene(SUModelRef model, int index, SUSceneRef scene, ref int out_index);

        /// <summary>
        /// Retrieves the active scene associated with a model object.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="scene">[out] The scene object retrieved (in degrees).</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if scene is NULL
        /// SU_ERROR_OVERWRITE_VALID if scene is already a valid object
        /// SU_ERROR_NO_DATA if there is no active scene to retrieve
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetActiveScene(SUModelRef model, ref SUSceneRef scene);

        /// <summary>
        /// Sets the provided scene as the active scene.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="scene">[in] The scene object to be set as the active scene.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model or scene is not a valid object
        /// SU_ERROR_GENERIC if try to activate a scene which is not in the model
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelSetActiveScene(SUModelRef model, SUSceneRef scene);

        /// <summary>
        /// Adds a single matched photo scene to a model object.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="image_file">[in] The full path of the image associated with this scene.</param>
        /// <param name="camera">[in] The camera associated with this scene.</param>
        /// <param name="scene_name">[in] The name of the scene to add.</param>
        /// <param name="scene">[out] The scene object created.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model or camera is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if scene_name or image_file is NULL
        /// SU_ERROR_INVALID_OUTPUT if scene is NULL
        /// SU_ERROR_GENERIC if image_file is invalid or not found
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelAddMatchPhotoScene(SUModelRef model, string image_file, SUCameraRef camera, string scene_name, ref SUSceneRef scene);

        /// <summary>
        /// Retrieves the name of a model object.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="name">[out] The destination of the retrieved name object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if name is NULL
        /// SU_ERROR_INVALID_OUTPUT if name does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetName(SUModelRef model, ref SUStringRef name);

        /// <summary>
        /// Sets the name of a model object.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="name">[in] The name of the model object. Assumed to be UTF-8 encoded.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if path is NULL
        /// SU_ERROR_INVALID_OUTPUT if path does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelSetName(SUModelRef model, string name);

        /// <summary>
        /// Retrieves the path of a model object.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="path">[out] The destination of the retrieved path object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if path is NULL
        /// SU_ERROR_INVALID_OUTPUT if path does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetPath(SUModelRef model, ref SUStringRef path);

        /// <summary>
        /// Retrieves the path of a model object.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="title">[out] The destination of the retrieved title object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if title is NULL
        /// SU_ERROR_INVALID_OUTPUT if title does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetTitle(SUModelRef model, ref SUStringRef title);

        /// <summary>
        /// Retrieves the description of a model object.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="description">[out] The destination of the retrieved description object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if description is NULL
        /// SU_ERROR_INVALID_OUTPUT if description does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetDescription(SUModelRef model, ref SUStringRef description);

        /// <summary>
        /// Sets the description of a model object.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="description">[in] The description of the model object. Assumed to be UTF-8 encoded.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if description is NULL
        /// SU_ERROR_INVALID_OUTPUT if description does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelSetDescription(SUModelRef model, char[] description);

        /// <summary>
        /// Returns the units associated with the given model.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="units">[out] The units retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if units is NULL
        /// SU_ERROR_INVALID_OUTPUT if units does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetUnits(SUModelRef model, ref SUModelUnits units);

        /// <summary>
        /// Returns the classifications associated with the given model.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="classifications">[out] The classifications retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if classifications is NULL
        /// SU_ERROR_INVALID_OUTPUT if classifications does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetClassifications(SUModelRef model, ref SUClassificationsRef classifications);

        /// <summary>
        /// Returns the axes associated with the given model.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="axes">[out] The axes retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if axes is NULL
        /// SU_ERROR_INVALID_OUTPUT if axes does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetAxes(SUModelRef model, ref SUAxesRef axes);

        /// <summary>
        /// Returns the styles associated with the given model.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="styles">[out] The styles retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if styles is NULL
        /// SU_ERROR_INVALID_OUTPUT if styles does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetStyles(SUModelRef model, ref SUStylesRef styles);

        /// <summary>
        /// Retrieves the instance path (including an entity) corresponding to a given persistent id.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="pid_ref">[in] Persistent id of the entity.</param>
        /// <param name="instance_path_ref">[out] Instance path to the entity.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if instance_path_ref is NULL
        /// SU_ERROR_INVALID_OUTPUT if instance_path_ref does not point to a valid SUStringRef object
        /// SU_ERROR_PARTIAL_SUCCESS if an instance path can not be is fully traced
        /// SU_ERROR_GENERIC on general failure
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetInstancePathByPid(SUModelRef model, SUStringRef pid_ref, ref SUInstancePathRef instance_path_ref);

        /// <summary>
        /// Retrieves the number of fonts in a model object.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="count">[out] The number of font objects available.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetNumFonts(SUModelRef model, ref size_t count);

        /// <summary>
        /// Retrieves all the materials associated with a model object.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="len">[in] The number of material objects to retrieve.</param>
        /// <param name="fonts">[out] The name of the scene to add.</param>
        /// <param name="count">[out] The number of material objects retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model or camera is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if fonts or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetFonts(SUModelRef model, size_t len, SUFontRef[] fonts, ref size_t count);

        /// <summary>
        /// Retrieves the dimension style associated with a model object.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="styles">[out] The dimension styles retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if styles is NULL
        /// SU_ERROR_INVALID_OUTPUT if styles does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetDimensionStyle(SUModelRef model, ref SUDimensionStyleRef styles);

        /// <summary>
        /// Retrieves length formatter settings from the model. The given length 
        /// formatter object must have been constructed using \ref
        /// SULengthFormatterCreate. It must be released using \ref
        /// SULengthFormatterRelease.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="formatter">[out] The formatter used to retrieve the settings.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if formatter is NULL
        /// SU_ERROR_INVALID_OUTPUT if formatter does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetLengthFormatter(SUModelRef model, ref SULengthFormatterRef formatter);

        /// <summary>
        /// Retrieves a unique material name from the model that is based on the
        /// provided one. If the provided name is unique it will be returned,
        /// otherwise any trailing indices will be replaced by a new index.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="in_name">[in] The suggested name.</param>
        /// <param name="out_name">[out] The returned name.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if in_name is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if out_name is NULL
        /// SU_ERROR_INVALID_OUTPUT if out_name does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGenerateUniqueMaterialName(SUModelRef model, string in_name, ref SUStringRef out_name);

        /// <summary>
        /// Fixes any errors found in the given model.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelFixErrors(SUModelRef model);

        /// <summary>
        /// Updates the faces in the model so that they are oriented consistently.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="recurse_components">[in] Orient components of the model.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelOrientFacesConsistently(SUModelRef model,bool recurse_components);

        /// <summary>
        /// Retrieves line styles from the model.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="line_styles">[out] The line styles of the model.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if line_styles is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetLineStyles(SUModelRef model, ref SULineStylesRef line_styles);

        /// <summary>
        /// Loads a component from a file.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="filename">[in] The full path and filename to a SkethchUp model.</param>
        /// <param name="definition">[out] The component definition that is created after load.</param>
        /// <returns></returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelLoadDefinition(SUModelRef model, string filename, ref SUComponentDefinitionRef definition);

        /// <summary>
        /// Removes all materials provided in the array.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="len">[in] The length of the array.</param>
        /// <param name="materials">[in] The materials to be deleted.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if materials is NULL
        /// SU_ERROR_OUT_OF_RANGE if len is zero
        /// SU_ERROR_PARTIAL_SUCCESS if removing the materials failed mid-process
        /// SU_ERROR_NO_DATA if materials provided are invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelRemoveMaterials(SUModelRef model, size_t len, SUMaterialRef[] materials);

        /// <summary>
        /// Removes all scenes provided in the array.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="len">[in] The length of the array.</param>
        /// <param name="scenes">[in] The scenes to be deleted.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if scenes is NULL
        /// SU_ERROR_OUT_OF_RANGE if len is zero
        /// SU_ERROR_PARTIAL_SUCCESS if removing the scenes failed mid-process
        /// SU_ERROR_NO_DATA if scenes provided are invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelRemoveScenes(SUModelRef model, size_t len, SUSceneRef[] scenes);

        /// <summary>
        /// Retrieves the number of all the materials in a model including those belonging to SUImageRef and SULayerRef.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="count">[out] The number of material objects available.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetNumAllMaterials(SUModelRef model, ref size_t count);

        /// <summary>
        /// Retrieves all the materials associated with a model object including those belonging to SUImageRef and SULayerRef.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="len">[in] The number of material objects to retrieve.</param>
        /// <param name="materials">[out] The material objects retrieved.</param>
        /// <param name="count">[out] The number of material objects retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if materials or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetAllMaterials(SUModelRef model, size_t len, SUMaterialRef[] materials, ref size_t count);

        /// <summary>
        /// Retrieves the guid of a model object.
        /// </summary>
        /// <param name="model">[in] The model object.</param>
        /// <param name="guid">[out] The guid string.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if model is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if guid is NULL
        /// SU_ERROR_INVALID_OUTPUT if guid does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUModelGetGuid(SUModelRef model, ref SUStringRef guid);
    }
}
