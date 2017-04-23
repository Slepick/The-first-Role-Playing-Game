using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    //Класс, предоставляющий данные для события
    class DeathRattleEventArgs : EventArgs
    {
        protected double HPpercent;
        public DeathRattleEventArgs(uint full_health, uint current_health)
        {
            HPpercent = (double)current_health/full_health;
        }
        public double Heath
        {
            get { return HPpercent; }
        }
    }

}
