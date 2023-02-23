using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject infoScreen;

    public void LoadGame(){
        SceneManager.LoadScene(1);
    }

    public void ShowInfo(){
        infoScreen.gameObject.SetActive(true);
    }

    public void CloseInfo(){
        infoScreen.gameObject.SetActive(false);
    }
}
