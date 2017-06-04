using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace RPG
{
    public class RestoreHP : Spell
    {
        public uint Power;
        public PlayerMovement thePlayer; 
        public RestoreHP(uint power, bool isSilent, bool isStaned) : base(power * 2, isSilent, isStaned)
        {
            Power = power;
        }

        public override void Cast(RPG_Character character, uint power = 0)
        {
            if (power == 0)
                character.CurrentHP += Power;
            else
                character.CurrentHP += power;
            Instantiate(effect, thePlayer.transform.position, thePlayer.transform.rotation);
            var clone = (GameObject)Instantiate(effect, thePlayer.transform.position, Quaternion.Euler(Vector3.zero));
        }
        private void Start()
        {
            thePlayer = FindObjectOfType<PlayerMovement>();
        }
        
    }
}
