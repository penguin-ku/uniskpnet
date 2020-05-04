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
    /// An axes entity reference.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUAxesRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// axes
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Converts from an SUAxesRef to an SUEntityRef. This is essentially an upcast operation.
        /// </summary>
        /// <param name="axes">[in] The axes object.</param>
        /// <returns>
        /// The converted SUEntityRef if axes is a valid object
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUEntityRef SUAxesToEntity(SUAxesRef axes);

        /// <summary>
        /// Converts from an SUEntityRef to an SUAxesRef.
        /// This is essentially a downcast operation so the given SUEntityRef
        /// must be convertible to an SUAxesRef.
        /// </summary>
        /// <param name="entity">[in] The entity object.</param>
        /// <returns>
        /// The converted SUAxesRef if the downcast operation succeeds
        /// If the downcast operation fails, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUAxesRef SUAxesFromEntity(SUEntityRef entity);

        /// <summary>
        /// Converts from an SUAxesRef to an SUDrawingElementRef.
        /// This is essentially an upcast operation.
        /// </summary>
        /// <param name="axes">[in] The given axes reference.</param>
        /// <returns>
        /// The converted SUEntityRef if axes is a valid axes
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUDrawingElementRef SUAxesToDrawingElement(SUAxesRef axes);

        /// <summary>
        /// Converts from an SUDrawingElementRef to an SUAxesRef.
        /// This is essentially a downcast operation so the given element must be
        /// convertible to an SUAxesRef.
        /// </summary>
        /// <param name="drawing_elem">[in] The given element reference.</param>
        /// <returns>
        /// The converted SUAxesRef if the downcast operation succeeds
        /// If not, the returned reference will be invalid.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUAxesRef SUAxesFromDrawingElement(SUDrawingElementRef drawing_elem);

        /// <summary>
        /// Creates a default constructed axes object. The axes object must be subsequently deallocated with SUAxesRelease unless it is associated with a parent object.
        /// </summary>
        /// <param name="axes">[out] The axes object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if axes is NULL
        /// SU_ERROR_OVERWRITE_VALID if axes references a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUAxesCreate(ref SUAxesRef axes);

        /// <summary>
        /// Creates an axes object. The axes object must be subsequently deallocated with SUAxesRelease unless it is associated with a parent object.
        /// </summary>
        /// <param name="axes">[out]  The axes object.</param>
        /// <param name="origin">[in] The origin of the new axes.</param>
        /// <param name="xaxis">[in] The 1st axis for the custom 3D axes.</param>
        /// <param name="yaxis">[in] The 2nd axis for the custom 3D axes.</param>
        /// <param name="zaxis">[in] The 3rd axis for the custom 3D axes.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if axes is NULL
        /// SU_ERROR_OVERWRITE_VALID if axes references a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if any of the input pointers (origin, xaxis yaxis, and zaxis) are NULL
        /// SU_ERROR_GENERIC if the three vectors don't make an orthogonal axes
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUAxesCreateCustom(ref SUAxesRef axes, ref SUPoint3D origin, ref SUVector3D xaxis, ref SUVector3D yaxis, ref SUVector3D zaxis);

        /// <summary>
        /// Releases aa axes object. The axes object must have been created with
        /// SUAxesCreate and not subsequently associated with a parent object
        /// (e.g. SUEntitiesRef).
        /// </summary>
        /// <param name="axes">[in, out] The axes object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if axes is NULL
        /// SU_ERROR_INVALID_INPUT if axes does not reference a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUAxesRelease(ref SUAxesRef axes);

        /// <summary>
        /// Retrieves the origin point value, not a reference.
        /// </summary>
        /// <param name="axes">[in] The axes object.</param>
        /// <param name="origin">[out] Pointer to a SUPoint3D struct for returning the origin.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if axes is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if origin is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUAxesGetOrigin(SUAxesRef axes, ref SUPoint3D origin);

        /// <summary>
        /// Sets the origin point value for the provided axes.
        /// </summary>
        /// <param name="axes">[in] The axes object.</param>
        /// <param name="origin">[in] Pointer to a SUPoint3D struct for setting the origin.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if axes is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if origin is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUAxesSetOrigin(SUAxesRef axes, ref SUPoint3D origin);

        /// <summary>
        /// Retrieves the 1st axis vector value, not a reference.
        /// </summary>
        /// <param name="axes">[in] The axes object.</param>
        /// <param name="axis">[out] Pointer to a SUVector3D struct for getting the 1st axis.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if axes is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if axis is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUAxesGetXAxis(SUAxesRef axes, ref SUVector3D axis);

        /// <summary>
        /// Retrieves the 2nd axis vector value, not a reference.
        /// </summary>
        /// <param name="axes">[in] The axes object.</param>
        /// <param name="axis">[out] Pointer to a SUVector3D struct for getting the 2nd axis.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if axes is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if axis is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUAxesGetYAxis(SUAxesRef axes, ref SUVector3D axis);

        /// <summary>
        /// Retrieves the 3rd axis vector value, not a reference.
        /// </summary>
        /// <param name="axes">[in] The axes object.</param>
        /// <param name="axis">[out] Pointer to a SUVector3D struct for getting the 3rd axis.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if axes is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if axis is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUAxesGetZAxis(SUAxesRef axes, ref SUVector3D axis);

        /// <summary>
        /// Sets the axes' vectors. Fails if vectors don't make an orthogonal axes.
        /// </summary>
        /// <param name="axes">[in, out] axes The axes object.</param>
        /// <param name="xaxis">[in] xaxis Pointer to a SUVector3D struct for setting the 1st axis.</param>
        /// <param name="yaxis">[in] yaxis Pointer to a SUVector3D struct for setting the 2nd axis.</param>
        /// <param name="zaxis">[in] zaxis Pointer to a SUVector3D struct for setting the 3rd axis.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if axes is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if xaxis, yaxis, or zaxis is NULL
        /// SU_ERROR_GENERIC if the three vectors don't make an orthogonal axes
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUAxesSetAxesVecs(SUAxesRef axes, ref SUVector3D xaxis, ref SUVector3D yaxis, ref SUVector3D zaxis);

        /// <summary>
        /// Retrieves a copy of the transformation.
        /// </summary>
        /// <param name="axes">[in] The axes object.</param>
        /// <param name="transform">[out] Pointer to a SUTransformation struct for getting the transformation data.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if axes is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if transform is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUAxesGetTransform(SUAxesRef axes, ref SUTransformation transform);

        /// <summary>
        /// Retrieves a copy of the plane.
        /// </summary>
        /// <param name="axes">[in] The axes object.</param>
        /// <param name="plane">[out] Pointer to a SUPlane3D struct for getting the plane data.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if axes is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if plane is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUAxesGetPlane(SUAxesRef axes, ref SUPlane3D plane);
    }
}
