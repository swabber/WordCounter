using System.Runtime.CompilerServices;
using System.Text;

namespace WordsCount.Test {
    [TestClass]
    public class NaiveApproachTest {
        [TestMethod]
        public void NaiveSmallTest() {
            var naive = new NaiveApproach();
            string naiveRes = naive.CountWordsInFile(smallText1);
            Assert.AreEqual(smallText1Expected1, naiveRes);
        }
        private static string nl = Environment.NewLine;
        private static string smallText1 = "Go go Power Rangers";
        private static string smallText1Expected1 = $"2: go{nl}1: power{nl}1: rangers";

        [TestMethod]
        public void Naive6MBFileTest() {
            var naive = new NaiveApproach();
            var inputText = File.ReadAllText("../../../6MB_ManyBooks.txt");
            var expectedText = File.ReadAllText("../../../6MB_ManyBooks_naive.txt");
            string naiveRes = naive.CountWordsInFile(inputText);
            Assert.AreEqual(expectedText, naiveRes);
        }
    }
}