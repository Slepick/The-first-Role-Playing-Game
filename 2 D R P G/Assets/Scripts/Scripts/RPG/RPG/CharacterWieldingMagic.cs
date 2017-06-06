using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace RPG
{
    public class CharacterWieldingMagic : RPG_Character
    {
        public List<Spell> StudiedSpells;
        public uint currentMP;                                        //текущая мана
        public uint MaxMP;//{ get; set; }
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
                    if (value > MaxMP)
                        currentMP = MaxMP;
                    else
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
                && (IsTalkative || spl.CanBeStaned) && currentMP >= spl.requiredMP)
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
        public void Start()
        {            
            Hit += HitHandler;          
            Target = this;
        }
    }
}
