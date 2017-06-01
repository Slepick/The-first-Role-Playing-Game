using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RPG
{
    class Program
    {
        static void Main(string[] args)
        {

            CharacterWieldingMagic vlad = new CharacterWieldingMagic("Влад", race.Human, true);
            Dead_Water_Bottle SmallBottle = new Dead_Water_Bottle(10, Size.Small);
            Staff_Of_Lightning Staff = new Staff_Of_Lightning(110);
            RestoreHP s = new RestoreHP(10, false, false);
            Console.WriteLine(vlad);
            vlad.CurrentHP -= 50;
            vlad.IsTalkative = true;
            vlad.IsWalkable = true;
            Console.WriteLine(vlad);
            vlad.Learn(s);
            vlad.Cast(s, vlad);

            Console.WriteLine(vlad);

        }
    }
}
