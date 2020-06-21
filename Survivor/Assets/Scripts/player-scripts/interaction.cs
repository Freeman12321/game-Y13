using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interaction : MonoBehaviour {

    public float radius = 7f; // create an interaction distance

    bool isFocused = false; // checks if we have a focus

    bool hasInteracted = false; // checks if we have interacted with the focus

    Transform player; // position of the player

    public virtual void Interact () {
        //Debug.Log("interacting with " + transform.name);
    }

    void Update() {
        if (isFocused && !hasInteracted) { // if we are moving to the target but have not entered interaction range
            //Debug.Log("Focused");
            isFocused = true; // we have a focus
            float distance = Vector3.Distance(player.position, transform.position); 
            if (distance <= radius) {
                //Debug.Log("Interact");
                Interact(); // interact with it: since interaction will be different individual scripts 
                hasInteracted = true; // we have an interaction
            }
        }
    }

    public void whenFocused (Transform playerTransform) {
        isFocused = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void Unfocused () {
        isFocused = false;
        player = null;
        hasInteracted = false;
    }

    void OnDrawGizmosSelected () {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
