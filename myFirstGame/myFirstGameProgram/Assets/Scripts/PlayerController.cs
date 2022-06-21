using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour

{
    public float moveSpeed;
    public Rigidbody2D myRigidbody; //prevents player from bouncing against collision walls

    private Animator anim; 

    private bool playerMoving;
    public Vector2 lastMove;

    private static bool playerExists;
    
    private bool attacking; 
    public float attackTime;
    private float attackTimeCounter;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); // first time the scene starts
        myRigidbody = GetComponent<Rigidbody2D>();
        myRigidbody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
        {

        playerMoving = false;

        if(!attacking)
            {

        if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) /* f equals float */
            {
                myRigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal")*moveSpeed,myRigidbody.velocity.y);
                //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime,0f,0f)); //move player around the world 
                
                playerMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"),0f);
            }
        
         if(Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f) /* f equals float */
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x,Input.GetAxisRaw("Vertical")*moveSpeed);
                //transform.Translate(new Vector3(0f,Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime,0f)); /*x,y,z value*/
                
                playerMoving = true;
                lastMove = new Vector2(0f,Input.GetAxisRaw("Vertical"));
            }

        if(Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f) //prevenets bouncing against walls
            {
                myRigidbody.velocity = new Vector2(0f,myRigidbody.velocity.y);
            }
        if(Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
            {
                myRigidbody.velocity = new Vector2(myRigidbody.velocity.x,0f);
            }
        if(Input.GetKeyDown(KeyCode.J))
            {
            attackTimeCounter = attackTime;
            attacking = true;
            myRigidbody.velocity = Vector2.zero;
            anim.SetBool("Attack",true);
            }
            }
        
        

        if(attackTimeCounter > 0)
            {
                attackTimeCounter -= Time.deltaTime;
            }
        if(attackTimeCounter<= 0)
            {
                attacking = false;
                anim.SetBool("Attack",false);
            }

            anim.SetFloat("MoveX",Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("MoveY",Input.GetAxisRaw("Vertical"));
            anim.SetBool("PlayerMoving",playerMoving);
            anim.SetFloat("LastMoveX",lastMove.x);
            anim.SetFloat("LastMoveY",lastMove.y);   
    }
}
