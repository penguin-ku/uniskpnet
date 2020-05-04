using System.Linq;
using UnityEngine;

namespace System
{
    public static class UnityConvert
    {
        public static Vector3 ToVector3(string p_strSource, char p_seperator)
        {
            if (string.IsNullOrEmpty(p_strSource))
            {
                return Vector3.zero;
            }
            string[] strItems = p_strSource.Split(p_seperator);
            Vector3 vec = Vector3.zero;
            try
            {
                vec.x = float.Parse(strItems[0]);
                vec.y = float.Parse(strItems[1]);
                vec.z = float.Parse(strItems[2]);
                return vec;
            }
            catch
            {
                return Vector3.zero;
            }
        }

        public static Vector2 ToVector2(string p_strSource, char p_seperator)
        {
            if (string.IsNullOrEmpty(p_strSource))
            {
                return Vector2.zero;
            }
            string[] strItems = p_strSource.Split(p_seperator);
            Vector2 vec = Vector2.zero;
            try
            {
                vec.x = float.Parse(strItems[0]);
                vec.y = float.Parse(strItems[1]);
                return vec;
            }
            catch
            {
                return Vector2.zero;
            }
        }

        public static Vector3[] ToVerctor3Array(string p_strSource, char p_seperator0, char p_seperator1)
        {
            if (string.IsNullOrEmpty(p_strSource))
            {
                return new Vector3[0];
            }
            string[] strItems = p_strSource.Split(p_seperator0);
            Vector3[] vecArray = new Vector3[strItems.Length];
            for (int i = 0; i < strItems.Length; i++)
            {
                vecArray[i] = ToVector3(strItems[i], p_seperator1);
            }

            return vecArray;
        }

        public static int[] ToIntArray(string p_strSource, char p_seperator)
        {
            if (string.IsNullOrEmpty(p_strSource))
            {
                return new int[0];
            }
            string[] strItems = p_strSource.Split(p_seperator);
            int[] array = new int[strItems.Length];
            for (int i = 0; i < strItems.Length; i++)
            {
                int temp;
                if (int.TryParse(strItems[i], out temp))
                {
                    array[i] = temp;
                }
            }
            return array;
        }

        public static string ToString(Vector3 p_value, char p_seperator)
        {
            return string.Join(p_seperator.ToString(), new string[] { p_value.x.ToString(), p_value.y.ToString(), p_value.z.ToString() });
        }
        public static string ToString(Vector2 p_value, char p_seperator)
        {
            return string.Join(p_seperator.ToString(), new string[] { p_value.x.ToString(), p_value.y.ToString() });
        }

        public static string ToString(Vector3[] p_array, char p_seperator0, char p_seperator1)
        {
            if (p_array == null || p_array.Length == 0)
            {
                return string.Empty;
            }
            string[] strItems = new string[p_array.Length];
            for (int i = 0; i < p_array.Length; i++)
            {
                strItems[i] = ToString(p_array[i], p_seperator1);
            }
            return string.Join(p_seperator0.ToString(), strItems);
        }

        public static string ToString(int[] p_array, char p_seperator)
        {
            if (p_array == null || p_array.Length == 0)
            {
                return string.Empty;
            }
            return string.Join(p_seperator.ToString(), p_array.Select(p => p.ToString()).ToArray());
        }

        public static string ToString(float[] p_array, char p_seperator)
        {
            if (p_array == null || p_array.Length == 0)
            {
                return string.Empty;
            }
            return string.Join(p_seperator.ToString(), p_array.Select(p => p.ToString()).ToArray());
        }

        public static Color32 ToColor32(string p_strSource, bool p_hasPrefix = false)
        {
            if (string.IsNullOrEmpty(p_strSource))
            {
                return Color.white;
            }
            byte r = 255;
            byte g = 255;
            byte b = 255;
            byte a = 255;
            try
            {
                int indexStart = p_hasPrefix ? 1 : 0;
                r = Convert.ToByte(p_strSource.Substring(indexStart, 2), 16);
                indexStart += 2;
                g = Convert.ToByte(p_strSource.Substring(indexStart, 2), 16);
                indexStart += 2;
                b = Convert.ToByte(p_strSource.Substring(indexStart, 2), 16);
                indexStart += 2;
                a = Convert.ToByte(p_strSource.Substring(indexStart, 2), 16);

            }
            catch
            {

            }
            return new Color32(r, g, b, a);
        }

