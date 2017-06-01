using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class Staff_Of_Lightning : Artefact
    {
        public Staff_Of_Lightning(uint energy) : base(energy, true)
        {
        }

        public override void Cast(RPG_Character character, uint power = 0)
        {
            if (Energy < power)
                power = Energy;
            if (power > character.CurrentHP)
                power = character.CurrentHP;
            character.CurrentHP -= power;
            Energy -= power;
        }
    }
}
