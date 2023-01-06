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
    [SerializeField] private float strength;
    void Awake()
    {
        rb2d = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        lr = gameObject.GetComponent(typeof(LineRenderer)) as LineRenderer;
        dj2d = gameObject.GetComponent(typeof(DistanceJoint2D)) as DistanceJoint2D;
    }

    void Start() {
        dj2d.enabled = false;
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Trampoline"){
            gameObject.transform.rotation = other.gameObject.transform.rotation;
            rb2d.velocity = new Vector2(other.gameObject.transform.up.x * bounce, other.gameObject.transform.up.y * bounce);
        }
    }

    void Update()
    {
        bounce = strength*rb2d.velocity.magnitude;

        if (Input.GetKeyDown(KeyCode.Mouse1)){
            Vector2 mousePos = (Vector2)mainCamera.ScreenToWorldPoint(Input.mousePosition);
            lr.SetPosition(0,mousePos);
            lr.SetPosition(1, transform.position);
            dj2d.connectedAnchor = mousePos;
            dj2d.enabled = true;
            lr.enabled = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1)){
            dj2d.enabled = false;
            lr.enabled = false;
        }
        if (dj2d.enabled){
            lr.SetPosition(1, transform.position); 
        }
    }
}
