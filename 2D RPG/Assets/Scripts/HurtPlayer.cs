using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

    public int damageToGive;
    private int currentDamage;
    public GameObject damageNumber;
    public float timeToAttack;
    private float timeToAttackCounter;
    private PlayerStats thePS;
    // Use this for initialization
    void Start () {
        timeToAttackCounter = timeToAttack;
        thePS = FindObjectOfType<PlayerStats>();
    }
	
	// Update is called once per frame
	void Update () {
        timeToAttackCounter -= Time.deltaTime;

    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (timeToAttackCounter <= 0)
        {
            if (other.gameObject.name == "Player" && other.gameObject.GetComponent<HealthManager>().playerCurrentHealth > 0)
            {
                currentDamage = damageToGive - thePS.currentDefense;
                if(currentDamage <= 0)
                {
                    currentDamage = 1;
                }
                other.gameObject.GetComponent<HealthManager>().HurtPlayer(currentDamage);
                var clone = (GameObject)Instantiate(damageNumber, other.transform.position, Quaternion.Euler(Vector3.zero));
                clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
                timeToAttackCounter = timeToAttack;
            }
        }
    }
}
