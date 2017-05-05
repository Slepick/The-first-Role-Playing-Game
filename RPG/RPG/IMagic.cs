using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    interface IMagic
    {
        void Cast(RPG_Character character, uint power=0);
        //void Cast(RPG_Character character);
        //void Cast(uint power);
        //void Cast();
    }
}
