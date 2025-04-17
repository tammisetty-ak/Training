// See https://aka.ms/new-console-template for more information

/*

   Copying an Array
   Write code to create a copy of an array. First, start by creating an initial array. (You can use
   whatever type of data you want.) Let’s start with 10 items. Declare an array variable and
   assign it a new array with 10 items in it. Use the things we’ve discussed to put some values
   in the array.
   Now create a second array variable. Give it a new array with the same length as the first.
   Instead of using a number for this length, use the Lengthproperty to get the size of the
   original array.
   Use a loop to read values from the original array and place them in the new array. Also
   print out the contents of both arrays, to be sure everything copied correctly
*/

using System.Text;
using Assignment02;


Console.WriteLine("===========1==========");
int[] arr1 = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};

int[] second_arr = new int[arr1.Length];
for (int i = 0; i < arr1.Length; i++)
{
   second_arr[i] = arr1[i];
}

Console.Write("First Array: ");
for (int i = 0; i < arr1.Length; i++)
{
   Console.Write(arr1[i] + " ");
}

Console.WriteLine();
Console.Write("Second Array: ");
for (int i = 0; i < arr1.Length; i++)
{
   Console.Write(second_arr[i] + " ");
}
Console.WriteLine("===========1==========");

/*
 * Write a simple program that lets the user manage a list of elements. It can be a grocery list,
   "to do" list, etc. Refer to Looping Based on a Logical Expression if necessary to see how to
   implement an infinite loop. Each time through the loop, ask the user to perform an
   operation, and then show the current contents of their list.
 */

Console.WriteLine("===========2==========");

QuestionTwo groceryList = new QuestionTwo();

while (true)
{
   Console.WriteLine("Enter command (+ item, - item, -- to clear or any other key to exit): )):"); 
   var command = Console.ReadLine();

   if (string.IsNullOrEmpty(command))
   {
      continue;
   }

   if (command == "--")
   {
      groceryList.clearItems();
   }

   else if (command.StartsWith("+"))
   {
      groceryList.addItem(command.Substring(1));
      Console.WriteLine("Added item: " + command.Substring(1));
   }

   else if (command.StartsWith("-"))
   {
      groceryList.removeItem(command.Substring(1));
      Console.WriteLine("Removed item: " + command.Substring(1));
   }
   else
   {
      Console.WriteLine("Exiting");
      break;
   }
   Console.Write("Current Grocery List:");
   if (groceryList.getItems().Count == 0)
   {
      Console.Write("Empty");
   }
   else
   {
      foreach (string item in groceryList.getItems())
      {
         Console.Write(item + " ");
      }
   }

   Console.WriteLine();

}

Console.WriteLine("===========2==========");

/*
   Write a method that calculates all prime numbers in given range and returns them as array
   of integers
*/

Console.WriteLine("===========3==========");

int[] primes = PrimeNumbers.FindPrimesInRange(1, 1100);
foreach (int prime in primes)
{
   Console.WriteLine(prime);
}

Console.WriteLine("===========3==========");


/*
Write a program to read an array of n integers (space separated on a single line) and an
   integer k, rotate the array right k times and sum the obtained arrays after each rotation as
   shown below.
*/


Console.WriteLine("===========4==========");


Console.WriteLine("Enter n : size of array: ");
int n = int.Parse(Console.ReadLine());
int[] arr = new int[n];
Console.WriteLine("Enter integers into the array");
for (int i = 0; i < n; i++)
{
   arr[i] = int.Parse(Console.ReadLine());
}

Console.WriteLine("Enter no.of Rotations");
int r = int.Parse(Console.ReadLine());

int[] sum = new int[n];

for (int k = 1; k <= r; k++)
{
   // For each element in the original array
   for (int i = 0; i < n; i++)
   {
      // Calculate new position after r rotations
      int newIndex = (i + k) % n;
      // Add the element to the corresponding position in the sum array
      sum[newIndex] += arr[i];
   }
}

// Print the resulting sum array
Console.WriteLine("Resulting sum array after rotations:");
Console.WriteLine(string.Join(" ", sum));

Console.WriteLine("===========4==========");


/*
 * Write a program that finds the longest sequence of equal elements in an array of integers.
   If several longest sequences exist, print the leftmost one.
 */



Console.WriteLine("===========5==========");

Console.WriteLine("Enter n : size of array: ");
int length = int.Parse(Console.ReadLine());
int[] arr5 = new int[length];
Console.WriteLine("Enter integers into the array");
for (int i = 0; i < length; i++)
{
   arr5[i] = int.Parse(Console.ReadLine());
}

if (arr5.Length == 0)
{
   Console.WriteLine("Array is empty.");
   return;
}

int bestStart = 0;
int bestLength = 1;

int currentStart = 0;
int currentLength = 1;

for (int i = 1; i < arr5.Length; i++)
{
   if (arr5[i] == arr5[i - 1])
   {
      currentLength++;
   }
   else
   {
      if (currentLength > bestLength)
      {
         bestLength = currentLength;
         bestStart = currentStart;
      }
      currentStart = i;
      currentLength = 1;
   }
}

if (currentLength > bestLength)
{
   bestLength = currentLength;
   bestStart = currentStart;
}

Console.WriteLine("Longest sequence of equal elements:");
Console.WriteLine(string.Join(" ", arr5.Skip(bestStart).Take(bestLength)));

Console.WriteLine("===========5==========");


/*
 * Write a program that finds the most frequent number in a given sequence of numbers. In
   case of multiple numbers with the same maximal frequency, print the leftmost of them
 */


Console.WriteLine("===========6==========");

