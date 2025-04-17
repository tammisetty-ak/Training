namespace Assignment04;

public class MyList<T>
{
    /*
    Create a Generic List data structure MyList<T> that can store any data type.
        Implement the following methods.
    1. void Add (T element)
        2. T Remove (int index)
        3. bool Contains (T element)
        4. void Clear ()
        5. void InsertAt (T element, int index)
        6. void DeleteAt (int index)
        7. T Find (int index)
    */

    private List<T> myList;

    public MyList()
    {
        myList = new List<T>();
    }

    public void Add(T element)
    {
        myList.Add(element);
    }

    public T Remove(int index)
    {
        ValidateIndexForAccess(index);
        T removedElement = myList[index];
        myList.RemoveAt(index);
        return removedElement;
    }

    public bool Contains(T element)
    {
        return myList.Contains(element);
    }

    public void Clear()
    {
        myList.Clear();
    }

    public void InsertAt(T element, int index)
    {
        if (index < 0 || index > myList.Count)
        {
            throw new IndexOutOfRangeException("Index is out of range.");
        }
        myList.Insert(index, element);
    }

    public void DeleteAt(int index)
    {
        ValidateIndexForAccess(index);
        myList.RemoveAt(index);
    }
    
    private void ValidateIndexForAccess(int index)
    {
        if (index < 0 || index >= myList.Count)
        {
            throw new IndexOutOfRangeException("Index is out of range.");
        }
    }

    public T Find(int index)
    {
        if (myList.Count < index)
        {
            Console.WriteLine("Index out of range");
        }
        return myList[index];
    }
}

