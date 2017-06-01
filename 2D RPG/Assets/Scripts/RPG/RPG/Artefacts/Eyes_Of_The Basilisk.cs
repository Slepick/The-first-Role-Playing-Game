using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG.Artefacts
{
    public class Eyes_Of_The_Basilisk: Artefact
    {
        public Eyes_Of_The_Basilisk() : base(0, false) { }

        public override void Cast(RPG_Character character, uint power = 0)
        {
            if (character.Cond != condition.Dead)
                character.Cond = condition.Paralyzed;
        }
    }
}
