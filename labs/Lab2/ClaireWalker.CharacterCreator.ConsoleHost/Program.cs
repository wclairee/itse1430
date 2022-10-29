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

    switch (input)
    {
        case MenuOption.AddNewCharacter:
        {
            character = AddNewCharacter();
            break;
        }
        case MenuOption.ViewCharacter: HandleViewCharacter(character); break;
        case MenuOption.EditCharacter:
        {
            character = HandleEditCharacter(character);
            break;
        }
        case MenuOption.DeleteCharacter:
        {
            character = HandleDeleteCharacter();
            break;
        }
        case MenuOption.Quit: done = HandleQuit(); break;
    }

} while (!done);


MenuOption DisplayMenu ()
{

    do
    {
        Console.WriteLine();
        Console.WriteLine("Press A to add a new character.");
        Console.WriteLine("Press V to view your character.");
        Console.WriteLine("Press E to edit your character.");
        Console.WriteLine("Press D to delete your character.");
        Console.WriteLine("Press Q to quit.");
        Console.WriteLine();

        ConsoleKeyInfo key = Console.ReadKey(true);

        switch (key.Key)
        {
            case ConsoleKey.A: return MenuOption.AddNewCharacter;
            case ConsoleKey.V: return MenuOption.ViewCharacter;
            case ConsoleKey.E: return MenuOption.EditCharacter;
            case ConsoleKey.D: return MenuOption.DeleteCharacter;
            case ConsoleKey.Q: return MenuOption.Quit;
        };

    } while (true);
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

void DisplayInfo ()
{
    //information displays when application starts
    Console.WriteLine("Claire Walker");
    Console.WriteLine("ITSE 1430");
    Console.WriteLine("Fall 2022");
    Console.WriteLine();
}

void HandleViewCharacter ( Character character )
{
    if (character == null)
    {
        Console.WriteLine("There is no character available to view.");
        return;
    };

    DisplayCharacter(character);
}

void DisplayCharacter ( Character character )
{
    Console.WriteLine($"Name: {character.Name}");
    Console.WriteLine($"Profession: {character.Profession}");
    Console.WriteLine($"Race: {character.Race}");
    Console.WriteLine($"Background: {character.Background}");
    Console.WriteLine($"Strength: {character.Strength}");
    Console.WriteLine($"Charisma: {character.Charisma}");
    Console.WriteLine($"Intelligence: {character.Intelligence}");
    Console.WriteLine($"Agility: {character.Agility}");
    Console.WriteLine($"Constitution: {character.Constitution}");
}

Character AddNewCharacter ()
{
    Character character = new Character();

    character.Name = ReadString("Enter the name of your character: ", true);
    character = HandleProfession(character);
    character = HandleRace(character);
    Console.WriteLine("");
    character.Background = ReadString("Enter the background information on your character (Optional): ", false);
    character.Strength = ReadInt32("Enter the strength of your character using a number between 1-100: ", 1, 100);
    character.Charisma = ReadInt32("Enter the charisma of your character using a number between 1-100: ", 1, 100);
    character.Intelligence = ReadInt32("Enter the intelligence of your character using a number between 1-100: ", 1, 100);
    character.Agility = ReadInt32("Enter the agility of your character using a number between 1-100: ", 1, 100);
    character.Constitution = ReadInt32("Enter the constitution of your character using a number between 1-100: ", 1, 100);

    return character;
}

Character HandleEditCharacter ( Character character )
{
    if (character == null)
    {
        character = AddNewCharacter();
        return character;
    };

    character = EditCharacter();
    return character;
}

Character EditCharacter()
{
    Console.WriteLine("Which character trait would you like to change?");
    Console.WriteLine("Select N for name.");
    Console.WriteLine("Select P for profession.");
    Console.WriteLine("Select R for race.");
    Console.WriteLine("Select B for background.");
    Console.WriteLine("Select S for strength.");
    Console.WriteLine("Select C for charisma.");
    Console.WriteLine("Select I for intelligence.");
    Console.WriteLine("Select A for agility.");
    Console.WriteLine("Select X for constitution.");

    switch(GetKeyInput(ConsoleKey.N, ConsoleKey.P, ConsoleKey.R, ConsoleKey.B, ConsoleKey.S, ConsoleKey.C, ConsoleKey.I, ConsoleKey.A, ConsoleKey.X))
    {
        case ConsoleKey.N:
        {
            character.Name = ReadString("Enter the name of your character: ", true);
            break;
        }
        case ConsoleKey.P: character = HandleProfession(character); break;
        case ConsoleKey.R: character = HandleRace(character); break;
        case ConsoleKey.B:
        {
            character.Background = ReadString("Enter the background information on your character (Optional): ", false);
            break;
        }
        case ConsoleKey.S:
        {
            character.Strength = ReadInt32("What would you like the new strength to be?", 1, 100);
            break;
        }
        case ConsoleKey.C:
        {
            character.Charisma = ReadInt32("What would you like the new charisma to be?", 1, 100);
            break;
        }
        case ConsoleKey.I:
        {
            character.Intelligence = ReadInt32("What would you like the new intelligence to be?", 1, 100);
            break;
        }
        case ConsoleKey.A:
        {
            character.Agility = ReadInt32("What would you like the new agility to be?", 1, 100);
            break;
        }

        case ConsoleKey.X:
        {
            character.Constitution = ReadInt32("What would you like the new constitution to be?", 1, 100);
            break;
        }
    }
    DisplayCharacter(character);
    return character;

}

Character HandleProfession ( Character character )
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

            case ConsoleKey.H: character.Profession = "Hunter"; break;
            case ConsoleKey.W: character.Profession = "Wizard"; break;
            case ConsoleKey.P: character.Profession = "Priest"; break;
            case ConsoleKey.F: character.Profession = "Fighter"; break;
            case ConsoleKey.R: character.Profession = "Rogue"; break;
        };

        return character;

    } while (true);
}

Character HandleRace ( Character character )
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

            case ConsoleKey.D: character.Race = "Dwarf"; break;
            case ConsoleKey.E: character.Race = "Elf"; break;
            case ConsoleKey.G: character.Race = "Gnome"; break;
            case ConsoleKey.F: character.Race = "Fairy"; break;
            case ConsoleKey.H: character.Race = "Human"; break;
        };

        return character;

    } while (true);
}

Character HandleDeleteCharacter ()
{
    if (character == null)
    {
        Console.WriteLine("There is no character available to delete.");
        return character;
    }

    if (!Confirm("Are you sure you want to delete your character? (Y/N) "))
        return character;

    else if (character != null)
       character = DeleteCharacter();
    return character;
}

Character DeleteCharacter()
{
    character = null;
    return character;
}

