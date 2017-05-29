using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG;
using UnityEngine.UI;

public class GameInventory : MonoBehaviour {
    private RPG_Character person;
    private List<Item> list;
    public GameObject inventory;
    public GameObject container;
    public PlayerMovement playerContr;
    // Use this for initialization
    void Start () {
        //person = GetComponent<PlayerMovement>().myHero;
        list = new List<Item>();
        playerContr = GetComponent<PlayerMovement>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0) && !inventory.activeSelf)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, Input.mousePosition,1.0f);
            if (hit.collider != null)
            {
                Item it = hit.collider.GetComponent<Item>();
                if (it != null)
                {
                    list.Add(it);
                    Destroy(hit.collider.gameObject);
                }
            }
        }
        if(Input.GetKeyUp(KeyCode.I))
        {
            
            if (inventory.activeSelf)
            {
                inventory.SetActive(false);
                for (int i = 0; i < inventory.transform.childCount; i++)
                {
                    if (inventory.transform.GetChild(i).transform.childCount > 0)
                        Destroy(inventory.transform.GetChild(i).transform.GetChild(0).gameObject);
                }
            }
            else
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
                        img.GetComponent<Drag>().item = it;
                    }
                    else
                        break;
                }
            }
        }
	}
    void remove(Drag drag)
    {
        Item it = drag.item;
        GameObject newo = Instantiate<GameObject>(Resources.Load<GameObject>(it.prefab));
        newo.transform.position = transform.position - transform.up;
        Destroy(drag.gameObject);
        list.Remove(it);
    }
    void use(Drag drag)
    {
        if (drag.item.type == "smallFood")
        {
            playerContr.gameObject.GetComponent<HealthManager>().AddHealth(20);
        }
        else if(drag.item.type == "hand")
        {
            HandItem myitem = Instantiate<GameObject>(Resources.Load<GameObject>(drag.item.prefab)).GetComponent<HandItem>();
            playerContr.gameObject.GetComponent<PlayerMovement>().addHand(myitem);
        }
        list.Remove(drag.item);
        Destroy(drag.gameObject);       
    }
}
