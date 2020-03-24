using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // debug vNav

public class playerController : MonoBehaviour {
    // private variables store the components from unity to use in scripts
    private Animator vAnimator; // Stores the animator tab in unity 
    // debuging issue NavMashAgent = NavMeshAgent Missing asembly reference (using UnityEngine.AI) 
    private NavMeshAgent vNavMeshAgent; // Stores the NavMeshAgent (Navigation)

    public interaction focus; // create a focus variable that occurs when we right click

    public Transform target;

    public bool vRunning = false;
    // Use this for initialization
    void Start() {
        vAnimator = GetComponent<Animator>();
        vNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update() {

        // debugging Raycast varaible 
        if (Input.GetMouseButtonDown(0)) {
            // create a ray
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit clicked;

            // if the ray connects with the world (NavMeshAgent)
            if (Physics.Raycast(ray, out clicked)) {
                Debug.Log("We hit " + clicked.collider.name + " " + clicked.point);
                // move to the point we clicked
                vNavMeshAgent.destination = clicked.point;
                // stop any interactions that are occuring
                removeFocus();
            }
        }
        if (Input.GetMouseButtonDown(1)) {
            Debug.Log("Interaction");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit clicked;
            if (Physics.Raycast(ray, out clicked)) {
                Debug.Log("We Interacted with " + clicked.collider.name);
                interaction interaction = clicked.collider.GetComponent<interaction>();
                if (interaction != null) {
                    setFocus(interaction);
                }
                if (vNavMeshAgent.remainingDistance <= interaction.radius) {//debug attempt to fix the character walking outside the radius
                    
                }
            }
            
        }
        if (target != null) {
            vNavMeshAgent.SetDestination(target.position);
            faceTarget();
        }
        // debugging > !>= 
        if (vNavMeshAgent.remainingDistance > vNavMeshAgent.stoppingDistance) {
            vRunning = true;
        }
        else {
            vRunning = false;
        }
        vAnimator.SetBool("running", vRunning);
    }

    void setFocus(interaction newFocus) {
        focus = newFocus;
        followTarget(newFocus);
    }
    void removeFocus() {
        focus = null;
        unFollowTarget();
    }
    void followTarget(interaction newTarget) {
        target = newTarget.transform;
        vNavMeshAgent.stoppingDistance = newTarget.radius;
        //vNavMeshAgent.updateRotation = false; // debug
    }
    void unFollowTarget() {
        target = null;
        //vNavMeshAgent.updateRotation = true; // debug
        vNavMeshAgent.stoppingDistance = 0f;
    }
    void faceTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f); // debug
    }
}
