using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

    public GameObject gas;
    private float time = 3f;
    private bool timer = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (timer == true)
            time -= Time.deltaTime;
        if (time <= 0)
        {
            timer = false;
            gas.SetActive(false);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            gas.SetActive(true);
            other.GetComponent<RPG.RPG_Character>().Cond = RPG.condition.Poisoned;
            timer = true;
        }
    }
}
