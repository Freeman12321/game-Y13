using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStats : characterStats {

    public GameObject hitbox; // reference the hitbox
    public GameObject enemy; // reference the enemy
    public healthBar vHealthbar;
    void Start() {
        vHealthbar = GetComponent<healthBar>();
    }
    public override void Death() {
        base.Death();
        Destroy(hitbox); 
        Destroy(enemy);
    }
}
