using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pause : MonoBehaviour
{
    public float timer;
    public bool ispuse;
    public GameObject MenuPanel;
    public GameObject settings;

    private void Update()
    {


        Time.timeScale = timer;
        if (Input.GetKeyDown(KeyCode.Escape) && ispuse == false)
        {
            MenuPanel.SetActive(true);
            ispuse = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && ispuse == true)
        {
            MenuPanel.SetActive(false);
            ispuse = false;
        }
        if (ispuse == true)
        {

            GameObject.Find("Player").GetComponent<GameInventory>().enabled = false;
            GameObject.Find("Player").GetComponent<Animator>().enabled = false;
            timer = 0;
        }
        else if (ispuse == false)
        {            
            timer = 1f;
            if (GameObject.Find("Player") != null)
            {
                GameObject.Find("Player").GetComponent<GameInventory>().enabled = true;
                GameObject.Find("Player").GetComponent<Animator>().enabled = true;
            }
        }
    }
    public void NewGame()
    {
        Application.LoadLevel("House");
        ispuse = false;
        timer = 0;
        MenuPanel.SetActive(false);
    }
    public void MainMenu()
    {
        Application.LoadLevel("Menu");
        ispuse = false;
        timer = 0;
        MenuPanel.SetActive(false);
    }
    public void Continue()
    {
        ispuse = false;
        timer = 0;
        MenuPanel.SetActive (false);
    }
    public void Control()
    {
        settings.SetActive(!settings.activeSelf);
    }
    public void Exit()
    {        
       
        Application.Quit();
    }    
}