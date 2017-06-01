using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnOnCanvas : MonoBehaviour {

    private Canvas canvas;
	// Use this for initialization
	void Start () {
        canvas = FindObjectOfType<Canvas>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            canvas.GetComponent<UIManager>().healthBar.gameObject.SetActive(true);
            canvas.GetComponent<UIManager>().manaBar.gameObject.SetActive(true);
            canvas.GetComponent<UIManager>().expBar.gameObject.SetActive(true);
            canvas.GetComponent<UIManager>().HPText.gameObject.SetActive(true);
            canvas.GetComponent<UIManager>().MPText.gameObject.SetActive(true);
            canvas.GetComponent<UIManager>().ExpText.gameObject.SetActive(true);
            canvas.GetComponent<UIManager>().levelText.gameObject.SetActive(true);
        }
    }
}
