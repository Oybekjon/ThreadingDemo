using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Threading
{
    public class ParallelContainer<T>
    {
        /// <summary>
        /// soem comment about stuff
        /// </summary>
        /// <param name="functions"></param>
        /// <returns></returns>
        public List<T> RunParallely(List<Func<T>> functions)
        {
            var count = functions.Count;
            var result = new List<T>();
            var threads = new List<Thread>();
            var counter = new CountdownEvent(count);

            foreach (var func in functions)
            {
                var copy = func;
                threads.Add(new Thread(() => {
                    result.Add(copy());
                    counter.Signal();
                }));
            }
            foreach (var t in threads)
            {
                t.Start();
            }

            counter.Wait();

            return result;
        }
    }
}
