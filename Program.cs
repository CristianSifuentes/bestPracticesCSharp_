using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        private const string Separator = "----------------------------------------";

        // Property initializer: TaskList is created when the Program class is loaded.
        public static List<string> TaskList { get; } = new List<string>();


        public enum MenuOptions
        {
            Invalid = 0,
            NewTask = 1,
            RemoveTask = 2,
            PendingTasks = 3,
            Exit = 4
        }
        static void Main(string[] args)
        {
            try
            {
                RunApplication();
            }
            catch (Exception exception)
            {
                ShowUnexpectedError(exception);
            }
        }

        private static void RunApplication()
        {
            MenuOptions menuOption;
            do
            {
                menuOption = ShowMainMenu();

                switch (menuOption)
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
                    case MenuOptions.Invalid:
                        Console.WriteLine("Invalid menu option");
                        break;
                }
            } while (menuOption != MenuOptions.Exit);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static MenuOptions ShowMainMenu()
        {
            ShowSeparator();
            Console.WriteLine("Enter the option to perform: ");
            Console.WriteLine("1. New task");
            Console.WriteLine("2. Remove task");
            Console.WriteLine("3. Pending tasks");
            Console.WriteLine("4. Exit");

            // Read line
            string line = Console.ReadLine();
            if (int.TryParse(line, out int option) && Enum.IsDefined(typeof(MenuOptions), option))
            {
                return (MenuOptions)option;
            }

            return MenuOptions.Invalid;
        }

        public static void ShowMenuRemove()
        {
            if (!HasTasks())
            {
                ShowNoPendingTasks();
                return;
            }

            Console.WriteLine("Enter the number of the task to remove: ");
            ShowTaskList();

            string line = Console.ReadLine();
            if (!int.TryParse(line, out int taskNumber))
            {
                Console.WriteLine("Invalid task number");
                return;
            }

            // Remove one position
            int indexToRemove = taskNumber - 1;
            if (indexToRemove < 0 || indexToRemove >= TaskList.Count)
            {
                Console.WriteLine("Task number does not exist");
                return;
            }

            string task = TaskList[indexToRemove];
            TaskList.RemoveAt(indexToRemove);
            // String interpolation: inserts the task value directly into the output text.
            Console.WriteLine($"Task {task} removed");
        }

        public static void ShowMenuAdd()
        {
            Console.WriteLine("Enter the task name: ");
            string task = Console.ReadLine();
            TaskList.Add(task);
            Console.WriteLine("Task registered");
        }

        public static void ShowMenuPending()
        {
            if (!HasTasks())
            {
                ShowNoPendingTasks();
                return;
            }

            ShowTaskList();
        }

        private static bool HasTasks()
        {
            // Null-conditional operator: safely checks Count only if TaskList is not null.
            return TaskList?.Count > 0;
        }

        private static void ShowTaskList()
        {
            ShowSeparator();
            for (int i = 0; i < TaskList.Count; i++)
            {
                // String interpolation: formats the task number and task text in one readable line.
                Console.WriteLine($"{i + 1}. {TaskList[i]}");
            }
            ShowSeparator();
        }

        private static void ShowSeparator()
        {
            Console.WriteLine(Separator);
        }

        private static void ShowNoPendingTasks()
        {
            Console.WriteLine("There are no pending tasks");
        }

        private static void ShowUnexpectedError(Exception exception)
        {
            Console.WriteLine("An unexpected error occurred.");
            Console.WriteLine(exception.Message);
        }
    }
}
