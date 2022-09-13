//Movie definition
string title = "";
string description = "";
int runLength = 0; //in minutes
int releaseYear = 1900;
string rating = "";
bool isClassic = false;

DisplayInformation();

bool done = false;
do
{
    MenuOption input = DisplayMenu();
    Console.WriteLine();
    switch (input)
    {
        case MenuOption.Add:
        {
            AddMovie();
            break;
        }

        case MenuOption.Edit: EditMovie(); break;
        case MenuOption.View: ViewMovie(); break;
        case MenuOption.Delete: DeleteMovie(); break;
        case MenuOption.Quit: done = true; break;
    };
    //if (input == 'A')
    //    AddMovie();
    //else if (input == 'E')
    //    EditMovie();
    //else if (input == 'V')
    //    ViewMovie();
    //else if (input == 'D')
    //    DeleteMovie();
    //else if (input == 'Q')
    //    break;
} while (!done);


/// Functions
///

void DisplayInformation()
{
    Console.WriteLine("Movie Library");
    Console.WriteLine("Claire Walker");
    Console.WriteLine("Fall 2022");
}

MenuOption DisplayMenu ()
{
    Console.WriteLine();
    Console.WriteLine("A)dd Movie");
    Console.WriteLine("E)dit Movie");
    Console.WriteLine("V)iew Movie");
    Console.WriteLine("D)elete Movie");
    Console.WriteLine("Q)uit");

    do
    {
        ConsoleKeyInfo key = Console.ReadKey(true);
        switch (key.Key)
        {
            case ConsoleKey.A: return MenuOption.Add;
            case ConsoleKey.E: return MenuOption.Edit;
            case ConsoleKey.V: return MenuOption.View;
            case ConsoleKey.D: return MenuOption.Delete;
            case ConsoleKey.Q: return MenuOption.Quit;
        };

        //if (key.Key == ConsoleKey.A)
        //    return 'A';
        //else if (key.Key == ConsoleKey.E)
        //    return 'E';
        //else if (key.Key == ConsoleKey.V)
        //    return 'V';
        //else if (key.Key == ConsoleKey.D)
        //    return 'D';
        //else if (key.Key == ConsoleKey.Q)
        //    return 'Q';
    } while (true);
}

bool ReadBoolean ( string message )
{
    Console.Write(message);

    //Looking for Y/N
    do 
    { 
           ConsoleKeyInfo key = Console.ReadKey();
        if (key.Key == ConsoleKey.Y)
            return true;
        else if (key.Key == ConsoleKey.N)
            return false;
    } while (true);
}

int ReadInt32 ( string message, int minimumValue, int maximumValue )
{
    Console.Write(message);

    do
    {

   
        string value = Console.ReadLine();

        //Inline variable declarations
        //int result;
        //if (Int32.TryParse(value, out result))
        if (Int32.TryParse(value, out int result))
        {
            if (result >= minimumValue && result <= maximumValue)
            return result;
        };

        //if (false)
            //break; //Exit loop
            //continue; //Exit iteration

        Console.WriteLine("Value must be between " + minimumValue + " and " + maximumValue);
    } while (true);
}

string ReadString ( string message, bool required )
{
    //message = "Bob";
    Console.Write(message);

    while (true)
    {
        string value = Console.ReadLine();

        //check if required
        if (value != "" || !required)
            return value;

        //value is empty and required
        Console.WriteLine("Value is required");
    };
}

void AddMovie ()
{
    //string title = "";
    title = ReadString("Enter a title: ", true);

    //string description = "";
    description = ReadString("Enter an optional description: ", false);

    //int runLength = 0; //in minutes
    runLength = ReadInt32("Enter a run length (in minutes): ", 0, 300);

    releaseYear = ReadInt32("Enter the release year: ", 1900, 2100);
    rating = ReadString("Entering MPAA rating: ", true);

    isClassic = ReadBoolean("Is this a classic? ");
}

void DeleteMovie ()
{
    if (title == "")
        return;

    //Not confirmed
    if (!ReadBoolean("Are you sure you want to delete the movie (Y/N)? "))
        return;

    //TODO: Delete Movie
    title = "";
}

void EditMovie ()
{ }

void ViewMovie ()
{
    if (title == "")
    {
        Console.WriteLine("No movies available");
        return;
    };

    Console.WriteLine(title);
    Console.WriteLine(releaseYear);
    Console.WriteLine("Length: " + runLength + " mins");
    Console.WriteLine("MPAA Rating: " + rating);
    Console.WriteLine("Classic: " + isClassic);
    Console.WriteLine(description);
}
