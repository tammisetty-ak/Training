namespace Assignment01._02UnderstandingTypes;

public class CenturyConversion
{
    
    public int Centuries {get; set;}
    
    public uint Years { get; set; }
    
    public uint Days { get; set; }
    
    public uint Hours { get; set; }
    
    public ulong Minutes { get; set; }
    
    public ulong Seconds { get; set; }
    
    public ulong Milliseconds { get; set; }
    
    public ulong Microseconds { get; set; }
    
    public ulong Nanoseconds { get; set; }

    public CenturyConversion(int centuries)
    {
        Centuries = centuries;
    }

    public void convert()
    {
        if (Centuries < 0)
        {
            Console.WriteLine("Please provide a non-negative value for centuries.");
            return;
        }
        Years = 100 * (uint) Centuries;

        for (int i = 1; i <= Years; i++)
        {
            Days += DateTime.IsLeapYear(i) ?  (uint) 366 : (uint) 365;
        }
        Hours = Days * 24;
        Minutes = Hours * 60;
        Seconds = Minutes * 60;
        Milliseconds = Seconds * 1000;
        Microseconds = Milliseconds * 1000;
        Nanoseconds = Microseconds * 1000;
        
        Console.WriteLine($"{Centuries} centuries = {Years} years = {Days} days = {Hours} hours = {Minutes} minutes = {Seconds} seconds = {Milliseconds} milliseconds = {Microseconds} microseconds = {Nanoseconds} nanoseconds");
    }
}



