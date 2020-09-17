using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStats : characterStats {

    public GameObject hitbox; // reference the hitbox
    public GameObject enemy; // reference the enemy
<<<<<<< HEAD
    public healthBar vHealthbar;
    void Start() {
        vHealthbar = GetComponent<healthBar>();
    }
    public override void Death() {
        base.Death();
=======

    public override void Death() {
        base.Death();
        //ragdoll effect/death animation
        //loot
        //cutscene
            
>>>>>>> 4be645352fa7435b49f0624285de94fb540b56fb
        Destroy(hitbox); 
        Destroy(enemy);
    }
}
