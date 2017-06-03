using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Artefacts
{
    public class Eye_of_the_Basilisk: Artefact
    {

        public Eye_of_the_Basilisk() : base(0, false) { }

        public override void Cast(RPG_Character character, uint power = 0)
        {
            if (character.Cond != condition.Dead)
                character.Cond = condition.Paralyzed;
        }

        // Use this for initialization
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }
    }
}