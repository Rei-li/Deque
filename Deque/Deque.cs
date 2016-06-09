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


    public class Node<T>
    {
        public T Value { set; get; }
        public Node<T> Next { set; get; }
        public Node<T> Previous { set; get; }

    }

    public class Deque<T>
    {
        private const string EMPTY_DEQUE_MSG = "Deque is empty";
        public event DequeEventHandler<T> OnChanged;
        public Node<T> FirstNode { set; get; }
        public Node<T> LastNode { set; get; }
        public int Count { get; private set; }

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
                throw new IndexOutOfRangeException(EMPTY_DEQUE_MSG);
            }
        }

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
                throw new IndexOutOfRangeException(EMPTY_DEQUE_MSG);
            }
        }


        public T PeekBack()
        {
            if (LastNode != null)
            {
                return LastNode.Value;
            }
            else
            {
                throw new IndexOutOfRangeException(EMPTY_DEQUE_MSG);
            }
        }

        public T PeekFront()
        {
            if (FirstNode != null)
            {
                return FirstNode.Value;
            }
            else
            {
                throw new IndexOutOfRangeException(EMPTY_DEQUE_MSG);
            }
        }


        public void Clear()
        {
            FirstNode = null;
            LastNode = null;
            Count = 0;
        }


        public bool Contains(T item)
        {
            return FirstNode != null && CheckNodeValueEqals(FirstNode, item);
        }


        private static bool CheckNodeValueEqals(Node<T> node, T item)
        {
            return node.Value.Equals(item) || node.Next != null && CheckNodeValueEqals(node.Next, item);
        }

    }


}
