using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour {

    public static playerManager referenceInstance; // reference this class with playerManager.referenceInstance

    void Awake() {
        referenceInstance = this; // set the reference to this class
    }

    public GameObject player; // the player game object
}
