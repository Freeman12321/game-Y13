using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStats : characterStats {

    public GameObject hitbox; // reference the hitbox
    public GameObject enemy; // reference the enemy

    public override void Death() {
        base.Death();
        //ragdoll effect/death animation
        //loot
        //cutscene
            
        Destroy(hitbox); 
        Destroy(enemy);
    }
}
