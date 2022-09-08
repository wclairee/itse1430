//Movie definition
string title = "";
string description = "";
int runLength = 0; //in minutes
int releaseYear = 1900;
string rating = "";
bool isClassic = false;

AddMovie();

bool ReadBoolean ( string message )
{
    Console.Write(message);

    //Looking for Y/N
    ConsoleKeyInfo key = Console.ReadKey();
    if (key.Key == ConsoleKey.Y)
        return true;
    else if (key.Key == ConsoleKey.N)
        return false;


    //TODO: error
    return false;
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