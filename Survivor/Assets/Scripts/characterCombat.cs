using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(characterStats))] // this class must utilise the character stats
public class characterCombat : MonoBehaviour {

    public float attackSpeed = 1f; // how quickly the character attacks
    public float attackCooldown = 0f; // the cooldown between each attack
<<<<<<< HEAD
=======

    characterStats CharactersStats; // reference character stats
>>>>>>> 4be645352fa7435b49f0624285de94fb540b56fb

    characterStats CharactersStats; // reference character stats
    Animator vAnimator;
    void Start() {
<<<<<<< HEAD
        vAnimator = GetComponent<Animator>(); // define animator
=======
>>>>>>> 4be645352fa7435b49f0624285de94fb540b56fb
        CharactersStats = GetComponent<characterStats>(); // define character stats
    }

    void Update() {
        attackCooldown -= Time.deltaTime; // decrease the time linearly by subtracting the amount of seconds in the previous frame every frame
<<<<<<< HEAD
        //vAnimator.SetBool("shooting", vShooting); // set the shooting animation to shooting (Debug) Not SetBool rather SetTrigger.
=======
>>>>>>> 4be645352fa7435b49f0624285de94fb540b56fb
    }

    public void Attack (characterStats stats) { // take in a characters stats 
        if (attackCooldown <= 0) { // if the attack is off cooldown so you can't attack infinite times   
            Debug.Log("Attacking" + transform.name);
            stats.TakeDamage(CharactersStats.damage.getValue()); // get the characters stats and subtract the correct amount of damage
            attackCooldown = 1f/attackSpeed; // reset the attack cooldown decrease if the attack speed is higher
<<<<<<< HEAD
            vAnimator.SetTrigger("shooting");
=======
>>>>>>> 4be645352fa7435b49f0624285de94fb540b56fb
        }
    }
}