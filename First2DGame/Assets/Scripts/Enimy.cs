using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enimy : MonoBehaviour
{
    
    public float walkTime;

    private Rigidbody2D rig;
    private float speed = 2f;
    private float timer;
    private bool rightDir;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
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
    }

    void OnCollisionStay2D(){
        rig.gravityScale = 1f;
    }
    void OnCollisionExit2D(){
        rig.gravityScale = 21f;
    }
}
