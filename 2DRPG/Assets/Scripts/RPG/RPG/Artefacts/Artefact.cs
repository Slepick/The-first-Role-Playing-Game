using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RPG
{
    public abstract class Artefact : IMagic
    {
        public uint Energy;
        public bool IsRenewable;
        
        public Artefact(uint energy, bool isRenewable)
        {
            this.Energy = energy;
            this.IsRenewable = isRenewable;
           
        }
        public abstract void Cast(RPG_Character character, uint power);
        //public abstract void Cast(RPG_Character character);
        //public abstract void Cast(double power);
        //public abstract void Cast();
    }

}
