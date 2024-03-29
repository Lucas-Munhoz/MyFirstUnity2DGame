using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    private Rigidbody2D rig;
    private float speed = 10f;
    public bool isRight;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isRight){
            rig.velocity = Vector2.right * speed;
        }
        else{
            rig.velocity = Vector2.left * speed;
        }
        
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "enemy"){
            col.GetComponent<Enemy>().Damage(damage);
            Destroy(gameObject);
        }
        if(col.gameObject.tag == "treasure"){
            col.GetComponent<Treasure>().Damage(damage);
            Destroy(gameObject);
        }
    }
}
