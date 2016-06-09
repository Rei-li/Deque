using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deque
{
    class Program
    {
        private static Dictionary<string, Deque<string>> deques = new Dictionary<string, Deque<string>>();
        private const string WRONG_DEQUE_NAME_MSG = "Wrong deque name";

        private static void CreateDeque(string name)
        {
            var deque = new Deque<string>();
            deque.OnChanged += deque_OnChanged;
            deques.Add(name, deque);
        }

        static void deque_OnChanged(object source, DequeEventArgs<string> e)
        {
            Console.WriteLine(e.GetChangeDequeType() + ": " + e.GetValue());
        }

        private static void PushBack(string name, string value)
        {
            Deque<string> deque;
            if (deques.TryGetValue(name, out deque))
            {
                deque.PushBack(value);
            }
        }

        private static void PushFront(string name, string value)
        {
            Deque<string> deque;
            if (deques.TryGetValue(name, out deque))
            {
                deque.PushFront(value);
            }
        }

        private static string PopFront(string name)
        {
            Deque<string> deque;
            if (deques.TryGetValue(name, out deque))
            {
                return deque.PopFront();
            }
            return null;
        }

        private static string PopBack(string name)
        {
            Deque<string> deque;
            if (deques.TryGetValue(name, out deque))
            {
               return deque.PopBack();
            }
            return null;
        }

        private static string PeekBack(string name)
        {
            Deque<string> deque;
            if (deques.TryGetValue(name, out deque))
            {
                return deque.PeekBack();
            }
            return null;
        }

        private static string PeekFront(string name)
        {
            Deque<string> deque;
            if (deques.TryGetValue(name, out deque))
            {
                return deque.PeekFront();
            }
            return null;
        }

        private static void Clear(string name)
        {
            Deque<string> deque;
            if (deques.TryGetValue(name, out deque))
            {
                 deque.Clear();
            }
        }

        private static int? GetCount(string name)
        {
            Deque<string> deque;
            if (deques.TryGetValue(name, out deque))
            {
               return deque.Count;
            }
            return null;
        }

        private static bool Contains(string name, string value)
        {
            Deque<string> deque;
            if (deques.TryGetValue(name, out deque))
            {
                return deque.Contains(value);
            }
            return false;
        }

        private static void Clone(string name, string newName)
        {
            Deque<string> deque;
            if (deques.TryGetValue(name, out deque))
            {
                var newDeque = deque.Clone();
                newDeque.OnChanged += deque_OnChanged;
                deques.Add(newName, newDeque); 
            }
        }

        private static string[] ToArray(string name)
        {
            Deque<string> deque;
            if (deques.TryGetValue(name, out deque))
            {
                return deque.ToArray();
            }
            return null;
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to testing program for Deque class. Please use -help command to see the list of available commands");
            RunCommand();
        }

        private static void RunCommand()
        {
            var command = Console.ReadLine();
            List<string> commandElements = new List<string>();
            if (command != null)
            {
                commandElements = command.Split(' ').ToList();
            }


            if (commandElements.Any())
            {
                switch (commandElements[0])
                {
                    case "create":
                        if (commandElements.Count >= 2 && !deques.ContainsKey(commandElements[1]))
                        {
                            var name = commandElements[1];
                            CreateDeque(name);
                            Console.WriteLine(name + " was created");
                        }
                        else
                        {
                            Console.WriteLine("Wrong deque name. Name should be unique and not empty");
                        }
                        RunCommand();
                        break;

                    case "pushb":
                        if (commandElements.Count >= 3)
                        {
                            var name = commandElements[1];
                            var value = commandElements[2];
                            PushBack(name, value);
                            Console.WriteLine(value + " was added to " + name);
                        }
                        else
                        {
                            Console.WriteLine(WRONG_DEQUE_NAME_MSG);
                        }
                        RunCommand();
                        break;

                    case "pushf":
                        if (commandElements.Count >= 3)
                        {
                            var name = commandElements[1];
                            var value = commandElements[2];
                            PushFront(name, value);
                            Console.WriteLine(value + " was added to " + name);
                        }
                        else
                        {
                            Console.WriteLine(WRONG_DEQUE_NAME_MSG);
                        }
                        RunCommand();
                        break;

                    case "popf":
                        if (commandElements.Count >= 2)
                        {
                            var name = commandElements[1];
                            try
                            {
                                var value = PopFront(name);
                                Console.WriteLine(value);
                            }
                            catch (EmptyDequeException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            
                            
                        }
                        else
                        {
                            Console.WriteLine(WRONG_DEQUE_NAME_MSG);
                        }
                        RunCommand();
                        break;

                    case "popb":
                        if (commandElements.Count >= 2)
                        {
                            var name = commandElements[1];
                            try
                            {
                                var value = PopBack(name);
                                Console.WriteLine(value);
                            }
                            catch (EmptyDequeException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine(WRONG_DEQUE_NAME_MSG);
                        }
                        RunCommand();
                        break;

                    case "peekb":
                        if (commandElements.Count >= 2)
                        {
                            var name = commandElements[1];
                            try
                            {
                                var value = PeekBack(name);
                                Console.WriteLine(value);
                            }
                            catch (EmptyDequeException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine(WRONG_DEQUE_NAME_MSG);
                        }
                        RunCommand();
                        break;

                    case "peekf":
                        if (commandElements.Count >= 2)
                        {
                            var name = commandElements[1];
                            try
                            {
                                var value = PeekFront(name);
                                Console.WriteLine(value);
                            }
                            catch (EmptyDequeException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine(WRONG_DEQUE_NAME_MSG);
                        }
                        RunCommand();
                        break;

                    case "clear":
                        if (commandElements.Count >= 2)
                        {
                            var name = commandElements[1];
                            Clear(name);
                            Console.WriteLine(name + " was cleared");
                        }
                        else
                        {
                            Console.WriteLine(WRONG_DEQUE_NAME_MSG);
                        }
                        RunCommand();
                        break;

                    case "count":
                        if (commandElements.Count >= 2)
                        {
                            var name = commandElements[1];
                            var value = GetCount(name);
                            Console.WriteLine(name + " count: " + value);
                        }
                        else
                        {
                            Console.WriteLine(WRONG_DEQUE_NAME_MSG);
                        }
                        RunCommand();
                        break;

                    case "contain":
                        if (commandElements.Count >= 3)
                        {
                            var name = commandElements[1];
                            var value = commandElements[2];
                            Console.WriteLine(name + " contains " + value + ": " + Contains(name, value).ToString());
                        }
                        else
                        {
                            Console.WriteLine(WRONG_DEQUE_NAME_MSG);
                        }
                        RunCommand();
                        break;

                    case "clone":
                        if (commandElements.Count >= 3 && !deques.ContainsKey(commandElements[2]))
                        {
                            var name = commandElements[1];
                            var newName = commandElements[2];
                            Clone(name, newName);
                            Console.WriteLine(newName + " was created");
                        }
                        else
                        {
                            Console.WriteLine("Wrong deque name. Name should be unique and not empty");
                        }
                        RunCommand();
                        break;

                    case "arr":
                        if (commandElements.Count >= 2)
                        {
                            var name = commandElements[1];
                            var arr = ToArray(name);
                            foreach (var item in arr)
                            {
                                Console.WriteLine(item);
                            }
                        }
                        else
                        {
                            Console.WriteLine(WRONG_DEQUE_NAME_MSG);
                        }
                        RunCommand();
                        break;

                    case "q": break;
                    case "-help": 
                        Console.WriteLine("create DequeName - creates new deque");
                        Console.WriteLine("pushb DequeName Value - push value to the end of the deque");
                        Console.WriteLine("pushf DequeName Value - push value to the begining of the deque");
                        Console.WriteLine("popf DequeName - get value of the first element of the deque");
                        Console.WriteLine("popb DequeName - get value of the last element of the deque");
                        Console.WriteLine("peekf DequeName - get value of the first element of the deque (deque not changes)");
                        Console.WriteLine("peekb DequeName  - get value of the last element of the deque (deque not changes)");
                        Console.WriteLine("clear DequeName - clear deque");
                        Console.WriteLine("count DequeName - get count of elements of the deque contains such value");
                        Console.WriteLine("contain DequeName Value - check if the deque");
                        Console.WriteLine("clone DequeName NewDequeName - create new deque with values from the current one");
                        Console.WriteLine("arr DequeName - create new array with values from the deque and display all values ");
                        Console.WriteLine("-help - display all available commands ");
                        Console.WriteLine("q - exit ");
                        RunCommand();
                        break;

                    default: Console.WriteLine("Wrong command");
                        RunCommand();
                        break;
                }
            }
            
        }

      
        
    }
}
