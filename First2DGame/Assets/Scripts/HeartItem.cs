using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartItem : MonoBehaviour
{
    private int healingValue = 1;

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            Destroy(gameObject);
            col.gameObject.GetComponent<Player>().Healing(healingValue);
        }
    }

}
