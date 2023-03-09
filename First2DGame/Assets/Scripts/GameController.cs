using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public Text healthTxt;
    public Text coinsText;

    private int coins;
    private int totalCoins;

    private bool isPaused;
    private bool isMobile = true;

    public static GameController instance;
    public GameObject pauseObj;
    public GameObject gameOverObj;
    private GameObject touchControllers;

    private Player player;

    //Awake is called first than Start(), VERY USEFUL
    void Awake()
    {
        //Like a constructor
        instance = this;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.isMobile = isMobile;

        if(!isMobile){
            touchControllers = GameObject.FindGameObjectWithTag("touchController");
            touchControllers.SetActive(false);
        }
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

    public void GameOver(){
        gameOverObj.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart(){
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void ReturnMainMenu(){
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
