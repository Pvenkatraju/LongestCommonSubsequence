using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestCommonSubsequence
{
    class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string txtData = string.Empty;
                do
                {
                    Console.Write("Enter Text: ");
                    txtData = Console.ReadLine();

                } while (string.IsNullOrEmpty(txtData) || txtData.TrimEnd(';').Split(';').Length != 2);
                string str1 = string.Empty;
                string str2 = string.Empty;
                if (!String.IsNullOrEmpty(txtData) && txtData.TrimEnd(';').Split(';').Length == 2)
                {
                    str1 = txtData.Split(';')[0];
                    str2 = txtData.Split(';')[1];
                    str1 = str1?.Length > 50 ? str1.Substring(0, 50) : str1;
                    str2 = str2?.Length > 50 ? str2.Substring(0, 50) : str2;
                    string lcs = LongestCommonSubsequence(str1, str2);
                    Console.WriteLine("Longest common subsequence: " + (lcs.Trim()?.Length > 0 ? lcs.Trim() : "Not found"));

                }
            }
        }

        static string LongestCommonSubsequence(string str1, string str2)
        {
            int i, j, k, t;
            int s1Len = str1.Length;
            int s2Len = str2.Length;
            int[] z = new int[(s1Len + 1) * (s2Len + 1)];
            int[,] c = new int[(s1Len + 1), (s2Len + 1)];

            for (i = 0; i <= s1Len; ++i)
                c[i, 0] = z[i * (s2Len + 1)];

            for (i = 1; i <= s1Len; ++i)
            {
                for (j = 1; j <= s2Len; ++j)
                {
                    if (str1[i - 1] == str2[j - 1])
                        c[i, j] = c[i - 1, j - 1] + 1;
                    else
                        c[i, j] = MAX(c[i - 1, j], c[i, j - 1]);
                }
            }

            t = c[s1Len, s2Len];
            char[] outputSB = new char[t];

            for (i = s1Len, j = s2Len, k = t - 1; k >= 0;)
            {
                if (str1[i - 1] == str2[j - 1])
                {
                    outputSB[k] = str1[i - 1];
                    --i;
                    --j;
                    --k;
                }
                else if (c[i, j - 1] > c[i - 1, j])
                    --j;
                else
                    --i;
            }

            return new string(outputSB);
        }

        private static int MAX(int a, int b)
        {
            return a > b ? a : b;
        }
    }
}
