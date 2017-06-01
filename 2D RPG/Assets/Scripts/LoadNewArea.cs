using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour {

    public GameObject pointToStart;
    private PlayerMovement thePlayer;
    private CameraController theCamera;
    // Use this for initialization
    void Start () {
        thePlayer = FindObjectOfType<PlayerMovement>();
        theCamera = FindObjectOfType<CameraController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            thePlayer.transform.position = pointToStart.transform.position;
            theCamera.transform.position = new Vector3(pointToStart.transform.position.x, pointToStart.transform.position.y, theCamera.transform.position.z);
        }
    }
}
