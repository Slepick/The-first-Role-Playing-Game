using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG;
using UnityEngine.UI;

public class MagicUsePanel : MonoBehaviour
{
    public GameObject inventory;
    private List<RPG.Spell> list;
    public GameObject container;

    // Use this for initialization

    void Start()
    {
        list = GameObject.Find("Player").GetComponent<CharacterWieldingMagic>().StudiedSpells;
        for (int i = 0; i < inventory.transform.childCount; i++)
        {
            GameObject img = Instantiate(container);
            img.transform.SetParent(inventory.transform.GetChild(i).transform);

            RPG.Spell it = list[i];
            img.GetComponent<Image>().sprite = Resources.Load<Sprite>(it.sprite);
            img.GetComponent<SpellClick>().spell = it;
        }

    }


    // Update is called once per frame
    void Update()
    {
        //inventory.SetActive(true);
        //int count = list.Count;
        //for (int i = 0; i < count; i++)
        //{
        //    RPG.Spell it = list[i];
        //    inventory.transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(it.sprite);
        //    inventory.transform.GetChild(i).transform.GetChild(0).GetComponent<Drag>().spell = it;
        //}

    }
    //void use(Drag drag)
    //{
    //    RPG.CharacterWieldingMagic Player = GameObject.Find("Player").GetComponent<RPG.CharacterWieldingMagic>();
    //    if (Player.StudiedSpells.Contains(drag.spell))
    //    {
    //        Player.Cast(drag.spell, Player.Target);
    //    }

    //}
}