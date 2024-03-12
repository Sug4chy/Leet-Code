namespace LeetCode.Helpers;

public class ListNode(int val = 0, ListNode next = null)
{
    public int val = val;
    public ListNode next = next;
}

public static class ListNodeExtensions
{
    public static List<int> ToList(this ListNode head)
    {
        var current = head;
        var result = new List<int>();
        while (current is not null)
        {
            result.Add(current.val);
            current = current.next;
        }

        return result;
    }
}