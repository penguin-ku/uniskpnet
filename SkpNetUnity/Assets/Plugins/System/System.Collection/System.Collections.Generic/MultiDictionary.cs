namespace System.Collections.Generic
{
    /// <summary>
    /// 模拟C++ multimap
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public sealed class MultiDictionary<TKey, TValue> : Dictionary<TKey, List<TValue>>
    {
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        public void Add(TKey key, TValue value)
        {          
            if (ContainsKey(key))
            {
                List<TValue> l = this[key];
                l.Add(value);
            }
            else
            {
                List<TValue> l = new List<TValue>();
                l.Add(value);
                base.Add(key, l);
            }
        }

        /// <summary>
        /// 移除
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Remove(TKey key, TValue value)
        {
            if (ContainsKey(key))
            {
                List<TValue> l = this[key];
                l.Remove(value);
            }
        }
    }
}
