using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStats : characterStats {

    public override void Death() {
        base.Death();
        //ragdoll effect/death animation
        //loot
        //cutscene
        Destroy(gameObject); 
    }
}
