using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    // Update is called once per frame
    public GameObject pauseMenuUI;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !(WinScreen.winCheck)){
            if (isPaused){
                Resume();
            } else {
                Pause();
            }
        }

        if (WinScreen.winCheck){
            Pause();
        } else{
            //Resume();
        }
    }
    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause(){
        if (!WinScreen.winCheck){
        pauseMenuUI.SetActive(true);
        }
        Debug.Log("yep?");
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void LoadMenu(){
        Debug.Log("ok");
        
        SceneManager.LoadScene("LevelSelection");
        Resume();
    }

    public void QuitGame(){
        Debug.Log("QUIT");
    }
}
