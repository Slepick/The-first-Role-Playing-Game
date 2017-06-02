using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public int currentLevel;
    public int currentExp;
    public int[] toLevelUp;
    public int[] HPLevels;
    public int[] MPLevels;
    public int[] attackLevels;
    public int[] defenseLevels;
    public int currentHP;
    public int currentMP;
    public int currentAttack;
    public int currentDefense;
    private RPG.CharacterWieldingMagic thePlayerHPMP;
   
    // Use this for initialization
    void Start () {
        currentHP = HPLevels[1];
        currentMP = MPLevels[1];
        currentAttack = attackLevels[1];
        currentDefense = defenseLevels[1];
        thePlayerHPMP = FindObjectOfType<RPG.CharacterWieldingMagic>();
}
	
	// Update is called once per frame
	void Update () {
		if(currentExp >= toLevelUp[currentLevel])
        {
            //currentLevel++;

            LevelUp();
        }
	}
    public void AddExperience(int experienceToAdd)
    {
        currentExp += experienceToAdd;
    }
    public void LevelUp()
    {
        currentLevel++;

        currentHP = HPLevels[currentLevel];
        thePlayerHPMP.MaxHP = (uint)(currentHP);
        thePlayerHPMP.CurrentHP += (uint)(currentHP - HPLevels[currentLevel - 1]);

        currentMP = MPLevels[currentLevel];
        thePlayerHPMP.MaxMP = (uint)(currentMP);
        thePlayerHPMP.CurrentMP += (uint)(currentMP - MPLevels[currentLevel - 1]);
        
        currentAttack = attackLevels[currentLevel];
        currentDefense = defenseLevels[currentLevel];
    }
}
