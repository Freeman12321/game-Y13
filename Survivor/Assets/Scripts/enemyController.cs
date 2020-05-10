﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyController : MonoBehaviour {

    public float senseRange = 10f;

    Transform target;
    NavMeshAgent vNavMeshAgent;
    // Use this for initialization
    void Start () {
        // we don't want to manually reference the player, for each enemy, with the code, GameObject.FindGameObjectWithTag("Player");
        vNavMeshAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {

    }
    public void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, senseRange);
    } 
}