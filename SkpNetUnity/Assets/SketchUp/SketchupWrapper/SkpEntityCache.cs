using PgSkpDK.SketchupRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgSkpDK.SketchupWrapper
{
    public static class SkpEntityCache
    {
        #region public static functions

        /// <summary>
        /// 获取唯一标记
        /// </summary>
        /// <param name="suEntity"></param>
        /// <param name="p_indentityDefault"></param>
        /// <returns></returns>
        public static string GetIdentity(SUEntityRef suEntity)
        {
            if (suEntity.ptr == IntPtr.Zero)
            {
                return null;
            }

            long persistentID = default;
            SKPCExport.SUEntityGetPersistentID(suEntity, ref persistentID);
            if (persistentID != 0)
            {
                string identityStr = persistentID.ToString();
                return identityStr;
            }

            if (GetAttribute(suEntity, "Sandu", "Identity", out string identitySandu))
            {
                return identitySandu;
            }

            int entityID = default;
            SKPCExport.SUEntityGetID(suEntity, ref entityID);
            string identityID = entityID.ToString();
            return identityID;
        }

        /// <summary>
        /// 获取属性值
        /// </summary>
        /// <param name="suEntityRef"></param>
        /// <param name="attributeName"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static bool GetAttribute(SUEntityRef suEntityRef, string attributeName, string propertyName, out string defaultValue)
        {
            if (suEntityRef.ptr == IntPtr.Zero)
            {
                defaultValue = null;
                return false;
            }
            SUAttributeDictionaryRef dictionaryRef = default(SUAttributeDictionaryRef);
            if (SKPCExport.SUEntityGetAttributeDictionary(suEntityRef, attributeName, ref dictionaryRef) == SUResult.SU_ERROR_NONE)
            {
                SUTypedValueRef propertyValueRef = default(SUTypedValueRef);
                if (SKPCExport.SUAttributeDictionaryGetValue(dictionaryRef, attributeName, ref propertyValueRef) == SUResult.SU_ERROR_NONE)
                {
                    SUStringRef temp = default;
                    SKPCExport.SUStringCreate(ref temp);
                    SKPCExport.SUTypedValueGetString(propertyValueRef, ref temp);
                    defaultValue = Utilities.GetString(temp);
                    SKPCExport.SUStringRelease(ref temp);
                    return true;
                }
            }
            defaultValue = null;
            return false;
        }

        public static string GetMaterialDefault(SUDrawingElementRef element)
        {
            SUMaterialRef suMaterialRef = default(SUMaterialRef);
            SKPCExport.SUDrawingElementGetMaterial(element, ref suMaterialRef);
            return GetIdentity(SKPCExport.SUMaterialToEntity(suMaterialRef));
        }

        #endregion
    }
}
