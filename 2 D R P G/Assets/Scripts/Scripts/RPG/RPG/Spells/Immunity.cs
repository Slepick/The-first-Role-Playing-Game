using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RPG
{

    public class Immunity : Spell
    {
        public int Power;
        private float time;
        public PlayerMovement thePlayer;
        private bool isActive = false;
        private UnityEngine.SpriteRenderer playerSprite;
        private void Start()
        {
            thePlayer = FindObjectOfType<PlayerMovement>();
            playerSprite = thePlayer.gameObject.GetComponent<UnityEngine.SpriteRenderer>();
            
            time = (float)Power;
        }
        private void Update()
        {
            if (isActive == true)
            {
                time -= UnityEngine.Time.deltaTime;
                if (time <= 0)
                {
                    thePlayer.gameObject.GetComponent<UnityEngine.SpriteRenderer>().color = new UnityEngine.Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                    isActive = false;
                    time = (float)Power;
                }
            }

        }
        public Immunity(int power, bool isSilent, bool isStaned) : base((uint)(50 * power), isSilent, isStaned)
        {
            this.Power = power;
        }

        public override void Cast(RPG_Character character, uint power)
        {
            character.Hit -= character.HitHandler;           
            Thread thread = new Thread(returnSusceptibility);                                                         
            thread.Start(character);
            playerSprite.color = new UnityEngine.Color(255, 255, 115, 0.15f);
            isActive = true;
            //Instantiate(effect, thePlayer.transform.position, thePlayer.transform.rotation);
            //var clone = (UnityEngine.GameObject)Instantiate(effect, thePlayer.transform.position, UnityEngine.Quaternion.Euler(UnityEngine.Vector3.zero));
        }
        private void returnSusceptibility(Object character)
        {
            Thread.Sleep(Power*1000);                                            // Жду 
            (character as RPG_Character).Hit += (character as RPG_Character).HitHandler; // Подключаю снова
        }
    }



}