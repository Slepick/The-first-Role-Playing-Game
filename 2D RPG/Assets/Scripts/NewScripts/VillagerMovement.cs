using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VillagerMovement : MonoBehaviour {


    public float moveSpeed;
    private Rigidbody2D myRigidbody;
    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;
    public bool isWalking;
    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;
    private int walkDirection;
    public Collider2D walkZone;
    private bool hasWalkZone;
    public bool canMove;
    private DialogueManager theDM;
    // Use this for initialization
    void Start () {
        myRigidbody = GetComponent<Rigidbody2D>();
        theDM = FindObjectOfType<DialogueManager>();
        walkCounter = Random.Range(walkTime * 0.75f, walkTime * 1.25f); 
        waitCounter = Random.Range(waitTime * 0.75f, waitTime * 1.25f);
        ChooseDirection();
        if (walkZone != null)
        {
            minWalkPoint = walkZone.bounds.min;
            maxWalkPoint = walkZone.bounds.max;
            hasWalkZone = true;
        }
        canMove = true;
    }
	
	// Update is called once per frame
	void Update () {
        if(!theDM.dialogActive)
        {
            canMove = true;
        }
        if(!canMove)
        {
            myRigidbody.velocity = Vector2.zero;
            return;
        }
        if(isWalking == true)
        {
            walkCounter -= Time.deltaTime;

            switch(walkDirection)
            {
                case 0:
                    myRigidbody.velocity = new Vector2(0, moveSpeed);
                    if(hasWalkZone && transform.position.y > maxWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = Random.Range(waitTime * 0.75f, waitTime * 1.25f);
                    }
                    break;
                case 1:
                    myRigidbody.velocity = new Vector2(moveSpeed, 0);
                    if (hasWalkZone && transform.position.x > maxWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = Random.Range(waitTime * 0.75f, waitTime * 1.25f);
                    }
                    break;
                case 2:
                    myRigidbody.velocity = new Vector2(0, -moveSpeed);
                    if (hasWalkZone && transform.position.y < minWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = Random.Range(waitTime * 0.75f, waitTime * 1.25f);
                    }
                    break;
                case 3:
                    myRigidbody.velocity = new Vector2(-moveSpeed, 0);
                    if (hasWalkZone && transform.position.x < minWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = Random.Range(waitTime * 0.75f, waitTime * 1.25f);
                    }
                    break;
            }

            if (walkCounter < 0)
            {
                isWalking = false;
                waitCounter = Random.Range(waitTime * 0.75f, waitTime * 1.25f);
            }
        }
        else
        {
            waitCounter -= Time.deltaTime;
            myRigidbody.velocity = Vector2.zero;
            if (waitCounter < 0)
            {
                ChooseDirection();
            }
        }
    }
    public void ChooseDirection()
    {
        walkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = Random.Range(walkTime * 0.75f, walkTime * 1.25f);
    }
}
