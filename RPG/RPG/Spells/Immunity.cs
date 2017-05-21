using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RPG
{

    class Immunity : Spell
    {
        public int Power;
        public Immunity(int power, bool isSilent, bool isStaned) : base((uint)(50 * power), isSilent, isStaned)
        {
            this.Power = power;
        }

        public override void Cast(RPG_Character character, uint power)
        {
            character.Hit -= character.HitHandler;                          // Отключаю обработчик события hit
            TimerCallback tm = new TimerCallback(returnSusceptibility);     // Метод, который будет выполнять таймер в новом треде
                                                                            // Новый тред создаётся автоматически
            Timer timer = new Timer(tm, character, 0, -1);                  // Первый параметр метод,второй параметр объекта, 
                                                                            // 0 - чтобы выполнялся без задрежки,-1 не повторяясь
        }
        private void returnSusceptibility(object character)
        {
            Thread.Sleep(Power);                                            // Жду 
            (character as RPG_Character).Hit += (character as RPG_Character).HitHandler; // Подключаю снова
        }
    }



}