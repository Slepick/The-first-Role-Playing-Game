using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    class Revival : Spell
    {
        public Revival(uint requiredMP, bool isSilent, bool isStaned) : base(requiredMP, isSilent, isStaned)
        {
        }

        public override void Cast(RPG_Character character, uint power = 0)
        {
            if (character.cond == RPG_Character.condition.Dead)
            {
                Random rand = new Random();
                if ((rand.Next() & 1) == 0)
                    character.cond = RPG_Character.condition.Normal;
                else
                    character.cond = RPG_Character.condition.Weakened;
                character.currentHP = 1;
            }
        }
    }
}
