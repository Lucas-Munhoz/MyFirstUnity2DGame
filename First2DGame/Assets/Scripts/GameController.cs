using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Text healthTxt;
    public static GameController instance;

    // Start is called before the first frame update
    void Start()
    {
        //Like a constructor
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateHeartCount(int value){
        healthTxt.text = "x " + value.ToString();
    }
}
