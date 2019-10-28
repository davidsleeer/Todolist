using System;
using System.Collections.Generic;
using System.Linq;

namespace TodoFunctional
{

    public class Todolist
    {
        public string TodoTitles;
        public bool TodoCompleted;

        public Todolist()
        {

        }

        public Todolist (string TodoTitle)
        {
            this.TodoTitles=TodoTitle;
        }

        public Todolist(string TodoTitle, bool TodoComplete)
        {
            this.TodoTitles=TodoTitle;
            this.TodoCompleted=TodoComplete;
        }
    }
    class Program
    {

        static List<Todolist> Todolists = new List<Todolist>();
        //static List<bool> TodoCompleted = new List<bool>();


        static int AddTodo(string title, bool completed)
        {
            var index = Todolists.Count;
            
            Todolists.Add(new Todolist (title, completed));
            
            
            //TodoCompleted.Add(completed);

            return index;
        }
        static void RemoveTodo(int index)
        {
            Todolists.RemoveAt(index);
            
        }

        static void DisplayTodo(int index)
        {
            string title = Todolists[index].TodoTitles;
            bool completed = Todolists[index].TodoCompleted;

            if (completed)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }

            Console.WriteLine(" - " + (index+1) + "  " + title);
            Console.ForegroundColor = ConsoleColor.White;

        }
        static void DrawSepearator()
        {
            Console.WriteLine(string.Concat(Enumerable.Repeat("-", Console.BufferWidth)));
        }
        static void DisplayAllTodos()
        {
            DrawSepearator();
            for (int i = 0; i < Todolists.Count; i++)
            {
                DisplayTodo(i);
            }

            DrawSepearator();
        }

        static void ReadNewTodo()
        {
            bool add = true;
            while (add)
            {
                Console.WriteLine("Add Todo: ");
                // Do stuff in here to create a new Todo.
                string temp = Console.ReadLine();
                Console.WriteLine("Finished: true or false");
                bool tf = bool.Parse(Console.ReadLine());
                AddTodo(temp, tf);
                Console.WriteLine("Add more items:  t for true or f for false");
                string more = Console.ReadLine();
                bool fb = (more == "t" || more == "T");
                add = fb;
            }
           


            

        }

        static void ReadToggleExistingTodo()
        {
            
            Console.WriteLine("Toggle Todo: ");
            // Do something to toggle the todo item thingy-ma-bob thing
            
            DrawSepearator();
            Console.WriteLine("Toggle Todo: item number to be toggled  please");
            int index = int.Parse(Console.ReadLine());
            if (index <= Todolists.Count)
            {
                if (Todolists[index - 1].TodoCompleted)
                {
                    Todolists[index - 1].TodoCompleted = false;
                }
                else
                {
                    Todolists[index - 1].TodoCompleted = true;

                }
            }
            else
            {
                while (index > Todolists.Count)
                {
                    Console.WriteLine("Toggle Todo: item number please, not out range idiot!");
                    int index1 = int.Parse(Console.ReadLine());
                    index = index1;
                }

                if (Todolists[index - 1].TodoCompleted)
                {
                    Todolists[index - 1].TodoCompleted = false;
                }
                else
                {
                    Todolists[index - 1].TodoCompleted = true;

                }


            }

              
                
            Console.WriteLine($"Item {index} toggled!");
            DrawSepearator();
            //Console.WriteLine("Press any key to resume...");
            //Console.ReadKey();
        }

        static void ReadRemoveTodo()
        {
            Console.WriteLine("Remove Todo: item number please");
            int index = int.Parse(Console.ReadLine());

            if (index<=Todolists.Count)
            {
                RemoveTodo(index-1);
            }else
            {
                while (index> Todolists.Count)
                {
                    Console.WriteLine("Remove Todo: item number please, not out range idiot!");
                    int index1 = int.Parse(Console.ReadLine());
                    index = index1;
                }

                RemoveTodo(index - 1);


            }

            // Remove craptasic todos here
            Console.WriteLine($"Item {index} deleted!");
            Console.WriteLine("Press any key to resume...");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Todo Application");

            // Add a few example Todos
            AddTodo("Get the shopping from the store because you a lazy dude and had to pre order it", false);
            AddTodo("Kiss a tree because climate", false);
            AddTodo("Finish this task because you are a model student", false);
            AddTodo("Go to Intro Class this arvo", true);
            AddTodo("Attended Hormone treatment", false);


            while (true)
            {
                Console.Clear();
                DisplayAllTodos();
                Console.WriteLine($"There are {Todolists.Count} items overall");
                Console.WriteLine("Pick an option:");
                Console.WriteLine(" (1) -> Create Todo");
                Console.WriteLine(" (2) -> Toggle Completed");
                Console.WriteLine(" (3) -> Remove Todo");
                Console.WriteLine(" (4) -> Exit");


                var key = Console.ReadKey(true);

                if(key.Key == ConsoleKey.D1)
                {
                    ReadNewTodo();
                }
                else if(key.Key == ConsoleKey.D2)
                {
                    ReadToggleExistingTodo();
                }
                else if(key.Key == ConsoleKey.D3)
                {
                    ReadRemoveTodo();
                }
                else if(key.Key == ConsoleKey.D4)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Nah you dumb, give me a valid answer please. Press any key to stop me raging at you....");
                    Console.ReadKey(true);
                }                

            }

        }
    }
}
