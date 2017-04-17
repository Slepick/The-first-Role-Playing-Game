using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PapaMama
{
    class SayClass
    {
        private int ms;
        private int repeat;
        private String word;
        public static object lo = new object();
        private static int outputs = 11;

        public int MS { get { return ms; } }
        public String Word { get { return word; } }
        public int Repeat { get { return repeat; } }

        public SayClass(int ms, String word, int repeat)
        {
            this.ms = ms;
            this.word = word;
            this.repeat = repeat;
        }
        public void SayWord()
        {
            for (int i = 0; i < repeat && outputs > 0; i++, outputs--)
            {
                Thread.Sleep(MS);
                lock (lo)
                {
                    if (outputs <= 0)
                        break;
                    Console.Write(Word + " ");
                }
            }
        }
    }
}
