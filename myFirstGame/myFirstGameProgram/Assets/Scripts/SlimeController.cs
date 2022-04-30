using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour

{
    public float moveSpeed;

    private Rigidbody2D myRigidbody;

    private bool moving; // is the enemy moving or notmoving? 

    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;

    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        timeBetweenMoveCounter = timeBetweenMove;
        timeToMoveCounter = timeToMove;
    }

    // Update is called once per frame
    void Update() {
        
        if (moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            myRigidbody.velocity = moveDirection;
       
       
            if(timeToMoveCounter < 0f)
            {
                moving = false;
                timeBetweenMoveCounter = timeBetweenMove;
            } 

        } else {
            timeBetweenMoveCounter -= Time.deltaTime;
            myRigidbody.velocity = Vector2.zero; // Vector2 = zeros anywhere around the world 
            
            if(timeBetweenMoveCounter < 0f) 
                {
                    moving = true;
                    timeToMoveCounter = timeToMove;
                    moveDirection = new Vector3(Random.Range(-1f,1f)*moveSpeed,Random.Range(-1f,1f)*moveSpeed,0f);//picks a random number between 2 seconds

                }
        } 
    }
}
