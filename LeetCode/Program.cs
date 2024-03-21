namespace LeetCode;

internal static class Program
{
    public static void Main()
    {
        char[] a = ['a', 'a', 'b', 'b', 'c', 'c', 'c'];
        Console.WriteLine(new Solution().Compress(a));
        foreach (char c in a)
        {
            Console.WriteLine(c);
        }
    }
}