using System.Diagnostics;
using System.Text;

namespace WordsCount {
    internal class Program {
        static void Main(string[] args) {
            var setting = Output.File;
            //var file = "../../../1KB_PathToFile.txt";
            //var file = "../../../259KB_The-case-of-charles-dexter-ward.txt";
            var file = "../../../../WordsCount.Test/6MB_ManyBooks.txt";
            //var file = "../../../10MB_ManyBooks.txt";
            //var file = "../../../Random.txt";

            //GenerateFile(7,100000); // 1 500 000
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var naive = new NaiveApproach();
            string naiveRes = naive.CountWordsInFile(ReadFile(file));
            PresentResult(naiveRes, setting, file, "naive");

            Console.WriteLine($"Naive: {sw.Elapsed}");
            Console.WriteLine();

            sw.Restart();
            
            var trie = new TrieApproach();
            string trieRes = trie.CountWordsInFile(ReadFile(file));
            PresentResult(trieRes, setting, file, "trie");

            Console.WriteLine($"Tries: {sw.Elapsed}");
        }

        private static void PresentResult(string res, Output setting, string filePath, string prefix) {
            if (setting == Output.File) {
                File.WriteAllText(filePath.Replace(".txt", $"_{prefix}.txt"), res);
            } else {
                Console.WriteLine(res);
            }
        }

        private static string ReadFile(string filePath) {
            return File.ReadAllText(filePath);
        }

        private static void GenerateFile(int WordLength, int combinations) { 
            StringBuilder sb = new StringBuilder();
            Random r = new Random();
            for (int i = 0; i < combinations; i++) {
                StringBuilder curWord = new StringBuilder();
                foreach (var k in Enumerable.Range(0, WordLength)) {
                    curWord.Append((char)('A'+r.Next(0, 25)));
                }
                int j = 0;
                while(j<WordLength){
                    sb.Append(" "+curWord.ToString());
                    char c = curWord[curWord.Length - 1];
                    curWord.Length--;
                    curWord.Insert(0, c);
                    j++;
                }
            }
            File.WriteAllText("../../../Random.txt", sb.ToString());
        }
    }
}
