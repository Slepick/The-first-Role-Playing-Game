using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SpellClick : MonoBehaviour, IPointerClickHandler
{

    public GameObject inventory;
    public RPG.Spell spell;
    void Start()
    {
        inventory = GameObject.Find("MagicBook");
    }
    void Update()
    {
    }
        public void OnPointerClick(PointerEventData eventData)
    {
        RPG.CharacterWieldingMagic Player = GameObject.Find("Player").GetComponent<RPG.CharacterWieldingMagic>();
        if (Player.StudiedSpells.Contains(spell))
        {
            Player.Cast(spell, Player.Target);            
        }
        else
        {
            Player.Learn(spell);
            List<RPG.Spell> list = GameObject.Find("Player").GetComponent<RPG.CharacterWieldingMagic>().StudiedSpells;
            for (int i = 0; i < inventory.transform.childCount; i++)
                if (inventory.transform.GetChild(i).childCount == 0)
                {
                    transform.SetParent(inventory.transform.GetChild(i));
                    break;
                }
        }
    }
}
