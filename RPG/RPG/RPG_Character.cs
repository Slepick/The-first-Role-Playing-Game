using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    [Serializable]
    class RPG_Character : IComparable
    {

        event EventHandler<DeathRattleEventArgs> hpChange; //Создал событие!!!

        /// <summary>
        /// поля
        /// </summary>
        /// 
        private static uint nextID = 1;
        private uint ID { get; set; }
        private string name { get; set; }                                           //имя       
        public enum condition { Normal, Weakened, Sick, Poisoned, Paralyzed, Dead };       //состояние
        public condition cond { get; set; }
        public bool talkative { get; set; }                                         //возможность разговаривать
        public bool walkable { get; set; }                                          //возможность двигаться
        public enum race { Human, Dwarf, Elf, Ork, Goblin };                               //раса
        private race race_type { get; set; }
        private bool sex { get; set; }                                              //пол(женский false, мужской true)(а может enum?)
        public uint age { get; set; }                                               //возраст
        public uint currentHP                                                   //текущее здоровье
        {
            get
            {
                return currentHP;
            }
            set
            {
                currentHP = value;
                hpChange(this, new DeathRattleEventArgs(maxHP, currentHP));//когда оно происходит!!!
            }
        }
        public uint maxHP { get; set; }                                             //макс здоровье
        public uint Expirience { get; set; }                                        // опыт



        /// <summary>
        /// конструктор неизменяемых полей
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="R"></param>
        /// <param name="Sex"></param>
        public RPG_Character(string Name, race R, bool Sex)
        {
            name = Name;
            race_type = R;
            sex = Sex;
            ID = nextID;
            nextID++;
            this.hpChange += this.status_check;//подписался!!!на всякий случай в начале this написал,может не надо
        }

        /// <summary>
        /// метод для реализации интерфейса
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            if (!(obj is RPG_Character))
                throw new ArgumentException("object is not a RPG_Character");
            RPG_Character otherRPG_Character = (RPG_Character)obj;
            if (this.Expirience < otherRPG_Character.Expirience)
                return -1;
            if (this.Expirience > otherRPG_Character.Expirience)
                return 1;
            return 0;
        }

        /// <summary>
        /// надеюсь про здоровье это событие и его реализация в DeathRattle(данные для события) и HP_Change(класс-событие)
        /// обработчик события
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="ev"></param>        
        private void status_check(object sender, DeathRattleEventArgs ev)//твой Обработчик события
        {
            if ((ev.Heath >= 10) && (cond == condition.Weakened))
            {
                cond = condition.Normal;
            }
            if ((ev.Heath > 0) && (ev.Heath < 10) && (cond == condition.Normal))
            {
                cond = condition.Weakened;
            }
            if ((ev.Heath == 0) && (cond != condition.Dead))
            {
                cond = condition.Dead;
            }
        }


        //ToString
        public override string ToString()
        {
            return base.ToString() + ":\n "
                + "\n Идентификатор персонажа: " + ID.ToString()
                + "\n Имя персонажа: " + name.ToString()
                + "\n Состояние персонажа: " + cond.ToString()
                + "\n Возможность персонажа разговаривать: " + talkative.ToString()
                + "\n Возможность персонажа передвигаться: " + walkable.ToString()
                + "\n Раса персонажа: " + race_type.ToString()
                + "\n Пол персонажа: " + sex.ToString()
                + "\n Возраст персонажа: " + age.ToString()
                + "\n Текущее здоровье персонажа: " + currentHP.ToString()
                + "\n Максимальное здоровье персонажа: " + maxHP.ToString()
                + "\n Опыт персонажа: " + Expirience.ToString();
        }












































    }
}
