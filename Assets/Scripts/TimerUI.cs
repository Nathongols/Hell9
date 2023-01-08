using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    public static bool timerActive = false;

    public static float timeScore = 0;
    public Text timerText;
    // Start is called before the first frame update
    void Start()
    {
        trampolineGen.isSlowed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive && trampolineGen.isSlowed){
            timeScore += Time.deltaTime*4;
            timerText.text = "" + timeScore.ToString("0.00");
        }
        else if (timerActive){
            timeScore += Time.deltaTime;
            timerText.text = "" + timeScore.ToString("0.00");
        }
    }
}
