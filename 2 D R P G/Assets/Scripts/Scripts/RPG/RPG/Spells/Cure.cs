using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;

namespace RPG
{
    public class Cure : Spell
    {
        public Cure(uint requiredMP, bool isSilent, bool isStaned) : base(requiredMP, isSilent, isStaned)
        {
        }

        public override void Cast(RPG_Character character,uint power=0)
        {
            if (character.Cond == condition.Sick)
                character.ChangeStatusToNormal();            
        }
    }
}
