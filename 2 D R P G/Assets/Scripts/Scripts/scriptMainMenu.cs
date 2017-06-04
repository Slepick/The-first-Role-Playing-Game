using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptMainMenu : MonoBehaviour
{
    public GameObject settings;

    public void StartGame()
    {
        Application.LoadLevel(0);
        
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
