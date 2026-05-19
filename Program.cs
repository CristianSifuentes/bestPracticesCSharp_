using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TaskList { get; set; }


        public enum MenuOptions
        {
            NewTask = 1,
            RemoveTask = 2,
            PendingTasks = 3,
            Exit = 4
        }
        static void Main(string[] args)
        {
            TaskList = new List<string>();
            int menuOption = 0;
            do
            {
                menuOption = ShowMainMenu();

                switch ((MenuOptions)menuOption)
                {
                    case MenuOptions.NewTask:
                        ShowMenuAdd();
                        break;
                    case MenuOptions.RemoveTask:
                        ShowMenuRemove();
                        break;
                    case MenuOptions.PendingTasks:
                        ShowMenuPending();
                        break;
                }
            } while (menuOption != (int)MenuOptions.Exit);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static int ShowMainMenu()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Enter the option to perform: ");
            Console.WriteLine("1. New task");
            Console.WriteLine("2. Remove task");
            Console.WriteLine("3. Pending tasks");
            Console.WriteLine("4. Exit");

            // Read line
            string line = Console.ReadLine();
            return Convert.ToInt32(line);
        }

        public static void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Enter the number of the task to remove: ");
                // Show current tasks
                for (int i = 0; i < TaskList.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + TaskList[i]);
                }
                Console.WriteLine("----------------------------------------");

                string line = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(line) - 1;
                if (indexToRemove > -1)
                {
                    if (TaskList.Count > 0)
                    {
                        string task = TaskList[indexToRemove];
                        TaskList.RemoveAt(indexToRemove);
                        Console.WriteLine("Task " + task + " removed");
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Enter the task name: ");
                string task = Console.ReadLine();
                TaskList.Add(task);
                Console.WriteLine("Task registered");
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuPending()
        {
            if (TaskList == null || TaskList.Count == 0)
            {
                Console.WriteLine("There are no pending tasks");
            } 
            else
            {
                Console.WriteLine("----------------------------------------");
                for (int i = 0; i < TaskList.Count; i++)
                {
                    Console.WriteLine((i + 1) + ". " + TaskList[i]);
                }
                Console.WriteLine("----------------------------------------");
            }
        }
    }
}
