using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private int health = 3;
    public float speed;
    public float jumpForce;
    private float movement;
    private bool isJumping;
    private bool doubleJump;
    private bool isDashing;
    private bool isShooting;

    public GameObject arrow;
    public Transform bow;

    private Rigidbody2D rig;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        GameController.instance.UpdateHeartCount(health);
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Dash();
        Bow();
    }

    void FixedUpdate(){
        Move();
    }

    void Move(){
        //GetAxis right/left, A/D and joystick
        //float 0 to 1
        //Edit/Project Settings/Input Manager
        movement = Input.GetAxis("Horizontal");
        
        rig.velocity = new Vector2(movement * speed, rig.velocity.y);

        //Right
        if(movement > 0){
            if(isJumping == false && isShooting == false && isDashing == false){
                anim.SetInteger("transition",1);
            }
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }

        //Left
        if(movement < 0){
            if(isJumping == false && isShooting == false && isDashing == false){
                anim.SetInteger("transition",1);
            }
            transform.eulerAngles = new Vector3(0f,180f,0f);
        }

        //Idlle
        if(movement == 0 && isJumping == false && isShooting == false && isDashing == false){
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
                    rig.AddForce(new Vector2(0, jumpForce * 0.6f), ForceMode2D.Impulse);
                    doubleJump = false;
                }
            }
        }
    }

    void Dash(){
        StartCoroutine("DashCoroutine");
    }

    void Bow(){
        StartCoroutine("Shoot");
    }

    IEnumerator Shoot(){
        if(Input.GetKeyDown(KeyCode.E)){
            isShooting = true;
            anim.SetInteger("transition",3);
            GameObject Arrow = Instantiate(arrow,bow.position, bow.rotation);
            if(this.transform.rotation.y == 0f){
                Arrow.GetComponent<Arrow>().isRight = true;
            }
            else{
                Arrow.GetComponent<Arrow>().isRight = false;
            }
            yield return new WaitForSeconds(0.2f);
            isShooting = false;
            anim.SetInteger("transition",0);
        }
    }

    IEnumerator DashCoroutine(){
        if(Input.GetKeyDown(KeyCode.LeftShift) && isDashing == false){
            isDashing = true;
            anim.SetInteger("transition",4);
            if(this.transform.rotation.y == 0f){
                rig.AddForce(Vector2.right * 5000, ForceMode2D.Force);
            }else{
                rig.AddForce(Vector2.left * 5000, ForceMode2D.Force);
            }
            yield return new WaitForSeconds(0.35f);
            anim.SetInteger("transition",0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.layer == 8){
            isJumping = false;
            isDashing = false;
        }

        if(collision.gameObject.tag == "spike"){
            Damage(1);
        }
    }

    public void Damage(int dmg){
        health -= dmg;
        GameController.instance.UpdateHeartCount(health);
        anim.SetTrigger("hit");

        if(this.transform.rotation.y == 0f){
            rig.AddForce(Vector2.left * 3000, ForceMode2D.Force);
        }
        else{
            rig.AddForce(Vector2.right * 3000, ForceMode2D.Force);
        }

        if(health <= 0){
            GameController.instance.GameOver();
        }
    }

    public void Healing(int healingValue){
        health += healingValue;
        GameController.instance.UpdateHeartCount(health);
    }
}
