using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartingPoint : MonoBehaviour {

    private PlayerMovement thePlayer;
    private CameraController theCamera;
    public float x;
    public float y;
    public string pointName;
    // Use this for initialization
    void Start () {
        thePlayer = FindObjectOfType<PlayerMovement>();
        if (thePlayer.startPoint == pointName)
        {
            thePlayer.transform.position = transform.position;
            thePlayer.anim.SetFloat("input_x", x);
            thePlayer.anim.SetFloat("input_y", y);
            theCamera = FindObjectOfType<CameraController>();
            theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
