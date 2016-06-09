using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deque
{

    public delegate void DequeEventHandler<T>(object source, DequeEventArgs<T> e);

   
    public class DequeEventArgs<T> : EventArgs
    {
        private ChangeDequeType _changeDequeType;
        private T _value;
        public DequeEventArgs(ChangeDequeType text, T value)
        {
            _changeDequeType = text;
            _value = value;

        }
        public ChangeDequeType GetChangeDequeType()
        {
            return _changeDequeType;
        }

        public T GetValue()
        {
            return _value;
        }
    }





    public enum ChangeDequeType { PushedBack, PushedFront, PoppedBack, PoppedFront };




    public class Deque<T>
    {
        private class Node<TNode> where TNode : T
        {
            public TNode Value { set; get; }
            public Node<TNode> Next { set; get; }
            public Node<TNode> Previous { set; get; }

        }

        private const string EMPTY_DEQUE_MSG = "Deque is empty";
        public event DequeEventHandler<T> OnChanged;
        private Node<T> FirstNode { set; get; }
        private Node<T> LastNode { set; get; }
        public int Count { get; private set; }

        /// <summary>
        /// Add value to the end of the deque
        /// </summary>
        /// <param name="item">value to add</param>
        public void PushBack(T item)
        {
            Node<T> newNode = new Node<T>()
            {
                Value = item
            };

            if (LastNode == null)
            {
                LastNode = newNode;
                FirstNode = newNode;
                Count = 1;
            }
            else
            {
                newNode.Previous = LastNode;
                LastNode.Next = newNode;
                LastNode = newNode;
                Count++;
            }

            if (OnChanged != null)
            {
                OnChanged(this, new DequeEventArgs<T>( ChangeDequeType.PushedBack, item));
            }
        }


        /// <summary>
        /// Add value to the begining of the deque
        /// </summary>
        /// <param name="item">value to add</param>
        public void PushFront(T item)
        {
            Node<T> newNode = new Node<T>()
            {
                Value = item
            };

            if (FirstNode == null)
            {
                LastNode = newNode;
                FirstNode = newNode;
                Count = 1;
            }
            else
            {
                newNode.Next = FirstNode;
                FirstNode.Previous = newNode;
                FirstNode = newNode;
                Count++;
            }

            if (OnChanged != null)
            {
                OnChanged(this, new DequeEventArgs<T>( ChangeDequeType.PushedFront, item));
            }
        }


        /// <summary>
        /// Get last element of the deque
        /// </summary>
        /// <returns>the last deque element</returns>
        public T PopBack()
        {
            if (LastNode != null)
            {
                T value = LastNode.Value;

                if (Count > 1)
                {
                    if (LastNode.Previous == null)
                    {
                        FirstNode = null;
                    }
                    LastNode = LastNode.Previous;
                    LastNode.Next = null;
                    Count--;
                }
                else
                {
                    Clear();
                }
       
                if (OnChanged != null)
                {
                    OnChanged(this, new DequeEventArgs<T>( ChangeDequeType.PoppedBack, value));
                }
                return value;
            }
            else
            {
                throw new EmptyDequeException(EMPTY_DEQUE_MSG);
            }
        }


        /// <summary>
        /// Get vallue of the first element of the deque
        /// </summary>
        /// <returns>the first deque element</returns>
        public T PopFront()
        {
            if (FirstNode != null)
            {
                T value = FirstNode.Value;

                if (Count > 1)
                {
                    if (FirstNode.Next == null)
                    {
                        LastNode = null;
                    }
                    FirstNode = FirstNode.Next;
                    FirstNode.Previous = null;
                    Count--;
                }
                else
                {
                    Clear();
                }

                
                if (OnChanged != null)
                {
                    OnChanged(this, new DequeEventArgs<T>( ChangeDequeType.PoppedFront, value));
                }
                return value;
            }
            else
            {
                throw new EmptyDequeException(EMPTY_DEQUE_MSG);
            }
        }

        /// <summary>
        /// Get the last value but not change deque
        /// </summary>
        /// <returns>value of the last element</returns>
        public T PeekBack()
        {
            if (LastNode != null)
            {
                return LastNode.Value;
            }
            else
            {
                throw new EmptyDequeException(EMPTY_DEQUE_MSG);
            }
        }

        /// <summary>
        /// Get the first value but not change deque
        /// </summary>
        /// <returns>value of the first element</returns>
        public T PeekFront()
        {
            if (FirstNode != null)
            {
                return FirstNode.Value;
            }
            else
            {
                throw new EmptyDequeException(EMPTY_DEQUE_MSG);
            }
        }


        /// <summary>
        /// Clear deque 
        /// </summary>
        public void Clear()
        {
            FirstNode = null;
            LastNode = null;
            Count = 0;
        }


        /// <summary>
        /// Check if deque contains an element with specific value
        /// </summary>
        /// <param name="item">value to find</param>
        /// <returns>if value found - true, else - false</returns>
        public bool Contains(T item)
        {
            if (FirstNode == null) return false;

            var node = FirstNode;
            while (true)
            {
                if (node.Value.Equals(item)) return true;
                if (node.Next != null)
                {
                    node = node.Next;
                    continue;
                }
                break;
            }
            return false;
        }


       

        /// <summary>
        /// Create new deque with the same values
        /// </summary>
        /// <returns>separate deque instnce with the same values</returns>
        public  Deque<T> Clone()
        {
            var newDeque = new Deque<T>();
            if (FirstNode == null) return newDeque;
            var node = FirstNode;

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
            return newDeque;
        }

    }


}
