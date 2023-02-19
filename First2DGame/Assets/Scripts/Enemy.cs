using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float walkTime;

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

    void OnCollisionStay2D(){
        rig.gravityScale = 1f;
    }
    void OnCollisionExit2D(){
        rig.gravityScale = 21f;
    }

    public void Damage(int dmg){
        anim.SetTrigger("hit");
        health -= dmg;
        if(health <= 0){
            Destroy(gameObject);
        }
    }
}
