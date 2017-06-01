﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgressiveSlime : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody2D myRigidbody;
    private bool moving;
    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;
    private Vector3 moveDirection;
    private Vector3 moveDirection1;
    public Transform player;
    private Animator anim;
    public float distance = 5.0f;
    private bool aggresive = false;
    // Use this for initialization
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //timeBetweenMoveCounter = timeBetweenMove;
        //timeToMoveCounter = timeToMove;
        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
        timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        if (distance < 4.0f)
        {
            moveDirection1 = new Vector2((transform.position.x - player.transform.position.x) * moveSpeed, (transform.position.y - player.transform.position.y) * moveSpeed);
            //transform.Translate(moveDirection1.normalized * Time.deltaTime * moveSpeed);
            GetComponent<Rigidbody2D>().velocity = -moveDirection1.normalized * moveSpeed;

        }
        else
        {
            if (moving)
            {
                
                timeToMoveCounter -= Time.deltaTime;
                myRigidbody.velocity = moveDirection;
                if (timeToMoveCounter < 0f)
                {
                    moving = false;
                    //timeBetweenMoveCounter = timeBetweenMove;
                    timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.75f, timeBetweenMove * 1.25f);
                }
            }
            else
            {
                timeBetweenMoveCounter -= Time.deltaTime;
                myRigidbody.velocity = Vector2.zero;
                if (timeBetweenMoveCounter < 0f)
                {
                    moving = true;
                    //timeToMoveCounter = timeToMove;
                    timeToMoveCounter = Random.Range(timeToMove * 0.75f, timeBetweenMove * 1.25f);
                    moveDirection = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0f);
                }
            }
        }
    }
}
