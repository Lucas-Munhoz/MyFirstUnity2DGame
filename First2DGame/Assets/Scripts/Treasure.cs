using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    private int health = 100;
    private Animator anim;

    void Start(){
        anim = GetComponent<Animator>();
    }

    public void Damage(int dmg){
        anim.SetTrigger("hit");
        health -= dmg;
        if(health <= 0){
            GameController.instance.UpdateCoinsCount(10);
            Destroy(gameObject);
        }
    }
}
