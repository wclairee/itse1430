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