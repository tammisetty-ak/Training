namespace Assignment03;

public class QuestionOne
{

    public int[] GenerateNumbers()
    {
        Console.WriteLine("Enter length of array you want to generate");
        int length = int.Parse(Console.ReadLine());
        Console.Write("Enter numbers: ");
        int[] numbers = new int[length];
        for (int i = 0; i < length; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }
        return numbers;
    }

    public void Reverse(int[] numbers)
    {
        for (int i = 0; i < numbers.Length / 2; i++)
        {
            (numbers[i], numbers[numbers.Length - 1 - i]) = (numbers[numbers.Length - 1 - i], numbers[i]);
        }
    }

    public void PrintNumbers(int[] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write(numbers[i] + " ");
        }
    }
}