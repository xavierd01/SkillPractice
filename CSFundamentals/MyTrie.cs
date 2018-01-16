using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSFundamentals
{
    public class ContactTrie
    {
        internal class TrieNode
        {
            private int wordCount;
            public int WordCount
            {
                get { return wordCount; }
                set { wordCount = value; }
            }

            private Dictionary<char, TrieNode> lookup;
            public Dictionary<char, TrieNode> Children
            {
                get { return lookup; }
            }

            private bool isCompleteWord;
            public bool CompleteWord
            {
                get { return isCompleteWord; }
                set { isCompleteWord = value; }
            }

            public TrieNode AddChild(char c)
            {
                if (!lookup.ContainsKey(c))
                {
                    lookup.Add(c, new TrieNode());
                }
                return lookup[c];
            }

            public bool Contains(char c)
            {
                return lookup.ContainsKey(c);
            }

            public TrieNode GetChild(char c)
            {
                return lookup[c];
            }


            public TrieNode()
            {
                lookup = new Dictionary<char, TrieNode>();
                isCompleteWord = false;
                wordCount = 0;
            }
        }

        readonly TrieNode root;
        public ContactTrie()
        {
            root = new TrieNode();
        }

        public void AddContact(string name)
        {
            if (Search(name))
            {   // name already exists.
                return;
            }
            var temp = root;
            foreach (var c in name)
            {
                temp.WordCount++;
                temp = temp.AddChild(c);
            }
            temp.WordCount++;
            temp.CompleteWord = true;
        }

        public int CountPartial(string part)
        {
            // First, search for the prefix (partial match).
            var prefix = root;
            foreach (var c in part)
            {
                if (!prefix.Contains(c))
                {
                    return 0;
                }
                prefix = prefix.GetChild(c);
            }


            // TODO Make part of a return word function?
            //Stack<TrieNode> searchStack = new Stack<CSFundamentals.ContactTrie.TrieNode>();
            //searchStack.Push(prefix);
            //int count = 0;
            //while (searchStack.Count > 0)
            //{
            //    var temp = searchStack.Pop();
            //    if (temp.CompleteWord)
            //    {
            //        count++;
            //    }
            //    foreach (var kv in temp.Children)
            //    {
            //        searchStack.Push(kv.Value);
            //    }
            //}

            // From prefix, perform search for words.
            return prefix.WordCount;
        }

        public bool Search(string search)
        {
            var prefix = root;
            foreach (var c in search)
            {
                if (!prefix.Contains(c))
                {
                    return false;
                }
                prefix = prefix.GetChild(c);
            }
            return prefix.CompleteWord;
        }
    }
}
