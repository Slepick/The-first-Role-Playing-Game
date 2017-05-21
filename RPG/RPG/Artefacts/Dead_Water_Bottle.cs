using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    class Dead_Water_Bottle : Artefact
    {
        Size size;
        public Dead_Water_Bottle(uint energy, Size size) : base(energy, false)
        {
            this.size = size;
        }


        public override void Cast(RPG_Character character, uint power = 0)
        {
            if (character is CharacterWieldingMagic)
                switch (size)
                {
                    case Size.Big:
                        (character as CharacterWieldingMagic).CurrentMP += 50;
                        break;
                    case Size.Medium:
                        (character as CharacterWieldingMagic).CurrentMP += 25;
                        break;
                    case Size.Small:
                        (character as CharacterWieldingMagic).CurrentMP += 10;
                        break;
                }
        }
    }
}
