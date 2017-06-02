using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public enum Size { Big, Medium, Small };
    public class Living_Water_Bottle : Artefact
    {
        public Size size;
        public Living_Water_Bottle(Size size) : base(0, false)
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
                    Energy = 25;
                    break;
            }
        }


        public override void Cast(RPG_Character character, uint power = 0)
        {
            if (power == 0)
                character.CurrentHP += Energy;
            else
                character.CurrentHP += power;
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
                    Energy = 25;
                    break;
            }
        }

    }
}
