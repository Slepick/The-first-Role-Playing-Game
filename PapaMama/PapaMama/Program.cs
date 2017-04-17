using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PapaMama
{
    class Program
    {
        static void Main(string[] args)
        {
            SayClass mama = new SayClass(100, "МАМА", 20);
            SayClass papa = new SayClass(100, "ПАПА", 20);
            SayClass son = new SayClass(10, "СЫН", 20);
            //SayClass daughter = new SayClass(2000, "Дочь", 20);
            //SayClass dog = new SayClass(4000, "Пёс", 20);
            Thread t1 = new Thread(mama.SayWord);
            Thread t2 = new Thread(papa.SayWord);
            Thread t3 = new Thread(son.SayWord);
            //Thread t4 = new Thread(dog.SayWord);
            //Thread t5 = new Thread(daughter.SayWord);
            t1.Start();
            t2.Start();
            t3.Start();
            //t4.Start();
            //t5.Start();
        }
    }
}
