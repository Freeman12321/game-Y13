using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerManager : MonoBehaviour {

    public static playerManager referenceInstance;

    void Awake() {
        referenceInstance = this;
    }

    public GameObject player;
}
