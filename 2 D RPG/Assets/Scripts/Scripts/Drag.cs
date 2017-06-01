using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{

    public Transform canvas;
    public Transform old;
    public GameObject player;
    public Item item;
    // Use this for initialization
    void Start()
    {
        canvas = GameObject.Find("Canvas").transform;
        player = GameObject.FindGameObjectWithTag("Player");
    }
   
    public void OnBeginDrag(PointerEventData eventData)
    {

        old = transform.parent;
        transform.SetParent(canvas);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        //
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if (transform.parent == canvas)
        {
            transform.SetParent(old);
        }
        GetComponent<CanvasGroup>().blocksRaycasts = true;

    }

    public void OnPointerClick(PointerEventData eventData)
    {

        if (eventData.button == PointerEventData.InputButton.Left)
        {            
            player.BroadcastMessage("use", this);
        }
        else
            player.BroadcastMessage("remove", this);
    }
}
