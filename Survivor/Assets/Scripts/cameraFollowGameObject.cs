using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowGameObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    [SerializeField] Transform target;
    // Update is called once per frame
    void Update () {
		 
 

     transform.position = new Vector3(target.position.x, transform.position.y, target.position.z); 
 
	}
}
