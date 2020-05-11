using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interaction : MonoBehaviour {

    public float radius;

    bool isFocused = false;

    bool hasInteracted = false;

    Transform player;

    public virtual void Interact () {
        Debug.Log("interacting with " + transform.name);
    }

    void Update()
    {
        if (isFocused && !hasInteracted) {
            Debug.Log("Focused");
            float distance = Vector3.Distance(player.position, transform.position); 
            if (distance <= radius) {
                Debug.Log("Interact");
                Interact();
                hasInteracted = true;
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

    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
