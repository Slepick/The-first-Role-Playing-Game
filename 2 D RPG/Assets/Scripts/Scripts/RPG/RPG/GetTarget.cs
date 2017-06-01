using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTarget : MonoBehaviour {

    public RPG.CharacterWieldingMagic Who;
	// Use this for initialization
	void Start () {
       // Who = gameObject.GetComponent<CharacterWieldingMagic>;
	}
    void OnMouseDown()
    {
       Who.Target = this.gameObject.GetComponent<RPG.CharacterWieldingMagic>();
    }
	// Update is called once per frame
	void Update ()
    {
       
    }
}

  



