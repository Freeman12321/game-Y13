using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class moveOnClick : MonoBehaviour {
    //private variables store the components from unity to use in scripts
    private Animator vAnimator;
    //debuging issue NavMashAgent = NavMeshAgent Missing asembly reference (using UnityEngine.AI) 
    private NavMeshAgent vNavMeshAgent;
    // Use this for initialization
    void Start() {
        vAnimator = GetComponent<Animator>();
        vNavMeshAgent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //RaycastHit clicked;
        //debugging  
        if (Input.GetMouseButtonDown(0)) {
            vNavMeshAgent.destination = point;
        }


    }
}
