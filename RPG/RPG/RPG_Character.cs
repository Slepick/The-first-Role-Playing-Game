using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    [Serializable]
    class RPG_Character
    {
        private static uint nextID = 1;
        public uint ID { get; set; }
        private string name { get; set; }
        public uint age { get; set; }
        bool talkative;
        bool walkable;
        //начало положено
        
        
    }
}
