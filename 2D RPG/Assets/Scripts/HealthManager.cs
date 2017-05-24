using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {

    public int playerCurrentHealth;
    public int playerMaxHealth;

    public int playerCurrentMana;
    public int playerMaxMana;
    // Use this for initialization
    void Start () {
        playerCurrentHealth = playerMaxHealth;
        playerCurrentMana = playerMaxMana;
    }
	
	// Update is called once per frame
	void Update () {
		if(playerCurrentHealth == 0)
        {
            gameObject.SetActive(false);
        }
	}

    public void HurtPlayer(int damageToGive)
    {
        playerCurrentHealth -= damageToGive;
        if (playerCurrentHealth < 0)
            playerCurrentHealth = 0;
    }

    public void UseMana(int mana)
    {
        playerCurrentMana -= mana;
        if (playerCurrentMana < 0)
            playerCurrentMana = 0;
    }

    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }
}
