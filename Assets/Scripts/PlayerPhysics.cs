using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    private Rigidbody2D rb2d = new Rigidbody2D();
    [SerializeField] private Camera mainCamera;
    private LineRenderer lr = new LineRenderer();
    private DistanceJoint2D dj2d = new DistanceJoint2D();
    private float bounce;
    private int trig = 0;
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
        if(other.gameObject.tag == "Trampoline"){
            if (other.gameObject.transform.localEulerAngles.z <= 90f || other.gameObject.transform.localEulerAngles.z >= 270f){
                rb2d.AddForce(new Vector2(other.gameObject.transform.up.x * bounce *0.6f, other.gameObject.transform.up.y * bounce *0.6f), ForceMode2D.Impulse);
            }
            else {
                rb2d.AddForce(new Vector2(-other.gameObject.transform.up.x * bounce*0.6f, -other.gameObject.transform.up.y * bounce*0.6f), ForceMode2D.Impulse);
            }
        }
        if(other.gameObject.tag == "Spike"){
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Trampoline"){
            if (other.gameObject.transform.localEulerAngles.z <= 90f || other.gameObject.transform.localEulerAngles.z >= 270f){
                rb2d.AddForce(new Vector2(other.gameObject.transform.up.x * bounce*other.gameObject.transform.localScale.z, other.gameObject.transform.up.y * bounce*other.gameObject.transform.localScale.z), ForceMode2D.Impulse);
            }
            else {
                rb2d.AddForce(new Vector2(-other.gameObject.transform.up.x * bounce, -other.gameObject.transform.up.y * bounce), ForceMode2D.Impulse);
            }
        }

        if(other.gameObject.tag == "Trigger"){
            if (trig == 0){
                Debug.Log("one");
                TriggerScript.isStep1 = false;
                TriggerScript.isStep2 = true;
                trig += 1;
            } else if (trig == 1){
                TriggerScript.isStep2 = false;
                TriggerScript.isStep3 = true;
                trig += 1;
            } 
        }
    }
    private void FixedUpdate() {
        bounce = strength*rb2d.velocity.magnitude;
    }

    //--------------------Grappling Hook ---------------------------------------

    void Update()
    {   
        if (PauseMenu.isPaused == false){
            if (Input.GetKeyDown(KeyCode.Mouse1)){
                RaycastHit2D _hit = SetGrapplePoint();
                Vector2 grapplePos = _hit.point;
                if (_hit.transform.tag == "Wall"){
                    lr.SetPosition(0, grapplePos);
                    lr.SetPosition(1, transform.position);
                    dj2d.connectedAnchor = grapplePos;
                    dj2d.enabled = true;
                    lr.enabled = true;
                }
                if (_hit.transform.tag == "Enemy"){
                    lr.SetPosition(0, grapplePos);
                    lr.SetPosition(1, transform.position);
                    lr.enabled = true;
                    rb2d.velocity = new Vector2(0,0);
                    Vector2 dashDir = _hit.point - (Vector2)transform.position;
                    rb2d.AddForce(dashDir.normalized*20, ForceMode2D.Impulse);
                }
                
            }
            else if (Input.GetKeyUp(KeyCode.Mouse1)){
                dj2d.enabled = false;
                lr.enabled = false;
                rb2d.gravityScale = 1f;
            }
            lr.SetPosition(1, transform.position); 
        }
    }

    RaycastHit2D SetGrapplePoint()
    {
        Vector2 distanceVector = mainCamera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        RaycastHit2D hitGround = Physics2D.Raycast(transform.position, distanceVector.normalized);
        return hitGround;
    }
}
