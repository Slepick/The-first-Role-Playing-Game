using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {

    public int playerCurrentHealth;
    public int playerMaxHealth;

    public int playerCurrentMana;
    public int playerMaxMana;
    public bool flashActive;
    public float flashLength;
    private float flashCounter;
    private SpriteRenderer playerSprite;
    private DialogueManager theDM;
    // Use this for initialization
    void Start () {
        playerCurrentHealth = playerMaxHealth;
        playerCurrentMana = playerMaxMana;
        playerSprite = GetComponent<SpriteRenderer>();
        theDM = FindObjectOfType<DialogueManager>();
    }
	
	// Update is called once per frame
	void Update () {
		if(playerCurrentHealth == 0)
        {
            GetComponent<Animator>().SetBool("isalive", false);
            GetComponent<PlayerMovement>().canMove = false;           
            //gameObject.SetActive(false);
        }
        else
        {
            GetComponent<Animator>().SetBool("isalive", true);
            if(!theDM.dialogActive)
            {
                GetComponent<PlayerMovement>().canMove = true;
            }
        }
        if(flashActive)
        {
            if (flashCounter > flashLength * .66f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            }
            else if(flashCounter > flashLength * .33f)
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
            }
            else if(flashCounter > 0)
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 0f);
            else
            {
                playerSprite.color = new Color(playerSprite.color.r, playerSprite.color.g, playerSprite.color.b, 1f);
                flashActive = false;
            }
            flashCounter -= Time.deltaTime;
        }
	}

    public void HurtPlayer(int damageToGive)
    {
        playerCurrentHealth -= damageToGive;
        if (playerCurrentHealth < 0)
            playerCurrentHealth = 0;
        flashActive = true;
        flashCounter = flashLength;
    }

    public void UseMana(int mana)
    {
        playerCurrentMana -= mana;
        if (playerCurrentMana < 0)
            playerCurrentMana = 0;
    }

    public void AddHealth(int health)
    {
        playerCurrentHealth += health;
        if (playerCurrentHealth > playerMaxHealth)
            playerCurrentHealth = playerMaxHealth;
    }

    public void AddMana(int mana)
    {
        playerCurrentMana += mana;
        if (playerCurrentMana > playerMaxMana)
            playerCurrentMana = playerMaxMana;
    }
}
