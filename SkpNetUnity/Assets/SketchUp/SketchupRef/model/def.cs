using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace PgSkpDK.SketchupRef
{
    /// <summary>
    /// Types of concrete object references.
    /// </summary>
    public enum SURefType
    {
        SURefType_Unknown = 0,
        SURefType_AttributeDictionary,
        SURefType_Camera,
        SURefType_ComponentDefinition,
        SURefType_ComponentInstance,
        SURefType_Curve,
        SURefType_Edge,
        SURefType_EdgeUse,
        SURefType_Entities,
        SURefType_Face,
        SURefType_Group,
        SURefType_Image,
        SURefType_Layer,
        SURefType_Location,
        SURefType_Loop,
        SURefType_MeshHelper,
        SURefType_Material,
        SURefType_Model,
        SURefType_Polyline3D,
        SURefType_Scene,
        SURefType_Texture,
        SURefType_TextureWriter,
        SURefType_TypedValue,
        SURefType_UVHelper,
        SURefType_Vertex,
        SURefType_RenderingOptions,
        SURefType_GuidePoint,
        SURefType_GuideLine,
        SURefType_Schema,
        SURefType_SchemaType,
        SURefType_ShadowInfo,
        SURefType_Axes,
        SURefType_ArcCurve,
        SURefType_SectionPlane,
        SURefType_DynamicComponentInfo,
        SURefType_DynamicComponentAttribute,
        SURefType_Style,
        SURefType_Styles,
        SURefType_ImageRep,
        SURefType_InstancePath,
        SURefType_Font,
        SURefType_Dimension,
        SURefType_DimensionLinear,
        SURefType_DimensionRadial,
        SURefType_DimensionStyle,
        SURefType_Text,
        SURefType_EntityList,
        SURefType_EntityListIterator,
        SURefType_DrawingElement,
        SURefType_Entity,
        SURefType_LengthFormatter
    };
}
