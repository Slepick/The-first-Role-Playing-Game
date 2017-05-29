using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG;

public class HealthPotions : MonoBehaviour {

    public Size sizeOfBottle;
    private Living_Water_Bottle healthPotion;
	// Use this for initialization
	void Start () {
        healthPotion = new Living_Water_Bottle(sizeOfBottle);
	}
	
	// Update is called once per frame
	void Update () {
    }
}
