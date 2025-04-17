namespace Assignment02;

public class QuestionTwo
{
    public List<String> GroceryList {get; set;}

    public QuestionTwo()
    {
        GroceryList = new List<String>();
    }

    public void addItem(String item)
    {
        GroceryList.Add(item);
    }

    public List<String> getItems()
    {
        return GroceryList;
    }

    public void removeItem(String item)
    {
        if (GroceryList.Contains(item))
        {
            GroceryList.Remove(item);
        }
        else
        {
            Console.WriteLine("Item not found");
        }
    }

    public void clearItems()
    {
        GroceryList.Clear();
    }
}