using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    class Antidote:Spell
    {
        public Antidote(uint requiredMP, bool isSilent, bool isStaned) : base(requiredMP, isSilent, isStaned)
        {
        }
        public override void Cast(RPG_Character character, uint power = 0)
        {
            if (character.cond == RPG_Character.condition.Poisoned)
                character.ChangeStatusToNormal();
        }
    }
}
