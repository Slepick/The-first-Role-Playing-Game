using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Givesmth : MonoBehaviour {

    public string smth;
    private GameObject newObject;
    private bool readyToGive = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKeyUp(KeyCode.Space) && readyToGive == true)
        {
            newObject = Instantiate(Resources.Load(smth, typeof(GameObject))) as GameObject;
            readyToGive = false;
            newObject.transform.position = transform.position + transform.right;
        }
    }
}
