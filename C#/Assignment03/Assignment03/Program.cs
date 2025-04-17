// See https://aka.ms/new-console-template for more information

using Assignment03;
using Assignment03.ColorBall;


Console.WriteLine("============1============");
QuestionOne questionOne = new QuestionOne();

int[] numbers = questionOne.GenerateNumbers();
questionOne.Reverse(numbers);
questionOne.PrintNumbers(numbers);
Console.WriteLine();

Console.WriteLine("============1============");




Console.WriteLine("============2============");

QuestionTwo questionTwo = new QuestionTwo();

for (int i = 1; i <= 10; i++)
{
    Console.WriteLine(questionTwo.fibonacci(i));
}
Console.WriteLine("============2============");

Console.WriteLine("============Color Ball ============");
Color redColor = new Color(255, 0, 0);               // Red, fully opaque.
Color blueColor = new Color(0, 0, 255, 128);           // Blue, semi-transparent.
Color greenColor = new Color(0, 255, 0);               // Green, fully opaque.

// Create several Ball objects with different sizes and colors.
Ball ball1 = new Ball(10, redColor);
Ball ball2 = new Ball(15, blueColor);
Ball ball3 = new Ball(20, greenColor);

// Simulate throwing the balls.
ball1.Throw();
ball1.Throw();
ball2.Throw();
ball3.Throw();
ball3.Throw();
ball3.Throw();

// Now pop ball2 and ball3.
ball2.Pop();
ball3.Pop();

// Attempt to throw the popped balls (should not increase throw count).
ball2.Throw();
ball3.Throw();

// Display the throw count for each ball.
Console.WriteLine("Ball 1 has been thrown {0} times.", ball1.GetThrowCount());
Console.WriteLine("Ball 2 has been thrown {0} times.", ball2.GetThrowCount());
Console.WriteLine("Ball 3 has been thrown {0} times.", ball3.GetThrowCount());