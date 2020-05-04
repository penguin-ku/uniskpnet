namespace System.Collections.Generic {

    /// <summary>
    /// 线程安全的list,加锁处理
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SafeList<T> : List<T>
    {
        private readonly object m_lock = new object();

        public new void AddRange(IEnumerable<T> collection)
        {
            lock (m_lock)
            {
                base.AddRange(collection);
            }
        }

        public new void Add(T p_item)
        {
            lock (m_lock)
            {
                base.Add(p_item);
            }
        }

        public new void Remove(T p_item)
        {
            lock (m_lock)
            {
                base.Remove(p_item);
            }
        }

        public new void RemoveAt(int p_index)
        {
            lock (m_lock)
            {
                base.RemoveAt(p_index);
            }
        }

        public new T this[int p_index]
        {
            set
            {
                lock (m_lock)
                {
                    base[p_index] = value;
                }
            }
            get
            {
                lock (m_lock)
                {
                    return base[p_index];
                }
            }
        }

    }
}
