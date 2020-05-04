using PgSkpDK.SketchupRef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgSkpDK.SketchupWrapper
{
    /// <summary>
    /// 数据类型
    /// </summary>
    public enum DataType
    {
        None = 0,
        Byte,
        Short,
        Int32,
        Float,
        Double,
        Bool,
        Color,
        Time,
        String,
        Vector3D,
        Array
    }

    /// <summary>
    /// 数据
    /// </summary>
    public class SkpDataValue
    {
        #region private members

        private DataType m_dataType;
        private object m_value;

        #endregion

        #region public properties

        public DataType DataType
        {
            set
            {
                m_dataType = value;
            }
            get
            {
                return m_dataType;
            }
        }

        public object Value
        {
            set
            {
                m_value = value;
            }
            get
            {
                return m_value;
            }
        }

        #endregion

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="p_dataType"></param>
        /// <param name="p_value"></param>
        public SkpDataValue(DataType p_dataType, object p_value)
        {
            m_dataType = p_dataType;
            m_value = p_value;
        }


        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="value"></param>
        public SkpDataValue(SUTypedValueRef value)
        {
            SUTypedValueType type = SUTypedValueType.SUTypedValueType_Empty;
            SKPCExport.SUTypedValueGetType(value, ref type);
            m_dataType = (DataType)type;

            switch (type)
            {
                case SUTypedValueType.SUTypedValueType_Empty:
                    {
                        m_value = null;
                        break;
                    }
                case SUTypedValueType.SUTypedValueType_Byte:
                    {
                        byte temp = default;
                        SKPCExport.SUTypedValueGetByte(value, ref temp);
                        m_value = temp;
                        break;
                    }
                case SUTypedValueType.SUTypedValueType_Short:
                    {
                        short temp = default;
                        SKPCExport.SUTypedValueGetInt16(value, ref temp);
                        m_value = temp;
                        break;
                    }
                case SUTypedValueType.SUTypedValueType_Int32:
                    {
                        int temp = default;
                        SKPCExport.SUTypedValueGetInt32(value, ref temp);
                        m_value = temp;
                        break;
                    }
                case SUTypedValueType.SUTypedValueType_Float:
                    {
                        float temp = default;
                        SKPCExport.SUTypedValueGetFloat(value, ref temp);
                        m_value = temp;
                        break;
                    }
                case SUTypedValueType.SUTypedValueType_Double:
                    {
                        double temp = default;
                        SKPCExport.SUTypedValueGetDouble(value, ref temp);
                        m_value = temp;
                        break;
                    }
                case SUTypedValueType.SUTypedValueType_Bool:
                    {
                        bool temp = default;
                        SKPCExport.SUTypedValueGetBool(value, ref temp);
                        m_value = temp;
                        break;
                    }
                case SUTypedValueType.SUTypedValueType_Color:
                    {
                        SUColor temp = default;
                        SKPCExport.SUTypedValueGetColor(value, ref temp);
                        m_value = /*new SkpColor(temp)*/temp;
                        break;
                    }
                case SUTypedValueType.SUTypedValueType_Time:
                    {
                        long temp = default;
                        SKPCExport.SUTypedValueGetTime(value, ref temp);
                        m_value = new System.DateTime(1970, 1, 1).AddSeconds(temp);
                        break;
                    }
                case SUTypedValueType.SUTypedValueType_String:
                    {
                        SUStringRef temp = default;
                        SKPCExport.SUStringCreate(ref temp);
                        SKPCExport.SUTypedValueGetString(value, ref temp);
                        m_value = Utilities.GetString(temp);
                        SKPCExport.SUStringRelease(ref temp);
                        break;
                    }
                case SUTypedValueType.SUTypedValueType_Vector3D:
                    {
                        double[] temp = new double[3];
                        SKPCExport.SUTypedValueGetVector3d(value, temp);
                        m_value = new SUVector3D { x = temp[0], y = temp[1], z = temp[2] };
                        break;
                    }
                case SUTypedValueType.SUTypedValueType_Array:
                    {
                        long count = default;
                        SKPCExport.SUTypedValueGetNumArrayItems(value, ref count);
                        SUTypedValueRef[] values = new SUTypedValueRef[count];
                        SKPCExport.SUTypedValueGetArrayItems(value, count, values, ref count);
                        SkpDataValue[] temp = new SkpDataValue[count];
                        for (int i = 0; i < count; i++)
                        {
                            temp[i] = new SkpDataValue(values[i]);
                        }
                        m_value = temp;
                        break;
                    }
                default:
                    break;
            }
        }

        public override string ToString()
        {
            return m_value.ToString();
        }

    }
}
