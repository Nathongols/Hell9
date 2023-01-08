using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    public static bool winCheck = false;

    public GameObject winScreenUI;

    // Update is called once per frame
    void Update()
    {
        if (winCheck){
            winScreenUI.SetActive(true);
            PauseMenu.isPaused = true;
        } else{
            winScreenUI.SetActive(false);
            PauseMenu.isPaused = false;
        }
    }

    public void Retry(){
        PauseMenu.isPaused = false;
        SceneManager.LoadScene("Level" + LevelSelector.selectedLevel.ToString());
        winCheck = false;
        Time.timeScale = 1f;
    }

    public void OpenNextScene(){
            PauseMenu.isPaused = false;
            SceneManager.LoadScene("LevelSelection");
            winCheck = false;
            Time.timeScale = 1f;
        
    }
}
