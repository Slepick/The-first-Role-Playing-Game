using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
enum condition { Normal, Weakened, Sick, Poisoned, Paralyzed, Dead };
namespace RPG
{
    class HP_Change
    {
        protected double HPpercent;
        protected condition Condition;
        public event EventHandler<DeathRattleEventArgs> HP_Event; //без объявления делегата
        public HP_Change(double percent, condition c)
        {
            HPpercent = percent;
            Condition = c;
        }
        public void Set(DeathRattleEventArgs e)
        {
            if ((HPpercent >= 10) && (Condition == condition.Weakened))
            {
                Condition = condition.Normal;
                EventHandler<DeathRattleEventArgs> handler = HP_Event;
                if (HP_Event != null)
                    HP_Event(this, e);
            }
            if ((HPpercent > 0) && (HPpercent < 10) && (Condition == condition.Normal))
            {
                Condition = condition.Weakened;
                EventHandler<DeathRattleEventArgs> handler = HP_Event;
                if (HP_Event != null)
                    HP_Event(this, e);
            }
            if ((HPpercent == 0) && (Condition != condition.Dead))
            {
                Condition = condition.Dead;
                EventHandler<DeathRattleEventArgs> handler = HP_Event;
                if (HP_Event != null)
                    HP_Event(this, e);
            }
        }
    }
}
