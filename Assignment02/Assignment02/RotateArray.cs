namespace Assignment02;

public class RotateArray
{
    
    public static void rotate(int[] array, int r)
    {
        int n = array.Length;
        r = r % n; // Handle cases where k > n

        reverse(array, 0, n - 1);      // Step 1: Reverse entire array
        reverse(array, 0, r - 1);      // Step 2: Reverse first k elements
        reverse(array, r, n - 1);  
    }
    
    private static void reverse(int[] array, int start, int end) {
        while (start < end) {
            (array[start], array[end]) = (array[end], array[start]);
            start++;
            end--;
        }
    }
    
    
}