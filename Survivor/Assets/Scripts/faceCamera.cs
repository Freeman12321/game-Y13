using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class faceCamera : MonoBehaviour {

    public Transform cam;

    void LateUpdate() {
        transform.LookAt(transform.position + cam.forward); // make the enemies' health bars always face the direction of the user or camera
    }
}
