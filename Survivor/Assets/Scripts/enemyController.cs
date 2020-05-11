using System.Collections;
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
        target = playerManager.referenceInstance.player.transform;
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= senseRange) {
            vNavMeshAgent.SetDestination(target.position);
            if (distance <= vNavMeshAgent.stoppingDistance) {
                faceTarget();
            }
        }
    }
    void faceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f); // debug
    }
    public void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, senseRange);
    } 
}
