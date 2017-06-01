using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public enum Size { Big, Medium, Small };
    public class Living_Water_Bottle : Artefact
    {
        Size size;
        public Living_Water_Bottle( Size size) : base(0, false)
        {
            this.size = size;
        }


        public override void Cast(RPG_Character character, uint power = 0)
        {
            switch (size)
            {
                case Size.Big:
                    character.CurrentHP += 50;
                    break;
                case Size.Medium:
                    character.CurrentHP += 25;
                    break;
                case Size.Small:
                    character.CurrentHP += 10;
                    break;                
            }            
        }


    }
}
