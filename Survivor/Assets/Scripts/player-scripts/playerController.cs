using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.AI; // debug vNav - Needed for use of NavMesh Agent

public class playerController : MonoBehaviour {
    // private variables store the components from unity to use in scripts
    private Animator vAnimator; // Stores the animator tab in unity and allows us to change it here
    // debuging issue NavMashAgent = NavMeshAgent Missing asembly reference (using UnityEngine.AI) 
    private NavMeshAgent vNavMeshAgent; // Stores the NavMeshAgent (Navigation)

    public interaction focus; // create a focus variable that occurs when we right click a unity object with the interaction script on it

    public Transform target; // create a transform to follow the focus

    public bool vRunning = false; // is our character running in animations

    public GameObject bullet; // bullet the player will shoot

    // Use this for initialization
    void Start() {
        vAnimator = GetComponent<Animator>(); // create a variable where we can access the Animator
        vNavMeshAgent = GetComponent<NavMeshAgent>(); // create a variable where we can access the NavMeshAgent
    }

    // Update is called once per frame
    void Update() {
        if (EventSystem.current.IsPointerOverGameObject()) {
            return;
        } // if we click on the inventory don't continue interacting with the game behind it
        // debugging Raycast varaible 
        if (Input.GetMouseButtonDown(0)) { // if we left click
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // create a ray to the mouse position
            RaycastHit clicked; // if it hits assign value to clicked variable
            // if the ray connects with the world (NavMeshAgent)
            if (Physics.Raycast(ray, out clicked)) { // if the ray hits something
                //Debug.Log("We hit " + clicked.collider.name + " " + clicked.point);
                vNavMeshAgent.destination = clicked.point; // move to the point we clicked
                // debugging doesn't untarget after focus selected fixed by switching  focus.Unfocused(); and focus = null;
                removeFocus(); // stop any interactions that are occuring
            }
        }
        if (Input.GetMouseButtonDown(1)) { // if we right click
            //Debug.Log("Interaction");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // return a ray from the mouse position store in variable ray 
            RaycastHit clicked; // if it hits assign value to clicked variable
            if (Physics.Raycast(ray, out clicked)) { // if the ray hits something
                //Debug.Log("We Interacted with " + clicked.collider.name);
                interaction interaction = clicked.collider.GetComponent<interaction>(); // set interaction variable to what we clicked
                if (interaction != null) { // if we have an interaction on the object clicked
                    setFocus(interaction); // set the players focus that interaction
                }
            }

        }
        if (target != null) { // if we have a target
            vNavMeshAgent.SetDestination(target.position); // set the players destination to that target
            faceTarget(); // face the direction of the target
        }
        // debugging > !>= 
        if (vNavMeshAgent.remainingDistance > vNavMeshAgent.stoppingDistance) { // if there is distance to cover by the player
            vRunning = true; // play the running animation
        }
        else { // if not
            vRunning = false; // play the idol animation
        }
        vAnimator.SetBool("running", vRunning); // set the running animation to vRunning
    }

    void setFocus(interaction newFocus) { // take an interactable
        // debugging cant have multiple focuses at once 
        if (newFocus != focus) { // if the focus changes
            // debugging only want us to unfocus an object if we have an object to focus otherwise we cant interact with an object
            if (focus != null) { 
                focus.Unfocused(); // unfocus the old focus
            }
                focus = newFocus; // focus the new focus
                followTarget(newFocus); // move toward the new focus
        }
        newFocus.whenFocused(transform); // get the transform (position) of player give it to the interaction script
    }
    void removeFocus() {
        if (focus != null){ // if we have a focus
            focus.Unfocused(); // remove the transform, and focus from interaction (called from interaction)
        }
        focus = null; // remove focus from player
        unFollowTarget(); // stop moving towards targer
    }
    void followTarget(interaction newTarget) { // take an interaction of new target
        target = newTarget.transform; // move to the targets position
        vNavMeshAgent.stoppingDistance = newTarget.radius; // set the stopping distance to the radius in interaction
        //vNavMeshAgent.updateRotation = false; // debug
    }
    void unFollowTarget() {
            target = null; // stop following the interaction
        //vNavMeshAgent.updateRotation = true; // debug
        vNavMeshAgent.stoppingDistance = 0f; // no stopping distance (as there is no target)
    }
    void faceTarget() {
        Vector3 direction = (target.position - transform.position).normalized; // get direction from our position to the targets position
        Quaternion lookRotation = Quaternion.LookRotation(direction); // turn the direction into a rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f); // set the players to smoothly interpolate to the rotation
    }
}
