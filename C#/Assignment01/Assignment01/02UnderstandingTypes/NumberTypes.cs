namespace Assignment01._02UnderstandingTypes;



/*
1. Create a console application project named /02UnderstandingTypes/ that outputs the
number of bytes in memory that each of the following number types uses, and the
    minimum and maximum values they can have: sbyte, byte, short, ushort, int, uint, long,
ulong, float, double, and decimal.
*/


public class NumberTypes
{
    private int sbyte_memory;
    
    private sbyte min_sbyte_value;
    
    private sbyte max_sbyte_value;

    private int byte_memory;

    private byte min_byte_value;
    
    private byte max_byte_value;
    
    private int short_memory;
    
    private short min_short_value;
    
    private short max_short_value;
    
    private int ushort_memory;
    
    private ushort min_ushort_value;
    
    private ushort max_ushort_value;
    
    private int uint_memory;
    
    private uint min_uint_value;
    
    private uint max_uint_value;
    
    private int int_memory;
    
    private int min_int_value;
    
    private int max_int_value;
    
    private int ulong_memory;
    
    private ulong min_ulong_value;

    private ulong max_ulong_value;
    
    private int long_memory;
    
    private long min_long_value;
    
    private long max_long_value;

    public NumberTypes()
    {
        sbyte_memory = sizeof(sbyte);
        byte_memory = sizeof(byte);
        short_memory = sizeof(short);
        ushort_memory = sizeof(ushort);
        int_memory = sizeof(int);
        uint_memory = sizeof(uint);
        long_memory = sizeof(long);
        ulong_memory = sizeof(ulong);

        min_sbyte_value = sbyte.MinValue;
        max_sbyte_value = sbyte.MaxValue;

        min_short_value = short.MinValue;
        max_short_value = short.MaxValue;
        min_int_value = int.MinValue;
        max_int_value = int.MaxValue;
        min_long_value = long.MinValue;
        max_long_value = long.MaxValue;
        
        min_byte_value = byte.MaxValue;
        max_byte_value = byte.MaxValue;
        min_ushort_value = ushort.MinValue;
        max_ushort_value = ushort.MaxValue;
        min_uint_value = uint.MinValue;
        max_uint_value = uint.MaxValue;
        min_ulong_value = ulong.MinValue;
        max_ulong_value = ulong.MaxValue;
       
    }

    public void getMemMinMaxValues()
    {
        Console.WriteLine($"sbyte memory : {sbyte_memory.GetType()} byte,Min : {min_sbyte_value} Max: {max_sbyte_value}");
        Console.WriteLine($"byte memory : {byte_memory} byte, Min : {min_byte_value} Max: {max_byte_value}");
        Console.WriteLine($"short memory : {short_memory} bytes, Min : {min_short_value} Max: {max_short_value}");
        Console.WriteLine($"ushort memory : {ushort_memory} bytes, Min : {min_ushort_value} Max: {max_ushort_value}");
        Console.WriteLine($"int memory : {int_memory} bytes, Min : {min_int_value} Max: {max_int_value}");
        Console.WriteLine($"uint memory : {uint_memory} bytes, Min : {min_uint_value} Max: {max_uint_value}");
        Console.WriteLine($"long memory : {long_memory} bytes, Min : {min_long_value} Max: {max_long_value}");
        Console.WriteLine($"ulong memory : {ulong_memory} bytes, Min : {min_ulong_value} Max: {max_ulong_value}");
    }
}