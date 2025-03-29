namespace Assignment04;

public class MyStack<T>
{
    private Stack<T> stack;

    public MyStack()
    {
        stack = new Stack<T>();
    }
    public int Count()
    {
        return stack.Count;
    }

    public T Pop()
    {
        if (stack.Count != 0)
        {
            return stack.Pop();
        }
        
        return default;
    }

    public void Push(T item)
    {
        stack.Push(item);
    }
}