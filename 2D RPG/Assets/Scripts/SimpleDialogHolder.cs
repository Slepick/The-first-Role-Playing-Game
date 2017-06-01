﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDialogHolder : MonoBehaviour {

    public string dialogue;
    private DialogueManager dMan;
    public string[] dialogueLines;


    // Use this for initialization
    void Start()
    {
        dMan = FindObjectOfType<DialogueManager>();

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                //dMan.ShowBox(dialogue);
                if(!dMan.dialogActive)
                {
                    dMan.dialogLines = dialogueLines;
                    dMan.currentLine = 0;
                    dMan.ShowDialogue();
                }
                if(transform.parent.GetComponent<VillagerMovement>() != null)
                {
                    transform.parent.GetComponent<VillagerMovement>().canMove = false;
                }
            }
        }
    }
}

