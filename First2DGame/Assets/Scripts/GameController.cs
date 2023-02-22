using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Text healthTxt;
    public Text coinsText;

    private int coins;

    public static GameController instance;

    //Awake is called first than Start(), VERY USEFUL
    void Awake()
    {
        //Like a constructor
        instance = this;
    }

    public void updateHeartCount(int value){
        healthTxt.text = "x " + value.ToString();
    }

    public void updateCoinsCount(int value){
        coins += value;
        coinsText.text = coins.ToString();
    }
}
