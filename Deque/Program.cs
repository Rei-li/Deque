using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deque
{
    class Program
    {

        static void Main(string[] args)
        {
            //var deque = new Deque<int>();

            //deque.OnChanged += deque_OnChanged;

            //deque.PushBack(5);
            //deque.PushBack(6);
            //deque.PushFront(4);
            //deque.PushBack(7);
            //deque.PushFront(3);
            //deque.PushBack(8);
            //deque.PushFront(2);
            //deque.PushBack(9);
            //deque.PushFront(1);

            //var c = deque.Contains(4);
            //Console.WriteLine("deque.Contains(4): "+ c);

            //while (deque.Count> 0)
            //{
            //    Console.WriteLine(deque.PopFront());
            //}

            //var deque2 = new Deque<int>();
            //deque2.OnChanged += deque_OnChanged;
            //deque2.PushBack(5);
            //deque2.PushBack(6);
            //deque2.PushFront(4);
            //deque2.PushBack(7);
            //deque2.PushFront(3);
            //deque2.PushBack(8);
            //deque2.PushFront(2);
            //deque2.PushBack(9);
            //deque2.PushFront(1);

            //while (deque2.Count > 0)
            //{
            //    Console.WriteLine(deque2.PopBack());
            //}

            var deque3 = new Deque<int>();
            deque3.OnChanged += deque_OnChanged;
            deque3.PushBack(5);
            deque3.PushBack(6);
            deque3.PushFront(4);
            deque3.PushBack(7);
            deque3.PushFront(3);
            deque3.PushBack(8);
            deque3.PushFront(2);
            deque3.PushBack(9);
            deque3.PushFront(1);

            while (deque3.Count > 0)
            {
                Console.WriteLine(deque3.PopFront());
               if(deque3.Count != 0)
                Console.WriteLine(deque3.PopBack());
            }


            //Console.WriteLine();
            //Console.WriteLine();



            //var deque4 = new Deque<string>();
            //deque4.PushBack("e");
            //deque4.PushBack("f");
            //deque4.PushFront("d");
            //deque4.PushBack("g");
            //deque4.PushFront("c");
            //deque4.PushBack("h");
            //deque4.PushFront("b");
            //deque4.PushBack("i");
            //deque4.PushFront("a");

            //var cstr = deque4.Contains("g");
            //Console.WriteLine("deque.Contains(g): " + cstr);

            //var cstrv = deque4.Contains("v");
            //Console.WriteLine("deque.Contains(v): " + cstrv);

            //while (deque4.Count > 0)
            //{
            //    Console.WriteLine(deque4.PopFront());
            //}

            //var deque5 = new Deque<string>();
            //deque5.PushBack("e");
            //deque5.PushBack("f");
            //deque5.PushFront("d");
            //deque5.PushBack("g");
            //deque5.PushFront("c");
            //deque5.PushBack("h");
            //deque5.PushFront("b");
            //deque5.PushBack("i");
            //deque5.PushFront("a");

            //while (deque5.Count > 0)
            //{
            //    Console.WriteLine(deque5.PopBack());
            //}

            var deque6 = new Deque<string>();

            deque6.OnChanged += deque6_OnChanged;
            deque6.PushBack("e");
            deque6.PushBack("f");
            deque6.PushFront("d");
            deque6.PushBack("g");
            deque6.PushFront("c");
            deque6.PushBack("h");
            deque6.PushFront("b");
            deque6.PushBack("i");
            deque6.PushFront("a");

            Console.WriteLine(deque6.Count);
            Console.WriteLine();

            var deque7 = deque6.Clone();

            while (deque6.Count > 0)
            {
                Console.WriteLine(deque6.Count);
                Console.WriteLine(deque6.PopFront());
                Console.WriteLine(deque6.Count);
                if (deque6.Count > 0)
                {
                    Console.WriteLine(deque6.PopBack());
                    Console.WriteLine(deque6.Count);
                    Console.WriteLine();
                }
            }




            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(deque6.Count);
            Console.WriteLine(deque7.Count);
            Console.WriteLine();
            Console.WriteLine(deque7.PeekFront());
            Console.WriteLine(deque7.PeekBack());




        }

        static void deque6_OnChanged(object source, DequeEventArgs<string> e)
        {
            Console.WriteLine(e.GetChangeDequeType() + ": " + e.GetValue());
        }

        static void deque_OnChanged(object source, DequeEventArgs<int> e)
        {
            Console.WriteLine(e.GetChangeDequeType()+ ": " + e.GetValue());
        }
    }
}
