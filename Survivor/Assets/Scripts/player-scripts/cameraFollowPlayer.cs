﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//debugging: Worked but player no longer followed the mouse button (calling player by public variable)
//debugging 2: Worked but camera did not rotate to face the player despite it snapping to the correct transform (position)
public class cameraFollowPlayer : MonoBehaviour {

    public Transform player; // holds players poition

    public Vector3 offset; // holds distance off camera from player
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
    //debugging didnt snap to position and rotation didnt translate from scene to game.  
	void Update () {
        transform.position = player.position + offset; // snap the camera to the player keeping some distance away
	}
}
