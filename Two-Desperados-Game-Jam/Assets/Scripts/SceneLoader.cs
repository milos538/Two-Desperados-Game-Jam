using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour{
    public void playGame(){
        SceneManager.LoadScene("Room 1");
    }
    public void quitGame(){
        Application.Quit();
    }
}
