using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSFundamentals;

namespace UnitTestCSFundamentals
{
    [TestClass]
    public class ArrayAndStringUnitTests
    {
        [TestMethod]
        public void ContainsAllUniqueCharacters_empty_returns_true()
        {
            Assert.IsTrue(ArrayAndString.ContainsAllUniqueCharacters(string.Empty));
        }

        [TestMethod]
        public void ContainsAllUniqueCharacters_aa_returns_false()
        {
            Assert.IsFalse(ArrayAndString.ContainsAllUniqueCharacters("aa"));
        }

        [TestMethod]
        public void ContainsAllUniqueCharacters_abc_returns_true()
        {
            Assert.IsTrue(ArrayAndString.ContainsAllUniqueCharacters("abc"));
        }

        [TestMethod]
        public void ContainsAllUniqueCharactersWithSort_empty_returns_true()
        {
            Assert.IsTrue(ArrayAndString.ContainsAllUniqueCharactersWithSort(string.Empty));
        }

        [TestMethod]
        public void ContainsAllUniqueCharactersWithSort_aa_returns_false()
        {
            Assert.IsFalse(ArrayAndString.ContainsAllUniqueCharactersWithSort("aa"));
        }

        [TestMethod]
        public void ContainsAllUniqueCharactersWithSort_abc_returns_true()
        {
            Assert.IsTrue(ArrayAndString.ContainsAllUniqueCharactersWithSort("abc"));
        }

        [TestMethod]
        public void ContainsAllUniqueCharactersWithSort_abcaketpaoseidutl_returns_false()
        {
            Assert.IsFalse(ArrayAndString.ContainsAllUniqueCharactersWithSort("abcaketpaoseidutl"));
        }

        [TestMethod]
        public void ContainsAllUniqueCharactersWithSort_qwertyuioplkjhgfdsa_returns_true()
        {
            Assert.IsTrue(ArrayAndString.ContainsAllUniqueCharactersWithSort("qwertyuioplkjhgfdsa"));
        }

        [TestMethod]
        public void IsPermutation_different_length_strings_returns_false()
        {
            Assert.IsFalse(ArrayAndString.IsPermutation("abc", "ab"));
        }

        [TestMethod]
        public void IsPermutation_empty_strings_returns_false()
        {
            Assert.IsFalse(ArrayAndString.IsPermutation(String.Empty, String.Empty));
        }

        [TestMethod]
        public void IsPermutationTest_string_permutation_of_itself_is_true()
        {
            Assert.IsTrue(ArrayAndString.IsPermutation("abc", "abc"));
        }

        [TestMethod]
        public void IsPermutationTest_string_permutations()
        {
            Assert.IsTrue(ArrayAndString.IsPermutation("abc", "abc"));
            Assert.IsTrue(ArrayAndString.IsPermutation("abc", "acb"));
            Assert.IsTrue(ArrayAndString.IsPermutation("abc", "bac"));
            Assert.IsTrue(ArrayAndString.IsPermutation("abc", "bca"));
            Assert.IsTrue(ArrayAndString.IsPermutation("abc", "cab"));
            Assert.IsTrue(ArrayAndString.IsPermutation("abc", "cba"));
        }

        [TestMethod]
        public void URLify()
        {
            char[] input = new char[] { 'M', 'r', ' ', 'J', 'o', 'h', 'n', ' ', 'S', 'm', 'i', 't', 'h', ' ', ' ', ' ', ' ' };
            char[] expected = new char[] { 'M', 'r', '%', '2', '0', 'J', 'o', 'h', 'n', '%', '2', '0', 'S', 'm', 'i', 't', 'h'};

            ArrayAndString.URLify(input, 13);
            var actual = input; 
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
