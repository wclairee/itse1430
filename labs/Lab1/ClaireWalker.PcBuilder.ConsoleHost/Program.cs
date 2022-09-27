decimal currentCartTotal = 0;
var memoryChoice = 0;
var processorChoice = 0;
decimal ryzen9 = 1410;
decimal ryzen7 = 1270;
decimal ryzen5 = 1200;
decimal intel9 = 1590;
decimal intel7 = 1400;
decimal intel5 = 1280;
decimal memory8gb = 30;
decimal memory16gb = 40;
decimal memory32gb = 90;
decimal memory64gb = 410;
decimal memory128gb = 600;

DisplayInfo();

do
{

    var userResponse = DisplayMenu();

    Console.WriteLine();

    if (userResponse == 1)
        StartNewOrder();
    else if (userResponse == 2)
        ViewOrder(processorChoice, memoryChoice);
    else if (userResponse == 3)
        ClearOrder();
    else if (userResponse == 4)
        ModifyOrder();
    else if (userResponse == 5)
    {
        bool answer = ReadBoolean("Are you sure you want to quit? Y/N ");
        if (answer != true)
            continue;
        break;
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
    Console.WriteLine();
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
    currentCartTotal = 0;

    Console.WriteLine();
    Console.WriteLine("1.) AMD Ryzen 9 5900X\t$" + ryzen9);
    Console.WriteLine("2.) AMD Ryzen 7 5700X\t$" + ryzen7);
    Console.WriteLine("3.) AMD Ryzen 5 5600X\t$" + ryzen5);
    Console.WriteLine("4.) Intel i9-12900K\t$" + intel9);
    Console.WriteLine("5.) Intel i7-12700K\t$" + intel7);
    Console.WriteLine("6.) Intel i5-12600K\t$" + intel5);

    processorChoice = ReadInt32("Which processor would you like to use? Select a number between 1-6", 1, 6);

    Console.WriteLine();
    Console.WriteLine("1.) 8 GB\t$" + memory8gb);
    Console.WriteLine("2.) 16 GB\t$" + memory16gb);
    Console.WriteLine("3.) 32 GB\t$" + memory32gb);
    Console.WriteLine("4.) 64 GB\t$" + memory64gb);
    Console.WriteLine("5.) 128 GB\t$" + memory128gb);

    memoryChoice = ReadInt32("What memory storage would you like to have? Select a number between 1-5", 1, 5);

    currentCartTotal = CalculatePrice( processorChoice, memoryChoice );

}

decimal CalculatePrice ( int processor, int memory )
{

    do
    {
        if (processor == 1)
            currentCartTotal += ryzen9;
        else if (processor == 2)
            currentCartTotal += ryzen7;
        else if (processor == 3)
            currentCartTotal += ryzen5;
        else if (processor == 4)
            currentCartTotal += intel9;
        else if (processor == 5)
            currentCartTotal += intel7;
        else if (processor == 6)
            currentCartTotal += intel5;

        if (memory == 1)
            return currentCartTotal += memory8gb;
        else if (memory == 2)
            return currentCartTotal += memory16gb;
        else if (memory == 3)
            return currentCartTotal = memory32gb;
        else if (memory == 4)
            return currentCartTotal += memory64gb;
        else if (memory == 5)
            return currentCartTotal += memory128gb;

    } while (true);

}

void ViewOrder ( int processorSelection, int memorySelection)
{
    if (currentCartTotal == 0)
    {
        Console.WriteLine("There is currently no order available.");
        return;
    }

    Console.Write("Processor: ");
    if (processorSelection == 1)
        Console.WriteLine("AMD Ryzen 9 5900X\t$" + ryzen9);
    else if (processorSelection == 2)
        Console.WriteLine("AMD Ryzen 7 5700X\t$" + ryzen7);
    else if (processorSelection == 3)
        Console.WriteLine("AMD Ryzen 5 5600X\t$" + ryzen5);
    else if (processorSelection == 4)
        Console.WriteLine("Intel i9-12900K\t$" + intel9);
    else if (processorSelection == 5)
        Console.WriteLine("Intel i7-12700K\t$" + intel7);
    else if (processorSelection == 6)
        Console.WriteLine("Intel i5-12600K\t$" + intel5);

    Console.Write("Memory Storage: ");
    if (memorySelection == 1)
        Console.WriteLine("8 GB\t$" + memory8gb);
    else if (memorySelection == 2)
        Console.WriteLine("16 GB\t$" + memory16gb);
    else if (memorySelection == 3)
        Console.WriteLine("32 GB\t$" + memory32gb);
    else if (memorySelection == 4)
        Console.WriteLine("64 GB\t$" + memory64gb);
    else if (memorySelection == 5)
        Console.WriteLine("128 GB\t$" + memory128gb);

    Console.WriteLine("Your current total is: \t$" + currentCartTotal);

    return;
}

void ModifyOrder()
{ 

}

void ClearOrder()
{
    if (currentCartTotal == 0)
        return;

    if(!ReadBoolean("Are you sure you want to clear your order? Y/N "))
        return;

    currentCartTotal = 0;
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