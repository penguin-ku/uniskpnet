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
    /// A text entity reference.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUTextRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// Indicates the supported leader line types
    /// </summary>
    public enum SUTextLeaderType
    {
        SUTextLeaderType_None = 0,
        SUTextLeaderType_ViewBased,
        SUTextLeaderType_PushPin
    };

    /// <summary>
    /// texture
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Converts from an SUTextRef to an SUEntityRef.
        /// This is essentially an upcast operation.
        /// </summary>
        /// <param name="text">[in] The given text reference.</param>
        /// <returns>
        /// The converted SUEntityRef if text is a valid text.
        /// If not, the returned reference will be invalid.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUEntityRef SUTextToEntity(SUTextRef text);

        /// <summary>
        /// Converts from an SUEntityRef to an SUTextRef.
        /// This is essentially a downcast operation so the given entity must be
        /// convertible to an SUTextRef.
        /// </summary>
        /// <param name="entity">[in] The given entity reference.</param>
        /// <returns>
        /// The converted SUTextRef if the downcast operation succeeds
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUTextRef SUTextFromEntity(SUEntityRef entity);

        /// <summary>
        /// Converts from an SUTextRef to an SUDrawingElementRef.
        /// This is essentially an upcast operation.
        /// </summary>
        /// <param name="text">[in] The given text reference.</param>
        /// <returns>
        /// The converted SUDrawingElementRef if text is a valid text.
        /// If not, the returned reference will be invalid.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUDrawingElementRef SUTextToDrawingElement(SUTextRef text);

        /// <summary>
        /// Converts from an SUDrawingElementRef to an SUTextRef.
        /// This is essentially a downcast operation so the given entity must be
        /// convertible to an SUTextRef.
        /// </summary>
        /// <param name="entity">[in] The given entity reference.</param>
        /// <returns>
        /// The converted SUTextRef if the downcast operation succeeds
        /// If not, the returned reference will be invalid
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SUTextRef SUTextFromDrawingElement(SUDrawingElementRef entity);

        /// <summary>
        /// Creates a text edge object. The text object must be subsequently deallocated with SUTextRelease  unless the text object is associated with a parent object.
        /// subsequently deallocated with SUPolyline3dRelease unless it is
        /// associated with a parent object.
        /// </summary>
        /// <param name="text">[out] The text object created.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_OUTPUT if text is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextCreate(ref SUTextRef text);

        /// <summary>
        /// Releases a text object. The text object must have been created with SUTextCreate and not subsequently associated with a parent object (e.g. SUEntitiesAddTexts).
        /// </summary>
        /// <param name="text">[in] The text object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_NULL_POINTER_INPUT if text points to an NULL
        /// SU_ERROR_INVALID_INPUT if the text object is not a valid object.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextRelease(ref SUTextRef text);

        /// <summary>
        /// Retrieves the string from the text object
        /// </summary>
        /// <param name="text">[in] The text object.</param>
        /// <param name="pstring">[out] The string retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if text is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if pstring is NULL
        /// SU_ERROR_INVALID_OUTPUT if pstring does not point to a valid SUStringRef object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextGetString(SUTextRef text, out SUStringRef pstring);

        /// <summary>
        /// Sets the name of a section plane object.
        /// </summary>
        /// <param name="text">[in] The text object.</param>
        /// <param name="pstring">[in] The string to set as the section plane name. Assumed to be UTF-8 encoded. An example of a name would
        /// be "South West Section" for the section on the south west side of a building.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if text is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if name is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextSetString(SUTextRef text, string pstring);

        /// <summary>
        /// Retrieves the string from the text object
        /// </summary>
        /// <param name="text">[in] The text object.</param>
        /// <param name="font">[out] The font retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if text is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if font is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextGetFont(SUTextRef text, ref SUFontRef font);

        /// <summary>
        /// Sets the name of a section plane object.
        /// </summary>
        /// <param name="text">[in] The text object.</param>
        /// <param name="font">[in] The font to set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if text or font is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextSetFont(SUTextRef text, SUFontRef font);

        /// <summary>
        /// Retrieves the leader type from the text object
        /// </summary>
        /// <param name="text">[in] The text object.</param>
        /// <param name="leader">[out] The leader retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if text is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if leader is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextGetLeaderType(SUTextRef text, out SUTextLeaderType leader);

        /// <summary>
        /// Sets the leader type to the text object
        /// </summary>
        /// <param name="text">[in] The text object.</param>
        /// <param name="leader">[in] The leader to set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if text or leader is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextSetLeaderType(SUTextRef text, SUTextLeaderType leader);

        /// <summary>
        /// Retrieves the arrow type from the text object
        /// </summary>
        /// <param name="text">[in] The text object.</param>
        /// <param name="arrow_type">[out] The arrow type retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if text is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if arrow_type is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextGetArrowType(SUTextRef text, ref SUArrowType arrow_type);

        /// <summary>
        /// Sets the arrow type to the text object
        /// </summary>
        /// <param name="text">[in] The text object.</param>
        /// <param name="arrow_type">[in] The arrow type to set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if text is not a valid object
        /// SU_ERROR_OUT_OF_RANGE if arrow_type is not a valid value
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextSetArrowType(SUTextRef text, SUArrowType arrow_type);

        /// <summary>
        /// Retrieves the point associated with the text object. The given instance 
        /// path object either must have been constructed using one of the
        /// SUInstancePathCreate* functions or it will be generated on the fly if it
        /// is invalid. It must be released using SUInstancePathRelease when it
        /// is no longer needed.
        /// </summary>
        /// <param name="text">[in] The text object.</param>
        /// <param name="point">[out] The point retrieved.</param>
        /// <param name="path">[out] The path retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if text is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if path or point is NULL
        /// SU_ERROR_INVALID_OUTPUT if path is not a valid object
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextGetPoint(SUTextRef text, ref SUPoint3D point, ref SUInstancePathRef path);

        /// <summary>
        /// Sets the connection point of a text object. A text's connection point can
        /// be set in a few different ways. In the simplest form a connection point
        /// can be set to an arbitrary point in space by providing a non-null \ref
        /// SUPoint3D and an invalid SUInstancePathRef. The more complex forms
        /// to connect the point to a position on an entity in the model by providing
        /// a valid SUInstancePathRef which refers to an existing model entity.
        /// In the more complex forms the input SUPoint3D must be non-null for all
        /// connectable entity types except for vertices and guide points, in which
        /// case the SUPoint3D argument may be null as it will be ignored. It
        /// should be noted that when changing a text's connection point the other
        /// point may need to be adjusted as well. Users may want to verify the other
        /// connection point after setting this one.
        /// </summary>
        /// <param name="text">[in] The text object.</param>
        /// <param name="arrow_type">[in] The point to set.</param>
        /// <param name="point">[in] The instance path to be set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if text is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if path is invalid and point is NULL
        /// SU_ERROR_INVALID_ARGUMENT path is valid but refers to an invalid instance path
        /// SU_ERROR_GENERIC if point is NULL and path doesn't have a vertex or guide point for its leaf
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextSetPoint(SUTextRef text, ref SUPoint3D point, SUInstancePathRef arrow_type);

        /// <summary>
        /// Retrieves the leader vector associated with the text object
        /// </summary>
        /// <param name="text">[in] The text object.</param>
        /// <param name="vector">[out] The vector retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if text is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if vector is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextGetLeaderVector(SUTextRef text, ref SUVector3D vector);

        /// <summary>
        /// Sets the leader vector associated with the text object
        /// </summary>
        /// <param name="text">[in] The text object.</param>
        /// <param name="vector">[in] The vector to set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if text is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if vector is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextSetLeaderVector(SUTextRef text, SUVector3D vector);

        /// <summary>
        /// Retrieves the color from the text object
        /// </summary>
        /// <param name="text">[in] The text object.</param>
        /// <param name="color">[out] The color retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if text is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if color is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextGetColor(SUTextRef text, ref SUColor color);

        /// <summary>
        /// Sets the color to the text object
        /// </summary>
        /// <param name="text">[in] The text object.</param>
        /// <param name="color">[in] The color to set.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if text is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if color is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextSetColor(SUTextRef text, SUColor color);

        /// <summary>
        /// Sets the screen position for text with no leader.
        /// </summary>
        /// <param name="text">[in] The text object.</param>
        /// <param name="percent_x">[in] The x position on screen in a range of 0.0 - 1.0 relative to the screen width.</param>
        /// <param name="percent_y">[in] The y position on screen in a range of 0.0 - 1.0 relative to the screen height.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if text is not a valid object
        /// SU_ERROR_NO_DATA if the text has a leader to position with.
        /// SU_ERROR_OUT_OF_RANGE if a leader exists, or if the percentages are not between 0 and 1 inclusive.
         /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextSetScreenPosition(SUTextRef text, double percent_x,double percent_y);

        /// <summary>
        /// Retrieves the screen location for text with no leader.
        /// </summary>
        /// <param name="text">[in] The text object.</param>
        /// <param name="percent_x">[out] The percent of screen width to the text position.</param>
        /// <param name="percent_y">[out] The percent of screen height to the text position.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if text is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if either percent is NULL
        /// SU_ERROR_NO_DATA if text has a leader
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUTextGetScreenPosition(SUTextRef text, ref double percent_x, ref double percent_y);
    }
}
