using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG;
using UnityEngine.UI;

public class Wizzard : MonoBehaviour
{

    public GameObject inventory;
    public List<RPG.Spell> list;
    public GameObject container;

    // Use this for initialization

    void Start()
    {

        // playerContr = GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {



    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                inventory.SetActive(!inventory.activeSelf);
                if (inventory.activeSelf == true)
                {
                    int count = list.Count;
                    for (int i = 0; i < count; i++)
                    {
                        RPG.Spell it = list[i];
                        if (!other.gameObject.GetComponent<RPG.CharacterWieldingMagic>().StudiedSpells.Contains(it))
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
                if (inventory.activeSelf == false)
                {
                    for (int i = 0; i < inventory.transform.childCount; i++)
                    {
                        if (inventory.transform.GetChild(i).transform.childCount > 0)
                            Destroy(inventory.transform.GetChild(i).transform.GetChild(0).gameObject);
                    }
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            inventory.SetActive(false);
            for (int i = 0; i < inventory.transform.childCount; i++)
            {
                if (inventory.transform.GetChild(i).transform.childCount > 0)
                    Destroy(inventory.transform.GetChild(i).transform.GetChild(0).gameObject);
            }
        }
    }

}