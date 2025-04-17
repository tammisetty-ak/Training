namespace Assignment02;

public class PrimeNumbers
{
    public static int[] FindPrimesInRange(int start, int end)
    {
        List<int> primes = new List<int>();
        for (int i = start; i <= end; i++)
        {
            if (isPrime(i))
            {
                primes.Add(i);
            }
        }
        return primes.ToArray();
    }

    private static bool isPrime(int number)
    {
        if (number <= 1)
        {
            return false;
        }

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}