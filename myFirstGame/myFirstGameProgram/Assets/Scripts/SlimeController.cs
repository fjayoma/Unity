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
    public float waitToReload;
    private bool reloading; 
    private GameObject thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myRigidbody.freezeRotation = true;

        //timeBetweenMoveCounter = timeBetweenMove;
        //timeToMoveCounter = timeToMove;

        timeBetweenMoveCounter = Random.Range(timeBetweenMove*0.75f,timeBetweenMove*1.25f);
        timeToMoveCounter = Random.Range(timeToMove*0.75f,timeBetweenMove*1.25f);

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
                //timeBetweenMoveCounter = timeBetweenMove;
                    timeBetweenMoveCounter = Random.Range(timeBetweenMove*0.75f,timeBetweenMove*1.25f);
            } 

        } else {
            timeBetweenMoveCounter -= Time.deltaTime;
            myRigidbody.velocity = Vector2.zero; // Vector2 = zeros anywhere around the world 
            
            if(timeBetweenMoveCounter < 0f) 
                {
                    moving = true;
    
                    timeToMoveCounter = Random.Range(timeToMove*0.75f,timeBetweenMove*1.25f);
                    //timeToMoveCounter = timeToMove;
                    moveDirection = new Vector3(Random.Range(-1f,1f)*moveSpeed,Random.Range(-1f,1f)*moveSpeed,0f);//picks a random number between 2 seconds

                }
        } 
        if(reloading)
        {
            waitToReload -= Time.deltaTime;
            if(waitToReload < 0)
                {
                    Application.LoadLevel(Application.loadedLevel);
                    thePlayer.SetActive(true); 
                }
        }
    }
    
    void OnCollisionEnter2D(Collision2D other){ //on collision with the enemy
        /*if(other.gameObject.name == "Player")
        {
            //Destroy (other.gameObject); // destroys player as soon as collision detected from enemoy
            other.gameObject.SetActive(false); //hides the player from the game
            reloading = true;
            thePlayer = other.gameObject;
        } */
    
    }    
}
