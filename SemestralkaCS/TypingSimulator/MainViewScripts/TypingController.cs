using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mysqlx.Session;

namespace TypingSimulator.MainViewScripts
{
    internal class TypingController
    {
        public DateTime startOfTyping { get; set; } = DateTime.Now;
        private List<bool> correctWord_ = [];
        private string typedWordChars_ = "";
        private string sampleWordChars_ = "";
        private bool IsTyping { get; set; } = false;
        public void AddCorrectWords()
        {
            correctWord_.Add(typedWordChars_ == sampleWordChars_);
        }
        public void AddTypedWordChar(char c)
        {
            typedWordChars_ += c;
        }
        public void AddSampleWordChars(string sampleWordChars)
        {
            sampleWordChars_ += sampleWordChars;
        }
        public IReadOnlyList<bool> GetCorrectWords()
        {
            return correctWord_;
        }
        public string GetWordChars()
        {
            return typedWordChars_;
        }
        public void StartTyping()
        {
            startOfTyping = DateTime.Now;
            correctWord_.Clear();
            typedWordChars_ = "";
        }
    }
}
