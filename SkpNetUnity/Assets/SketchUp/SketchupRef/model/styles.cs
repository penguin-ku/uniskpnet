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
    /// A styles entity reference.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SUStylesRef
    {
        public IntPtr ptr;
    }

    /// <summary>
    /// styles
    /// </summary>
    public static partial class SKPCExport
    {
        /// <summary>
        /// Adds a new style to the styles with the specified name.
        /// </summary>
        /// <param name="styles">[in] The styles object.</param>
        /// <param name="path">[in] The string specifying the file path to the new style.</param>
        /// <param name="activate">[in] If true activate the style</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if styles is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if name is NULL
        /// SU_ERROR_SERIALIZATION if style couldn't be created from the file at path
        /// SU_ERROR_DUPLICATE if the name corresponds to an existing style
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern  SU_RESULT SUStylesAddStyle(SUStylesRef styles, string path, bool activate);

        /// <summary>
        /// Retrieves the number of styles in a styles object.
        /// </summary>
        /// <param name="styles">[in] The styles object.</param>
        /// <param name="count">[out] The number of style objects available.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if styles is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStylesGetNumStyles(SUStylesRef styles, ref size_t count);

        /// <summary>
        /// Retrieves all the styles associated with a styles object.
        /// </summary>
        /// <param name="styles">[in] The styles object.</param>
        /// <param name="len">[in] The number of style objects to retrieve.</param>
        /// <param name="style_array">[out] The style objects retrieved.</param>
        /// <param name="count">[out] The number of style objects retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if styles is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if style_array or count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStylesGetStyles(SUStylesRef styles, size_t len, SUStyleRef[] style_array, ref size_t count);

        /// <summary>
        /// Retrieves the active style.
        /// </summary>
        /// <param name="styles">[in] The styles object.</param>
        /// <param name="style">[out] Pointer to a SUStyleRef for returning the style.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if styles is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if style is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStylesGetActiveStyle(SUStylesRef styles, ref SUStyleRef style);

        /// <summary>
        /// Retrieves the selected style.
        /// </summary>
        /// <param name="styles">[in] The styles object.</param>
        /// <param name="style">[out] Pointer to a SUStyleRef for returning the style.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if styles is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if style is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStylesGetSelectedStyle(SUStylesRef styles, ref SUStyleRef style);

        /// <summary>
        /// Retrieves the style corresponding to the specified Guid.
        /// </summary>
        /// <param name="styles">[in] The styles object.</param>
        /// <param name="guid">[in] The string specifying a style by Guid.</param>
        /// <param name="style">[out] Pointer to a SUStyleRef for returning the style.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if styles is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if guid is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if style is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStylesGetStyleByGuid(SUStylesRef styles, string guid, ref SUStyleRef style);

        /// <summary>
        /// Retrieves the style corresponding to the specified path.
        /// </summary>
        /// <param name="styles">[in] The styles object.</param>
        /// <param name="path">[in] The string specifying a style by path.</param>
        /// <param name="style">[out] Pointer to a SUStyleRef for returning the style.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if styles is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if path is NULL
        /// SU_ERROR_NULL_POINTER_OUTPUT if style is NULL
        /// SU_ERROR_NO_DATA if no style in styles matches the style at path.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStylesGetStyleByPath(SUStylesRef styles, string path, ref SUStyleRef style);

        /// <summary>
        /// Retrieves a bolean indicating if the active style has changed.
        /// </summary>
        /// <param name="styles">[in] The styles object.</param>
        /// <param name="changed">[out] Returns true if the active style was changed.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if styles is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if changed is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStylesGetActiveStyleChanged(SUStylesRef styles, ref bool changed);

        /// <summary>
        /// Applies the specified style to the specified scene
        /// </summary>
        /// <param name="styles">[in] The styles object.</param>
        /// <param name="style">[in] The style to be applied to a scene.</param>
        /// <param name="scene">[in] The scene to which the style will be applied.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if any of styles, style, or scene are not valid objects
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStylesApplyStyleToScene(SUStylesRef styles, SUStyleRef style, SUSceneRef scene);

        /// <summary>
        /// Sets the selected style.
        /// </summary>
        /// <param name="styles">[in] The styles object.</param>
        /// <param name="style">[in] The style object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if styles or style are not valid objects
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStylesSetSelectedStyle(SUStylesRef styles, SUStyleRef style);

        /// <summary>
        /// Delete the selected style. The style will be removed from all scenes
        /// that use it and then released.The first different style in the style
        /// manager will replace the style on model pages. The manager must have at
        /// least one style remaining.
        /// </summary>
        /// <param name="styles">[in] The styles object.</param>
        /// <param name="style">[in,out] The style object.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if styles is not a valid object
        /// SU_ERROR_NULL_POINTER_INPUT if style is NULL
        /// SU_ERROR_INVALID_ARGUMENT if style is not within styles
        /// SU_ERROR_OUT_OF_RANGE if the style is the last style in the manager
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SUStylesRemoveStyle(SUStylesRef styles, ref SUStyleRef style);
    }
}
