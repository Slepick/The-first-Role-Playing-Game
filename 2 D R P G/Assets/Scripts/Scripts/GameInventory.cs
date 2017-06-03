using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG;
using UnityEngine.UI;

public class GameInventory : MonoBehaviour
{
    public static List<Item> list;
    public GameObject inventory;
    public GameObject container;
    public PlayerMovement playerContr;
    public static Sprite pic;
    public GameObject scroll;
    private float distance;
    // Use this for initialization

    void Start()
    {
        pic = container.GetComponent<Image>().sprite;
        //person = GetComponent<PlayerMovement>().myHero;
        
        list = GameObject.Find("Player").GetComponent<RPG_Character>().Invetory;
        playerContr = GetComponent<PlayerMovement>();
        
    }

    public bool AddInInventory(Item it)
    {
        int empty = -1;
        for (int k = 0; k < inventory.transform.childCount; k++)
        {
            if (inventory.transform.GetChild(k).transform.childCount == 0)
            {
                empty = k;
                break;
            }
        }
       
        if (empty == -1)
            return false;
        list.Add(it);
        GameObject img = Instantiate(container);
        img.transform.SetParent(inventory.transform.GetChild(empty).transform);
        inventory.transform.GetChild(empty).transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>(it.sprite);
        inventory.transform.GetChild(empty).transform.GetChild(0).GetComponent<Drag>().item = it;
        return true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, Input.mousePosition, 1.0f); 
            if (hit.collider != null)
            {
                distance = Vector2.Distance(transform.position, hit.collider.transform.position);
                if (distance < 1.2f)
                {
                    Item it = hit.collider.GetComponent<Item>();
                    if (it != null)
                    {
                        if(AddInInventory(it))
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
        }
        if (Input.GetKeyUp(KeyCode.I))
        {
            inventory.SetActive(!inventory.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            scroll.SetActive(false);
        }
    }

    

    void remove(Drag drag)
    {
        Item it = drag.item;
        GameObject newo = Instantiate<GameObject>(Resources.Load<GameObject>(it.prefab));
        newo.transform.position = transform.position - transform.up;
        list.Remove(it);
        Destroy(drag.gameObject);
    }
    void use(Drag drag)
    {

        if (drag.item is Artefact)
        {
            RPG.RPG_Character Player = GameObject.Find("Player").GetComponent<RPG.RPG_Character>();
            Player.UseArt(drag.item as Artefact, Player.Target);
            if (!(drag.item as Artefact).IsRenewable)
                Destroy(drag.gameObject);
            
        }
        else if (drag.item is HandItem)
        {
            HandItem myitem;
            myitem = Instantiate<GameObject>(Resources.Load<GameObject>(drag.item.prefab)).GetComponent<HandItem>();
            playerContr.gameObject.GetComponent<PlayerMovement>().addHand(myitem);
            list.Remove(drag.item);
            Destroy(drag.gameObject);
        }
        else
            scroll.SetActive(true);




    }

}
