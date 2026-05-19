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
- [Naming Best Practices in C#](#naming-best-practices-in-c)
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

## Suggested Improvements

Future refactoring sessions can focus on:

- Renaming `TL` to a clearer name such as `tasks`
- Renaming generic variables such as `variable` to names that describe their purpose
- Handling invalid menu input without crashing
- Avoiding empty `catch` blocks
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
