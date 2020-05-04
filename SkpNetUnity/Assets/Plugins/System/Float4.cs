using UnityEngine;

namespace System
{
    public class Float4
    {
        public float x { set; get; }

        public float y { set; get; }

        public float z { set; get; }

        public float w { get; set; }

        public static implicit operator Float4(Quaternion p_value)
        {
            if (p_value == null)
            {
                return new Float4();
            }

            return new Float4()
            {
                x = p_value.x,
                y = p_value.y,
                z = p_value.z,
                w = p_value.w
            };
        }

        public static implicit operator Float4(Vector4 p_value)
        {
            if (p_value == null)
            {
                return new Float4();
            }

            return new Float4()
            {
                x = p_value.x,
                y = p_value.y,
                z = p_value.z,
                w = p_value.w
            };
        }

        public static implicit operator Float4(Color color)
        {
            return new Float4()
            {
                x = color.r,
                y = color.g,
                z = color.b,
                w = color.a
            };
        }

        public static implicit operator Quaternion(Float4 p_value)
        {
            if (p_value == null)
                return Quaternion.identity;
            return new Quaternion(p_value.x, p_value.y, p_value.z, p_value.w);
        }

        public static implicit operator Vector4(Float4 p_value)
        {
            if (p_value == null)
                return Vector4.zero;
            return new Vector4(p_value.x, p_value.y, p_value.z, p_value.w);
        }

        public static implicit operator Color(Float4 value)
        {
            if (value == null)
                return Color.white;
            return new Color(value.x, value.y, value.z, value.w);
        }

        public Float3 eulerAngles => new Quaternion(x, y, z, w).eulerAngles;
    }
}
