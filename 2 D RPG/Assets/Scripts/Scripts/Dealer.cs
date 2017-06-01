using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG;
using UnityEngine.UI;

public class Dealer : MonoBehaviour
{


    public GameObject inventory;
    public List<Item> list;
    public GameObject container;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


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
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" && Input.GetKeyDown(KeyCode.Space))
        {
                        
                if (inventory.activeSelf == false)
                {
                    inventory.SetActive(true);
                    int count = list.Count;
                    for (int i = 0; i < count; i++)
                    {
                        Item it = list[i];
                        if (inventory.transform.childCount >= i)
                        {
                            GameObject img = Instantiate(container);
                            img.transform.SetParent(inventory.transform.GetChild(i).transform);
                            img.GetComponent<Image>().sprite = Resources.Load<Sprite>(it.sprite);
                            img.GetComponent<DealerItemClick>().item = it;
                        }
                        else
                            break;
                    }

                }
                else
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
}
