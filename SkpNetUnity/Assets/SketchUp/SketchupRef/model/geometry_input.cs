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
    /// References a geometry input object. It is used as an input to SUEntitiesFill.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUGeometryInputRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// References a geometry input loop object. It is used as an input to SUEntitiesFill.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SULoopInputRef
    {
        public IntPtr ptr;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUMaterialInput
    {
        /// <summary>
        /// Number of texture coordinates. 0 if no texture. 1 to 4 otherwise.
        /// </summary>
        public size_t num_uv_coords;

        /// <summary>
        /// Texture coordinates.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public SUPoint2D[] uv_coords;

        /// <summary>
        /// Vertex indices corresponding to the texture coordinates. Should reference the vertex array of the parent SUGeometryInputRef.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public size_t[] vertex_indices;

        /// <summary>
        /// Material to be applied.
        /// </summary>
        public SUMaterialRef material;
    }

    /// <summary>
    /// geometry_input
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Creates a geometry input object.
        /// </summary>
        /// <param name="geom_input">[out] The object created. This object can be passed into
        /// SUEntitiesFill to populate an entities object.
        /// It should be released subsequently by calling SUGeometryInputRelease.</param>
        /// <returns></returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGeometryInputCreate(ref SUGeometryInputRef geom_input);

        /// <summary>
        /// Deallocates a geometry input object.
        /// </summary>
        /// <param name="geom_input">[in] The object to deallocate.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if geom_input is NULL
        /// SU_ERROR_INVALID_INPUT if geom_input points to an invalid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGeometryInputRelease(ref SUGeometryInputRef geom_input);

        /// <summary>
        /// Adds a vertex to a geometry input object.
        /// </summary>
        /// <param name="geom_input">[in] The geometry input object.</param>
        /// <param name="point">[in] The location of the vertex to be added.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if geom_input is not valid
        /// SU_ERROR_NULL_POINTER_INPUT if point is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGeometryInputAddVertex(SUGeometryInputRef geom_input, ref SUPoint3D point);

        /// <summary>
        /// Sets all vertices of a geometry input object. Any existing vertices will be overridden.
        /// </summary>
        /// <param name="geom_input">[in] The geometry input object.</param>
        /// <param name="num_vertices">[in] The number of vertices in the given point array.</param>
        /// <param name="points">[in] The points array containing the location of vertices.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if geom_input is not valid
        /// SU_ERROR_NULL_POINTER_INPUT if points is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGeometryInputSetVertices(SUGeometryInputRef geom_input, size_t num_vertices, SUPoint3D[] points);

        /// <summary>
        /// Adds an edge to a geometry input object. This method is intended for
        /// specifying edges which are not associated with loop inputs. For
        /// specifying edge properties on a face use the SULoopInput interface.
        /// </summary>
        /// <param name="geom_input">[in] The geometry input object.</param>
        /// <param name="vertex0_index">[in] The vertex index of the edge's first vertex.</param>
        /// <param name="vertex1_index">[in] The vertex index of the edge's last vertex.</param>
        /// <param name="added_edge_index">[out] (optional) If not NULL, returns the index of the added edge.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if geom_input is not valid
        /// SU_ERROR_OUT_OF_RANGE if vertex0_index or vertex1_index are greater than the total vertex count
        /// SU_ERROR_INVALID_ARGUMENT if vertex0_index and vertex1_index are equal
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGeometryInputAddEdge(SUGeometryInputRef geom_input, size_t vertex0_index, size_t vertex1_index, ref size_t added_edge_index);

        /// <summary>
        /// Sets the hidden flag of an edge in a geometry input object which is not associated with a loop input.
        /// </summary>
        /// <param name="geom_input">[in] The geometry input object.</param>
        /// <param name="edge_index">[in] The zero-based index of the edge which is not associated with a loop input.</param>
        /// <param name="hidden">[in] The flag to set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if geom_input is not valid
        /// SU_ERROR_OUT_OF_RANGE if edge_index references beyond the current total number of edges which are not associated with loop inputs
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGeometryInputEdgeSetHidden(SUGeometryInputRef geom_input, size_t edge_index, bool hidden);

        /// <summary>
        /// Sets the soft flag of an edge in a geometry input object which is not associated with a loop input.
        /// </summary>
        /// <param name="geom_input">[in] The geometry input object.</param>
        /// <param name="edge_index">[in] The zero-based index of the edge which is not associated with a loop input.</param>
        /// <param name="soft">[in] The flag to set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if geom_input is not valid
        /// SU_ERROR_OUT_OF_RANGE if edge_index references beyond the current total number of edges which are not associated with loop inputs
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGeometryInputEdgeSetSoft(SUGeometryInputRef geom_input, size_t edge_index, bool soft);

        /// <summary>
        /// Sets the smooth flag of an edge in a geometry input object which is not associated with a loop input.
        /// </summary>
        /// <param name="geom_input">[in] The geometry input object.</param>
        /// <param name="edge_index">[in] The zero-based index of the edge which is not associated with a loop input.</param>
        /// <param name="smooth">[in] The flag to set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if geom_input is not valid
        /// SU_ERROR_OUT_OF_RANGE if edge_index references beyond the current total number of edges which are not associated with loop inputs
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGeometryInputEdgeSetSmooth(SUGeometryInputRef geom_input, size_t edge_index, bool smooth);

        /// <summary>
        /// Sets the material of an edge in the geometry input.
        /// </summary>
        /// <param name="geom_input">[in] The geometry input object.</param>
        /// <param name="edge_index">[in] The zero-based index of the edge which is not associated with a loop input.</param>
        /// <param name="material">[in] The material to set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if geom_input or material  is not valid
        /// SU_ERROR_OUT_OF_RANGE if edge_index references beyond the current total number of edges which are not associated with loop inputs
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGeometryInputEdgeSetMaterial(SUGeometryInputRef geom_input, size_t edge_index, SUMaterialRef material);

        /// <summary>
        /// Sets the layer of an edge in the geometry input.
        /// </summary>
        /// <param name="geom_input">[in] The geometry input object.</param>
        /// <param name="edge_index">[in] The zero-based index of the edge which is not associated with a loop input.</param>
        /// <param name="layer">[in] The layer to set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if geom_input or layer  is not valid
        /// SU_ERROR_OUT_OF_RANGE if edge_index references beyond the current total number of edges which are not associated with loop inputs
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGeometryInputEdgeSetLayer(SUGeometryInputRef geom_input, size_t edge_index, SULayerRef layer);

        /// <summary>
        /// Adds a curve to a geometry input object. This method is intended for
        /// specifying curves which are not associated with loop inputs.For
        /// specifying curves on faces use the SULoopInput interface.
        /// </summary>
        /// <param name="geom_input">[in] The geometry input object.</param>
        /// <param name="num_edges">[in] The number of edges to be used in the curve.</param>
        /// <param name="edge_indices">[in] The edge indices to be used in defining the curve.</param>
        /// <param name="added_curve_index">[out] (optional) If not NULL, returns the index of the added curve.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if geom_input is not valid
        /// SU_ERROR_NULL_POINTER_INPUT if edge_indices is NULL
        /// SU_ERROR_OUT_OF_RANGE if any of the indices in edge_indices are greater than the total number of edges which are not associated with loop inputs
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGeometryInputAddCurve(SUGeometryInputRef geom_input, size_t num_edges, size_t[] edge_indices, ref size_t added_curve_index);

        /// <summary>
        /// Adds an arccurve to a geometry input object. In addition to adding an
        /// arccurve to the geometry input this method will append num_segments edges
        /// to the geometry's edge collection where control_edge_index is the index
        /// of the first new edge.Also, num_segments-1 vertices along the arc will
        /// be appended to the geometry's collection of verttices. In order to
        /// include an arccurve in a loop the user only needs add the arccurve's
        /// points to a loop using SULoopInputAddVertexIndex.
        /// </summary>
        /// <param name="geom_input">[in] The geometry input object.</param>
        /// <param name="start_point">[in] The index of the vertex at the start of the arc.</param>
        /// <param name="end_point">[in] The index of the vertex at the end of the arc.</param>
        /// <param name="center">[in] The center point of the arc's circle.</param>
        /// <param name="normal">[in] The normal vector of the arc plane.</param>
        /// <param name="num_segments">[in] The number of edges for the arc.</param>
        /// <param name="added_curve_index">[out] (optional) If not NULL, returns the index of the added curve.</param>
        /// <param name="control_edge_index">[out] (optional) If not NULL, returns the index of the the arc's control edge which can be used to set the arc's edge properties.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if geom_input is not valid
        /// SU_ERROR_NULL_POINTER_INPUT if center or normal is NULL
        /// SU_ERROR_OUT_OF_RANGE if either start_point or end_point are greater than the total number of points in geom_input
        /// SU_ERROR_INVALID_ARGUMENT if the data specifies an invalid arccurve
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGeometryInputAddArcCurve(SUGeometryInputRef geom_input, size_t start_point, size_t end_point, ref SUPoint3D center, ref SUVector3D normal, size_t num_segments, ref size_t added_curve_index, ref size_t control_edge_index);

        /// <summary>
        /// Creates a loop input object.
        /// </summary>
        /// <param name="loop_input">[out] loop_input The object created.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if loop_input is NULL
        /// SU_ERROR_OVERWRITE_VALID if loop_input already references a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULoopInputCreate(ref SULoopInputRef loop_input);

        /// <summary>
        /// Deallocates a loop input object.
        /// </summary>
        /// <param name="loop_input">[in] loop_input The object created.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if loop_input is NULL
        /// SU_ERROR_INVALID_INPUT if loop_input points to an invalid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULoopInputRelease(ref SULoopInputRef loop_input);

        /// <summary>
        /// Adds a vertex index to a loop input object.
        /// </summary>
        /// <param name="loop_input">[in] The loop input object.</param>
        /// <param name="vertex_index">[in] The vertex index to add. This references a vertex within the parent geometry input's vertex collection (as a zero- based index).</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if loop_input is NULL
        /// SU_ERROR_UNSUPPORTED if the loop was already closed
        /// SU_ERROR_INVALID_ARGUMENT if vertex_index already existed in the loop not at the front
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULoopInputAddVertexIndex(SULoopInputRef loop_input, size_t vertex_index);

        /// <summary>
        /// Sets the hidden flag of an edge in a loop input object.
        /// </summary>
        /// <param name="loop_input">[in] The loop input object.</param>
        /// <param name="edge_index">[in] The zero-based index of the edge which is not associated with a loop input.</param>
        /// <param name="hidden">[in] The flag to set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if loop_input is not valid
        /// SU_ERROR_OUT_OF_RANGE if edge_index references beyond the current edge
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULoopInputEdgeSetHidden(SULoopInputRef loop_input, size_t edge_index, bool hidden);

        /// <summary>
        /// Sets the soft flag of an edge in a loop input object.
        /// </summary>
        /// <param name="loop_input">[in] The loop input object.</param>
        /// <param name="edge_index">[in] The zero-based index of the edge which is not associated with a loop input.</param>
        /// <param name="soft">[in] The flag to set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if loop_input is not valid
        /// SU_ERROR_OUT_OF_RANGE if edge_index references beyond the current edge
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULoopInputEdgeSetSoft(SULoopInputRef loop_input, size_t edge_index, bool soft);

        /// <summary>
        /// Sets the smooth flag of an edge in a loop input object.
        /// </summary>
        /// <param name="loop_input">[in] The loop input object.</param>
        /// <param name="edge_index">[in] The zero-based index of the edge which is not associated with a loop input.</param>
        /// <param name="smooth">[in] The flag to set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if loop_input is not valid
        /// SU_ERROR_OUT_OF_RANGE if edge_index references beyond the current edge
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULoopInputEdgeSetSmooth(SULoopInputRef loop_input, size_t edge_index, bool smooth);

        /// <summary>
        /// Sets the material of an edge in the loop input.
        /// </summary>
        /// <param name="loop_input">[in] The loop input object.</param>
        /// <param name="edge_index">[in] The zero-based index of the edge which is not associated with a loop input.</param>
        /// <param name="material">[in] The material to set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if geom_input or material  is not valid
        /// SU_ERROR_OUT_OF_RANGE if edge_index references beyond the current total number of edges which are not associated with loop inputs
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULoopInputEdgeSetMaterial(SULoopInputRef loop_input, size_t edge_index, SUMaterialRef material);

        /// <summary>
        /// Sets the layer of an edge in the loop input.
        /// </summary>
        /// <param name="geom_input">[in] The geometry input object.</param>
        /// <param name="edge_index">[in] The zero-based index of the edge which is not associated with a loop input.</param>
        /// <param name="layer">[in] The layer to set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if geom_input or layer  is not valid
        /// SU_ERROR_OUT_OF_RANGE if edge_index references beyond the current total number of edges which are not associated with loop inputs
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULoopInputEdgeSetLayer(SUGeometryInputRef geom_input, size_t edge_index, SULayerRef layer);

        /// <summary>
        /// Adds a simple curve to a loop input object.
        /// </summary>
        /// <param name="loop_input">[in] The loop input object.</param>
        /// <param name="first_edge_index">[in] First edge index to be associated with the curve.</param>
        /// <param name="last_edge_index">[in] Last edge index to be associated with the curve.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if loop_input is not valid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULoopInputAddCurve(SULoopInputRef loop_input, size_t first_edge_index, size_t last_edge_index);


        /// <summary>
        /// Retrieves whether the loop input is closed. A loop input can be closed
        /// either by re-adding the start vertex to the end of the loop using
        /// SULoopInputAddVertexIndex or by adding a curve to the loop input which
        /// connects the loop's start and end points using SULoopInputAddCurve.
        /// </summary>
        /// <param name="loop_input">[in] The loop input object.</param>
        /// <param name="is_closed">[out] The flag retrieved (true if the loop is closed).</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if loop_input is not valid
        /// SU_ERROR_NULL_POINTER_OUTPUT if is_closed is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SULoopInputIsClosed(SULoopInputRef loop_input, ref bool is_closed);

        /// <summary>
        /// Adds a face to a geometry input object with a given outer loop for the face.
        /// </summary>
        /// <param name="geom_input">[in] The geometry input object.</param>
        /// <param name="outer_loop">[in] The outer loop to be set for the face. If the function succeeds (i.e. returns SU_ERROR_NONE), this loop will be deallocated.</param>
        /// <param name="added_face_index">[out]  (optional) If not NULL, returns the index of the added face.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if geom_input is not valid
        /// SU_ERROR_OUT_OF_RANGE if face_index references a face beyond the total face count of geom_input
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGeometryInputAddFace(SUGeometryInputRef geom_input, ref SULoopInputRef outer_loop, ref size_t added_face_index);

        /// <summary>
        /// Sets a flag in the geometry input that, when true, will create a face by reversing the orientations of all of its loops.
        /// </summary>
        /// <param name="geom_input">[in] The geometry input object.</param>
        /// <param name="face_index">[in] Index of the face to be reversed.</param>
        /// <param name="reverse">[in] The given reverse flag.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if geom_input is not valid
        /// SU_ERROR_OUT_OF_RANGE if face_index references a face beyond the total face count of geom_input
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGeometryInputFaceSetReverse(SUGeometryInputRef geom_input, size_t face_index, bool reverse);

        /// <summary>
        /// Sets the layer of a face in the geometry input.
        /// </summary>
        /// <param name="geom_input">[in] The geometry input object.</param>
        /// <param name="face_index">[in] Index of the face to be reversed.</param>
        /// <param name="layer">[in] The layer to be set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if geom_input or layer is not valid
        /// SU_ERROR_OUT_OF_RANGE if face_index references a face beyond the total face count of geom_input
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGeometryInputFaceSetLayer(SUGeometryInputRef geom_input, size_t face_index, SULayerRef layer);

        /// <summary>
        /// Adds an inner loop to a face in the geometry input.
        /// </summary>
        /// <param name="geom_input">[in] The geometry input object.</param>
        /// <param name="face_index">[in] Index of the face to receive the inner loop.</param>
        /// <param name="loop_input">[in] The inner loop to be added. If the function succeeds (i.e. returns SU_ERROR_NONE), this loop will be deallocated.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if geom_input or *loop_input are not valid
        /// SU_ERROR_NULL_POINTER_INPUT if loop_input is NULL
        /// SU_ERROR_OUT_OF_RANGE if face_index references a face beyond the total face count of geom_input.
        /// SU_ERROR_INVALID_ARGUMENT if the data specifies an invalid loop
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGeometryInputFaceAddInnerLoop(SUGeometryInputRef geom_input, size_t face_index, ref SULoopInputRef loop_input);

        /// <summary>
        /// Sets the front material of a face in the geometry input.
        /// </summary>
        /// <param name="geom_input">[in] The geometry input object.</param>
        /// <param name="face_index">[in] Index of the face to receive the material.</param>
        /// <param name="material_input">[in] The material input to set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if geom_input is not valid
        /// SU_ERROR_OUT_OF_RANGE if face_index references a face beyond the total face count of geom_input
        /// SU_ERROR_NULL_POINTER_INPUT if material_input is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGeometryInputFaceSetFrontMaterial(SUGeometryInputRef geom_input, size_t face_index, ref SUMaterialInput material_input);

        /// <summary>
        /// Sets the back material of a face in the geometry input.
        /// </summary>
        /// <param name="geom_input">[in] The geometry input object.</param>
        /// <param name="face_index">[in] Index of the face to receive the material.</param>
        /// <param name="material_input">[in] The material input to set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if geom_input is not valid
        /// SU_ERROR_OUT_OF_RANGE if face_index references a face beyond the total face count of geom_input
        /// SU_ERROR_NULL_POINTER_INPUT if material_input is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGeometryInputFaceSetBackMaterial(SUGeometryInputRef geom_input, size_t face_index, ref SUMaterialInput material_input);

        /// <summary>
        /// Sets a flag in the geometry input that, when true, will create a hidden face.
        /// </summary>
        /// <param name="geom_input">[in] The geometry input object.</param>
        /// <param name="face_index">[in] Index of the face to be hidden.</param>
        /// <param name="hidden">[in] The given hidden flag.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if geom_input is not valid
        /// SU_ERROR_OUT_OF_RANGE if face_index references a face beyond the total face count of geom_input
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGeometryInputFaceSetHidden(SUGeometryInputRef geom_input, size_t face_index, bool hidden);

        /// <summary>
        /// Returns all the various geometry counts.
        /// </summary>
        /// <param name="geom_input">[in] The geometry input object.</param>
        /// <param name="vertices_count">[out] The total count of vertices.</param>
        /// <param name="faces_count">[out] The total count of faces.</param>
        /// <param name="edge_count">[out] The total count of edges.</param>
        /// <param name="curve_count">[out] The total count of curves.</param>
        /// <param name="arc_count">[out] The total count of arcs.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if vertices_count, faces_count, edge_count, curve_count, or arc_count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUGeometryInputGetCounts(SUGeometryInputRef geom_input, ref size_t vertices_count, ref size_t faces_count, ref size_t edge_count, ref size_t curve_count, ref size_t arc_count);
    }
}
