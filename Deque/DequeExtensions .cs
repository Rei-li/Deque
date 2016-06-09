using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deque
{
    public static class DequeExtensions
    {
        /// <summary>
        /// Copy deque values to array
        /// </summary>
        /// <typeparam name="T">type of values</typeparam>
        /// <param name="deque">deque to copy to array</param>
        /// <returns>array with deque values</returns>
        public static T[] ToArray<T>(this Deque<T> deque)
        {
            var newDeque = deque.Clone();
            var arr = new T[newDeque.Count];

            var i = 0;
            while (newDeque.Count > 0)
            {
                arr[i] = newDeque.PopFront();
                i++;
            }

            return arr;
        }



    }
}
