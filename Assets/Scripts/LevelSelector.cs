using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{   
    public static int selectedLevel;
    public int level;
    public static int nextLevel;
    public Text levelText;
    // Start is called before the first frame update
    void Start()
    {
        levelText.text = "L E V E L  " + level.ToString();
    }

    public void OpenScene() {
        selectedLevel = level;
        nextLevel = level + 1;
        SceneManager.LoadScene("Level" + level.ToString());
        
    }

}
