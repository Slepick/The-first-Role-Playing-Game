using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    class Dead_Water_Bottle : Artefact
    {
        public Size size;
        public Dead_Water_Bottle(uint energy, Size size) : base(0, false)
        {
            this.size = size;
            switch (size)
            {
                case Size.Big:
                    Energy = 50;
                    break;
                case Size.Medium:
                    Energy = 25;
                    break;
                case Size.Small:
                    Energy = 10;
                    break;
            }
        }



        public override void Cast(RPG_Character character, uint power = 0)
        {
            if (character is CharacterWieldingMagic)
                if (power == 0)
                    (character as CharacterWieldingMagic).CurrentMP += Energy;
                else
                    (character as CharacterWieldingMagic).CurrentMP += power;
        }

        public void Start()
        {
            switch (size)
            {
                case Size.Big:
                    Energy = 50;
                    break;
                case Size.Medium:
                    Energy = 25;
                    break;
                case Size.Small:
                    Energy = 10;
                    break;
            }
        }
    }
}
