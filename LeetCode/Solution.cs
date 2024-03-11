using System.Text;

namespace LeetCode;

public class Solution
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
}