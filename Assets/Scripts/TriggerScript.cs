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
    public static bool isStep4 = false;
    public static bool isStep5 = false;
    // Update is called once per frame
    public GameObject triggerUI;
    public GameObject triggerUI2;
    public GameObject triggerUI3;
    public GameObject triggerUI4;
    public GameObject triggerUI5;

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

        if (isStep4){
            triggerUI4.SetActive(true);
        } else{
            triggerUI4.SetActive(false);
        }

        if (isStep5){
            triggerUI5.SetActive(true);
        } else{
            triggerUI5.SetActive(false);
        }
    }
}
