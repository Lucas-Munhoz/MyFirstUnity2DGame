using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float walkTime;
    public int damage = 1;

    private Rigidbody2D rig;
    private Animator anim;
    private float speed = 2f;
    private float timer;
    private bool rightDir;
    private int health = 100;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if(timer >= walkTime){
            rightDir = !rightDir;
            timer = 0f;
        }
        if(rightDir){
            rig.velocity = Vector2.right * speed;
            transform.eulerAngles = new Vector2(0f,180f);
        }
        else{
            rig.velocity = Vector2.left * speed;
            transform.eulerAngles = new Vector2(0f,0f);
        }

        if(health <= 0){
            anim.SetTrigger("hit");
            Destroy(gameObject);
        }
    }

    void OnCollisionStay2D(Collision2D col){
        if(col.gameObject.tag == "Ground"){
            rig.gravityScale = 1f;
        }
        
    }
    void OnCollisionExit2D(Collision2D col){
        if(col.gameObject.tag == "Ground"){
            rig.gravityScale = 20f;
        }
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Player"){
            col.gameObject.GetComponent<Player>().Damage(damage);
            if(col.gameObject.GetComponent<Player>().transform.rotation.y == 0f){
                rig.AddForce(Vector2.right * 3000, ForceMode2D.Force);
            }
            if(col.gameObject.GetComponent<Player>().transform.rotation.y == 180f){
                rig.AddForce(Vector2.left * 3000, ForceMode2D.Force);
            }
        }
    }

    public void Damage(int dmg){
        anim.SetTrigger("hit");
        health -= dmg;
        if(health <= 0){
            Destroy(gameObject);
        }
    }
}
