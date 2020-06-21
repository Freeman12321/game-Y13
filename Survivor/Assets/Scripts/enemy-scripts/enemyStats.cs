using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStats : characterStats {

    public GameObject player;
    public void destroySoldier() {
        Destroy(player.transform.parent.parent);
    }

    public override void Death() {
        base.Death();
        //ragdoll effect/death animation
        //loot
        //cutscene
        Destroy(gameObject);
        Destroy(player);
    }
}
