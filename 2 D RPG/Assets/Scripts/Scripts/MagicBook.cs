using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG;
using UnityEngine.UI;

public class MajicBook : MonoBehaviour
{
    public GameObject inventory;
    private List<RPG.Spell> list;
    public GameObject container;

    // Use this for initialization

    void Start()
    {
        inventory.SetActive(true);
        int count = list.Count;
        for (int i = 0; i < count; i++)
        {
            RPG.Spell it = list[i];
            if (inventory.transform.childCount >= i)
            {
                GameObject img = Instantiate(container);
                img.transform.SetParent(inventory.transform.GetChild(i).transform);
                img.GetComponent<Image>().sprite = Resources.Load<Sprite>(it.sprite);
                img.GetComponent<SpellClick>().spell = it;
            }
            else
                break;
        }
        
        // playerContr = GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {



    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {


            inventory.SetActive(true);
            int count = list.Count;
            for (int i = 0; i < count; i++)
            {
                RPG.Spell it = list[i];
                if (inventory.transform.childCount >= i)
                {
                    GameObject img = Instantiate(container);
                    img.transform.SetParent(inventory.transform.GetChild(i).transform);
                    img.GetComponent<Image>().sprite = Resources.Load<Sprite>(it.sprite);
                    img.GetComponent<SpellClick>().spell = it;
                }
                else
                    break;
            }

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        inventory.SetActive(false);
        inventory.SetActive(false);
        for (int i = 0; i < inventory.transform.childCount; i++)
        {
            if (inventory.transform.GetChild(i).transform.childCount > 0)
                Destroy(inventory.transform.GetChild(i).transform.GetChild(0).gameObject);
        }
    }
    //void use(Drag drag)
    //{
    //    RPG.CharacterWieldingMagic Player = GameObject.Find("Player").GetComponent<RPG.CharacterWieldingMagic>();
    //    //if (Player.StudiedSpells.Contains(drag.spell))
    //    //{
    //    //    Player.Cast(drag.spell, Player.Target);
    //    //}
    //    //else
    //    {
    //        Player.Learn(drag.spell);
    //        list.Remove(drag.spell);
    //        Destroy(drag.gameObject);
    //    }
    //}
}