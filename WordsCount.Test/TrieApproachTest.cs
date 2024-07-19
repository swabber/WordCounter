using System.Runtime.CompilerServices;
using System.Text;

namespace WordsCount.Test {
    [TestClass]
    public class TrieApproachTest {
        [TestMethod]
        public void TrieSmallTest() {
            var trie = new TrieApproach();
            string trieRes = trie.CountWordsInFile(smallText1);
            Assert.AreEqual(smallText1Expected1, trieRes);
        }
        private static string nl = Environment.NewLine;
        private static string smallText1 = "Go go Power Rangers";
        private static string smallText1Expected1 = $"2: go1: power1: rangers";

        [TestMethod]
        public void Trie6MBFileTest() {
            var trie = new TrieApproach();
            var inputText = File.ReadAllText("../../../6MB_ManyBooks.txt");
            var expectedText = File.ReadAllText("../../../6MB_ManyBooks_trie.txt");
            string trieRes = trie.CountWordsInFile(inputText);
            Assert.AreEqual(expectedText, trieRes);
        }
    }
}