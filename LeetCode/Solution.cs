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
    
    //1732
    public int LargestAltitude(int[] gain)
    {
        int n = gain.Length;
        int altitude = 0;
        int maxAltitude = int.MinValue;
        for (int i = 0; i < n; i++)
        {
            if (altitude >= maxAltitude)
            {
                maxAltitude = altitude;
            }
            
            altitude += gain[i];
        }

        return maxAltitude;
    }
    
    //1431
    public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
    {
        int max = candies.Max();
        return candies.Select(c => c + extraCandies >= max)
            .ToList();
    }
    
    //605
    public bool CanPlaceFlowers(int[] flowerbed, int n)
    {
        bool prevIsEmpty = true;
        for (int i = 0; i < flowerbed.Length && n > 0; i++) {
            bool empty = flowerbed[i] == 0;
            bool nextIsEmpty = i + 1 >= flowerbed.Length || flowerbed[i + 1] == 0;
            if (prevIsEmpty && empty && nextIsEmpty) {
                flowerbed[i] = 1;
                n--;
                prevIsEmpty = false;
            } else {
                prevIsEmpty = empty;
            }            
        }

        return n == 0;
    }

    //345
    public string ReverseVowels(string s)
    {
        if (s.Length <= 1)
        { 
            return s;
        }

        char[] vowels = ['a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'];
        char[] str = s.ToCharArray();
        int i = 0;
        int j = s.Length - 1;
        while (i < j)
        {
            if (!vowels.Contains(str[i]))
            {
                i++;
            }

            if (!vowels.Contains(str[j]))
            {
                j--;
            }

            if (vowels.Contains(str[i]) && vowels.Contains(str[j]))
            {
                (str[i], str[j]) = (str[j], str[i]);
                i++;
                j--;
            }
        }

        return new string(str);
    }

    //151
    public string ReverseWords(string s)
    => string.Join(' ', s.Trim()
        .Split(' ', 
            StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
        .Reverse()
        .Select(str => str.Trim()));
    
    //238
    public int[] ProductExceptSelf(int[] nums)
    {
        int zeroes = 0;
        int product = 1;
        foreach (int i in nums) 
        {
            if (i != 0)
            {
                product *= i;
                continue;
            }

            zeroes++;
        }

        int[] res = new int[nums.Length];
        if (zeroes >= 2)
        {
            return res;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                res[i] = product;
                continue;
            }

            res[i] = zeroes == 1 ? 0 :product / nums[i];
        }

        return res;
    }
}

public class GuessGame
{
    private readonly int _n = Random.Shared.Next(minValue: 1, maxValue: int.MaxValue);

    protected int guess(int num)
        => _n.CompareTo(num);
}