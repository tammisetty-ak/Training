// See https://aka.ms/new-console-template for more information
using Assignment01._02UnderstandingTypes;

// Practice number sizes and ranges

//1
Console.WriteLine("=========Q1============");

NumberTypes number_types = new NumberTypes();

number_types.getMemMinMaxValues();

Console.WriteLine("=========Q1============");

//2

Console.WriteLine("=========Q2============");

Console.WriteLine("enter an integer number of centuries: ");
string centuries = Console.ReadLine();

CenturyConversion centuryConversion = new CenturyConversion(Convert.ToInt32(centuries));

centuryConversion.convert();

Console.WriteLine("=========Q2============");


//3
//fizz buzz

Console.WriteLine("=========1============");

int max = 100;
for (int i = 1; i < max; i++)
{
    WriteLine(i);
}

void WriteLine(int value)
{
    if (value % 3 == 0 && value % 5 == 0)
    {
        Console.WriteLine("fizzbuzz");
    }
    else if (value % 3 == 0)
    {
        Console.WriteLine("fizz");
    }
    else if (value % 5 == 0)
    {
        Console.WriteLine("buzz");
    }
    else
    {
        Console.WriteLine(value);
    }
}

Console.WriteLine("=========1============");


// 2 printing pyramid

Console.WriteLine("=========2============");

int rows = 5;

int cols = 5;

for (int i = 1; i <= rows; i++)
{
    for (int j = 1; j <= cols - i; j++)
    {
        Console.Write(' ');
    }

    for (int k = 1; k <= (2 * i - 1); k++)
    {
        Console.Write('*');
    }
    Console.WriteLine();
}


Console.WriteLine("=========2============");

// 3 Random number guess

Console.WriteLine("=========3============");

int correctNumber = new Random().Next(3) + 1;

Console.WriteLine("Random Number is generated between 1 and 3.");

Console.WriteLine("Guess the random number: ");

int guessNumber = Convert.ToInt32(Console.ReadLine());

Console.WriteLine();

while (true)
{

    if (guessNumber > 3 || guessNumber < 1)
    {
        Console.WriteLine("The numbers are out of range.");
    }

    else if (guessNumber < correctNumber)
    {
        Console.WriteLine("Your Guess is lower than the correct number.");
    }

    else if (guessNumber > correctNumber)
    {
        Console.WriteLine("Your Guess is higher than the correct number.");
    }
    else
    {
        Console.WriteLine("Your Guess is equal to the correct number.");
        break;
    }
    Console.WriteLine("Guess random number again? ");
    guessNumber = Convert.ToInt32(Console.ReadLine());


}

Console.WriteLine("=========3============");

// 4. Calculate dates from dob

Console.WriteLine("=========4============");

Console.WriteLine("Enter date of birth in MM/dd/yyyy");
string date = Console.ReadLine();

DateTime birthDate = DateTime.ParseExact(date, "MM/dd/yyyy", null);
DateTime now = DateTime.Now;

// Calculate the timespan between now and the birth date
TimeSpan ageSpan = now - birthDate;
// TotalDays property gives the complete number of days as a double; cast it to int if you need a whole number
int totalDays = (int)ageSpan.TotalDays;

int daysToNextAnniversary = 10000 - (totalDays % 10000);

DateTime nextAnniversary = now.AddDays(daysToNextAnniversary);

Console.WriteLine($"Total number of days from birth until today: {totalDays}");
Console.WriteLine($"Days to next anniversary: {nextAnniversary}");

Console.WriteLine("=========4============");


// 5
// 3 am - 12 pm mrng 
// 12pm - 3 pm afternoon
// 3 pm - 6 pm eveng
// 6 pm - 3 am night
Console.WriteLine("=========5============");


Console.WriteLine("Enter time in HH:MM:SS in 24 hours format");
string input = Console.ReadLine();
DateTime time = DateTime.ParseExact(input, "HH:mm:ss", null);

if (time.Hour >= 3 && time.Hour < 12)
{
    Console.WriteLine("Good Morning");
}

if (time.Hour >= 12 && time.Hour < 15)
{
    Console.WriteLine("Good Afternoon");
}

if (time.Hour >= 15 && time.Hour < 18)
{
    Console.WriteLine("Good Evening");
}

if (time.Hour >= 18 || time.Hour < 03)
{
    Console.WriteLine("Good Night");
}
Console.WriteLine("=========5============");


// 6 print 24 numbers 
Console.WriteLine("=========6============");


for (int i = 0; i < 4; i++)
{
    for (int j = 0; j <= 24; j++)
    {
        Console.Write(j + " ");
        if (i == 1)
        {
            j += 1;
        }

        if (i == 2)
        {
            j += 2;
        }

        if (i == 3)
        {
            j += 3;
        }
    }
    Console.WriteLine();
}
Console.WriteLine("=========6============");
