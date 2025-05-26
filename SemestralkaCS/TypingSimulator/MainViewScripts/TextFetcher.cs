using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypingSimulator.MainViewScripts
{
    public class TextFetcher(string language)
    {
        private readonly string language_ = language;
        public string[] GetRandomSample()
        {
            if (Directory.Exists(language_))
            {
                string[] sampleFiles = Directory.GetFiles(language_, "*.txt");
                return File.ReadAllLines(sampleFiles[Random.Shared.Next(0, sampleFiles.Length - 1)]);
            }
            else
            {
                string[] sampleFiles = { "No directory found for this language.", "However you can at least type this thing out."};
                return sampleFiles;
            }
        }
    }
}