        public static string ToString(Color32 p_color)
        {
            return
                $"{p_color.r.ToString("X2")}{p_color.g.ToString("X2")}{p_color.b.ToString("X2")}{p_color.a.ToString("X2")}";
        }

        public static string ToString(Color p_color)
        {
            return ToString((Color32)p_color);
        }

        public static string ToString(Color32 p_color, char p_prefix)
        {
            return
                $"{p_prefix}{p_color.r.ToString("X2")}{p_color.g.ToString("X2")}{p_color.b.ToString("X2")}{p_color.a.ToString("X2")}";
        }

        public static string ToString(Color p_color, char p_prefix)
        {
            return ToString((Color32)p_color, p_prefix);
        }

        public static Tuple<byte, byte, byte, byte> ToTuple(Color p_color)
        {
            Color32 color = p_color;
            return new Tuple<byte, byte, byte, byte>(color.r, color.g, color.b, color.a);
        }

        public static Color ToColor(Tuple<byte, byte, byte, byte> p_color)
        {
            return new Color32(p_color.Item1, p_color.Item2, p_color.Item3, p_color.Item4);
        }

        public static System.DateTime FromUnixTime(double p_unixTimeStamp)
        {
            System.DateTime time = System.DateTime.MinValue;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            time = startTime.AddMilliseconds(p_unixTimeStamp);
            return time;
        }

        public static T ParseEnum<T>(string p_value)
        {
            return (T)Enum.Parse(typeof(T), p_value);
        }
        //参数value为要处理的浮点数，参数digit为要保留的小数点位数
        public static float Round(float value, int digit)
        {
            float vt = Mathf.Pow(10, digit);
            //1.乘以倍数 + 0.5
            float vx = value * vt + 0.5f;
            //2.向下取整
            float temp = Mathf.Floor(vx);
            //3.再除以倍数
            return (temp / vt);
        }


        public static Tuple<int, int> M2mm(Vector2 p_vector2)
        {
            return new Tuple<int, int>(Mathf.RoundToInt(p_vector2.x * 1000), Mathf.RoundToInt(p_vector2.y * 1000));
        }

        public static Tuple<int, int, int> M2mm(Vector3 p_vector3)
        {
            return new Tuple<int, int, int>(Mathf.RoundToInt(p_vector3.x * 1000), Mathf.RoundToInt(p_vector3.y * 1000), Mathf.RoundToInt(p_vector3.z * 1000));
        }

        public static Vector2 Mm2m(Tuple<int, int> p_tuple)
        {
            return new Vector2(p_tuple.Item1 / 1000f, p_tuple.Item2 / 1000f);
        }

        public static Rect Mm2m(Tuple<int, int,int,int> p_tuple)
        {
            return new Rect(p_tuple.Item1 / 1000f, p_tuple.Item2 / 1000f, p_tuple.Item3 / 1000f, p_tuple.Item4 / 1000f);
        }

        public static Tuple<int, int, int, int> M2mm(Rect p_rect)
        {
            return new Tuple<int, int, int, int>(Mathf.RoundToInt(p_rect.x * 1000), Mathf.RoundToInt(p_rect.y * 1000), Mathf.RoundToInt(p_rect.width * 1000), Mathf.RoundToInt(p_rect.height * 1000));
        }

        public static Vector3 Mm2m(Tuple<int, int, int> p_tuple)
        {
            return new Vector3(p_tuple.Item1 / 1000f, p_tuple.Item2 / 1000f, p_tuple.Item3 / 1000f);
        }

        /// <summary>
        /// 毫米到米
        /// </summary>
        /// <param name="p_length"></param>
        /// <returns></returns>
        public static float Mm2m(int p_length)
        {
            return p_length / 1000f;
        }
        /// <summary>
        /// 厘米到米
        /// </summary>
        /// <param name="p_length"></param>
        /// <returns></returns>
        public static float Cm2m(float p_length)
        {
            return p_length / 100f;
        }
        /// <summary>
        /// 厘米到米
        /// </summary>
        /// <param name="p_length"></param>
        /// <returns></returns>
        public static float Cm2m(int p_length)
        {
            return p_length / 100f;
        }
        /// <summary>
        /// 米到厘米
        /// </summary>
        /// <param name="p_length"></param>
        /// <returns></returns>
        public static float M2cm(float p_length)
        {
            return p_length * 100;
        } 

        /// <summary>
        /// 米到毫米
        /// </summary>
        /// <param name="p_length"></param>
        /// <returns></returns>
        public static int M2mm(float p_length)
        {
            return Mathf.RoundToInt(p_length * 1000);
        }
    }
}
