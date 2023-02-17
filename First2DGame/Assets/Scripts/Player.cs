using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    private bool isJumping;
    private bool doubleJump;
    private Rigidbody2D rig;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move(){
        //GetAxis right/left, A/D and joystick
        //float 0 to 1
        //Edit/Project Settings/Input Manager
        float movement = Input.GetAxis("Horizontal");
        
        rig.velocity = new Vector2(movement * speed, rig.velocity.y);

        //Right
        if(movement > 0){
            if(isJumping == false){
                anim.SetInteger("transition",1);
            }
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }

        //Left
        if(movement < 0){
            if(isJumping == false){
                anim.SetInteger("transition",1);
            }
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }

        //Idlle
        if(movement == 0 && isJumping == false){
            anim.SetInteger("transition",0);
        }
    }

    void Jump(){
        if(Input.GetButtonDown("Jump")){
            if(isJumping == false){
                anim.SetInteger("transition",2);
                rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                isJumping = true;
            }
            else{
                if(doubleJump == true){
                    anim.SetInteger("transition",2);
                    rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.layer == 8){
            isJumping = false;
        }
    }
}
