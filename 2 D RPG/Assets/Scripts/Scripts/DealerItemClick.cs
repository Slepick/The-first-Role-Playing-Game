using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DealerItemClick : MonoBehaviour, IPointerClickHandler
{


    public Item item;
    public GameObject inventory;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject.Find("Player").GetComponent<GameInventory>().AddInInventory(item);    
       
    }
}
