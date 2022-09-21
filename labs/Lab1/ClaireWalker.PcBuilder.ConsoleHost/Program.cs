using System.ComponentModel.DataAnnotations;

var done = false;
decimal currentCartTotal = 0;
var memoryChoice = 0;
var processorChoice = 0;

DisplayInfo();

do
{
    var userResponse = DisplayMenu();
    Console.WriteLine();
    if (userResponse == 1)
        StartNewOrder();
    else if (userResponse == 2)
        ViewOrder();
    else if (userResponse == 3)
        ClearOrder();
    else if (userResponse == 4)
        ModifyOrder();
    else if (userResponse == 5)
    {
        bool answer = ReadBoolean("Are you sure you want to quit? Y/N");
        if (answer == true)
            break;
        else if (answer == false)


    }
} while (true);

//Functions
void DisplayInfo ()
{
    //information displays when application starts
    Console.WriteLine("Claire Walker");
    Console.WriteLine("ITSE 1430");
    Console.WriteLine("Fall 2022");
    Console.WriteLine();
}

int DisplayMenu()
{
    Console.WriteLine($"The current cart total is ${currentCartTotal}.");
    Console.WriteLine("Press 1 to start a new order.");
    Console.WriteLine("Press 2 to view your current order.");
    Console.WriteLine("Press 3 to clear your current order.");
    Console.WriteLine("Press 4 to modify your current order.");
    Console.WriteLine("Press 5 to quit.");
    do
    {
        string input = Console.ReadLine();
        int value = Int32.Parse(input);
        return value;
    } while (true);
}

void StartNewOrder ()
{
    decimal ryzen9 = 1410;
    decimal ryzen7 = 1270;
    decimal ryzen5 = 1200;
    decimal intel9 = 1590;
    decimal intel7 = 1400;
    decimal intel5 = 1280;
    currentCartTotal = 0;

    Console.WriteLine();
    Console.WriteLine("1.) AMD Ryzen 9 5900X\t$" + ryzen9);
    Console.WriteLine("2.) AMD Ryzen 7 5700X\t$" + ryzen7);
    Console.WriteLine("3.) AMD Ryzen 5 5600X\t$" + ryzen5);
    Console.WriteLine("4.) Intel i9-12900K\t$" + intel9);
    Console.WriteLine("5.) Intel i7-12700K\t$" + intel7);
    Console.WriteLine("6.) Intel i5-12600K\t$" + intel5);

    do
    {
        processorChoice = ReadInt32("Which processor would you like to use? Select a number between 1-6", 1, 6);
        if (processorChoice == 1)
            currentCartTotal += ryzen9;
        else if (processorChoice == 2)
            currentCartTotal += ryzen7;
        else if (processorChoice == 3)
            currentCartTotal += ryzen5;
        else if (processorChoice == 4)
            currentCartTotal += intel9;
        else if (processorChoice == 5)
            currentCartTotal += intel7;
        else if (processorChoice == 6)
            currentCartTotal += intel5;
            
    } while (true);
}

void CalculatePrice ()
{

}

void ViewOrder ()
{

}

void ModifyOrder()
{ 

}

void ClearOrder()
{

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

        //check if required
        if (value != "" || !required)
            return value;

        //value is empty and required
        Console.WriteLine("Value is required");
    };
}