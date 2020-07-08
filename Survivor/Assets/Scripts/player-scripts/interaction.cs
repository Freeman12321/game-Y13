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
            float distance = Vector3.Distance(player.position, transform.position); // create a distance between the player and the object of interaction
            if (distance <= radius) { // if the distance is within the range of the interaction 
                //Debug.Log("Interact");
                Interact(); // interact with it: since interaction will be different individual scripts we override this method in different scripts
                hasInteracted = true; // we have an interaction
            }
        }
    }

    public void whenFocused (Transform playerTransform) { // take in a transform
        isFocused = true; // we are forcused on an object
        player = playerTransform; // the position of the player is equal to the transform
        hasInteracted = false; // we have not yet interacted
    }

    public void Unfocused () {
        isFocused = false; // we are not focused on an object
        player = null; // there is no position to move to
        hasInteracted = false; // we have not interacted
    }

    void OnDrawGizmosSelected () { // make a gizmos
        Gizmos.color = Color.black; // make the colour black
        Gizmos.DrawWireSphere(transform.position, radius); // draw a wire sphere at the current position of the item in the scene editor make it radius long
    }
}
