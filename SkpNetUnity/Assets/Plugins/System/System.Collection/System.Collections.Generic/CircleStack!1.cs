/*
 * Description: 
 * Author: penguin_ku
 * Date: 2017/2/10 11:52:40
 * Copyright: ©www.dpjia.com
 * Last Modify Date:
 * Last Modifier:
 */

namespace System.Collections.Generic
{
    /// <summary>
    /// 环形堆栈
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CircleStack<T> : IEnumerable, IEnumerable<T>, IEnumerator, IEnumerator<T>, IDisposable
    {
        #region private members

        private T[] m_array;
        private int m_cursor;
        private int m_startCursor;
        private int m_count;

        private bool m_iteratorFlag;
        private int m_iterator;

        #endregion

        #region public properties

        public bool IsEmpty => m_count == 0;

        #endregion

        #region constructors

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="p_capacity"></param>
        public CircleStack(int p_capacity)
        {
            m_array = new T[p_capacity];
            m_cursor = -1;
            m_startCursor = -1;
            m_iterator = -1;
            m_iteratorFlag = false;
            m_count = 0;
        }

        #endregion

        #region public functions

        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="p_element"></param>
        public void Push(T p_element)
        {
            m_cursor++;
            if (m_cursor == 0)
            {
                m_startCursor = 0;
                m_iterator = m_startCursor - 1;
                m_array[m_cursor] = p_element;
                m_count++;
                return;
            }

            if (m_cursor == m_array.Length)
            {
                m_cursor = 0;
            }

            if (m_count == m_array.Length)
            {
                m_startCursor++;
                m_iterator = m_startCursor - 1;
            }

            if (m_count < m_array.Length)
            {
                m_count++;
            }

            m_array[m_cursor] = p_element;

        }

        /// <summary>
        /// 出栈
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            if (IsEmpty)
            {
                throw new Exception();
            }
            T element = m_array[m_cursor];
            m_cursor--;
            m_count--;
            if (m_count == 0)
            {
                m_startCursor = -1;
                m_iterator = m_startCursor - 1;
            }
            if (m_count != 0)
            {
                if (m_cursor < 0)
                {
                    m_cursor += m_array.Length;
                }
            }
            return element;
        }

        /// <summary>
        /// scan specified element
        /// </summary>
        /// <param name="p_index"></param>
        /// <returns></returns>
        public T Scan(int p_index)
        {
            if (IsEmpty || p_index > m_count)
            {
                throw new Exception();
            }

            return m_array[(m_cursor - p_index + m_array.Length) % m_array.Length];
        }

        /// <summary>
        /// scan current element
        /// </summary>
        /// <returns></returns>
        public T Scan()
        {
            return Scan(0);
        }

        /// <summary>
        /// 重置
        /// </summary>
        public void Clear()
        {
            m_cursor = -1;
            m_startCursor = -1;
            m_iterator = m_startCursor - 1;
            m_iteratorFlag = false;
            m_count = 0;
        }

        #endregion

        #region  IEnumerator<T> members

        public T Current => m_array[m_iterator];

        #endregion

        #region IEnumerator members

        object IEnumerator.Current => m_array[m_iterator];

        public bool MoveNext()
        {
            m_iterator++;
            m_iterator %= m_array.Length;
            if (!m_iteratorFlag)
            {
                m_iteratorFlag = true;
                if (m_iterator == -1)
                {
                    return false;
                }
            }
            else
            {
                if (m_iterator == m_cursor + 1)
                {
                    return false;
                }
            }
            return true;
        }

        public void Reset()
        {
            m_iterator = m_startCursor - 1;
            m_iteratorFlag = false;
        }

        #endregion

        #region IDisposable members

        public void Dispose()
        {
            Reset();
        }

        #endregion

        #region IEnumerable members

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }

        #endregion

        #region IEnumerable<T> members

        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        #endregion

    }

}
