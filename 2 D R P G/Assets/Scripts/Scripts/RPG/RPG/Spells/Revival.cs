using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace RPG
{
    public class Revival : Spell
    {
        public PlayerMovement thePlayer;
        private void Start()
        {
            thePlayer = FindObjectOfType<PlayerMovement>();
        }
        public Revival(uint requiredMP, bool isSilent, bool isStaned) : base(requiredMP, isSilent, isStaned)
        {
        }

        public override void Cast(RPG_Character character, uint power = 0)
        {
            GameObject.Find("Player").SetActive(true);
            if (character.Cond == condition.Dead)
            {
                character.Cond = condition.Weakened;
                character.CurrentHP=1;
            }
            Instantiate(effect, thePlayer.transform.position, thePlayer.transform.rotation);
            var clone = (GameObject)Instantiate(effect, thePlayer.transform.position, Quaternion.Euler(Vector3.zero));
        }
    }
}
