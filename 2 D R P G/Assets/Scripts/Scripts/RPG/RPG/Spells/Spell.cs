using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace RPG
{
    public abstract class Spell : MonoBehaviour, IMagic
    {
        public string sprite;
        public uint requiredMP;
        public bool CanBeSilent;
        public bool CanBeStaned;
        // public string Text;
        public Spell(uint requiredMP, bool CanBeSilent, bool CanBeStaned)
        {
            this.requiredMP = requiredMP;
            this.CanBeSilent = CanBeSilent;
            this.CanBeStaned = CanBeStaned;
        }
        public abstract void Cast(RPG_Character character, uint power);
        //public abstract void Cast(RPG_Character character);
        //public abstract void Cast(double power);
        //public abstract void Cast();
    }
    
}
