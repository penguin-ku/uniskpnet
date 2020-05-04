using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgSkpDK.SketchupWrapper
{
    public class TaskExcutor
    {
        #region private static members

        private static int g_threadNums = 10;

        #endregion

        #region static constructors

        /// <summary>
        /// 静态构造函数
        /// </summary>
        static TaskExcutor()
        {
            g_threadNums = Environment.ProcessorCount * 2 + 2;//2 * CPU核数 + 2 最完美的线程性能  IOCP
        }

        #endregion

        #region public static functions

        public static Task<IEnumerable<TDst>> Run<TDst, TSrc>(IEnumerable<TSrc> p_dataSource, Func<TSrc, TDst> p_proc)
        {
            List<TSrc>[] srcGroup = new List<TSrc>[g_threadNums];
            for (int i = 0; i < p_dataSource.Count(); i++)
            {
                if (srcGroup[i % g_threadNums] == null)
                {
                    srcGroup[i % g_threadNums] = new List<TSrc>();
                }
                srcGroup[i % g_threadNums].Add(p_dataSource.ElementAt(i));
            }

            List<TDst>[] dstGroup = new List<TDst>[g_threadNums];
            Task[] tasks = new Task[g_threadNums];
            for (int i = 0; i < g_threadNums; i++)
            {
                int index = i;
                tasks[index] = Task.Run(() =>
                {
                    if (srcGroup[index] != null && srcGroup[index].Count > 0)
                    {
                        dstGroup[index] = srcGroup[index].Select(p => p_proc(p)).ToList();
                    }
                    else
                    {
                        // 啥也别干
                    }
                });
            }

            return Task.WhenAll(tasks).ContinueWith(t =>
            {
                if (t.IsFaulted)
                {
                    throw t.Exception;
                }
                else
                {
                    return dstGroup.Where(p => p != null).SelectMany(p => p);// 此处一定要过滤掉空的，因为数据源未必能填满线程
                }
            });
        }

        #endregion
    }
}
