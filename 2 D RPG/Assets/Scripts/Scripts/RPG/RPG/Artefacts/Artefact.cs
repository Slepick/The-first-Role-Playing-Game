using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace RPG
{
    public abstract class Artefact :Item,IMagic
    {
        
        public uint Energy;
        public bool IsRenewable;

        public Artefact(uint energy, bool isRenewable)
        {
            this.Energy = energy;
            this.IsRenewable = isRenewable;

        }
        abstract public void Cast(RPG_Character character, uint power);
        //public abstract void Cast(RPG_Character character);
        //public abstract void Cast(double power);
        //public abstract void Cast();
    }

}
