using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trampolineGen : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    public GameObject myPrefab;
    private Vector2 pos1;
    private Vector2 pos2;
    private float dist;
    private float ang;

    private float timer = 0.0f;
    private float coolDown = 1.5f;
    private float visualTime = 0.0f;
    private bool coolReady = true;
    private bool newPos1 = false;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if (timer > coolDown){
            coolReady = true;
        }

        if (Input.GetKeyDown(KeyCode.Space)){
            Time.timeScale = 0.25f;
        } else if (Input.GetKeyUp(KeyCode.Space)){
            Time.timeScale = 1f;
        }

        if (PauseMenu.isPaused == false){
            if (coolReady){
                if (Input.GetKeyDown(KeyCode.Mouse0) && (coolReady)){
                    newPos1 = true;
                    pos1 = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
                } else if (Input.GetKeyUp(KeyCode.Mouse0) && (coolReady) && (newPos1)){
                    pos2 = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
                    dist = Vector2.Distance(pos1, pos2);
                    Debug.Log(dist);
                    ang = Mathf.Atan2(pos2.y - pos1.y, pos2.x - pos1.x) * 180 / Mathf.PI;
                    Quaternion target = Quaternion.Euler(0, 0, ang);
                    GameObject Create = Instantiate(myPrefab, pos1, target);
                    Destroy(Create, 2f);
                    float Track = 0;
                    for (float i = 0; i < dist * 10; i++){
                        GameObject Create2 = Instantiate(myPrefab,Vector3.Lerp(pos1, pos2, Track) , target);
                        Track += 0.025f;
                        Destroy(Create2, 2f);
                    }
                    GameObject Create3 = Instantiate(myPrefab, pos2, target);
                    Destroy(Create3, 2f);
                    coolReady = false;
                    newPos1 = false;
                    timer = 0.0f;

                }
            }
        }
    }
}