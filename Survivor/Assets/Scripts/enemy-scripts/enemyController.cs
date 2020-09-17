using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyController : MonoBehaviour {

    public float senseRange = 10f; // range enemy can sense the player
    public float attackRange = 3f; // range enemy can attack the player
    public bool vRunning = false; // running animation
    
    Transform target; // holds the target position
    NavMeshAgent vNavMeshAgent; // holds the navigation agent
    characterCombat combat; // triggers combat
    Animator vAnimator; // references animation

    // Use this for initialization
    void Start () {
        // we don't want to manually reference the player, for each enemy, with the code, GameObject.FindGameObjectWithTag("Player");
        vNavMeshAgent = GetComponent<NavMeshAgent>(); // retrieves the navigation agent
        target = playerManager.referenceInstance.player.transform; // retrieves the players position
        combat = GetComponent<characterCombat>(); // retrieves combat triggers
        vAnimator = GetComponent<Animator>(); //  retrieves the animator
	}
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(target.position, transform.position); // holds the distance between the enemy and the player
<<<<<<< HEAD
        if (distance <= senseRange) { // if this distance is within the enemy's sense range
=======
        if (distance <= senseRange) { // if this distance is within the enemys sense range
>>>>>>> 4be645352fa7435b49f0624285de94fb540b56fb
            vRunning = true; // trigger running animation
            vNavMeshAgent.SetDestination(target.position); // navigate towards the player
            if (distance <= vNavMeshAgent.stoppingDistance) { // if the distance between the enemy and player 
                characterStats targetStats = target.GetComponent<characterStats>(); // set the stats that the enemy attacks to player stats
                if (targetStats != null) { // if there is a target stats 
                    //Debug.Log("Attacking Player");
                    combat.Attack(targetStats); // attack the stats 
                    vRunning = false; // stop running
                }
<<<<<<< HEAD
                FaceTarget(); // while shooting face the direction of the target
=======
                faceTarget(); // while shooting face the direction of the target
>>>>>>> 4be645352fa7435b49f0624285de94fb540b56fb
            }
            vAnimator.SetBool("running", vRunning); // set the running animation 
        }
    }
    //debug tried to call public void face (playerController) target but the transforms for the player don't apply to the enemy
<<<<<<< HEAD
    void FaceTarget() { // see playerController 
=======
    void faceTarget() { // see playerController 
>>>>>>> 4be645352fa7435b49f0624285de94fb540b56fb
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f); // debug
    }
    public void OnDrawGizmosSelected() { // draw a wire sphere in the inspector when enemy selected Does not affect game play and is just easier for debugging
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, senseRange);
    } 
}
