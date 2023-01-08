using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class LineDraw : MonoBehaviour {
 public GameObject lineprefab;
 public GameObject currentLine;
 public LineRenderer linerenderer;
 public EdgeCollider2D edgeCollider;
 public List<Vector2> FingerPositions;

 void Update () {

if (PauseMenu.isPaused == false){
    if (trampolineGen.coolReady){
        if (Input.GetMouseButtonDown (0)) {
            Destroy(currentLine);
            CreateLine ();
        }

        if (Input.GetMouseButton (0)) {
        Vector2 temFingerPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
        if (Vector2.Distance (temFingerPos, FingerPositions [FingerPositions.Count - 1]) > .1f) {
            UpdateLine (temFingerPos);
        }
        }

        
    }
    if (Input.GetKeyUp(KeyCode.Mouse0)){
            Destroy(currentLine);
            //coolReady = false;
            //timer = 0.0f;
            }
    }
    }

 void CreateLine(){

  currentLine = Instantiate (lineprefab, Vector3.zero, Quaternion.identity);
  linerenderer = currentLine.GetComponent<LineRenderer> ();
  edgeCollider = currentLine.GetComponent<EdgeCollider2D> ();
  FingerPositions.Clear ();
  FingerPositions.Add (Camera.main.ScreenToWorldPoint (Input.mousePosition));
  FingerPositions.Add (Camera.main.ScreenToWorldPoint (Input.mousePosition));
  linerenderer.SetPosition (0, FingerPositions [0]);
  linerenderer.SetPosition (1, FingerPositions [1]);
  edgeCollider.points = FingerPositions.ToArray ();
 }

 void UpdateLine(Vector2 newFingerPos)
 {
  FingerPositions.Add (newFingerPos);
  linerenderer.positionCount++;
  linerenderer.SetPosition (linerenderer.positionCount - 1, newFingerPos);
 }

}