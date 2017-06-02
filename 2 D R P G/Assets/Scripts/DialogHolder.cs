using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogHolder : MonoBehaviour {

    public string dialogue;
    public GameObject disappearing;
    private DialogueManager dMan;
    private bool personExists = true;
    public string[] dialogueLines;


    // Use this for initialization
    void Start () {
        dMan = FindObjectOfType<DialogueManager>();

    }
	
	// Update is called once per frame
	void Update () {
        if (personExists == false && dMan.dialogFinished == true)
        {
            Instantiate(disappearing, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (!dMan.dialogActive)
            {
                dMan.dialogLines = dialogueLines;
                dMan.currentLine = 0;
                dMan.ShowDialogue();
                personExists = false;
            }
        }
    }
}
