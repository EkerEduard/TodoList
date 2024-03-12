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

void SeeAllTodos()
{
    if (todos.Count == 0)
    {
        ShowNoTodosMessage();
    }
    else
    {
        for (int i = 0; i < todos.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {todos[i]}");
        }
    }
}

void AddTodo()
{
    bool isValidDescripttion = false;
    while (!isValidDescripttion)
    {
        Console.WriteLine("Enter the TODO description:");
        var description = Console.ReadLine();

        if (description == "")
        {
            Console.WriteLine("The discription cannot be empty");
        }
        else if (todos.Contains(description))
        {
            Console.WriteLine("The description must be unique.");
        }
        else
        {
            isValidDescripttion = true;
            todos.Add(description);
        }
    }
}

void RemoveTodo()
{
    if (todos.Count == 0)
    {
        ShowNoTodosMessage();
        return;
    }
    bool isIndexValid = false;
    while (!isIndexValid)
    {
        Console.WriteLine("Select the index of the TODO you want to remove");
        SeeAllTodos();
        var userInput = Console.ReadLine();
        if (userInput == "")
        {
            Console.WriteLine("Selected index cannot be empty");
            continue;
        }

        if (int.TryParse(userInput, out int index) &&
            index >= 1 &&
            index <= todos.Count)
        {
            var indexOfTodo = index - 1;
            var todoToBeRemoved = todos[indexOfTodo];
            todos.RemoveAt(indexOfTodo);
            isIndexValid = true;
            Console.WriteLine("TODO removed: " + todoToBeRemoved);
        }
        else
        {
            Console.WriteLine("The given index is not valid.");
        }
    }
}





static void ShowNoTodosMessage()
{
    Console.WriteLine("No TODOs have been added yet.");
}

Console.ReadKey();