using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deque
{
    public static class DequeExtensions
    {
        public static Deque<T> Clone<T>(this Deque<T> deque)
        {
            var newDeque = new Deque<T>();
            if (deque.FirstNode != null)
            {
                var node = deque.FirstNode;
                     
                while (true)
                {
                    newDeque.PushBack(node.Value);
                    if (node.Next != null)
                    {
                        node = node.Next;
                        continue;
                    }
                    break;
                }
            }
            return newDeque;
        }

       
    }
}
