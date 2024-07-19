using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsCount {
    public class TrieNode {
        public static Dictionary<char, int> reserved = new Dictionary<char, int> { { '’', 0 }, { '-', 1 }, { 'ʻ', 2 } };
        public static int Offset = reserved.Count;
        public char Val { get; private set; }
        public TrieNode[] Children = new TrieNode[Offset + 26];
        public int Count = 0;
        public TrieNode(char c = ' ') {
            Val = c;
        }
        public override string ToString() {
            return Val.ToString();
        }
    }

    public class TrieApproach : IApproach {
        private int MostFriquentWord = 0;

        private bool IsLetter(char c, ref int num, ref char chOut) {
            if ('a' <= c && c <= 'z') {
                num = c - 'a' + TrieNode.Offset;
                chOut = c;
                return true;
            } else if ('A' <= c && c <= 'Z') {
                chOut = char.ToLower(c);
                num = chOut - 'a' + TrieNode.Offset;
                return true;
            } else if (TrieNode.reserved.ContainsKey(c)) {
                num = TrieNode.reserved[c];
                chOut = c;
                return true;
            }
            return false;
        }

        private TrieNode ConvertFileIntoTrieNode(string text) {
            TrieNode rootNode = new TrieNode();
            int i = 0;
            TrieNode curNode = rootNode;
            while (i < text.Length) {
                int num = 0;
                char chOut = text[i];
                if (IsLetter(text[i], ref num, ref chOut)) {
                    if (curNode.Children[num] == null) {
                        curNode.Children[num] = new TrieNode(chOut);
                    }
                    curNode = curNode.Children[num];
                } else if (curNode != rootNode) {
                    curNode.Count += 1;
                    MostFriquentWord = Math.Max(MostFriquentWord, curNode.Count);
                    curNode = rootNode;
                }
                i++;
            }
            if (curNode != rootNode) { curNode.Count += 1; }
            return rootNode;
        }

        private void DFS(TrieNode node, StringBuilder sb, List<string>[] WordsCount) {
            if (node == null) { return; }
            if (node.Val != ' ') { sb.Append(node.Val); }
            if (node.Count > 0) {
                if (WordsCount[node.Count] == null) {
                    WordsCount[node.Count] = new List<string>();
                }
                WordsCount[node.Count].Add($"{node.Count}: {sb.ToString()}");
            }

            foreach (var child in node.Children) {
                DFS(child, sb, WordsCount);
            }
            if (sb.Length > 0) { sb.Length--; }
        }

        private string PrintResult(List<string>[] wordsCount) {
            StringBuilder sb = new StringBuilder();
            for (int i = wordsCount.Length - 1; i >= 0; i--) {
                if (wordsCount[i] == null) { continue; }
                foreach (var word in wordsCount[i]) {
                    sb.Append(word);
                }
            }
            return sb.ToString();
        }

        public string CountWordsInFile(string text) {
            MostFriquentWord = 0;
            TrieNode rootNode = ConvertFileIntoTrieNode(text);
            var wordsStat = new List<string>[MostFriquentWord + 1];
            DFS(rootNode, new StringBuilder(), wordsStat);
            return PrintResult(wordsStat);
        }
    }
}
