using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    abstract class Spell : IMagic
    {
        public uint requiredMP;
        public bool isSilent;
        public bool isStaned;
        public Spell(uint requiredMP, bool isSilent, bool isStaned)
        {
            this.requiredMP = requiredMP;
            this.isSilent = isSilent;
            this.isStaned = isStaned;
        }
        public abstract void Cast(RPG_Character character, uint power);
        //public abstract void Cast(RPG_Character character);
        //public abstract void Cast(double power);
        //public abstract void Cast();
    }
}
