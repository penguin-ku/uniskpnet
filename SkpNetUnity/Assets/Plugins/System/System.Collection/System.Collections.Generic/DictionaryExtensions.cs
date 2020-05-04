using System.Linq;

namespace System.Collections.Generic
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// merge
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="p_dic0"></param>
        /// <param name="p_dic1"></param>
        public static void Union<T1, T2>(this Dictionary<T1, T2> p_dic0, Dictionary<T1, T2> p_dic1)
        {
            foreach (var item in p_dic1.Keys)
            {
                p_dic0[item] = p_dic1[item];
            }
        }

        /// <summary>
        /// copy
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="p_dic0"></param>
        /// <returns></returns>
        public static Dictionary<T1, T2> Copy<T1, T2>(this Dictionary<T1, T2> p_dic0)
        {
            return p_dic0.ToDictionary(p => p.Key, p => p.Value);
        }

        public static ReadOnlyDictionary<T1, T2> AsReadOnly<T1, T2>(this Dictionary<T1, T2> p_dic)
        {
            return new ReadOnlyDictionary<T1, T2>(p_dic);
        }
    }
}
