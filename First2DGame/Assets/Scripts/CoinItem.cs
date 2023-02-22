using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinItem : MonoBehaviour
{
    private int coinValue = 1;

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            Destroy(gameObject);
            GameController.instance.updateCoinsCount(coinValue);
        }
    }
}
