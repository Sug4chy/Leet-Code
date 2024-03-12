namespace LeetCode;

internal static class Program
{
    public static void Main()
    {
        int[] a = [0, 1, 0, 3, 12];
        new Solution().MoveZeroes(a);
        foreach (int i in a)
        {
            Console.WriteLine(i);
        }
    }
}