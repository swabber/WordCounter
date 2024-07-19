
namespace WordsCount {
    public class NaiveApproach : IApproach {
        public string CountWordsInFile(string text) {
            string[] wordCandidas = text.Split(' ', ',', '.', '?', '!', '“', '”', ';', '—', ')', '(');
            Dictionary<string, int> wordsDict = new Dictionary<string, int>();
            foreach (string word in wordCandidas) {
                var w = word.ToLower().Trim();
                if (string.IsNullOrWhiteSpace(w)) {  continue; }
                if (!wordsDict.ContainsKey(w)) {
                    wordsDict[w] = 1;
                } else {
                    wordsDict[w] += 1;
                }
            }
            string res = string.Join(Environment.NewLine, wordsDict.OrderByDescending(w => w.Value).ThenBy(w => w.Key).Select(w => $"{w.Value}: {w.Key}"));
            return res;
        }
    }
}