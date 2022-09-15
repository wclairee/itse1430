int hours;

Console.WriteLine("Hours: ");
string value = Console.ReadLine();

hours = Int32.Parse(value);

Console.WriteLine("Pay rate: ");
value = Console.ReadLine();

double payRate = Double.Parse(value);

Console.WriteLine("Your pay is " + (hours * payRate));

//int x;
double distanceFromMoon = 0;
//distanceFromMoon = 0;
char letterGrade;
bool isPassing;
string name;

string firstName = "Bob", lastName = "Smith";
firstName = lastName = "Sam";
//firstName = "Sam";
//lastName = "Sam";

// Block statement
{
    //decimal payRate;

}

//distanceFromMoon = 10.5;
isPassing = distanceFromMoon > 10;

//Strings

string emptyString = "";
string emptyString2 = String.Empty;
bool areEmptyStringsEqual = emptyString == emptyString2;
string nullString = null;
bool isEmptyString = (emptyString == null) || (emptyString == ""); //wrong way
isEmptyString = String.IsNullOrEmpty(emptyString); //right way

//Literal
string someString = "Hello \"World";
Console.WriteLine("Hello");
Console.WriteLine("World");
Console.WriteLine("Hello\nWorld");
string filePath = "C:\\windows\\system32";

//Verbatim
filePath = @"C:\windows\\system32";

//concatenation
string fullName = "Bob" + " " + "Smith";
fullName = String.Concat("Bob", " ", "Smith");
string someValues = String.Concat("You are ", 10, "Years Old", true);
string names = String.Join(", ", "Bob", "Sue", "Jan", "George");

int stringLength = fullName.Length;
isEmptyString = fullName.Length == 0; //still wrong way to check for empty string

//Manipulation
string upperName = fullName.ToUpper();
string lowerName = fullName.ToLower();

fullName = "     Bob Smith     ";
fullName = fullName.Trim(); //remove leading and trailing whitespace
//fullName.TrimStart().TrimEnd()
filePath = filePath.Trim('\\');

fullName.PadLeft(10); //fullName.PadRight(10);

//Comparison 1 - relational ops (culture aware, case sensitive)
filePath.StartsWith("C:\\", StringComparison.OrdinalIgnoreCase); //returns true if string starts with
filePath.EndsWith("\\");

bool areEqual = firstName == lastName;

string input = Console.ReadLine();
if (input.ToUpper() == "A") //use equality if case sensitive
//if (input == "A")
    Console.WriteLine("A");
else if (input == "B")
    Console.WriteLine("B");
else
    Console.WriteLine("Other");

//Comparison 2 - String.Compare any other comparisons
if (String.Compare(input, "A", StringComparison.OrdinalIgnoreCase) == 0)
    Console.WriteLine("A");
else if (String.Compare(input, "B", true) == 0) //this is equivalent to line 91
    Console.WriteLine("B");

// Comparison 3 - String.Equal if case does not matter and only checking if equal
if (String.Equals(input, "A", StringComparison.OrdinalIgnoreCase))
    Console.WriteLine("A");