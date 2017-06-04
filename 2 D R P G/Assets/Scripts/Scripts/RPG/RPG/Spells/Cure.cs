using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using UnityEngine;

namespace RPG
{
    public class Cure : Spell
    {
        public PlayerMovement thePlayer;
        private void Start()
        {
            thePlayer = FindObjectOfType<PlayerMovement>();
        }
        public Cure(uint requiredMP, bool isSilent, bool isStaned) : base(requiredMP, isSilent, isStaned)
        {
        }

        public override void Cast(RPG_Character character,uint power=0)
        {
            if (character.Cond == condition.Sick)
                character.ChangeStatusToNormal();
            Instantiate(effect, thePlayer.transform.position, thePlayer.transform.rotation);
            var clone = (GameObject)Instantiate(effect, thePlayer.transform.position, Quaternion.Euler(Vector3.zero));
        }
    }
}
