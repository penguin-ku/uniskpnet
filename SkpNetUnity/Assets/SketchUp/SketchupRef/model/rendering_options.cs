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
    /// Used to get and set values in a rendering options object.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct SURenderingOptionsRef
    {
        public IntPtr ptr;
        
    }

    public static partial class SKPCExport
    {
        /// <summary>
        /// Gets the number of available rendering options keys.
        /// </summary>
        /// <param name="rendering_options">[in] The rendering options object.</param>
        /// <param name="count">[out] The number of keys available.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if rendering_options is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if count is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SURenderingOptionsGetNumKeys(SURenderingOptionsRef rendering_options, ref size_t count);

        /// <summary>
        /// Retrieves keys associated with the rendering options object.
        /// </summary>
        /// <param name="rendering_options">[in] The rendering options object.</param>
        /// <param name="len">[in] The number of keys to retrieve.</param>
        /// <param name="keys">[out] The keys retrieved.</param>
        /// <param name="count">[out] The number of keys retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if rendering_options is not a valid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if keys or count is NULL
        /// SU_ERROR_INVALID_OUTPUT if any of the strings in the keys array are invalid.
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SURenderingOptionsGetKeys(SURenderingOptionsRef rendering_options, size_t len, SUStringRef[] keys, ref size_t count);

        /// <summary>
        /// Sets values in a rendering options object.
        /// </summary>
        /// <param name="rendering_options">[in] The rendering options object.</param>
        /// <param name="key">[in] The key. Assumed to be UTF-8 encoded.</param>
        /// <param name="value_in">[in] The value used to set the option.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if rendering_options or value_in is an invalid object
        /// SU_ERROR_NULL_POINTER_INPUT if key is NULL
        /// </returns>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SURenderingOptionsSetValue(SURenderingOptionsRef rendering_options,string key,SUTypedValueRef value_in);

        /// <summary>
        /// Retrieves the value of a given rendering option.
        /// </summary>
        /// <param name="rendering_options">[in] The rendering options object.</param>
        /// <param name="key">[in] The key. Assumed to be UTF-8 encoded.</param>
        /// <param name="value_out">[out] The value retrieved.</param>
        /// <returns>
        /// SU_ERROR_NONE on success
        /// SU_ERROR_INVALID_INPUT if rendering_options is an invalid object
        /// SU_ERROR_NULL_POINTER_INPUT if key is NULL
        /// SU_ERROR_INVALID_OUTPUT if value_out is an invalid object
        /// SU_ERROR_NULL_POINTER_OUTPUT if value_out is NULL
        /// </returns>
        /// <remarks>
        /// The breakdown of rendering options and value types is shown in the table below.
        /// 
        /// Rendering Option         | Value Type
        /// ------------------------ | ----------------------
        /// BackgroundColor          | SUTypedValueType_Color
        /// BandColor                | SUTypedValueType_Color
        /// ConstructionColor        | SUTypedValueType_Color
        /// DepthQueWidth            | SUTypedValueType_Int32
        /// DisplayColorByLayer      | SUTypedValueType_Bool
        /// DisplayDims              | SUTypedValueType_Bool
        /// DisplayFog               | SUTypedValueType_Bool
        /// DisplayInstanceAxes      | SUTypedValueType_Bool
        /// DisplaySectionPlanes(since SketchUp 2014, API 2.0) | SUTypedValueType_Bool
        /// DisplaySketchAxes        | SUTypedValueType_Bool
        /// DisplayText              | SUTypedValueType_Bool
        /// DisplayWatermarks        | SUTypedValueType_Bool
        /// DrawDepthQue             | SUTypedValueType_Bool
        /// DrawGround               | SUTypedValueType_Bool
        /// DrawHidden               | SUTypedValueType_Bool
        /// DrawHorizon              | SUTypedValueType_Bool
        ///  DrawLineEnds             | SUTypedValueType_Bool
        /// DrawProfilesOnly         | SUTypedValueType_Bool
        /// DrawSilhouettes          | SUTypedValueType_Bool
        /// DrawUnderground          | SUTypedValueType_Bool
        /// EdgeColorMode            | SUTypedValueType_Int32
        /// EdgeDisplayMode          | SUTypedValueType_Int32
        /// EdgeType                 | SUTypedValueType_Int32
        /// ExtendLines              | SUTypedValueType_Bool
        /// FaceBackColor            | SUTypedValueType_Color
        /// FaceColorMode            | SUTypedValueType_Int32
        /// FaceFrontColor           | SUTypedValueType_Color
        /// FogColor                 | SUTypedValueType_Color
        /// FogEndDist               | SUTypedValueType_Double
        /// FogStartDist             | SUTypedValueType_Double
        /// FogUseBkColor            | SUTypedValueType_Bool
        /// ForegroundColor          | SUTypedValueType_Color
        /// GroundColor              | SUTypedValueType_Color
        /// GroundTransparency       | SUTypedValueType_Int32
        /// HideConstructionGeometry | SUTypedValueType_Bool
        /// HighlightColor           | SUTypedValueType_Color
        /// HorizonColor             | SUTypedValueType_Color
        /// InactiveFade             | SUTypedValueType_Double
        /// InactiveHidden           | SUTypedValueType_Bool
        /// InstanceFade             | SUTypedValueType_Double
        /// InstanceHidden           | SUTypedValueType_Bool
        /// JitterEdges              | SUTypedValueType_Bool
        /// LineEndWidth             | SUTypedValueType_Int32
        /// LineExtension            | SUTypedValueType_Int32
        /// LockedColor              | SUTypedValueType_Color
        /// MaterialTransparency     | SUTypedValueType_Bool
        /// ModelTransparency        | SUTypedValueType_Bool
        /// RenderMode               | SUTypedValueType_Int32
        /// SectionActiveColor       | SUTypedValueType_Color
        /// SectionCutFilled(since SketchUp 2018, API 6.0) | SUTypedValueType_Bool
        /// SectionCutWidth          | SUTypedValueType_Int32
        /// SectionDefaultCutColor   | SUTypedValueType_Color
        /// SectionDefaultFillColor(since SketchUp 2018, API 6.0) | SUTypedValueType_Color
        /// SectionInactiveColor     | SUTypedValueType_Color
        /// ShowViewName             | SUTypedValueType_Bool
        /// SilhouetteWidth          | SUTypedValueType_Int32
        /// SkyColor                 | SUTypedValueType_Color
        /// Texture                  | SUTypedValueType_Bool
        /// TransparencySort         | SUTypedValueType_Int32
        /// 
        /// Some of the options map to enumerated values, as shown in the table below.
        /// 
        /// Option          | Value | Meaning
        /// --------------- | ----- | -------
        /// EdgeColorMode   | 0:    | ObjectColor
        /// &nbsp;          | 1:    | ForegroundColor
        /// &nbsp;          | 2:    | DirectionColor
        /// EdgeDisplayMode | 0:    | EdgeDisplayNone
        /// &nbsp;          | 1:    | EdgeDisplayAll
        /// &nbsp;          | 2:    | EdgeDisplayStandalone
        /// RenderMode      | 0:    | RenderWireframe
        /// &nbsp;          | 1:    | RenderHidden
        /// &nbsp;          | 2:    | RenderFlat
        /// &nbsp;          | 3:    | RenderSmooth
        /// &nbsp;          | 4:    | RenderTextureObsolete
        /// &nbsp;          | 5:    | RenderNoMaterials
        /// FaceColorMode   | 0:    | TwoSided
        /// &nbsp;          | 1:    | OneSided
        /// EdgeType        | 0:    | EdgeStandard
        /// &nbsp;          | 1:    | EdgeNPR
        /// </remarks>
        [DllImport("SketchUpAPI")]
        public static extern SU_RESULT SURenderingOptionsGetValue(SURenderingOptionsRef rendering_options, string key, ref SUTypedValueRef value_out);
    }
}
