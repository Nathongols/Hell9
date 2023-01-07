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
            } else if (Input.GetKeyUp(KeyCode.Mouse0)){
                pos2 = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
                dist = Vector2.Distance(pos1, pos2);
                ang = Mathf.Atan2(pos2.y - pos1.y, pos2.x - pos1.x) * 180 / Mathf.PI;
                Debug.Log(ang);
                Quaternion target = Quaternion.Euler(0, 0, ang);
                Instantiate(myPrefab, pos1, target);
                myPrefab.transform.localScale = new Vector2(dist, myPrefab.transform.localScale.y);

            }
        }
    }
}
