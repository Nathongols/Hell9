using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerPhysics : MonoBehaviour
{
    private Rigidbody2D rb2d = new Rigidbody2D();
    [SerializeField] private Camera mainCamera;
    private LineRenderer lr = new LineRenderer();
    private DistanceJoint2D dj2d = new DistanceJoint2D();
    private float bounce;
    public static int trig = 0;
    private float timer = 0.0f;
    private float coolDown = 0.1f;
    private bool grapple = false;

    [SerializeField] private GameObject startUI;
    private bool isReady = false;

    [SerializeField] private float strength;
    void Awake()
    {
        rb2d = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        lr = gameObject.GetComponent(typeof(LineRenderer)) as LineRenderer;
        dj2d = gameObject.GetComponent(typeof(DistanceJoint2D)) as DistanceJoint2D;
    }

    void Start() {
        dj2d.enabled = false;
        lr.enabled = false;
    }

    //--------------------Collission -------------------------------------------
    private void OnCollisionEnter2D(Collision2D other) {
        if (timer > coolDown){
        if(other.gameObject.tag == "Trampoline"){
            timer = 0.0f;
            if (other.gameObject.transform.localEulerAngles.z <= 90f || other.gameObject.transform.localEulerAngles.z >= 270f){
                rb2d.AddRelativeForce(new Vector2(other.gameObject.transform.up.x * bounce *0.6f, other.gameObject.transform.up.y * bounce *0.6f), ForceMode2D.Impulse);
            }
            else {
                rb2d.AddRelativeForce(new Vector2(-other.gameObject.transform.up.x * bounce*0.6f, -other.gameObject.transform.up.y * bounce*0.6f), ForceMode2D.Impulse);
            }
        }
        }
        if(other.gameObject.tag == "Spike"){
            TimerUI.timerActive = false;
            PauseMenu.isPaused2 = true;
            PauseMenu.isDead = true;
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Boost"){
            if (other.gameObject.transform.localEulerAngles.z <= 90f || other.gameObject.transform.localEulerAngles.z >= 270f){
                rb2d.AddRelativeForce(new Vector2(other.gameObject.transform.right.x * 0.3f * bounce, other.gameObject.transform.up.y * 0.3f * bounce), ForceMode2D.Impulse);
                
            }
            else {
                rb2d.AddRelativeForce(new Vector2(-other.gameObject.transform.right.x * 0.3f * bounce, -other.gameObject.transform.up.y * 0.3f * bounce), ForceMode2D.Impulse);
            }

        }

        if(other.gameObject.tag == "Trigger"){
            if (trig == 0){
                TriggerScript.isStep1 = false;
                TriggerScript.isStep2 = true;
                TriggerScript.isStep3 = false;
                TriggerScript.isStep4 = false;
                TriggerScript.isStep5 = false;
                trig += 1;
            } else if (trig == 1){
                TriggerScript.isStep2 = false;
                TriggerScript.isStep3 = true;
                trig += 1;
            } else if (trig == 2){
                TriggerScript.isStep3 = false;
                TriggerScript.isStep4 = true;
                trig += 1;
            } else if (trig == 3){
                TriggerScript.isStep4 = false;
                TriggerScript.isStep5 = true;
                trig += 1;
            }
        }

        if (other.gameObject.tag == "Success"){
            WinScreen.winCheck = true;
        }
    }
    private void FixedUpdate() {
        if (rb2d.velocity.magnitude <= 15){
            bounce = strength*rb2d.velocity.magnitude;
        } else{
            bounce = rb2d.velocity.magnitude;
        }
        
    }


    //--------------------Grappling Hook ---------------------------------------
    void Update()
    {   

        timer += Time.deltaTime;
        if (PauseMenu.isPaused == false){
            if (isReady){
                if (Input.GetKeyDown(KeyCode.Mouse1) && isReady){
                    Debug.Log("ok");
                    RaycastHit2D _hit = SetGrapplePoint();
                    Vector2 grapplePos = _hit.point;
                    if (_hit.transform.tag == "Wall" /*&& grapple */){
                        if (rb2d.velocity.magnitude == 0){ // stuck fail safe?
                            lr.SetPosition(0, grapplePos);
                            lr.SetPosition(1, transform.position);
                            lr.enabled = true;
                            rb2d.velocity = new Vector2(0,0);
                            Vector2 dashDir = _hit.point - (Vector2)transform.position;
                            rb2d.AddForce(dashDir.normalized*8, ForceMode2D.Impulse);
                        } else{
                            lr.SetPosition(0, grapplePos);
                            lr.SetPosition(1, transform.position);
                            dj2d.connectedAnchor = grapplePos;
                            dj2d.enabled = true;
                            lr.enabled = true;
                        }
                    }
                    if (_hit.transform.tag == "Enemy" /*&& grapple */){
                        lr.SetPosition(0, grapplePos);
                        lr.SetPosition(1, transform.position);
                        lr.enabled = true;
                        rb2d.velocity = new Vector2(0,0);
                        Vector2 dashDir = _hit.point - (Vector2)transform.position;
                        rb2d.AddForce(dashDir.normalized*20, ForceMode2D.Impulse);
                    }
                }
                else if (Input.GetKeyUp(KeyCode.Mouse1) && isReady){
                    dj2d.enabled = false;
                    lr.enabled = false;
                    rb2d.gravityScale = 1f;
                }
                lr.SetPosition(1, transform.position);
                
            } else if (Input.GetKeyDown(KeyCode.Mouse1)){
                    
                    startUI.SetActive(false);
                    TimerUI.timerActive = true;
                    isReady = true;
                    Time.timeScale = 1.0f;
                
        } else if (Input.GetKeyDown(KeyCode.Mouse0) ){
                    startUI.SetActive(false);
                    TimerUI.timerActive = true;
                    isReady = true;
                    Time.timeScale = 1.0f;
        } else{
            startUI.SetActive(true);
            Time.timeScale = 0.0f;
        } 
    }
        
        
}

    RaycastHit2D SetGrapplePoint()
    {
        Vector2 distanceVector = mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //Debug.Log(distanceVector);
        //if (distanceVector.y < 6){ y distance is weird for some reason, not working
        //grapple = true;
        RaycastHit2D hitGround = Physics2D.Raycast(transform.position, distanceVector.normalized);
        return hitGround;
        //} else {
           // grapple = false;
            //return new RaycastHit2D();
        //};

    }
}
