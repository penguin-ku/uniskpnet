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
    /// A style entity reference.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUStyleRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// The set style properties that can be set/retrieved. Each property supports a single data type indicated by comments in the list.
    /// </summary>
    public enum SUStylePropertyType
    {
        /// <summary>
        /// SUTypedValueType_Color.
        /// </summary>
        SUStyleEdgesColor = 0,
        /// <summary>
        /// SUTypedValueType_Bool.
        /// </summary>
        SUStyleEdgesExtensionsEnabled = 1,
        /// <summary>
        /// SUTypedValueType_Int32.
        /// </summary>
        SUStyleEdgesExtensionLength = 2,
        /// <summary>
        /// SUTypedValueType_Bool.
        /// </summary>
        SUStyleEdgesProfilesEnabled = 3,
        /// <summary>
        /// SUTypedValueType_Int32.
        /// </summary>
        SUStyleEdgesProfileWidth = 4,
        /// <summary>
        /// SUTypedValueType_Bool.
        /// </summary>
        SUStyleEdgesDepthCueEnabled = 5,
        /// <summary>
        /// SUTypedValueType_Int32.
        /// </summary>
        SUStyleEdgesDepthCueLevels = 6,
        /// <summary>
        ///  SUTypedValueType_Color.
        /// </summary>
        SUStyleBackgroundColor = 64
    }

    /// <summary>
    /// style
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Converts from an SUStyleRef to an SUEntityRef.
        /// This is essentially an upcast operation.
        /// </summary>
        /// <param name="style">[in] The given style reference.</param>
        /// <returns>
        /// The converted SUEntityRef if style is a valid style.
        /// If not, the returned reference will be invalid.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUEntityRef SUStyleToEntity(SUStyleRef style);

        /// <summary>
        /// Converts from an SUEntityRef to an SUStyleRef.
        /// This is essentially a downcast operation so the given entity must be
        /// convertible to an SUStyleRef.
        /// </summary>
        /// <param name="entity">[in] The given entity reference.</param>
        /// <returns>
        /// The converted SUStyleRef if the downcast operation succeeds
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUStyleRef SUStyleFromEntity(SUEntityRef entity);

        /// <summary>
        /// Creates an style object. The style object must be
        /// subsequently deallocated with style unless it is
        /// associated with a parent object.  The plane is initialized as an xy
        /// plane and can be changed with the style.
        /// subsequently deallocated with SUPolyline3dRelease unless it is
        /// associated with a parent object.
        /// </summary>
        /// <param name="style">[out] The style object created.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if style is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStyleCreate(out SUStyleRef style);

        /// <summary>
        /// Releases a style object. The style object must have been created with 
        /// style and not subsequently associated with a parent object (e.g. SUEntitiesRef).
        /// </summary>
        /// <param name="style">[in] The style object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if style points to an NULL
        /// SU_ERROR_INVALID_INPUT if the style object is not a valid object.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStyleRelease(ref SUStyleRef style);

        /// <summary>
        /// Creates a style object from a file at the given path.
        /// </summary>
        /// <param name="style">[in] The style object created.</param>
        /// <param name="path">[in] The file path. Assumed to be UTF-8 encoded.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if style is NULL
        /// SU_ERROR_OVERWRITE_VALID if *style already refers to a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if path is NULL
        /// SU_ERROR_SERIALIZATION if style couldn't be created from the file at path
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStyleCreate(out SUStyleRef style, string path);

        /// <summary>
        /// Retrieves the name of a style object. 
        /// </summary>
        /// <param name="style">[in] The style object.</param>
        /// <param name="name">[out] The name retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if style is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if name is NULL
        /// SU_ERROR_INVALID_OUTPUT if name does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStyleGetName(SUStyleRef style, ref SUStringRef name);

        /// <summary>
        /// Sets the name of a style object.
        /// </summary>
        /// <param name="style">[in] The style object.</param>
        /// <param name="name">[in] TThe name string to set the style object. Assumed to be UTF-8 encoded.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if style is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if name is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStyleSetName(SUStyleRef style, string name);

        /// <summary>
        /// Retrieves the display name of a style object.  If the name begins with a
        /// wildcard character "*" the wildcard will be replaced be a default
        /// string.  The default string defaults to "*", so is no default string is
        /// set this function will always return the same string as GetName.
        /// </summary>
        /// <param name="style">[in] The style object.</param>
        /// <param name="name">[out] The name retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if style is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if name is NULL
        /// SU_ERROR_INVALID_OUTPUT if name does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStyleGetDisplayName(SUStyleRef style, ref SUStringRef name);

        /// <summary>
        /// Retrieves the description of a style object. 
        /// </summary>
        /// <param name="style">[in] The style object.</param>
        /// <param name="description">[out] The description retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if style is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if name is NULL
        /// SU_ERROR_INVALID_OUTPUT if name does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStyleGetDescription(SUStyleRef style, ref SUStringRef description);

        /// <summary>
        /// Sets the description of a style object.
        /// </summary>
        /// <param name="style">[in] The style object.</param>
        /// <param name="description">[in] TThe description string to set the style object. Assumed to be UTF-8 encoded.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if style is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if description is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStyleSetDescription(SUStyleRef style, string description);

        /// <summary>
        /// Retrieves the filepath to the file which was used to import this style.
        /// </summary>
        /// <param name="style">[in] The style object.</param>
        /// <param name="path">[out] The path retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if style is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if path is NULL
        /// SU_ERROR_INVALID_OUTPUT if path does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStyleGetPath(SUStyleRef style, ref SUStringRef path);

        /// <summary>
        /// Retrieves the GUID of a style object.
        /// </summary>
        /// <param name="style">[in] The style object.</param>
        /// <param name="guid">[out] The guid retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if style is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if guid is NULL
        /// SU_ERROR_INVALID_OUTPUT if guid does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStyleGetGuid(SUStyleRef style, ref SUStringRef guid);

        /// <summary>
        /// Retrieves a boolean indicating whether the style displays a watermark.
        /// </summary>
        /// <param name="style">[in] The style object.</param>
        /// <param name="shows_mark">[out] The boolean retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if style is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if shows_mark is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStyleGetDisplaysWatermark(SUStyleRef style, ref bool shows_mark);

        /// <summary>
        /// Saves the style data to the specified path.
        /// </summary>
        /// <param name="style">[in] The style object.</param>
        /// <param name="path">[in] The path to where the data should be saved. Assumed to be UTF-8 encoded.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if style is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if path is NULL
        /// SU_ERROR_SERIALIZATION if the save operation fails
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStyleSaveToFile(SUStyleRef style, string path);

        /// <summary>
        /// Retrieves a SUTypedValueRef containing the value of the specified SUStylePropertyType.
        /// </summary>
        /// <param name="style">[in] The style object.</param>
        /// <param name="type">[in] The style type to retrieve.</param>
        /// <param name="value">[out] The SUTypedValueRef retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if style is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if value is NULL
        /// SU_ERROR_INVALID_OUTPUT if value does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStyleGetProperty(SUStyleRef style, SUStylePropertyType type,ref SUTypedValueRef value);

        /// <summary>
        /// Sets the value of the specified SUStylePropertyType.
        /// </summary>
        /// <param name="style">[in] The style object.</param>
        /// <param name="type">[in] The style type to retrieve.</param>
        /// <param name="value">[in] The value to set for type.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if style is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if value is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStyleSetProperty(SUStyleRef style, SUStylePropertyType type,SUTypedValueRef value);

        /// <summary>
        /// Retrieves an image containing the style's thumbnail.  The given image
        /// representation object must have been constructed using \ref
        /// SUImageRepCreate. It must be released using SUImageRepRelease.
        /// </summary>
        /// <param name="style">[in] The style object.</param>
        /// <param name="image">[out] The image retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if style is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if shows_mark is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStyleGetThumbnail(SUStyleRef style, ref SUImageRepRef image);

    }
}
