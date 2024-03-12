
using System;

var todos = new List<string>();

Console.WriteLine("Hello!");

bool shallExit = false;
while (!shallExit)
{
    Console.WriteLine("What do you want to do?");
    Console.WriteLine("[S]ee all todos");
    Console.WriteLine("[A]dd a todo");
    Console.WriteLine("[R]emove a todo");
    Console.WriteLine("[E]xit");

    var userChoice = Console.ReadLine();

    switch (userChoice)
    {
        case "S":
        case "s":
            SeeAllTodos();
            break;
        case "A":
        case "a":
            AddTodo();
            break;
        case "R":
        case "r":
            RemoveTodo();
            break;
        case "E":
        case "e":
            shallExit = true;
            break;
        default:
            Console.WriteLine("Invalid choice");
            break;
    }
}

// Список задач
void SeeAllTodos()
{
    if (todos.Count == 0)
    {
        ShowNoTodosMessage();
        return;
    }

    for (int i = 0; i < todos.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {todos[i]}");
    }

}

//Добавляем TODO
void AddTodo()
{
    // Запрашиваем у пользователя описание todo.
    // Как только пользователь вводит допустимое описание он помещает его в список задач.
    string description;
    do
    {
        Console.WriteLine("Enter the TODO description:");
        description = Console.ReadLine();
    } while (!IsDescriptionValid(description));

    todos.Add(description);
}

// Коррекнтность описания TODO
bool IsDescriptionValid(string description)
{
    if (description == "")
    {
        Console.WriteLine("The discription cannot be empty");
        return false;
    }
    else if (todos.Contains(description))
    {
        Console.WriteLine("The description must be unique.");
        return false;
    }
    return true;
}

void RemoveTodo()
{
    if (todos.Count == 0)
    {
        ShowNoTodosMessage();
        return;
    }

    int index;
    do
    {
        Console.WriteLine("Select the index of the TODO you want to remove");
        SeeAllTodos();
    } while (!TryReadIndex(out index));

    RemoveTodoAtindex(index - 1);
}

void RemoveTodoAtindex(int index)
{
    //Удаляет задачу по заданному индексу
    var todoToBeRemoved = todos[index];
    todos.RemoveAt(index);
    Console.WriteLine("TODO removed: " + todoToBeRemoved);
}

bool TryReadIndex(out int index)
{
    var userInput = Console.ReadLine();
    if (userInput == "")
    {
        index = 0;
        Console.WriteLine("Selected index cannot be empty");
        return false;
    }

    if (int.TryParse(userInput, out index) &&
        index >= 1 &&
        index <= todos.Count)
    {
        return true;
    }
    Console.WriteLine("The given index is not valid.");
    return false;

}

static void ShowNoTodosMessage()
{
    Console.WriteLine("No TODOs have been added yet.");
}

Console.ReadKey();