using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class Decoction_Of_Frog_Legs: Artefact
    {
        public Decoction_Of_Frog_Legs() : base(0, false)
        { }
        public override void Cast(RPG_Character character, uint power = 0)
        {
            if (character.Cond == condition.Poisoned)
                character.ChangeStatusToNormal();
        }

    }
}
