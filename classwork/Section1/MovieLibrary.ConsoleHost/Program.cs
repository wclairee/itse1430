//Movie definition
string title = "";
string description = "";
int runLength = 0; //in minutes
int releaseYear = 1900;
string rating = "";
bool isClassic = false;

AddMovie();

int ReadInt32 ( string message )
{
    Console.Write(message);

    string value = Console.ReadLine();

    //Inline variable declarations
    //int result;
    //if (Int32.TryParse(value, out result))
    if (Int32.TryParse(value, out int result))
        return result;

    //TODO Loop
    return -1;
}

string ReadString ( string message )
{
    Console.Write(message);

    string value = Console.ReadLine();

    return value;
}

void AddMovie ()
{
    //string title = "";
    title = ReadString("Enter a title: ");

    //string description = "";
    description = ReadString("Enter an optional description: ");

    //int runLength = 0; //in minutes
    runLength = ReadInt32("Enter a run length (in minutes): ");

    releaseYear = ReadInt32("Enter the release year: ");
    rating = ReadString("Entering MPAA rating: ");

    Console.WriteLine("Is this a classic? ");
}