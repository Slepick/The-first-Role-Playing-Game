using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class RestoreHP : Spell
    {
        public uint Power;
        public RestoreHP(uint power, bool isSilent, bool isStaned) :base(power*2,isSilent,isStaned)
        {
            Power = power;
        }

        public override void Cast(RPG_Character character, uint power=0)
        {        
            character.CurrentHP += power;
        }
    }
}
