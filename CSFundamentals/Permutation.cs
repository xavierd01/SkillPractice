using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFundamentals
{
    public class Permutation
    {
        static public List<string> GeneratePermutations(char[] input)
        {
            Dictionary<char, int> countMap = new Dictionary<char, int>();
            foreach (char i in input)
            {
                if (!countMap.ContainsKey(i))
                {
                    countMap.Add(i, 0);
                }
                countMap[i] += 1;
            }

            var str = new char[countMap.Count];
            var count = new int[countMap.Count];
            int index = 0;
            foreach (var kv in countMap)
            {
                str[index] = kv.Key;
                count[index] = kv.Value;
                index++;
            }

            var result = new char[input.Length];
            var level = 0;
            var permutations = new List<string>();
            Permutate(str, count, result, level, permutations);
            return permutations;
        }

        static private void Permutate(char[] str, int[] count, char[] result, int level, IList<string> permutations)
        {
            if (level == result.Length)
            {
                //Console.WriteLine(String.Join("", result));
                permutations.Add(String.Join("", result));
                return;
            }

            for (var s = 0; s < str.Length; s++)
            {
                if (count[s] > 0)
                {
                    result[level] = str[s];
                    count[s] -= 1;
                    Permutate(str, count, result, level + 1, permutations);
                    count[s] += 1;
                }
            }
        }
    }
}
