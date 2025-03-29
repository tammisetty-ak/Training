// See https://aka.ms/new-console-template for more information
using Assignment04;
using Assignment04.QuestionThree;

/*

Create a custom Stack class MyStack<T> that can be used with any data type which
   has following methods
   1. int Count()
   2. T Pop()
   3. Void Push()

*/
Console.WriteLine("==========1==========");
MyStack<int> myStack = new MyStack<int>();
myStack.Push(1);
myStack.Push(2);
myStack.Push(3);

Console.WriteLine(myStack.Count());

myStack.Pop();
Console.WriteLine(myStack.Count());

myStack.Pop();
Console.WriteLine(myStack.Count());
Console.WriteLine("==========1==========");

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
Console.WriteLine("==========2==========");
MyList<int> myList = new MyList<int>();

myList.Add(2);
myList.Add(1);
myList.Add(3);
myList.Add(4);

myList.Remove(2);

myList.Remove(1);

Console.WriteLine(myList.Contains(3));
Console.WriteLine(myList.Contains(1));

myList.InsertAt(5, 0);

myList.InsertAt(4, 1);


myList.DeleteAt(0);


Console.WriteLine("==========2==========");


Console.WriteLine("==========3==========");

IRepository<Entity> entityRepository = new GenericRepository<Entity>();

// Add products.
entityRepository.Add(new Entity { Id = 1});
entityRepository.Add(new Entity { Id = 2});
entityRepository.Save();

// Retrieve all products.
IEnumerable<Entity> entities = entityRepository.GetAll();
foreach (var entity in entities)
{
   Console.WriteLine($"Id: {entity.Id}");
}

// Find product by Id.
Entity entityId = entityRepository.GetById(1);
if (entityId != null)
{
   Console.WriteLine($"Found: {entityId}");
}

// Remove a product.
entityRepository.Remove(entityId);
entityRepository.Save();

// Confirm removal.
Console.WriteLine("After removal:");
foreach (var entity in entityRepository.GetAll())
{
   Console.WriteLine($"Id: {entity.Id}");
}

Console.WriteLine("==========3==========");

   