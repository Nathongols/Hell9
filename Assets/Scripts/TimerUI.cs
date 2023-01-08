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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive){
            timeScore += Time.deltaTime;
            timerText.text = "" + timeScore.ToString("0.00");
        }
    }
}
