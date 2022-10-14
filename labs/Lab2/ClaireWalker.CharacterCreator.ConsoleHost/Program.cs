//ITSE 1430 
//Fall 2022
//Claire Walker

DisplayInfo();
DisplayMenu();

var done = false;

do
{
    switch (DisplayMenu())
    {
        case MenuOption.Quit: done = HandleQuit(); break;
    }
} while (!done);

void DisplayInfo ()
{
    //information displays when application starts
    Console.WriteLine("Claire Walker");
    Console.WriteLine("ITSE 1430");
    Console.WriteLine("Fall 2022");
    Console.WriteLine();
}

MenuOption DisplayMenu()
{
    Console.WriteLine();
    Console.WriteLine("Press Q to quit.");

    switch (GetKeyInput(ConsoleKey.Q))
    {
        case ConsoleKey.Q: return MenuOption.Quit;
    };

    return 0;
}

bool HandleQuit()
{
    if (Confirm("Are you sure you want to quit (Y/N)?"))
        return true;

    return false;
}

bool Confirm( string message )
{
    Console.WriteLine(message);

    return GetKeyInput(ConsoleKey.Y, ConsoleKey.N) == ConsoleKey.Y;
}

ConsoleKey GetKeyInput ( params ConsoleKey[] validKeys )
{
    do
    {
        var key = Console.ReadKey(true);
        if (validKeys.Contains(key.Key))
        {
            Console.WriteLine();
            return key.Key;
        };
    } while (true);
}