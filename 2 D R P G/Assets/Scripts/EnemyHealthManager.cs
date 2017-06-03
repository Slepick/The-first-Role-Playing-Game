using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

    private PlayerStats thePlayerStats;
    public int expToGive;
    // Use this for initialization
    void Start()
    {

        this.gameObject.GetComponent<RPG.RPG_Character>().CurrentHP = this.gameObject.GetComponent<RPG.RPG_Character>().MaxHP;
        thePlayerStats = FindObjectOfType<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<RPG.RPG_Character>().CurrentHP <= 0)
        {
            thePlayerStats.AddExperience(expToGive);
            Destroy(gameObject);
        }
    }

    public void HurtEnemy(int damageToGive)
    {
        this.gameObject.GetComponent<RPG.RPG_Character>().CurrentHP -= (uint)damageToGive;
    }

    public void SetMaxHealth()
    {
        this.gameObject.GetComponent<RPG.RPG_Character>().CurrentHP = this.gameObject.GetComponent<RPG.RPG_Character>().MaxHP;
    }
}

