using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Text healthTxt;
    public Text coinsText;

    private int coins;
    private int totalCoins;

    private bool isPaused;

    public static GameController instance;
    public GameObject pauseObj;

    //Awake is called first than Start(), VERY USEFUL
    void Awake()
    {
        //Like a constructor
        instance = this;
    }

    void Start(){
        totalCoins = PlayerPrefs.GetInt("score");
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape)){
            PauseGame();
        }
    }

    public void UpdateHeartCount(int value){
        healthTxt.text = "x " + value.ToString();
    }

    public void UpdateCoinsCount(int value){
        coins += value;
        coinsText.text = coins.ToString();

        PlayerPrefs.SetInt("score",coins + totalCoins);
    }

    public void PauseGame(){
        isPaused = !isPaused;
        pauseObj.SetActive(isPaused);
        if(isPaused){
            Time.timeScale = 0f;
        }else{
            Time.timeScale = 1f;
        }
        
    }
}
