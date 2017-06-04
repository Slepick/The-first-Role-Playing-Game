using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG;

public class PlayerMovement : MonoBehaviour {
    public float Speed;
    public Animator anim;
    private Rigidbody2D rbody;
    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;
    private static string name = "Seva";
    public CharacterWieldingMagic myHero = new CharacterWieldingMagic(name, race.Human, true, 30, 0, 15);
    public Transform weapon;
    private HandItem item;
    private static bool playerExists;
    public string startPoint;
    public bool canMove;

    // Use this for initialization
    void Start () {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //myHero = new CharacterWieldingMagic(name, race.Human, true, 30, 0, 15);
        /*if (!playerExists)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);

        }
        else
            Destroy(gameObject);
        canMove = true;*/
    }
	
    public void addHand(HandItem it)
    {
        
        if (item != null)
        {
            item.transform.SetParent(null);
        }
        it.transform.SetParent(weapon);
        it.transform.localPosition = it.position;
        it.transform.localRotation = Quaternion.Euler(it.rotation);
        item = it;
    }

	// Update is called once per frame
	void Update () {
        if (!canMove)
        {
            rbody.velocity = Vector2.zero;
            return;
        }
        if (!attacking)
        {
            Vector2 movement_vector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (movement_vector != Vector2.zero)
            {
                anim.SetBool("iswalking", true);
                anim.SetFloat("input_x", movement_vector.x);
                anim.SetFloat("input_y", movement_vector.y);
            }
            else
            {
                anim.SetBool("iswalking", false);
            }
            if (movement_vector.x != 0 && movement_vector.x != 0)
                rbody.MovePosition(rbody.position + 0.75f * movement_vector * Speed * Time.deltaTime);
            else
                rbody.MovePosition(rbody.position + movement_vector * Speed * Time.deltaTime);
            if (Input.GetKeyDown(KeyCode.G) && item != null && gameObject.GetComponent<RPG.RPG_Character>().Cond!=RPG.condition.Paralyzed)
            {
                attackTimeCounter = attackTime;
                attacking = true;
                rbody.velocity = Vector2.zero;
                anim.SetBool("attack", true);
            }
        }
        if (attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }
        if (attackTimeCounter <= 0)
        {
            attacking = false;
            anim.SetBool("attack", false);
        }

    }
}
