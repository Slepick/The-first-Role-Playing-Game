using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RPG
{
    class Immunity : Spell
    {
        public Immunity(uint requiredMP, bool isSilent, bool isStaned) : base(requiredMP, isSilent, isStaned)
        {
        }

        public override void Cast(RPG_Character character, uint power)
        {
            throw new NotImplementedException();
        }

       
       
    }
}