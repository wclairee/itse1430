//ITSE 1430 
//Fall 2022
//Claire Walker

using System.Reflection.PortableExecutable;
using ClaireWalker.CharacterCreator;

DisplayInfo();

var done = false;

do
{
    var input = DisplayMenu();
    switch (input)
    {
        case MenuOption.AddNewCharacter: AddNewCharacter(); break;
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
    Console.WriteLine("Press A to add a new character.");
    Console.WriteLine("Press Q to quit.");

    do
    {
        ConsoleKeyInfo key = Console.ReadKey(true);
        switch (key.Key)
        {
            case ConsoleKey.A: return MenuOption.AddNewCharacter;
            case ConsoleKey.Q: return MenuOption.Quit;
        };
    } while (true);
}

bool ReadBoolean ( string message )
{
    Console.Write(message);

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

        if (Int32.TryParse(value, out var result))
        {
            if (result >= minimumValue && result <= maximumValue)
                return result;
        };

        Console.WriteLine("Value must be between " + minimumValue + " and " + maximumValue);
    } while (true);
}

string ReadString ( string message, bool required )
{
    Console.Write(message);

    while (true)
    {
        string value = Console.ReadLine();

        if (value != "" || !required)
            return value;

        Console.WriteLine("Value is required");
    };
}


bool HandleQuit ()
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

Character AddNewCharacter()
{
    Character character = new Character();

    character.Name = ReadString("Enter the name of your character: ", true);
    character.Profession = ReadString("Enter the desired profession of your character: ", true);
    character.Race = ReadString("Enter the desired race of your character: ", true);
    character.Background = ReadString("Enter the background information on your character (Optional): ", false);
    character.Strength = ReadInt32("Enter the strength of your character using a number between 1-100: ", 1, 100);
    character.Charisma = ReadInt32("Enter the charisma of your character using a number between 1-100: ", 1, 100);
    character.Intelligence = ReadInt32("Enter the intelligence of your character using a number between 1-100: ", 1, 100);
    character.Agility = ReadInt32("Enter the agility of your character using a number between 1-100: ", 1, 100);
    character.Constitution = ReadInt32("Enter the constitution of your character using a number between 1-100: ", 1, 100);

    return character;
}