Console.WriteLine("Enter n : size of array: ");
int length6 = int.Parse(Console.ReadLine());
int[] arr6 = new int[length6];
Console.WriteLine("Enter integers into the array");
for (int i = 0; i < length6; i++)
{
   arr6[i] = int.Parse(Console.ReadLine());
}

if (length6 == 0)
{
   Console.WriteLine("Array is empty");
}
int count = 0;
int candidate = 0;  
        
for (int i = 0; i < length6; i++)
{
   if (count == 0)
   {
      candidate = arr6[i];
      count = 1;
   }
   else if (arr6[i] == candidate)
   {
      count++;
   }
   else
   {
      count--;
   }
}
Console.WriteLine("The majority element is: " + candidate);

Console.WriteLine("===========6==========");




// Strings

Console.WriteLine("========Strings========");
Console.WriteLine("========1========");

Console.WriteLine("Enter a string:");
string input1 = Console.ReadLine();
        
// Method 1: Using char array and Array.Reverse
char[] charArray = input1.ToCharArray();
Array.Reverse(charArray);
string reversedUsingArray = new string(charArray);
Console.WriteLine("Reversed string using char array:");
Console.WriteLine(reversedUsingArray);

// Method 2: Using a for-loop to print characters in reverse order
Console.WriteLine("Reversed string using for-loop:");
for (int i = input1.Length - 1; i >= 0; i--)
{
   Console.Write(input1[i]);
}
Console.WriteLine(); 
Console.WriteLine("========1========");

//

 
Console.WriteLine("========2========");
HashSet<char> separators = new HashSet<char>
{
   '.', ',', ':', ';', '=', '(', ')', '&', '[', ']', '"', '\'', '\\', '/', '!', '?', ' '
};

Console.WriteLine("Enter a sentence (starts with a word and ends with a separator):");
string input = Console.ReadLine();

// Lists to store words and separators
List<string> words2 = new List<string>();
List<string> seps = new List<string>();

// Parse the input into alternating tokens
bool inWord = true; // since the sentence starts with a word
StringBuilder token = new StringBuilder();

foreach (char ch in input)
{
   if (inWord)
   {
      if (separators.Contains(ch))
      {
         // End of word token
         words2.Add(token.ToString());
         token.Clear();
         token.Append(ch);
         inWord = false;
      }
      else
      {
         token.Append(ch);
      }
   }
   else // Currently in a separator token
   {
      if (separators.Contains(ch))
      {
         token.Append(ch);
      }
      else
      {
         // End of separator token
         seps.Add(token.ToString());
         token.Clear();
         token.Append(ch);
         inWord = true;
      }
   }
}

// Add the final token to the appropriate list
if (inWord)
{
   words2.Add(token.ToString());
}
else
{
   seps.Add(token.ToString());
}

// The problem guarantees that the sentence starts with a word and ends with a separator.
// So we expect the lists to be of equal length.
if (words2.Count != seps.Count)
{
   Console.WriteLine("Input does not match the expected pattern (word then separator)!");
   return;
}

// Reverse the order of words
words2.Reverse();

// Reconstruct the sentence: place reversed words in the original word positions,
// while leaving the separators unchanged.
StringBuilder result = new StringBuilder();
for (int i = 0; i < words2.Count; i++)
{
   result.Append(words2[i]);
   result.Append(seps[i]);
}

Console.WriteLine("Result:");
Console.WriteLine(result.ToString());

Console.WriteLine("========2========");






Console.WriteLine("========3========");

bool IsPalindrome(string word)
{
   int left = 0;
   int right = word.Length - 1;
   while (left < right)
   {
      if (word[left] != word[right])
         return false;
      left++;
      right--;
   }
   return true;
}


Console.WriteLine("Enter text:");
string text = Console.ReadLine();

List<string> words = new List<string>();
string currentWord = "";
for (int i = 0; i < text.Length; i++)
{
   char c = text[i];
   // If the character is a letter, consider it part of a word.
   if (char.IsLetter(c))
   {
      currentWord += c;
   }
   else
   {
      // If we hit a non-letter and we have built up a word, add it.
      if (currentWord != "")
      {
         words.Add(currentWord);
         currentWord = "";
      }
   }
}
// Add the final word if the text ended with a letter.
if (currentWord != "")
{
   words.Add(currentWord);
}


SortedSet<string> uniquePalindromes = new SortedSet<string>();

foreach (string word in words)
{
   // Optionally, ignore single-letter words
   if (word.Length >= 1 && IsPalindrome(word))
   {
      uniquePalindromes.Add(word);
   }
}

// Print the unique palindromes separated by comma and space.
Console.WriteLine("Unique palindromes (sorted):");
Console.WriteLine(string.Join(", ", uniquePalindromes));

Console.WriteLine("========3========");



Console.WriteLine("========4========");

Console.WriteLine("Enter URL:");
string url = Console.ReadLine();

string protocol = null;
string server = null;
string resource = null;

int protocolEndIndex = url.IndexOf("://");
if (protocolEndIndex != -1)
{
   protocol = url.Substring(0, protocolEndIndex);
   url = url.Substring(protocolEndIndex + 3);
}


int serverEndIndex = url.IndexOf('/');
if (serverEndIndex != -1)
{
   server = url.Substring(0, serverEndIndex);
   resource = url.Substring(serverEndIndex + 1); 
}
else
{
   server = url;
}

Console.WriteLine("Parsed URL components:");
Console.WriteLine($"[Protocol] = {protocol}");
Console.WriteLine("[Server] = " + server);
Console.WriteLine("[Resource] = " + resource);

Console.WriteLine("========4========");