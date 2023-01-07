using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotate : MonoBehaviour
{
    [SerializeField] private float strength;
    private void FixedUpdate() {
        transform.Rotate(0,0,0.1f*strength, Space.Self);
    }
}
