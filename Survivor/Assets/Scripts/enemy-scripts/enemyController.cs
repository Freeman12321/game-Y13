using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyController : MonoBehaviour {

    public float senseRange = 10f;
    public float attackRange = 3f;
    public bool vRunning = false;
    
    Transform target;
    NavMeshAgent vNavMeshAgent;
    characterCombat combat;
    Animator vAnimator;

    // Use this for initialization
    void Start () {
        // we don't want to manually reference the player, for each enemy, with the code, GameObject.FindGameObjectWithTag("Player");
        vNavMeshAgent = GetComponent<NavMeshAgent>();
        target = playerManager.referenceInstance.player.transform;
        combat = GetComponent<characterCombat>();
        vAnimator = GetComponent<Animator>();
	}
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= senseRange) {
            vRunning = true;
            vNavMeshAgent.SetDestination(target.position);
            if (distance <= vNavMeshAgent.stoppingDistance) {
                characterStats targetStats = target.GetComponent<characterStats>();
                if (targetStats != null) {
                    //Debug.Log("Attacking Player");
                    combat.Attack(targetStats);
                    vRunning = false;
                }
                faceTarget();
            }
            vAnimator.SetBool("running", vRunning);
        }
    }
    //debug tried to call public void face (playerController) target but the transforms for the player don't apply to the enemy
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
