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
        public DateTime StartOfTyping { get; set; } = DateTime.Now;

        public void StartTyping()
        {
            StartOfTyping = DateTime.Now;
        }
    }
}
