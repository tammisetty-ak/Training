namespace Assignment03.ColorBall;

public class Color
{
    private int red;
    private int green;
    private int blue;
    private int alpha;

    public Color(int red, int green, int blue, int alpha)
    {
        this.red = red;
        this.green = green;
        this.blue = blue;
        this.alpha = alpha;
    }

    public Color(int red, int green, int blue) : this(red, green, blue, 255)
    {
    }

    public int Red
    {
        get { return red; }
        set { red = checked(value); }
    }

    public int Green
    {
        get { return green; }
        set { green = checked(value); }
    }

    public int Blue
    {
        get { return blue; }
        set { blue = checked(value); }
    }

    public int Alpha
    {
        get { return alpha; }
        set { alpha = checked(value); }
    }

    public int Checked(int value)
    {
        if (value < 0)
        {
            return 0;
        }

        if (value > 255)
        {
            return 255;
        }
        return value;
    }

    public int GetGreyScale()
    {
        return (red + green + blue) / 3;
    }
}