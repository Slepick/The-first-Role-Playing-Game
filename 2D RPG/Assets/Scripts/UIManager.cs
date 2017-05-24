using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Slider healthBar;
    public Slider manaBar;
    public Slider expBar;
    public Text HPText;
    public Text MPText;
    public Text ExpText;
    public Text levelText;
    public HealthManager playerHealthMana;
    private PlayerStats thePlayerStats;

    // Use this for initialization
    void Start () {
        thePlayerStats = GetComponent<PlayerStats>();

    }
	
	// Update is called once per frame
	void Update () {
        healthBar.maxValue = playerHealthMana.playerMaxHealth;
        healthBar.value = playerHealthMana.playerCurrentHealth;
        manaBar.maxValue = playerHealthMana.playerMaxMana;
        manaBar.value = playerHealthMana.playerCurrentMana;
        expBar.maxValue = thePlayerStats.toLevelUp[thePlayerStats.currentLevel];
        expBar.value = thePlayerStats.currentExp;
        levelText.text = "Lvl: " + thePlayerStats.currentLevel ;  
        HPText.text = "HP: " + playerHealthMana.playerCurrentHealth + "/" + playerHealthMana.playerMaxHealth;
        MPText.text = "MP: " + playerHealthMana.playerCurrentMana + "/" + playerHealthMana.playerMaxMana;
        ExpText.text = "Exp: " + thePlayerStats.currentExp + "/" + thePlayerStats.toLevelUp[thePlayerStats.currentLevel];
    }
}
