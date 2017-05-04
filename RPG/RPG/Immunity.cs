using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RPG
{
    class Immunity : Spell
    {
        int power;
        public Immunity(int power, bool isSilent, bool isStaned) : base((uint)(50*power), isSilent, isStaned)
        {
           this.power = power;
        }
        void getImmunity(RPG_Character character,int power)
        {
        }
        
        public override void Cast(RPG_Character character, uint power)
        {
            character.Hit -= character.HitHandler;
            Thread.Sleep((int)power);
            character.Hit += character.HitHandler;
        }

       
       
    }
}