using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RPG

{

    delegate void HitHandler(RPG_Character sender, uint damageValue);

    [Serializable]
    class RPG_Character : IComparable
    {

        public event HitHandler Hit;
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
                if (currentHP > value)
                    Hit(this, currentHP - value);
                else
                    currentHP = value;
                if (cond == condition.Normal || cond == condition.Weakened)
                    ChangeStatusToNormal();
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
        public void ChangeStatusToNormal()
        {
            double percent = 1.0 * currentHP / maxHP;
            if ((percent >= 0.1) && (cond != condition.Normal))
            {
                cond = condition.Normal;
            }
            if ((percent > 0) && (percent < 10) && (cond != condition.Weakened))
            {
                cond = condition.Weakened;
            }
            if (percent == 0)
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
        public void HitHandler(RPG_Character sender, uint damageValue)
        {
            sender.currentHP -= damageValue;
        }
       











































    }
}
