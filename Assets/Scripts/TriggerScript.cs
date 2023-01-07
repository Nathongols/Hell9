using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TriggerScript : MonoBehaviour
{
    public static bool isStep1 = true;
    public static bool isStep2 = false;
    public static bool isStep3 = false;
    // Update is called once per frame
    public GameObject triggerUI;
    public GameObject triggerUI2;
    public GameObject triggerUI3;

    // Update is called once per frame

    void Update()
    {
        if (isStep1){
            triggerUI.SetActive(true);
        } else{
            triggerUI.SetActive(false);
        }

        if (isStep2 == true){
            triggerUI2.SetActive(true);
            Debug.Log("okw");
        } else{
            triggerUI2.SetActive(false);
        }

        if (isStep3){
            triggerUI3.SetActive(true);
        } else{
            triggerUI3.SetActive(false);
        }
    }
}
