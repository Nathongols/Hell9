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

    public GameObject Create;
    public GameObject Create2;
    public GameObject Create3;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {   
        if (PauseMenu.isPaused == false){
            if (Input.GetKeyDown(KeyCode.Mouse0)){
                pos1 = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
                Time.timeScale = 0.5f;
            } else if (Input.GetKeyUp(KeyCode.Mouse0)){
                pos2 = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
                Time.timeScale = 1f;
                dist = Vector2.Distance(pos1, pos2);
                Debug.Log(dist);
                ang = Mathf.Atan2(pos2.y - pos1.y, pos2.x - pos1.x) * 180 / Mathf.PI;
                Quaternion target = Quaternion.Euler(0, 0, ang);
                GameObject Create = Instantiate(myPrefab, pos1, target);
                Destroy(Create, 1.5f);
                float Track = 0;
                for (float i = 0; i < dist * 10; i++){
                    GameObject Create2 = Instantiate(myPrefab,Vector3.Lerp(pos1, pos2, Track) , target);
                    Track += 0.025f;
                    Destroy(Create2, 1.5f);
                }
                GameObject Create3 = Instantiate(myPrefab, pos2, target);
                Destroy(Create3, 1.5f);
            }
        }
    }
}
