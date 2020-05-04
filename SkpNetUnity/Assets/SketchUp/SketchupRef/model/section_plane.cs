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
    /// A sectionPlane entity reference.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUSectionPlaneRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// section_plane
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Converts from an SUSectionPlaneRef to an SUEntityRef.
        /// This is essentially an upcast operation.
        /// </summary>
        /// <param name="drawing_elem">[in] The given drawing_elem reference.</param>
        /// <returns>
        /// The converted SUEntityRef if drawing_elem is a valid drawing_elem.
        /// If not, the returned reference will be invalid.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUEntityRef SUSectionPlaneToEntity(SUSectionPlaneRef drawing_elem);

        /// <summary>
        /// Converts from an SUEntityRef to an SUSectionPlaneRef.
        /// This is essentially a downcast operation so the given entity must be
        /// convertible to an SUSectionPlaneRef.
        /// </summary>
        /// <param name="entity">[in] The given entity reference.</param>
        /// <returns>
        /// The converted SUSectionPlaneRef if the downcast operation succeeds
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUSectionPlaneRef SUSectionPlaneFromEntity(SUEntityRef entity);

        /// <summary>
        /// Converts from an SUSectionPlaneRef to an SUDrawingElementRef.
        /// This is essentially an upcast operation.
        /// </summary>
        /// <param name="drawing_elem">[in] The given drawing_elem reference.</param>
        /// <returns>
        /// The converted SUDrawingElementRef if drawing_elem is a valid drawing_elem.
        /// If not, the returned reference will be invalid.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUDrawingElementRef SUSectionPlaneToDrawingElement(SUSectionPlaneRef drawing_elem);

        /// <summary>
        /// Converts from an SUDrawingElementRef to an SUSectionPlaneRef.
        /// This is essentially a downcast operation so the given entity must be
        /// convertible to an SUSectionPlaneRef.
        /// </summary>
        /// <param name="entity">[in] The given entity reference.</param>
        /// <returns>
        /// The converted SUSectionPlaneRef if the downcast operation succeeds
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUSectionPlaneRef SUSectionPlaneFromDrawingElement(SUDrawingElementRef entity);

        /// <summary>
        /// Creates an sectionPlane object. The sectionPlane object must be
        /// subsequently deallocated with SUSectionPlaneRelease unless it is
        /// associated with a parent object.  The plane is initialized as an xy
        /// plane and can be changed with the SUSectionPlaneSetPlane.
        /// subsequently deallocated with SUPolyline3dRelease unless it is
        /// associated with a parent object.
        /// </summary>
        /// <param name="sectionPlane">[out] The sectionPlane object created.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if sectionPlane is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSectionPlaneCreate(ref SUSectionPlaneRef sectionPlane);

        /// <summary>
        /// Releases a sectionPlane object. The sectionPlane object must have been created with 
        /// SUSectionPlaneCreate and not subsequently associated with a parent object (e.g. SUEntitiesRef).
        /// </summary>
        /// <param name="sectionPlane">[in] The sectionPlane object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if sectionPlane points to an NULL
        /// SU_ERROR_INVALID_INPUT if the sectionPlane object is not a valid object.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSectionPlaneRelease(ref SUSectionPlaneRef sectionPlane);

        /// <summary>
        /// Sets the plane of the section plane.
        /// </summary>
        /// <param name="sectionPlane">[in] The sectionPlane object.</param>
        /// <param name="plane">[in] The 3d plane to be set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if sectionPlane is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if plane is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSectionPlaneSetPlane(SUSectionPlaneRef sectionPlane, ref SUPlane3D plane);

        /// <summary>
        /// Retrieves the plane of the section plane.
        /// </summary>
        /// <param name="sectionPlane">[in] The sectionPlane object.</param>
        /// <param name="plane">[out] The 3d plane retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if sectionPlane is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if plane is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSectionPlaneGetPlane(SUSectionPlaneRef sectionPlane, ref SUPlane3D plane);

        /// <summary>
        /// Retrieves a boolean indicating whether or not the section plane is active.
        /// </summary>
        /// <param name="sectionPlane">[in] The sectionPlane object.</param>
        /// <param name="plane">[out] Returns true if the section plane is active. </param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if sectionPlane is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if is_active is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSectionPlaneIsActive(SUSectionPlaneRef sectionPlane, ref bool is_active);

        /// <summary>
        /// Retrieves the name of a section plane object. 
        /// </summary>
        /// <param name="sectionPlane">[in] The section plane object.</param>
        /// <param name="name">[out] The name retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if sectionPlane is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if name is NULL
        /// SU_ERROR_INVALID_OUTPUT if name does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSectionPlaneGetName(SUSectionPlaneRef sectionPlane, ref SUStringRef name);

        /// <summary>
        /// Sets the name of a section plane object.
        /// </summary>
        /// <param name="sectionPlane">[in] The sectionPlane object.</param>
        /// <param name="name">[in] The string to set as the section plane name. Assumed to be UTF-8 encoded. An example of a name would
        /// be "South West Section" for the section on the south west side of a building.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if sectionPlane is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if name is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSectionPlaneSetName(SUSectionPlaneRef sectionPlane, string name);

        /// <summary>
        /// Retrieves the symbol of a section plane object. The symbol is used in
        /// the Outliner and in the section display in the model. For example, you
        /// might have several sections on the same area of a building all named
        /// "South West Section" and use symbols to differenciate each section,
        /// "01", "02", "03".
        /// </summary>
        /// <param name="sectionPlane">[in] The section plane object.</param>
        /// <param name="symbol">[out] The symbol retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if sectionPlane is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if symbol is NULL
        /// SU_ERROR_INVALID_OUTPUT if symbol does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSectionPlaneGetSymbol(SUSectionPlaneRef sectionPlane, ref SUStringRef symbol);

        /// <summary>
        /// Sets the symbol of a section plane object.
        /// </summary>
        /// <param name="sectionPlane">[in] The sectionPlane object.</param>
        /// <param name="symbol">[in] The string to set as the section plane symbol. Assumed to be UTF-8 encoded.  The maximum number of characters is 3.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if sectionPlane is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if symbol is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUSectionPlaneSetSymbol(SUSectionPlaneRef sectionPlane, string symbol);

    }
}
