using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RPG
{

    public class Immunity : Spell
    {
        public int Power;
        
        public Immunity(int power, bool isSilent, bool isStaned) : base((uint)(50 * power), isSilent, isStaned)
        {
            this.Power = power;
        }

        public override void Cast(RPG_Character character, uint power)
        {
            character.Hit -= character.HitHandler;           
            Thread thread = new Thread(returnSusceptibility);                                                         
            thread.Start(character);
        }
        private void returnSusceptibility(Object character)
        {
            Thread.Sleep(Power*1000);                                            // Жду 
            (character as RPG_Character).Hit += (character as RPG_Character).HitHandler; // Подключаю снова
        }
    }



}