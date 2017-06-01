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
    public RPG.CharacterWieldingMagic playerHealthMana;
    private PlayerStats thePlayerStats;
    private static bool UIExist;

    // Use this for initialization
    void Start () {
        thePlayerStats = GetComponent<PlayerStats>();
        if (!UIExist)
        {
            UIExist = true;
            DontDestroyOnLoad(transform.gameObject);

        }
        else
            Destroy(gameObject);
    }
	
	// Update is called once per frame
	void Update () {
        healthBar.maxValue = playerHealthMana.MaxHP;
        healthBar.value = playerHealthMana.CurrentHP;
        manaBar.maxValue = playerHealthMana.MaxMP;
        manaBar.value = playerHealthMana.CurrentMP;
        expBar.maxValue = thePlayerStats.toLevelUp[thePlayerStats.currentLevel];
        expBar.value = thePlayerStats.currentExp;
        levelText.text = "Lvl: " + thePlayerStats.currentLevel ;  
        HPText.text = "HP: " + playerHealthMana.CurrentHP + "/" + playerHealthMana.MaxHP;
        MPText.text = "MP: " + playerHealthMana.CurrentMP + "/" + playerHealthMana.MaxMP;
        ExpText.text = "Exp: " + thePlayerStats.currentExp + "/" + thePlayerStats.toLevelUp[thePlayerStats.currentLevel];
    }
}
