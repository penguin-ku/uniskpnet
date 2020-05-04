using UnityEngine;

namespace System
{
    public class Float2
    {
        public float x { set; get; }

        public float y { set; get; }

        public static implicit operator Float2(Vector2 p_value)
        {
            if (p_value == null)
            {
                return new Float2();
            } 

            return new Float2()
            {
                x = p_value.x,
                y = p_value.y
            };
        }

        public static implicit operator Vector2(Float2 p_value)
        {
            if (p_value == null)
                return Vector2.zero;
            return new Vector2(p_value.x, p_value.y);
        }
    }
}
