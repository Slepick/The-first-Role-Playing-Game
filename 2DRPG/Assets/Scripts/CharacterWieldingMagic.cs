using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class CharacterWieldingMagic : RPG_Character
    {
        public uint currentMP { get; set; }                                        //текущая мана
        public uint maxMP { get; set; }                                             //макс мана
        public CharacterWieldingMagic(string Name, race R, bool Sex) : base(Name, R, Sex)
        {
            maxMP = 100; // Опять же, сколько по умолчанию
            currentMP = maxMP;
        }
    }
}
