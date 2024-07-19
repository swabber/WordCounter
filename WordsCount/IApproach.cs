using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsCount {
    public enum Output { 
        Console = 0,
        File = 1,
    }
    public interface IApproach {
        string CountWordsInFile(string text);
    }
}
