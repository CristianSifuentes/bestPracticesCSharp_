namespace ToDo;

/// <summary>
/// Entry point and console workflow for the in-memory ToDo application.
/// </summary>
internal class Program
{
    private const string Separator = "----------------------------------------";

    /// <summary>
    /// Stores tasks for the current application session.
    /// </summary>
    /// <remarks>
    /// Syntax improvement: the collection expression [] initializes the list at declaration time,
    /// keeping setup minimal and preventing null state for this in-memory collection.
    /// </remarks>
    public static List<string> TaskList { get; } = [];

    /// <summary>
    /// Represents the valid menu actions supported by the console UI.
    /// </summary>
    public enum MenuOptions
    {
        /// <summary>Fallback option for input that cannot be parsed.</summary>
        Invalid = 0,

        /// <summary>Adds a new task to the list.</summary>
        NewTask = 1,

        /// <summary>Removes an existing task from the list.</summary>
        RemoveTask = 2,

        /// <summary>Displays all pending tasks.</summary>
        PendingTasks = 3,

        /// <summary>Closes the application.</summary>
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
    /// Shows the main menu and returns the selected option.
    /// </summary>
    /// <returns>The selected menu option, or <see cref="MenuOptions.Invalid"/> when input cannot be parsed.</returns>
    public static MenuOptions ShowMainMenu()
    {
        ShowSeparator();
        Console.WriteLine("Enter the option to perform: ");
        Console.WriteLine($"{(int)MenuOptions.NewTask}. New task");
        Console.WriteLine($"{(int)MenuOptions.RemoveTask}. Remove task");
        Console.WriteLine($"{(int)MenuOptions.PendingTasks}. Pending tasks");
        Console.WriteLine($"{(int)MenuOptions.Exit}. Exit");

        // Null-coalescing keeps nullable console input explicit and warning-free.
        string line = Console.ReadLine() ?? string.Empty;
        if (int.TryParse(line, out int option) && Enum.IsDefined(typeof(MenuOptions), option))
        {
            return (MenuOptions)option;
        }

        return MenuOptions.Invalid;
    }

    /// <summary>
    /// Displays the removal workflow and removes a task when the selected number is valid.
    /// </summary>
    public static void ShowMenuRemove()
    {
        if (!HasTasks())
        {
            ShowNoPendingTasks();
            return;
        }

        Console.WriteLine("Enter the number of the task to remove: ");
        ShowTaskList();

        string line = Console.ReadLine() ?? string.Empty;
        if (!int.TryParse(line, out int taskNumber))
        {
            Console.WriteLine("Invalid task number");
            return;
        }

        int indexToRemove = taskNumber - 1;
        // Relational pattern matching makes the valid index range easy to read.
        if (indexToRemove is < 0 || indexToRemove >= TaskList.Count)
        {
            Console.WriteLine("Task number does not exist");
            return;
        }

        string task = TaskList[indexToRemove];
        TaskList.RemoveAt(indexToRemove);
        Console.WriteLine($"Task {task} removed");
    }

    /// <summary>
    /// Reads a new task from the console and stores it in <see cref="TaskList"/>.
    /// </summary>
    public static void ShowMenuAdd()
    {
        Console.WriteLine("Enter the task name: ");
        string task = Console.ReadLine() ?? string.Empty;
        TaskList.Add(task);
        Console.WriteLine("Task registered");
    }

    /// <summary>
    /// Displays the current pending tasks.
    /// </summary>
    public static void ShowMenuPending()
    {
        if (!HasTasks())
        {
            ShowNoPendingTasks();
            return;
        }

        ShowTaskList();
    }

    // Expression-bodied helpers keep one-line behavior compact without hiding intent.
    private static bool HasTasks() => TaskList.Count > 0;

    private static void ShowTaskList()
    {
        ShowSeparator();
        for (int i = 0; i < TaskList.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {TaskList[i]}");
        }
        ShowSeparator();
    }

    private static void ShowSeparator() => Console.WriteLine(Separator);

    private static void ShowNoPendingTasks() => Console.WriteLine("There are no pending tasks");

    private static void ShowUnexpectedError(Exception exception)
    {
        Console.WriteLine("An unexpected error occurred.");
        Console.WriteLine(exception.Message);
    }
}
