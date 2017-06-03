using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using UnityEngine;

namespace RPG

{
    public enum condition { Normal, Weakened, Sick, Poisoned, Paralyzed, Dead };
    public delegate void HitHandler(RPG_Character character, uint damageValue);
    public enum race { Human, Dwarf, Elf, Ork, Goblin };
    [Serializable]
    public class RPG_Character : MonoBehaviour, IComparable
    {
        public RPG_Character Target;
        public event HitHandler Hit; // Событие, происходящее, если персонажу нанесли урон
        private static uint nextID = 1;
        private uint ID;// { get; set; }
        private string Name; //{ get; set; }           // Имя                                                                                   
        public condition Cond; //{ get; set; }         // Состояние
        public bool IsTalkative=true;//{ get; set; }         // Возможность разговаривать
        public bool IsWalkable=true;//{ get; set; }          // Возможность двигаться
        private race race_type;//{ get; set; }        // Раса
        private bool isMale;//{ get; set; }           // Пол(женский false, мужской true)(а может enum?)
        public uint Age { get; set; }               // Возраст
        public uint currentHP;                     // Текущее здоровье
        public uint CurrentHP                       // Свойство текущего здоровья
        {
            get
            {
                return currentHP;
            }
            set
            {

                if (Cond != condition.Dead)
                {
                    if ((int)value < 0)          // Чтобы в минус не ушло
                        value = 0;
                    if (currentHP > value)
                    {
                        if (Hit != null)   // Это нужно,ибо я буду отключать обработчик при неуязвимости
                            Hit(this, currentHP - value);
                    }
                    else
                    {
                        if (value > MaxHP)
                            currentHP = MaxHP;
                        else
                            currentHP = value;
                    }
                    if (Cond == condition.Normal || Cond == condition.Weakened || currentHP == 0)
                        ChangeStatusToNormal();
                }
            }
        }
        public uint MaxHP;
        // public uint MaxHP { get ; set; }                                             //макс здоровье
        public uint Expirience { get; set; }                                        // опыт
        public List<Item> Invetory;

        /// <summary>
        /// Конструктор неизменяемых полей
        /// </summary>        
        public RPG_Character(string Name, race Race, bool Sex, uint MaxHP = 100, uint Expirience = 0)
        {
            this.Name = Name;
            race_type = Race;
            isMale = Sex;
            ID = nextID;
            nextID++;
            this.MaxHP = MaxHP;
            currentHP = MaxHP;
            this.Expirience = Expirience;
            IsTalkative = true;
            IsWalkable = true;
            Hit += HitHandler;
            Invetory = new List<Item>();
        }
        
        public int CompareTo(object obj)
        {
            if (!(obj is RPG_Character))
                throw new ArgumentException("object is not a RPG_Character");
            RPG_Character otherRPG_Character = (RPG_Character)obj;
            if (Expirience < otherRPG_Character.Expirience)
                return -1;
            if (Expirience > otherRPG_Character.Expirience)
                return 1;
            return 0;
        }


        public void ChangeStatusToNormal()
        {
            double percent = 100.0 * currentHP / MaxHP;
            if ((percent >= 10) && (Cond != condition.Normal))
            {
                Cond = condition.Normal;
            }
            if ((percent > 0) && (percent < 10) && (Cond != condition.Weakened))
            {
                Cond = condition.Weakened;
            }
            if (percent == 0)
            {
                Cond = condition.Dead;
               // gameObject.SetActive(false);
            }
        }

        public override string ToString()
        {
            return "Идентификатор персонажа: " + ID.ToString()
                + "\nИмя персонажа: " + Name.ToString()
                + "\nСостояние персонажа: " + Cond.ToString()
                + "\nВозможность персонажа разговаривать: " + IsTalkative.ToString()
                + "\nВозможность персонажа передвигаться: " + IsWalkable.ToString()
                + "\nРаса персонажа: " + race_type.ToString()
                + "\nПол персонажа: " + isMale.ToString()
                + "\nВозраст персонажа: " + Age.ToString()
                + "\nТекущее здоровье персонажа: " + currentHP.ToString()
                + "\nМаксимальное здоровье персонажа: " + MaxHP.ToString()
                + "\nОпыт персонажа: " + Expirience.ToString();
        }
        public void HitHandler(RPG_Character character, uint damageValue)
        {
            character.currentHP -= damageValue;
        }

        public void AddInInventory(Item art)
        {
            Invetory.Add(art);
        }
        public bool RemoveFromInventory(Item art)
        {
            return Invetory.Remove(art);
        }
        public void GiveArt(RPG_Character character, Item art)
        {
            if (Invetory.Contains(art))
                Invetory.Remove(art);
            character.AddInInventory(art);
        }
        public void UseArt(Artefact art, RPG_Character character = null, uint power = 0)
        {
            if (Invetory.Contains(art))
            {
                art.Cast(character, power);
                if (art.IsRenewable == false)
                    Invetory.Remove(art);
            }
        }
        virtual public void Start()
        {
            Hit += HitHandler;
        }
        private void Update()
        {

        }
        void OnMouseDown()
        {
            GameObject.Find("Player").gameObject.GetComponent<CharacterWieldingMagic>().Target = this.gameObject.GetComponent <RPG_Character>();
        }
    }
}
