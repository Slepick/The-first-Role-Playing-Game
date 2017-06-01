using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {

    
    RPG.CharacterWieldingMagic Player;
   
    public bool flashActive;
    public float flashLength;
    private float flashCounter;
    private SpriteRenderer playerSprite;
    private DialogueManager theDM;
    // Use this for initialization
    void Start () {
        Player = GameObject.Find("Player").GetComponent<RPG.CharacterWieldingMagic>();
        
        playerSprite = GetComponent<SpriteRenderer>();
        theDM = FindObjectOfType<DialogueManager>();
    }
	
	// Update is called once per frame
	void Update () {
		if(Player.Cond==RPG.condition.Dead)
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
        Player.CurrentHP -= (uint)damageToGive;        
        flashActive = true;
        flashCounter = flashLength;
    }

    public void UseMana(int mana)
    {
        Player.CurrentMP -= (uint)mana;      
    }

    public void AddHealth(int health)
    {
        Player.CurrentHP += (uint)health;
    }

    public void AddMana(int mana)
    {
        Player.CurrentMP += (uint)mana;
    }
}
