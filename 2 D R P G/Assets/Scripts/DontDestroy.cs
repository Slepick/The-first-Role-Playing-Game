using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {

    public GameObject item;
    private static bool itemExists;
    // Use this for initialization
    void Start () {
        if (!itemExists)
        {
            itemExists = true;
            DontDestroyOnLoad(transform.gameObject);

        }
        else
            Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
