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
    /// References a container object for all entities in a model, component definition or a group.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUEntitiesRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// entities
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Removes all entities in the container.
        /// </summary>
        /// <param name="entities">[in] The entities to clear.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesClear(SUEntitiesRef entities);

        /// <summary>
        /// SUEntitiesFill is the fastest way to populate an entities object. The important precondition is that no duplicate data should be given.
        /// </summary>
        /// <param name="entities">[in] The entities to populate. Must be an empty entities object.</param>
        /// <param name="geom_input">[in] The geometry input that the entities object is to be populated with.</param>
        /// <param name="weld_vertices">[in] Flag indicating whether to join coincident vertices.</param>
        /// <returns></returns>
        /// <remarks>
        /// Faces included in the geometry input object will be merged together when
        /// using this function. This only applies to geometry in the geometry input
        /// object and not to any already-existing geometry in the entities object.
        /// Examples of merging are:
        /// - If weld_vertices is true, duplicated vertices are merged.
        /// - Coincident faces are merged.
        /// - Coincident faces with opposite normals are merged into a single face using the
        /// appropriate materials from both faces as the front and back materials.
        /// - Faces are created from coplanar edge loops.
        /// </remarks>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesFill(SUEntitiesRef entities, SUGeometryInputRef geom_input, bool weld_vertices);

        /// <summary>
        /// Retrieves the bounding box of the entities.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="bbox">[out] The bounding box retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if bbox is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesGetBoundingBox(SUEntitiesRef entities, ref SUBoundingBox3D bbox);

        /// <summary>
        /// Retrieves the LLA coordinates (Latidue, Longitude and Altitude) bounding 
        /// box of the given entities object. 
        /// Note that the altitude is calculated based on the model origin, Example: 
        /// If an entities object has a bounding box with the following values
        /// {{100,100,100}, {200,200,200}}
        /// the result will be something like the
        /// following: {{Latitude, Longitude, 100/METERS_TO_INCHES
        ///  }, 
        /// {Latitude, Longitude, 200/METERS_TO_INCHES}} where Latitude and Longitude
        /// are the geographical coordinates and altitude is just a conversion from
        /// inches to meters.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="bbox">[out] The latidue longitude and altitude bounding box retrieved.</param>
        /// <returns></returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesGetBoundingBoxLLA(SUEntitiesRef entities, ref SUBoundingBox3D bbox);

        /// <summary>
        /// Retrieves the number of faces in the entities object.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="count">[out] The number of faces.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesGetNumFaces(SUEntitiesRef entities, ref size_t count);

        /// <summary>
        /// Retrieves the faces in the entities object.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="len">[in] The number of faces to retrieve.</param>
        /// <param name="faces">[out] The faces retrieved.</param>
        /// <param name="count">[out] The number of faces retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if faces or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesGetFaces(SUEntitiesRef entities, size_t len, SUFaceRef[] faces, ref size_t count);

        /// <summary>
        /// Retrieves the number of curves in the entities object that are not associated with a face.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="count">[out] The number of curves.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesGetNumCurves(SUEntitiesRef entities, ref size_t count);

        /// <summary>
        /// Retrieves the curves in the entities object that are not associated with a face.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="len">[in] The number of curves to retrieve.</param>
        /// <param name="curves">[out] The curves retrieved.</param>
        /// <param name="count">[out] The number of curves retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if curves or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesGetCurves(SUEntitiesRef entities, size_t len, SUCurveRef[] curves, ref size_t count);

        /// <summary>
        /// Retrieves the number of arccurves in the entities object that are not associated with a face.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="count">[out] The number of arccurves.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesGetNumArcCurves(SUEntitiesRef entities, out size_t count);

        /// <summary>
        /// Retrieves the arccurves in the entities object that are not associated with a face.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="len">[in] The number of arccurves to retrieve.</param>
        /// <param name="arccurves">[out] The arccurves retrieved.</param>
        /// <param name="count">[out] The number of curves retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if arccurves or count is NULL
        /// The number of curves retrieved.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesGetArcCurves(SUEntitiesRef entities, size_t len, SUArcCurveRef[] arccurves, ref size_t count);

        /// <summary>
        /// Retrieves the number of guide points in the entities object.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="count">[out] The number of guide_points.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesGetNumGuidePoints(SUEntitiesRef entities, out size_t count);

        /// <summary>
        /// Retrieves the guide points in the entities object.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="len">[in] The number of guide points to retrieve.</param>
        /// <param name="guide_points">[out] The guide_points retrieved.</param>
        /// <param name="count">[out] The number of guide_points retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if guide_points or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesGetGuidePoints(SUEntitiesRef entities, size_t len, SUGuidePointRef[] guide_points, ref size_t count);

        /// <summary>
        /// Retrieves the number of guide lines in the entities object.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="count">[out] The number of guide_lines.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesGetNumGuideLines(SUEntitiesRef entities, ref size_t count);

        /// <summary>
        /// Retrieves the guide lines in the entities object.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="len">[in] The number of guide lines to retrieve.</param>
        /// <param name="guide_lines">[out] The guide_lines retrieved.</param>
        /// <param name="count">[out] The number of guide_lines retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if guide_lines or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesGetGuideLines(SUEntitiesRef entities, size_t len, SUGuideLineRef[] guide_lines, ref size_t count);

        /// <summary>
        /// Retrieves the number of edges in the entities object.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="standalone_only">[in] Whether to count all edges (false) or only the edges not attached to curves and faces (true).</param>
        /// <param name="count">[out] The number of edges.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesGetNumEdges(SUEntitiesRef entities, bool standalone_only, ref size_t count);

        /// <summary>
        /// Retrieves the edges in the entities object.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="standalone_only">[in] Whether to get all edges (false) or only the edges not attached to curves and faces(true).</param>
        /// <param name="len">[in] The number of edges to retrieve.</param>
        /// <param name="edges">[out] The edges retrieved.</param>
        /// <param name="count">[out] The number of edges retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if edges or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesGetEdges(SUEntitiesRef entities, bool standalone_only, size_t len, SUEdgeRef[] edges, ref size_t count);

        /// <summary>
        /// Retrieves the number of polyline3d's in the entities object.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="count">[out] The the number of polyline3d's.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesGetNumPolyline3ds(SUEntitiesRef entities, ref size_t count);

        /// <summary>
        /// Retrieves the polyline3d's in the entities object.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="len">[in] The number of polyline3d's to retrieve.</param>
        /// <param name="lines">[out] The polyline3d's retrieved.</param>
        /// <param name="count">[out] The number of polyline3d's retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if lines or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesGetPolyline3ds(SUEntitiesRef entities, size_t len, SUPolyline3dRef[] lines, ref size_t count);

        /// <summary>
        /// Adds face objects to a entities object.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="len">[in] The length of the array of face objects.</param>
        /// <param name="faces">[in] The array of face objects to add.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if faces is NULL
        /// </returns>
        /// <remarks>
        /// This function does not merge geometry, which will likely create an invalid 
        /// SketchUp model.It is recommended to use SUGeometryInput instead which does 
        /// correctly merge geometry.
        /// </remarks>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesAddFaces(SUEntitiesRef entities, size_t len, ref SUFaceRef[] faces);

        /// <summary>
        /// Adds edge objects to a entities object.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="len">[in] The length of the array of edge objects.</param>
        /// <param name="edges">[in] The array of edge objects to add.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if edges is NULL
        /// </returns>
        /// <remarks>
        /// This function does not merge geometry, which will likely create an invalid 
        /// SketchUp model.It is recommended to use SUGeometryInput instead which does 
        /// correctly merge geometry.
        /// </remarks>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesAddEdges(SUEntitiesRef entities, size_t len, ref SUEdgeRef[] edges);

        /// <summary>
        /// Adds curve objects to a entities object.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="len">[in] The length of the array of curve objects.</param>
        /// <param name="curves">[in] The array of curve objects to add.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if curves is NULL
        /// </returns>
        /// <remarks>
        /// This function does not merge geometry, which will likely create an invalid 
        /// SketchUp model.It is recommended to use SUGeometryInput instead which does 
        /// correctly merge geometry.
        /// </remarks>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesAddCurves(SUEntitiesRef entities, size_t len, ref SUCurveRef[] curves);

        /// <summary>
        /// Adds curve objects to a entities object.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="len">[in] The length of the array of curve objects.</param>
        /// <param name="curves">[in] The array of curve objects to add.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if curves is NULL
        /// </returns>
        /// <remarks>
        /// This function does not merge geometry, which will likely create an invalid 
        /// SketchUp model.It is recommended to use SUGeometryInput instead which does 
        /// correctly merge geometry.
        /// </remarks>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesAddArcCurves(SUEntitiesRef entities, size_t len, ref SUArcCurveRef[] curves);

        /// <summary>
        /// Adds guide point objects to a entities object.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="len">[in] The length of the array of guide point objects.</param>
        /// <param name="guide_points">[in] The array of point objects to add.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if guide_points is NULL
        /// </returns>
        /// <remarks>
        /// This function does not merge geometry, which will likely create an invalid 
        /// SketchUp model.It is recommended to use SUGeometryInput instead which does 
        /// correctly merge geometry.
        /// </remarks>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesAddGuidePoints(SUEntitiesRef entities, size_t len, ref SUGuidePointRef[] guide_points);

        /// <summary>
        /// Adds guide line objects to a entities object.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="len">[in] The length of the array of guide line objects.</param>
        /// <param name="guide_lines">[in] The array of line objects to add.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if guide_lines is NULL
        /// </returns>
        /// <remarks>
        /// This function does not merge geometry, which will likely create an invalid 
        /// SketchUp model.It is recommended to use SUGeometryInput instead which does 
        /// correctly merge geometry.
        /// </remarks>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesAddGuideLines(SUEntitiesRef entities, size_t len, ref SUGuideLineRef[] guide_lines);

        /// <summary>
        /// Adds a group object to an entities object.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="group">[in] The group object to add.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities or group is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesAddGroup(SUEntitiesRef entities, SUGroupRef group);

        /// <summary>
        /// Adds a image object to an entities object.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="image">[in] The image object to add.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities or image is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesAddImage(SUEntitiesRef entities, SUImageRef image);

        /// <summary>
        /// Adds a component instance object to the entities.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="instance">[in] The component instance object to add.</param>
        /// <param name="name">[in] The unique name that is assigned to definition of the component instance. This can be NULL in which case the caller does not need to retrieve the assigned name.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities or instance is not a valid object
        /// SU_ERROR_INVALID_OUTPUT if name (when not NULL) does not refer to a valid
        /// SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesAddInstance(SUEntitiesRef entities, SUComponentInstanceRef instance, ref SUStringRef name);

        /// <summary>
        /// Adds section plane objects to an entities object.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="len">[in] The length of the array of section planes objects.</param>
        /// <param name="section_planes">[in] The array of section planes objects to add.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if section_planes is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesAddSectionPlanes(SUEntitiesRef entities, size_t len, ref SUSectionPlaneRef[] section_planes);

        /// <summary>
        /// Adds text objects to an entities object.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="len">[in] The length of the array of text objects.</param>
        /// <param name="texts">[in] The array of text objects to add.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if texts is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesAddTexts(SUEntitiesRef entities, size_t len, ref SUTextRef[] texts);

        /// <summary>
        /// Retrieves the number of groups in the entities.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="count">[out] The number of groups.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is an invalid entities object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesGetNumGroups(SUEntitiesRef entities, ref size_t count);

        /// <summary>
        /// Retrieves the groups in the entities.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="len">[in] The number of groups to retrieve.</param>
        /// <param name="groups">[out] The groups retrieved.</param>
        /// <param name="count">[out] The number of groups retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is an invalid entities object
        /// SU_ERROR_NULL_POINTER_OUTPUT if groups or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesGetGroups(SUEntitiesRef entities, size_t len, SUGroupRef[] groups, ref size_t count);

        /// <summary>
        /// Retrieves the number of images in the entities.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="count">[out] The number of images.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is an invalid entities object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesGetNumImages(SUEntitiesRef entities, ref size_t count);

        /// <summary>
        /// Retrieves the array of image objects of a entities object.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="len">[in] The number of image objects  to retrieve.</param>
        /// <param name="images">[out] The image objects retrieved.</param>
        /// <param name="count">[out] The number of image objects retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is an invalid entities object
        /// SU_ERROR_NULL_POINTER_OUTPUT if images or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesGetImages(SUEntitiesRef entities, size_t len, SUImageRef[] images, ref size_t count);

        /// <summary>
        /// Retrieves the number of component instances in the entities.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="count">[out] The number of component instances.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is an invalid entities object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesGetNumInstances(SUEntitiesRef entities, ref size_t count);

        /// <summary>
        /// Retrieves the array of component instances of a entities object.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="len">[in] The number of component instances  to retrieve.</param>
        /// <param name="instances">[out] The component instances retrieved.</param>
        /// <param name="count">[out] The number of component instances retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is an invalid entities object
        /// SU_ERROR_NULL_POINTER_OUTPUT if instances or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesGetInstances(SUEntitiesRef entities, size_t len, SUComponentInstanceRef[] instances, ref size_t count);

        /// <summary>
        /// Retrieves the number of section planes in the entities.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="count">[out] The number of component instances.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is an invalid entities object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesGetNumSectionPlanes(SUEntitiesRef entities, ref size_t count);

        /// <summary>
        /// Retrieves the array of section planes of a entities object.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="len">[in] The number of section planes to retrieve.</param>
        /// <param name="section_planes">[inout The section planes retrieved.</param>
        /// <param name="count">[out] The number of section planes retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is an invalid entities object
        /// SU_ERROR_NULL_POINTER_OUTPUT if section_planes or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesGetSectionPlanes(SUEntitiesRef entities, size_t len, SUComponentInstanceRef[] section_planes, ref size_t count);

        /// <summary>
        /// Retrieves the number of texts in the entities.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="count">[in] The number of texts.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is an invalid entities object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesGetNumTexts(SUEntitiesRef entities, ref size_t count);

        /// <summary>
        /// Retrieves the array of texts of a entities object.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="len">[in] The number of texts to retrieve.</param>
        /// <param name="texts">[out] The texts retrieved.</param>
        /// <param name="count">[out] The number of texts retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is an invalid entities object
        /// SU_ERROR_NULL_POINTER_OUTPUT if texts or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesGetTexts(SUEntitiesRef entities, size_t len, SUComponentInstanceRef[] texts, ref size_t count);

        /// <summary>
        /// Retrieves the number of dimensions in the entities.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="count">[out] The number of dimensions.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is an invalid entities object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesGetNumDimensions(SUEntitiesRef entities, ref size_t count);

        /// <summary>
        /// Retrieves the array of texts of a entities object.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="len">[in] The number of dimensions to retrieve.</param>
        /// <param name="dimensions">[out] The dimensions retrieved.</param>
        /// <param name="count">[out] The number of dimensions retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is an invalid entities object
        /// SU_ERROR_NULL_POINTER_OUTPUT if dimensions or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesGetDimensions(SUEntitiesRef entities, size_t len, SUDimensionRef[] dimensions, ref size_t count);

        /// <summary>
        /// Applies a 3D transformations to the elements of the provided entity
        /// array. The arrays of elements and transformations must be the same
        /// length.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="len">[in] The number of entities in the array.</param>
        /// <param name="elements">[in] The elements to be transformed.</param>
        /// <param name="tranforms">[in] The transformations to be applied.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if elements or tranforms are NULL
        /// SU_ERROR_UNSUPPORTED if any of the elements in the array are not contained by entities
        /// SU_ERROR_GENERIC if the transformation operation fails
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesTransformMultiple(SUEntitiesRef entities, size_t len, SUEntityRef[] elements, SUTransformation[] tranforms);

        /// <summary>
        /// Erases elements from an entities object. The input elements are
        /// destroyed, so the array elements are invalidated to prevent user from
        /// attempting to use destroyed entities.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="len">[in] The number of entities in the array.</param>
        /// <param name="elements">[in] The elements to be destroyed.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if elements is NULL
        /// SU_ERROR_UNSUPPORTED if any of the elements in the array are not contained by entities
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesErase(SUEntitiesRef entities, size_t len, SUEntityRef[] elements);

        /// <summary>
        /// Retrieves a boolean indicating whether the entities object is 
        /// recursively empty. A recursively empty entities object is defined as one
        /// that either has zero entities or contains only instances of definitions 
        /// with recursively empty entities objects.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="is_empty">[out] The bool value retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is invalid
        /// SU_ERROR_NULL_POINTER_OUTPUT if is_empty is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesIsRecursivelyEmpty(SUEntitiesRef entities, ref bool is_empty);

        /// <summary>
        /// Retrieves a boolean by recursively searching through the entities
        /// determining whether the entities has an active section plane or any
        /// of its nested components have an active section plane.
        /// </summary>
        /// <param name="entities">[in] The entities object.</param>
        /// <param name="has_section_cuts">[out] The bool value retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is invalid
        /// SU_ERROR_NULL_POINTER_OUTPUT if has_section_cuts is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesHasSectionCuts(SUEntitiesRef entities, ref bool has_section_cuts);

        /// <summary>
        /// Fills the list with all entities of the specified type in the instance.
        /// The list is not in any specific order.
        /// </summary>
        /// <param name="entities">[in] The entities object to be queried.</param>
        /// <param name="type">[in] The type of entities to be collected.</param>
        /// <param name="list">[in] The list object to be filled.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if entities is not a valid object
        /// SU_ERROR_INVALID_OUTPUT if list is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUEntitiesEntityListFill(SUEntitiesRef entities, SURefType type, SUEntityListRef list);


    }
}
