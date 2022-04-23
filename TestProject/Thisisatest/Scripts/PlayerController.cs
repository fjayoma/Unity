using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour

{
    public float moveSpeed;
    //public Rigidbody2D rb; //prevents player from bouncing against collision walls

    private Animator anim; 

    private bool playerMoving;
    private Vector2 lastMove;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>(); // first time the scene starts


    }

    // Update is called once per frame
    void Update(){



        if(Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f) /* f equals float */
            {
                transform.Translate (new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime,0f,0f));
                playerMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"),0f);
            }
        
         if(Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f) /* f equals float */
            {
                transform.Translate (new Vector3(0f,Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime,0f)); /*x,y,z value*/
                playerMoving = true;
                lastMove = new Vector2(0f,Input.GetAxisRaw("Vertical"));
            }

            anim.SetFloat("MoveX",Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("MoveY",Input.GetAxisRaw("Vertical"));
            anim.SetBool("PlayerMoving",playerMoving);
            anim.SetFloat("LastMoveX",lastMove.x);
            anim.SetFloat("LastMoveY",lastMove.y);
    }
}
