using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    class RestoreHP : Spell
    {
        public RestoreHP(uint requiredMP, bool isSilent, bool isStaned) : base(requiredMP, isSilent, isStaned)
        {
        }

        public override void Cast(RPG_Character character, uint power)
        {
            character.currentHP += power;
        }
    }
}
