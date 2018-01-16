using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFundamentals
{
    public class ArrayAndString
    {
        public static bool ContainsAllUniqueCharacters(string myString)
        {
            HashSet<char> foundCharacters = new HashSet<char>();
            foreach (char c in myString)
            {
                if (!foundCharacters.Contains(c))
                {
                    foundCharacters.Add(c);
                }
                else
                {
                    // found duplicate
                    return false;
                }
            }

            return true;
        }

        public static bool ContainsAllUniqueCharactersWithSort(string myString)
        {
            if (myString.Length == 0) return true;

            var stringArray = myString.ToArray();
            Array.Sort(stringArray);
            int current = 0;
            for (var next = 1; next < stringArray.Length; next++)
            {
                if (stringArray[next] == stringArray[current]) return false;
                current = next;
            }

            return true;
        }

        public static bool IsPermutation(string source, string toCheck)
        {
            // First check if they are the same length, if not then toCheck 
            // cannot be a permutation.
            if (toCheck.Length != source.Length) return false;
            if (toCheck.Length == 0 && source.Length == 0) return false;

            var characterCount = new Dictionary<char, int>();
            foreach (char s in source)
            {
                if (!characterCount.ContainsKey(s))
                {
                    characterCount.Add(s, 0);
                }
                characterCount[s] += 1;
            }
            foreach (char c in toCheck)
            {
                if (!characterCount.ContainsKey(c))
                {
                    return false;
                }
                characterCount[c] -= 1;
            }
            int sum = 0;
            foreach (var kv in characterCount)
            {
                sum += kv.Value;
            }
            if (sum == 0) return true;
            else return false;
        }

        public static void URLify(char[] input, int length)
        {
            Action<char[], int, int> Shift = (char[] str, int start, int count) =>
            {
                for (int i = (str.Length - 1) - count; i > start; i--)
                {
                    str[i + count] = str[i];
                    str[i] = ' ';
                }
            };
            char space = ' ';
            char[] urlSpace = new char[] { '%', '2', '0' };
            // Assumption is that input has sufficient space to hold additional characters.
            int urlSpaceLength = urlSpace.Length;

            for (int i = 0; i < length; i++)
            {
                if (input[i] == space)
                {
                    Shift(input, i, urlSpaceLength-1);
                    for (int s = 0; s < urlSpaceLength; s++)
                    {
                        input[i] = urlSpace[s];
                        i++;
                    }
                }
            }
        }
    }
}
