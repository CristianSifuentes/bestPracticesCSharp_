# C# Clean Code Course - ToDo Console App

This repository contains the base code for a C# clean code and best practices course. The project is intentionally small and simple: a console ToDo application that lets users add, remove, and list pending tasks.

The goal is not only to run the application, but also to study it, identify common code quality issues, and improve it through refactoring.

## Table of Contents

- [Overview](#overview)
- [Repository Setup](#repository-setup)
- [Requirements](#requirements)
- [How to Build and Run](#how-to-build-and-run)
- [How to Use the Application](#how-to-use-the-application)
- [Current Features](#current-features)
- [Clean Code Learning Goals](#clean-code-learning-goals)
- [C# Language Evolution](#c-language-evolution)
- [Modern C# Syntax in This Project](#modern-c-syntax-in-this-project)
- [Modernizing the .NET Project Structure](#modernizing-the-net-project-structure)
- [Naming Best Practices in C#](#naming-best-practices-in-c)
- [Code Smells in C#](#code-smells-in-c)
- [DRY Principle in C#](#dry-principle-in-c)
- [KISS Principle in C#](#kiss-principle-in-c)
- [Exception Handling in C#](#exception-handling-in-c)
- [Suggested Improvements](#suggested-improvements)
- [Project Structure](#project-structure)

## Overview

This project supports the first steps of a journey toward writing cleaner C# code. It starts from a working application with room for improvement, making it a useful exercise for practicing refactoring, naming, organization, and maintainability.

The application stores tasks during the current execution and provides a basic menu-driven interface. Because the logic is simple and currently concentrated in a single file, it is easy to inspect and evolve during the course.

## Repository Setup

Clone or download this repository from GitHub.

If you are familiar with Git, clone the repository and use the `master` or `base-code` branch:

```bash
git clone <repository-url>
cd bestPracticesCSharp_
```

If you are not familiar with GitHub, you can also use the **Download ZIP** option from GitHub, then extract the files and open the project folder locally.

## Requirements

- .NET 8 SDK or newer
- A terminal or command prompt
- A code editor such as Visual Studio, Visual Studio Code, or Rider

You can confirm your installed .NET version with:

```bash
dotnet --version
```

## How to Build and Run

From the repository root, build the solution:

```bash
dotnet build
```

Then run the application:

```bash
dotnet run
```

The application will start in the terminal and display an interactive menu.

## How to Use the Application

When the application starts, it displays the following options:

```text
1. New task
2. Remove task
3. Pending tasks
4. Exit
```

Choose an option by typing its number and pressing Enter.

### Add a New Task

Select option `1`, then type the task description.

Example tasks:

- Finish the university assignment
- Prepare the next course exercise
- Review clean code notes

### List Pending Tasks

Select option `3` to display all tasks added during the current execution.

### Remove a Task

Select option `2` to remove a task. The application shows the current tasks with their numbers. Type the number of the task you want to remove and press Enter.

### Exit the Application

Select option `4` to close the program.

## Current Features

- Add tasks from the console
- List pending tasks
- Remove tasks by number
- Exit through the menu

Tasks are stored in memory, so they are lost when the application closes.

## Clean Code Learning Goals

Although the application works, it is designed as a starting point for improvement. The course uses this code to highlight common issues that can make software harder to read and maintain.

Key learning goals include:

- Improve unclear variable and member names
- Replace ambiguous menu-related names with intention-revealing names
- Separate responsibilities into smaller methods or classes
- Improve input validation and error handling
- Make the code easier to test
- Apply refactoring techniques safely

## C# Language Evolution

C# has evolved continuously since its release. It is not just a programming language with a fixed syntax; it has grown alongside the .NET platform to support cleaner, safer, and more expressive code.

Understanding this evolution helps developers recognize when modern language features can simplify existing code without changing behavior.

### Important Milestones

Historically, C# versions were strongly connected to .NET Framework and later to .NET Core and modern .NET releases.

- **C# 4.0**: Released around the .NET Framework 4 era, it introduced language improvements that are still common in many codebases.
- **C# 6.0**: Arrived during the transition toward .NET Core and introduced several features that made everyday code more concise.
- **2017 and later**: C# and .NET releases became more frequent, with the language receiving regular improvements that focus on readability, safety, and developer productivity.

### Features That Improved Everyday Code

Several C# features are especially useful when refactoring older code into cleaner modern code.

**Auto-property initializers** let a property receive a default value directly where it is declared:

```csharp
public static List<string> TaskList { get; } = new List<string>();
```

This project uses that idea to create `TaskList` in one clear place instead of assigning it later in the application flow.

**String interpolation** improves readability when combining text with values:

```csharp
Console.WriteLine($"Task {task} removed");
```

This is clearer than building the same output with manual string concatenation.

**Null-conditional operators** reduce defensive `if` statements when checking nullable values:

```csharp
return TaskList?.Count > 0;
```

This keeps the null check close to the operation and makes the intent easy to read.

**Local functions and lambda expressions** can make code more compact when a small behavior belongs close to the method that uses it. They should still be used carefully: clarity matters more than clever syntax.

### Recent Language Features to Know

Modern C# versions introduced features that can make code shorter and more expressive:

- **Tuples**: Useful for returning small groups of related values without creating a full class.
- **Switch expressions and pattern matching**: Helpful when a decision returns a value or when branching depends on shape, type, or state.
- **Top-level statements**: Allow simple programs to avoid the full namespace/class/method structure.
- **Global using directives**: Reduce repeated `using` statements across files in larger projects.

Not every modern feature belongs in every project. The goal is to use language improvements when they make the code easier to understand, not just because they are available.

### Why These Improvements Matter

Modern C# features help developers write code that is:

- Easier for beginners to approach
- Easier for teams to read and maintain
- Less repetitive
- Safer around null values and invalid states
- Better aligned with current .NET development practices

For this ToDo console app, the most useful modern features are the small ones: property initializers, string interpolation, and null-conditional access. They improve the code without adding new architecture or changing the behavior.

## Modern C# Syntax in This Project

Modern C# includes small syntax improvements that make everyday code easier to read and maintain. This project uses a few of them in practical places.

### String Interpolation

String interpolation is useful when combining text with variables or expressions. It avoids long chains of string concatenation with `+`.

Before:

```csharp
foreach (var item in items)
{
    Console.WriteLine(index + ". " + item);
}
```

After:

```csharp
foreach (var item in items)
{
    Console.WriteLine($"{index}. {item}");
}
```

To use string interpolation:

1. Add `$` before the opening quotation mark.
2. Put variables or expressions inside `{}`.

In this project, string interpolation is used when displaying tasks and removal messages:

```csharp
Console.WriteLine($"{i + 1}. {TaskList[i]}");
Console.WriteLine($"Task {task} removed");
```

This keeps the output format compact and easy to scan.

### Property Initializers

Collections should be initialized before they are used. If a list is expected to store values throughout the program, initializing it early helps prevent null reference errors.

One option is to assign the list later:

```csharp
taskList = new List<Task>();
```

A cleaner option is to initialize the property where it is declared:

```csharp
public List<Task> TaskList { get; set; } = new List<Task>();
```

This project uses the same idea for the in-memory task list:

```csharp
public static List<string> TaskList { get; } = new List<string>();
```

Because the property is initialized immediately, the rest of the program can use `TaskList` without needing a separate setup assignment.

### Null-Conditional and Null-Coalescing Operators

C# provides operators that make null handling clearer.

The **null-conditional operator** `?.` safely accesses a member only when the value is not null:

```csharp
return TaskList?.Count > 0;
```

The **null-coalescing operator** `??` provides a fallback value when the left side is null:

```csharp
string message = userProvidedMessage ?? "Default value";
```

Use `?.` when you want to safely access a property or method. Use `??` when you want to provide a default value.

These operators reduce repetitive null checks while keeping the code expressive.

## Modernizing the .NET Project Structure

Modern C# features are easiest to use when the project targets a modern .NET version. Many language and SDK improvements became common starting with .NET 6 and continue in later versions such as .NET 8.

This repository currently targets .NET 8:

```xml
<TargetFramework>net8.0</TargetFramework>
```

That means the project can use modern C# syntax while staying aligned with a supported .NET platform.

### Target .NET 6 or Later

To use modern language features in an older project, update the project file to target `.NET 6` or later:

```xml
<PropertyGroup>
  <OutputType>Exe</OutputType>
  <TargetFramework>net8.0</TargetFramework>
</PropertyGroup>
```

For console applications, keep `OutputType` as `Exe`. If it is removed and the project uses executable-style code, the build may fail or the SDK may not treat the project as a runnable application.

### Implicit Usings

`ImplicitUsings` can reduce repeated `using` directives at the top of files. When enabled, the SDK automatically includes common namespaces for the project type.

```xml
<PropertyGroup>
  <OutputType>Exe</OutputType>
  <TargetFramework>net8.0</TargetFramework>
  <ImplicitUsings>enable</ImplicitUsings>
</PropertyGroup>
```

This can make small files cleaner, but it should be introduced intentionally. If the goal of the lesson is to show exactly where each namespace comes from, explicit `using` statements may still be useful.

### Top-Level Statements

Top-level statements allow small console applications to run without explicitly writing a `Program` class and `Main` method.

Traditional structure:

```csharp
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}
```

Top-level statement style:

```csharp
Console.WriteLine("Hello, World!");
```

This is helpful for demos, scripts, and very small programs. For this project, keeping the `Program` class is still reasonable because the course is practicing methods, responsibilities, enums, and refactoring.

### File-Scoped Namespaces

Modern C# also supports file-scoped namespaces. They remove one indentation level by replacing namespace braces with a semicolon:

```csharp
namespace ToDo;

internal class Program
{
}
```

This can reduce visual nesting while keeping the same namespace. It is a good candidate for a small future cleanup if the team wants a more modern file layout.

### Keep Modernization Non-Invasive

Modernization should make the code smaller or clearer without creating conflict. A safe approach is:

1. Update the target framework.
2. Build the project.
3. Enable one SDK or language feature at a time.
4. Build and run after each change.
5. Keep features that improve clarity and skip features that only make the code look clever.

For this repository, the best modernization path is evolutionary: keep the console app understandable, use modern syntax where it helps, and avoid turning a learning project into an overcomplicated structure.

## Naming Best Practices in C#

Following standards and naming best practices is essential for writing clean, readable, and maintainable C# code. Good names help explain intent, reduce confusion, and make collaboration easier for the whole team.

### Use Descriptive Variable Names

A variable name should communicate what the value stores or why it exists.

Poor practice:

```csharp
DateTime y;
```

Better practice:

```csharp
DateTime lastSyncModification;
```

In this project, `TL` is a useful example of a name that can be improved. A clearer name would describe the data being stored:

Poor practice:

```csharp
var TL = new List<string>();
```

Better practice:

```csharp
var taskList = new List<string>();
```

### Use PascalCase for Methods

Methods in C# should use PascalCase: start with an uppercase letter and capitalize each new word. Method names should also describe the action being performed.

Poor practice:

```csharp
void getuser()
{
    // Implementation
}
```

Better practice:

```csharp
void GetActiveUser()
{
    // Implementation
}
```

When working with an existing codebase, method names should be reviewed to make sure their purpose is clear. For example, a vague method such as `showMenu2` should be renamed to explain what menu action it handles.

Before:

```csharp
void showMenu2()
{
    // Code to remove a task
}
```

After:

```csharp
void ShowMenuRemoveTask()
{
    // Code to remove a task
}
```

### Use Clear Class Names

Class names should be descriptive and should represent the concept or responsibility of the class. Avoid Hungarian notation, generic placeholders, and numbers that do not add meaning. The type can usually be understood from the declaration itself.

Poor practice:

```csharp
public class ClassUser2
{
    // Implementation
}
```

Better practice:

```csharp
public class CustomUser
{
    // Implementation
}
```

### Apply Naming Improvements Safely

When improving names in an existing project, rename one concept at a time and verify that the program still works afterward. Useful steps include:

1. Identify unclear variable, method, or class names.
2. Rename them to describe their intent.
3. Build the project.
4. Run the application and test the affected behavior.

Use these commands after refactoring:

```bash
dotnet build
dotnet run
```

The next step is to continue analyzing the code, identify more opportunities for improvement, and apply these principles consistently. After naming, a natural follow-up topic is learning how to recognize and remove code smells.

## Code Smells in C#

A code smell is a symptom in the source code that suggests something may be harder to understand, maintain, test, or extend than it needs to be. A smell is not always a bug, but it is a signal that the code deserves a closer look.

Developers get better at recognizing code smells through practice. Over time, unclear names, repeated logic, long methods, hidden assumptions, and fragile error handling start to stand out quickly during reading or review.

### Naming Smells

Unclear names are one of the most common code smells. Variables, methods, and classes should explain their purpose without forcing the reader to inspect every implementation detail.

Examples of naming smells include:

- Abbreviations that hide meaning
- Generic names such as `data`, `item`, or `value` when a more specific name exists
- Method names that describe a UI location instead of a behavior
- Class names that include unnecessary prefixes, suffixes, or numbers

In this project, names such as `TaskList` and `menuOption` are more helpful than short or generic alternatives because they describe the role of the value.

### Long Methods and Large Classes

Very long methods and classes often indicate that too many responsibilities are grouped together. There is no universal line limit, but classes with hundreds or thousands of lines should raise a warning during review.

When a method or class feels difficult to scan, consider extracting smaller pieces with focused responsibilities. For this console application, one possible direction is separating task management logic from console input and output.

### Too Many Parameters

A method with many parameters can be hard to call correctly and hard to understand. It may also indicate that the method is doing too much or that related values should be grouped into a small object.

When a method starts accumulating parameters, review whether:

- The method has more than one responsibility
- Some parameters naturally belong together
- The behavior should be split into smaller operations
- A dedicated type would make the call clearer

### Magic Numbers and Strings

Magic numbers and strings are hardcoded values whose meaning is not obvious from the code. They make readers ask, "Why this value?"

In the current menu, the options are represented by direct numbers:

```csharp
if (menuOption == 1)
{
    ShowMenuAdd();
}
```

A clearer version can use an enum:

```csharp
enum MenuOption
{
    Add = 1,
    Remove = 2,
    List = 3,
    Exit = 4
}
```

With this approach, the code communicates intent through names instead of unexplained numbers.

### Empty Catch Blocks

Empty `catch` blocks hide failures and make debugging harder. If an exception is expected, handle it deliberately. If it is not expected, log it, show a useful message, or let it move up to a caller that can handle it.

Poor practice:

```csharp
try
{
    // Code that may fail
}
catch (Exception)
{
}
```

Better practice:

```csharp
try
{
    // Code that may fail
}
catch (FormatException ex)
{
    Console.WriteLine($"Invalid input: {ex.Message}");
}
```

When rethrowing an exception in C#, prefer `throw;` inside the `catch` block to preserve the original stack trace.

### String Concatenation in Loops

Strings are immutable in C#, so repeated concatenation inside large loops can create unnecessary allocations. For many repeated additions, use `StringBuilder`.

Poor practice:

```csharp
string message = string.Empty;

for (int i = 0; i < 100; i++)
{
    message = message + "Item " + i;
}
```

Better practice:

```csharp
var messageBuilder = new StringBuilder();

for (int i = 0; i < 100; i++)
{
    messageBuilder.Append("Item ");
    messageBuilder.Append(i);
}
```

### Other Common Code Smells

Additional smells to watch for include:

- Duplicate code that should be extracted into a shared method
- Compiler warnings that are ignored for too long
- Unnecessary object initialization before assigning the real value
- Missing null checks where values may be absent
- Event handlers that are subscribed but never unsubscribed
- Direct calls to `GC.Collect()` without a very specific reason
- Comments that explain confusing code instead of improving the code itself
- Missing tests for important behavior

### How to Improve Code Smells Safely

Improve smells in small steps. Each change should make the code easier to read or safer to modify without changing behavior unexpectedly.

Useful workflow:

1. Identify one smell.
2. Make the smallest useful improvement.
3. Build the project.
4. Run the application.
5. Repeat with the next smell.

```bash
dotnet build
dotnet run
```

For this project, good next steps include replacing menu magic numbers with an enum, improving input validation, and replacing empty `catch` blocks with intentional error handling.

## DRY Principle in C#

DRY means **Don't Repeat Yourself**. It is a software development principle that encourages developers to avoid unnecessary duplication in code, knowledge, and behavior.

In C#, applying DRY usually means extracting repeated routines into reusable methods, classes, or types. This keeps the code easier to read, easier to test, and easier to maintain. When duplicated logic changes, a DRY design lets you make the change in one place instead of hunting through multiple copies.

### Why DRY Is Often Broken

The most common reason DRY is broken is copy and paste. Copying code is not always wrong, especially while learning or exploring a solution, but copied code should be understood, adapted, and consolidated when a reusable pattern appears.

Duplication often appears in two forms:

- Exactly duplicated sections that can be extracted into a shared method
- Similar routines that can be unified with parameters or a small abstraction

The important step is to look for repeated patterns and ask whether the code is expressing one concept in several places.

### Applying DRY to This Project

This ToDo application has two flows that display tasks: listing pending tasks and showing tasks before removing one. If both flows contain their own copy of the task-listing logic, a future formatting change would need to be made twice.

A DRY improvement is to extract the shared display logic into a reusable method:

```csharp
public static void ShowMenuPending()
{
    if (TaskList == null || TaskList.Count == 0)
    {
        Console.WriteLine("There are no pending tasks");
        return;
    }

    ShowTaskList();
}

public static void ShowMenuRemove()
{
    Console.WriteLine("Enter the number of the task to remove: ");
    ShowTaskList();

    // Logic to remove the selected task...
}

private static void ShowTaskList()
{
    for (int i = 0; i < TaskList.Count; i++)
    {
        Console.WriteLine((i + 1) + ". " + TaskList[i]);
    }

    Console.WriteLine("----------------------------------------");
}
```

In this example, `ShowTaskList` owns the repeated task-list display behavior. Both menu actions can reuse it, so future changes to task formatting happen in one place.

### A Broader DRY Example

Without DRY, code that manages repeated concepts can grow quickly:

```csharp
string user1Name = "Alice";
int user1Age = 30;
string user1Email = "alice@email.com";

string user2Name = "Bob";
int user2Age = 25;
string user2Email = "bob@email.com";

Console.WriteLine($"User 1: {user1Name}, {user1Age} years old, Email: {user1Email}");
Console.WriteLine($"User 2: {user2Name}, {user2Age} years old, Email: {user2Email}");
```

A cleaner approach is to represent the repeated concept with a class:

```csharp
class User
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }

    public User(string name, int age, string email)
    {
        Name = name;
        Age = age;
        Email = email;
    }

    public void DisplayUserInfo()
    {
        Console.WriteLine($"User: {Name}, {Age} years old, Email: {Email}");
    }
}
```

Now the behavior and data structure live in one reusable place.

### Benefits of DRY

Applying DRY provides several practical benefits:

- Easier maintenance because shared behavior changes in one place
- Better readability because repeated noise is reduced
- Fewer inconsistencies because duplicated logic cannot drift apart as easily
- Better scalability because new features can reuse existing routines
- Improved testability because smaller reusable pieces are easier to verify

### Practicing DRY Safely

DRY should be applied thoughtfully. Extract repeated code when it represents the same idea, not just because two blocks look similar for the moment. Premature abstraction can make code harder to understand.

A safe workflow is:

1. Find repeated code.
2. Confirm the repeated code represents the same concept.
3. Extract the shared behavior into a method or type.
4. Build and run the project.
5. Keep the refactor small enough to review easily.

For this project, a good next DRY exercise is extracting the task-list display logic used by the pending-tasks and remove-task flows.

## KISS Principle in C#

KISS means **Keep It Simple, Stupid**. A friendlier version is **Keep It Short and Simple**. The idea is the same: prefer the simplest solution that clearly solves the problem.

Clean code does not always mean adding more files, classes, patterns, or abstraction layers. Sometimes the most professional solution is the small one that another developer can understand immediately.

### Why KISS Matters

KISS helps avoid overengineering. Overengineering happens when the solution is much more complex than the problem requires.

Separating responsibilities is useful when it improves clarity, testability, or changeability. The risk appears when new abstractions are added only "just in case" or to solve a simple problem with an unnecessarily large design.

Use this rule of thumb:

- If the problem is simple, start with a direct solution.
- If the problem becomes complex, introduce structure deliberately.
- If an abstraction does not reduce real complexity, wait before adding it.

### KISS and Refactoring

KISS is especially useful during refactoring. A refactor should make the code easier to understand without changing behavior. If a refactor creates too many moving parts, it may be technically clever but harder to maintain.

In this project, extracting a reusable `ShowTaskList` method is a good KISS-friendly refactor because it removes duplicated behavior without introducing a new class hierarchy or unnecessary architecture.

### Preincrement and Postincrement

When numbering items, C# supports both postincrement and preincrement:

- `index++` uses the current value first, then increments it.
- `++index` increments the value first, then uses it.

If a counter starts at `0`, postincrement prints `0` first:

```csharp
int index = 0;
Console.WriteLine(index++);
```

If the same counter uses preincrement, it prints `1` first:

```csharp
int index = 0;
Console.WriteLine(++index);
```

Another simple option is to start the counter at `1` and use postincrement:

```csharp
int index = 1;
Console.WriteLine(index++);
```

The current project uses `i + 1` while iterating through the list. That is also simple and clear for this small console application:

```csharp
for (int i = 0; i < TaskList.Count; i++)
{
    Console.WriteLine((i + 1) + ". " + TaskList[i]);
}
```

### Avoid Clever Code When Clear Code Is Better

A compact one-line expression is not always simpler. If a line requires too much mental effort, splitting it into clear steps may be more maintainable.

Less clear:

```csharp
var result = value > 10 ? value * 2 + offset / 3 : value - offset * 4;
```

Clearer:

```csharp
if (value > 10)
{
    return value * 2 + offset / 3;
}

return value - offset * 4;
```

The clearer version may use more lines, but it is easier to scan, debug, and change.

### Avoid Unnecessary Abstractions

Do not introduce classes, interfaces, or patterns before they solve a real problem. For example, this console application does not need a large architecture just to print a menu and manage an in-memory list.

Better reasons to add structure include:

- The file is becoming hard to navigate
- Logic needs automated tests
- Multiple features need the same behavior
- Responsibilities are clearly mixed
- Future changes are already painful

### Benefits of KISS

Applying KISS helps create code that is:

- Easier to read
- Easier to debug
- Easier to maintain
- Easier to extend
- Less likely to hide defects behind unnecessary complexity

### Practicing KISS Safely

Before adding a new abstraction, ask:

1. Does this solve a real problem today?
2. Does this make the code easier to read?
3. Would a simpler method or variable be enough?
4. Can the next developer understand this quickly?
5. Can I verify the behavior after the change?

Use the same safety loop after simplifying code:

```bash
dotnet build
dotnet run
```

For this project, KISS means making small improvements that reduce confusion without turning a simple console application into an oversized system.

## Exception Handling in C#

`try-catch` is a C# structure used to handle exceptional errors in a controlled way. It is important to use it deliberately: exceptions are useful for unexpected failures, but they should not replace normal validation or simple control flow.

### When to Use try-catch

Use `try-catch` when the code may fail for reasons that are hard to prevent with ordinary checks.

Good examples include:

- Network errors when calling an external service
- File system errors when reading or writing files
- Database failures
- Unexpected errors from third-party APIs
- Operations where the environment can change outside your program's control

Avoid using exceptions for expected user input mistakes. In those cases, validation is clearer and usually faster.

### Prefer Validation for Expected Cases

For expected situations, check the condition before the operation. This keeps the program flow simple and avoids using exceptions as normal logic.

Prefer this:

```csharp
public static double GetDivision(int a, int b)
{
    if (b == 0)
    {
        return double.NaN;
    }

    return a / b;
}
```

Avoid this when zero is an expected input:

```csharp
public static double GetDivisionException(int a, int b)
{
    try
    {
        return a / b;
    }
    catch (DivideByZeroException)
    {
        return double.NaN;
    }
}
```

The first version handles the known condition before the exception happens.

### Handle Exceptions Intentionally

An empty `catch` block hides failures and makes debugging harder. If an exception is caught, the code should do something useful with it: show a clear message, log the error, retry safely, release resources, or stop the operation.

Poor practice:

```csharp
try
{
    RemoveTask();
}
catch (Exception)
{
}
```

Better practice:

```csharp
try
{
    RemoveTask();
}
catch (InvalidOperationException ex)
{
    Console.WriteLine("The task could not be removed.");
    LogError(ex);
}
```

In real applications, `LogError` would write details to a logging system so developers can diagnose the issue later.

### Validate Indexes Before Accessing Lists

List access is a common place where validation is better than catching exceptions. Check that the selected index is inside the valid range before using it.

```csharp
if (indexToRemove >= 0 && indexToRemove < TaskList.Count)
{
    string task = TaskList[indexToRemove];
    TaskList.RemoveAt(indexToRemove);
}
else
{
    Console.WriteLine("Task number does not exist");
}
```

This project follows that approach in the remove-task flow: it validates the selected task number before removing from `TaskList`.

### Use TryParse for User Input

Console input is text, and users may type something that is not a number. `TryParse` keeps the code explicit and avoids unnecessary exceptions.

```csharp
if (!int.TryParse(line, out int taskNumber))
{
    Console.WriteLine("Invalid task number");
    return;
}
```

This is simpler than catching a parsing exception because invalid input is expected behavior in an interactive console app.

### Keep try-catch Focused

Large `try-catch` blocks can make it harder to know which operation failed. Keep the block as small as practical and catch the most specific exception type you can handle.

Good exception handling should:

- Catch exceptions only where the code can respond meaningfully
- Prefer specific exception types over generic `Exception`
- Avoid empty `catch` blocks
- Preserve useful diagnostic information
- Use `finally` or `using` when resources must be released
- Let unexpected errors move upward when the current method cannot handle them safely

### Impact on Program Flow

Used well, `try-catch` helps the program fail gracefully and gives developers better diagnostic information. Used everywhere, it can hide bugs, make the code harder to follow, and add unnecessary overhead.

For this project, the best current approach is to validate menu options and task indexes directly, while saving `try-catch` for future features that interact with files, databases, services, or other external resources.

## Suggested Improvements

Future refactoring sessions can focus on:

- Handling invalid menu input without crashing
- Avoiding empty `catch` blocks
- Extracting duplicated task-list display logic into a reusable method
- Extracting task management logic from console UI logic
- Adding automated tests for task behavior
- Persisting tasks to a file or database

## Project Structure

```text
bestPracticesCSharp_
├── Program.cs
├── ToDo.csproj
├── ToDo.sln
├── README.md
└── .gitignore
```

- `Program.cs`: Contains the console application logic.
- `ToDo.csproj`: Defines the .NET project configuration.
- `ToDo.sln`: Solution file for opening the project in IDEs.
- `README.md`: Project documentation.
