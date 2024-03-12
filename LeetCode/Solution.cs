using System.Text;

namespace LeetCode;

public class Solution : GuessGame
{
    //1768
    public string MergeAlternately(string word1, string word2)
    {
        int i = 0;
        int j = 0;
        var sb = new StringBuilder();
        bool flag = false;
        while (i < word1.Length && j < word2.Length)
        {
            if (flag)
            {
                sb.Append(word2[j]);
                j++;
            }
            else
            {
                sb.Append(word1[i]);
                i++;
            }

            flag = !flag;
        }

        sb.Append(i == word1.Length ? word2[j..] : word1[i..]);
        return sb.ToString();
    }

    //374
    public int GuessNumber(int n)
    {
        int left = 1;
        int right = n;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            switch (guess(mid))
            {
                case -1:
                    right = mid - 1;
                    break;
                case 1:
                    left = mid + 1;
                    break;
                case 0:
                    return mid;
            }
        }

        return -1;
    }

    //1071
    public string GcdOfStrings(string str1, string str2)
    {
        if (str1 + str2 != str2 + str1)
        {
            return "";
        }

        int n1 = str1.Length;
        int n2 = str2.Length;
        while (n1 != 0 && n2 != 0)
        {
            if (n1 > n2)
            {
                n1 %= n2;
            }
            else
            {
                n2 %= n1;
            }
        }

        return str1[..(n1 | n2)];
    }

    //283
    public void MoveZeroes(int[] nums)
    {
        int i = 0;
        int j = 0;
        while (i < nums.Length && j < nums.Length)
        {
            if (nums[i] != 0)
            {
                i++;
                j++;
                continue;
            }

            while (j < nums.Length - 1 && nums[j] == 0)
            {
                j++;
            }

            nums[i] = nums[j];
            nums[j] = 0;
            i++;
            j++;
        }
    }
}

public class GuessGame
{
    private readonly int _n = Random.Shared.Next(minValue: 1, maxValue: int.MaxValue);

    protected int guess(int num)
        => _n.CompareTo(num);
}