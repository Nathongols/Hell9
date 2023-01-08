using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public static bool isPaused2 = false;
    public static bool isDead = false;
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

        if (isPaused2){
            Pause();
        } else if (isPaused2 = false && (isPaused == false) && (isDead = true)){
            Resume();
        }

        if (WinScreen.winCheck){
            Pause();
        } else{
            //Resume();
        }
    }
    public void Resume(){
        if (isDead){
            pauseMenuUI.SetActive(false);
            PauseMenu.isPaused2 = false;
            PlayerPhysics.trig = 0;
            isDead = false;
            TimerUI.timeScore = 0.0f;
            SceneManager.LoadScene("Level" + LevelSelector.selectedLevel);
        }
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause(){
        if (!WinScreen.winCheck){
        pauseMenuUI.SetActive(true);
        }
        if (isDead){
            Time.timeScale = 0f;
        } else{
            Time.timeScale = 0f;
            isPaused = true;
        }
    }

    public void LoadMenu(){
        isDead = false;
        pauseMenuUI.SetActive(false);
        PauseMenu.isPaused2 = false;
        PlayerPhysics.trig = 0;
        TimerUI.timeScore = 0.0f;
        SceneManager.LoadScene("LevelSelection");
        Resume();
    }

    public void QuitGame(){
        Application.Quit();
    }
}
