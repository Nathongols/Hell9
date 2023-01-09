using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    public static bool winCheck = false;

    public GameObject winScreenUI;

    public static float highScore1 = float.PositiveInfinity;
    public static float highScore2 = float.PositiveInfinity;
    public static float highScore3 = float.PositiveInfinity;
    public static float highScore4 = float.PositiveInfinity;

    public Text endScore;

    public Text bestScore;
    // Update is called once per frame
    void Update()
    {
        if (winCheck){
            if (LevelSelector.selectedLevel == 0){
                if (TimerUI.timeScore < highScore1){
                    highScore1 = TimerUI.timeScore;
                    bestScore.text = "Personal Best: " + highScore1;
                } else{
                    bestScore.text = "Personal Best: " + highScore1;
                }
            } else if(LevelSelector.selectedLevel == 1){
                if (TimerUI.timeScore < highScore2){
                    highScore2 = TimerUI.timeScore;
                    bestScore.text = "Personal Best: " + highScore2;
                }else{
                    bestScore.text = "Personal Best: " + highScore2;
                }
            } else if(LevelSelector.selectedLevel == 2){
                if (TimerUI.timeScore < highScore3){
                    highScore3 = TimerUI.timeScore;
                    bestScore.text = "Personal Best: " + highScore3;
                }  else{
                    bestScore.text = "Personal Best: " + highScore3;
                }
            } else if(LevelSelector.selectedLevel == 3){
                if (TimerUI.timeScore < highScore4){
                    highScore4 = TimerUI.timeScore;
                    bestScore.text = "Personal Best: " + highScore4;
                }    else{
                    bestScore.text = "Personal Best: " + highScore4;
                }
            }
            winScreenUI.SetActive(true);
            PauseMenu.isPaused = true;
            endScore.text = "Final Time: " + TimerUI.timeScore.ToString("0.00");
            
            
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
        TimerUI.timeScore = 0.0f;
    }

    public void OpenNextScene(){
            PauseMenu.isPaused = false;
            SceneManager.LoadScene("LevelSelection");
            winCheck = false;
            Time.timeScale = 1f;
            TimerUI.timeScore = 0.0f;
        
    }
}
