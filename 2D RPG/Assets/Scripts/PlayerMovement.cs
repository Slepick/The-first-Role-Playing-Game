﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG;

public class PlayerMovement : MonoBehaviour {
    public float Speed;
    private Animator anim;
    private Rigidbody2D rbody;
    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;
    // Use this for initialization
    void Start () {
        rbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
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
            if(movement_vector.x != 0 && movement_vector.x != 0)
                rbody.MovePosition(rbody.position + 0.75f * movement_vector * Speed * Time.deltaTime);
            else
                rbody.MovePosition(rbody.position + movement_vector * Speed * Time.deltaTime);
        }
        if(attackTimeCounter > 0)
        {
            attackTimeCounter -= Time.deltaTime;
        }
        if (attackTimeCounter <= 0)
        {
            attacking = false;
            anim.SetBool("attack",false);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            attackTimeCounter = attackTime;
            attacking = true;
            rbody.velocity = Vector2.zero;
            anim.SetBool("attack", true);
        }
        
	}
}
