using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Artefacts
{
    class Poisonous_Saliva : Artefact
    {
        public Poisonous_Saliva(uint energy) : base(energy, true) { }

        public override void Cast(RPG_Character character, uint power = 0)
        {
            if (character.Cond == condition.Normal ||
                character.Cond == condition.Weakened)
            {
                character.Cond = condition.Poisoned;
            }
            character.CurrentHP -= Energy;//????? что делается с энергией
        }
    }
}
