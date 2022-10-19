//ITSE 1430 
//Fall 2022
//Claire Walker

using ClaireWalker.CharacterCreator;

DisplayInfo();

var done = false;
Character character = null;

do
{
    var input = DisplayMenu();

    switch ( input )
    {
        case MenuOption.AddNewCharacter:
        {
            var theCharacter = AddNewCharacter();
            character = theCharacter.Clone();
            break;
        }
        case MenuOption.ViewCharacter: HandleViewCharacter( character ); break;
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

MenuOption DisplayMenu ()
{

    do
    {
        Console.WriteLine();
        Console.WriteLine("Press A to add a new character.");
        Console.WriteLine("Press V to view your character.");
        Console.WriteLine("Press Q to quit.");

        ConsoleKeyInfo key = Console.ReadKey(true);
        switch (key.Key)
        {
            case ConsoleKey.A: return MenuOption.AddNewCharacter;
            case ConsoleKey.V: return MenuOption.ViewCharacter;
            case ConsoleKey.Q: return MenuOption.Quit;
        };

    } while (true);
}

bool ReadBoolean ( string message )
{
    Console.Write( message );

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
    Console.Write( message );

    do
    {

        string value = Console.ReadLine();

        if (Int32.TryParse(value, out var result))
        {
            if (result >= minimumValue && result <= maximumValue)
                return result;
        };

        Console.WriteLine("Value must be between " + minimumValue + " and " + maximumValue + ".");
        Console.WriteLine("");

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

        Console.WriteLine("An entry is required.");
        Console.WriteLine("");

    };
}

bool HandleQuit ()
{
    if (Confirm("Are you sure you want to quit (Y/N)?"))
        return true;

    return false;
}

bool Confirm ( string message )
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

    Profession _profession = HandleProfession();
    if (_profession == Profession.Fighter)
            character.Profession = "Fighter";
    else if (_profession == Profession.Hunter)
            character.Profession = "Hunter";
    else if (_profession == Profession.Priest)
            character.Profession = "Priest";
    else if (_profession == Profession.Rogue)
            character.Profession = "Rogue";
    else if (_profession == Profession.Wizard)
            character.Profession = "Wizard";

    Race _race = HandleRace();
    if (_race == Race.Dwarf)
            character.Race = "Dwarf";
    else if (_race == Race.Elf)
            character.Race = "Elf";
    else if (_race == Race.Gnome)
            character.Race = "Gnome";
    else if (_race == Race.Fairy)
            character.Race = "Fairy";
    else if (_race == Race.Human)
            character.Race = "Human";

    Console.WriteLine("");
    character.Background = ReadString("Enter the background information on your character (Optional): ", false);
    character.Strength = ReadInt32("Enter the strength of your character using a number between 1-100: ", 1, 100);
    character.Charisma = ReadInt32("Enter the charisma of your character using a number between 1-100: ", 1, 100);
    character.Intelligence = ReadInt32("Enter the intelligence of your character using a number between 1-100: ", 1, 100);
    character.Agility = ReadInt32("Enter the agility of your character using a number between 1-100: ", 1, 100);
    character.Constitution = ReadInt32("Enter the constitution of your character using a number between 1-100: ", 1, 100);

    return character;
}

void HandleViewCharacter (Character character)
{
    if (character == null)
    {
        Console.WriteLine("There is no character available to view.");
        return;
    };

    DisplayCharacter(character);
}

void DisplayCharacter (Character character)
{
    Console.WriteLine($"Name: {character.Name}");
    Console.WriteLine($"Profession: {character.Profession}");
    Console.WriteLine($"Race: {character.Race}");

    Console.WriteLine("");
    Console.WriteLine($"Background: {character?.Background}");

    Console.WriteLine("");
    Console.WriteLine($"Strength: {character.Strength}");
    Console.WriteLine($"Charisma: {character.Charisma}");
    Console.WriteLine($"Intelligence: {character.Intelligence}");
    Console.WriteLine($"Agility: {character.Agility}");
    Console.WriteLine($"Constitution: {character.Constitution}");
}

Profession HandleProfession ()
{
    do
    {

        Console.WriteLine();
        Console.WriteLine("Which profession do you choose for your character?");
        Console.WriteLine("Press H for Hunter.");
        Console.WriteLine("Press W for Wizard.");
        Console.WriteLine("Press P for Priest.");
        Console.WriteLine("Press F for Fighter.");
        Console.WriteLine("Press R for Rogue.");

        ConsoleKeyInfo key = Console.ReadKey(true);
        switch (key.Key)
        {
            case ConsoleKey.H: return Profession.Hunter;
            case ConsoleKey.W: return Profession.Wizard;
            case ConsoleKey.P: return Profession.Priest;
            case ConsoleKey.F: return Profession.Fighter;
            case ConsoleKey.R: return Profession.Rogue;
        };

    } while (true);
}

Race HandleRace ()
{
    do
    {

        Console.WriteLine();
        Console.WriteLine("Which race do you choose for your character?");
        Console.WriteLine("Press D for Dwarf.");
        Console.WriteLine("Press E for Elf.");
        Console.WriteLine("Press G for Gnome.");
        Console.WriteLine("Press F for Fairy.");
        Console.WriteLine("Press H for Human.");

        ConsoleKeyInfo key = Console.ReadKey(true);
        switch (key.Key)
        {
            case ConsoleKey.D: return Race.Dwarf;
            case ConsoleKey.E: return Race.Elf;
            case ConsoleKey.G: return Race.Gnome;
            case ConsoleKey.F: return Race.Fairy;
            case ConsoleKey.H: return Race.Human;
        };

    } while (true);
}