using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    class CharacterWieldingMagic : RPG_Character
    {
        public uint currrentMP { get; set; }                                        //текущая мана
        public uint maxMP { get; set; }                                             //макс мана
    }
}
