using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOn : MonoBehaviour {

    public GameObject gb;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.name == "Player" && Input.GetKeyUp(KeyCode.Space))
        {
            Destroy(gb);
            Destroy(gameObject);
        }
    }
}
