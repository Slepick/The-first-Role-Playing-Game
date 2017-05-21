using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    class CharacterWieldingMagic : RPG_Character
    {
        public List<Spell> StudiedSpells = new List<Spell>();
        private uint currentMP { get; set; }                                        //текущая мана
        public uint MaxMP { get; set; }
        public uint CurrentMP // Свойство текущей маны
        {
            get
            {
                return currentMP;
            }
            set
            {
                if (Cond != condition.Dead)
                {
                    if (value < 0)
                        value = 0;
                    if (value > MaxMP)
                        currentMP = MaxMP;
                    currentMP = value;
                }
            }
        }
        public CharacterWieldingMagic(string Name, race Race, bool Sex, uint MaxHP = 100, uint Expirience = 0, uint maxMP = 100)
            : base(Name, Race, Sex, MaxHP, Expirience)
        {
            this.MaxMP = maxMP;
            currentMP = maxMP;
        }

        public void Learn(Spell spl)
        {
            StudiedSpells.Add(spl);
        }
        public bool Forget(Spell spl)
        {
            return StudiedSpells.Remove(spl);
        }
        public void Cast(Spell spl, RPG_Character character = null, uint power = 0)
        {
            if (StudiedSpells.Contains(spl) && (IsWalkable || spl.CanBeSilent)
                && (IsTalkative || spl.CanBeStaned) && currentMP>spl.requiredMP)
            {
                spl.Cast(character, power);
                CurrentMP -= spl.requiredMP;
            }
        }

        public override string ToString()
        {
            return base.ToString() + "\nТекущее кол-во маны персонажа: " + CurrentMP.ToString()
                                   + "\nМаксимально кол-во маны персонажа: " + MaxMP.ToString();
        }
    }
}
