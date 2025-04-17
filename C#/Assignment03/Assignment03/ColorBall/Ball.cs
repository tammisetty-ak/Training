namespace Assignment03.ColorBall;

public class Ball
{
    private int size;
    private Color color;
    private int throwCount;

    public Ball(int size, Color color)
    {
        this.size = size;
        this.color = color;
        this.throwCount = 0;
    }

    public void Pop()
    {
        size = 0;
    }

    public void Throw()
    {
        if (size > 0)
        {
            throwCount++;
        }
        else
        {
            Console.WriteLine("Cannot throw ball because ball size is 0");
        }
    }

    public int GetThrowCount()
    {
        return throwCount;
    }
    
    
}