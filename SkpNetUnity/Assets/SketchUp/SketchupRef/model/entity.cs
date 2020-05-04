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
    public struct SUEntityRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// entity
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Returns the concrete type of the given entity.
        /// </summary>
        /// <param name="entity">[in] The entity.</param>
        /// <returns>
        /// The concrete type of the given entity reference. SURefType_Unknown if entity is not valid.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SURefType SUEntityGetType(SUEntityRef entity);

        /// <summary>
        /// Retrieves the id of the entity.
        /// </summary>
        /// <param name="entity">[in] The entity.</param>
        /// <param name="entity_id">[out] The id retrieved.</param>
        /// <returns>
        ///     SU_ERROR_NONE on success
        ///     SU_ERROR_INVALID_INPUT if entity is not a valid object
        ///     SU_ERROR_NULL_POINTER_OUTPUT if entity_id is NULL.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntityGetID(SUEntityRef entity, ref int32_t entity_id);

        /// <summary>
        /// Retrieves the persistent id of the entity.
        /// </summary>
        /// <param name="entity">[in] The entity.</param>
        /// <param name="entity_pid">[out] The persistent id retrieved.</param>
        /// <returns>
        ///     SU_ERROR_NONE on success
        ///     SU_ERROR_INVALID_INPUT if entity is not a valid object
        ///     SU_ERROR_NULL_POINTER_OUTPUT if entity_pid is NULL.
        /// </returns>
        /// <remarks>
        /// Only a subset of entity types support PIDs. Refer to the list
        /// below for which and when support was added.
        ///     SketchUp 2018
        ///      - SUSceneRef
        ///     SketchUp 2017
        ///         - SUAxesRef
        ///         - SUComponentDefinitionRef
        ///         - SUComponentInstanceRef
        ///         - SUGuideLineRef
        ///         - SUGuidePointRef
        ///         - SUCurveRef
        ///         - SUDimensionRef
        ///         - SUEdgeRef
        ///         - SUFaceRef
        ///         - SUPolyline3dRef
        ///         - SUSectionPlaneRef
        ///         - SUTextRef
        ///     - SUVertexRef
        /// </remarks>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntityGetPersistentID(SUEntityRef entity, ref int64_t entity_pid);

        /// <summary>
        /// Retrieves the number of attribute dictionaries of an entity.
        /// </summary>
        /// <param name="entity">[in] The entity.</param>
        /// <param name="count">[out] The number of attribute dictionaries.</param>
        /// <returns>
        ///     SU_ERROR_NONE on success
        ///     SU_ERROR_INVALID_INPUT if entity is not a valid object
        ///     SU_ERROR_NULL_POINTER_OUTPUT if count is NULL.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntityGetNumAttributeDictionaries(SUEntityRef entity, ref size_t count);

        /// <summary>
        /// Retrieves the attribute dictionaries of an entity.
        /// </summary>
        /// <param name="entity">[in] The entity.</param>
        /// <param name="len">[in] The number of attribute dictionaries to retrieve.</param>
        /// <param name="dictionaries">[out] The dictionaries retrieved.</param>
        /// <param name="count">[out] The number of dictionaries retrieved.</param>
        /// <returns>
        ///     SU_ERROR_NONE on success
        ///     SU_ERROR_INVALID_INPUT if entity is not a valid entity
        ///     SU_ERROR_NULL_POINTER_OUTPUT if dictionaries or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntityGetAttributeDictionaries(SUEntityRef entity, size_t len, SUAttributeDictionaryRef[] dictionaries, ref size_t count);

        /// <summary>
        /// Adds the attribute dictionary to an entity.
        /// </summary>
        /// <param name="entity">[in] The entity.</param>
        /// <param name="dictionary">[in] The dictionary object to be added. If the function is  successful, don't call SUAttributeDictionaryRelease on the dictionary because the new entity will take ownership.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entity or dictionary are not valid entities
        /// SU_ERROR_DUPLICATE if another attribute already exists with the same name.
        /// SU_ERROR_INVALID_ARGUMENT if dictionary's name is empty.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntityAddAttributeDictionary(SUEntityRef entity, SUAttributeDictionaryRef dictionary);

        /// <summary>
        /// Retrieves the attribute dictionary of an entity that has the given name.
        /// If a dictionary with the given name does not exist, one is added to the entity.
        /// </summary>
        /// <param name="entity">[in] entity The entity.</param>
        /// <param name="name">[in] The name of the retrieved attribute dictionary. Assumed to be UTF-8 encoded.</param>
        /// <param name="dictionary">[out] The destination of the retrieved dictionary object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entity is not a valid entity
        /// SU_ERROR_NULL_POINTER_INPUT if name is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if dictionary is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntityGetAttributeDictionary(SUEntityRef entity, string name, ref SUAttributeDictionaryRef dictionary);

        /// <summary>
        /// Retrieves the model object associated with the entity.
        /// </summary>
        /// <param name="entity">[in] The entity.</param>
        /// <param name="model">[out] The model object retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entity is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if model is NULL
        /// SU_ERROR_NO_DATA if the entity is not associated with a model
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntityGetModel(SUEntityRef entity, ref SUModelRef model);

        /// <summary>
        /// Retrieves the entities object which contains the entity.
        /// </summary>
        /// <param name="entity">[in] The entity.</param>
        /// <param name="entities">[out] The entities object retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entity is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if entities is NULL
        /// SU_ERROR_NO_DATA if the entity is not contained by an entities object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntityGetParentEntities(SUEntityRef entity, ref SUEntitiesRef entities);
    }
}
