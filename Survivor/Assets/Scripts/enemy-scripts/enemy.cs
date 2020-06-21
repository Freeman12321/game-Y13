using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(characterStats))]
public class enemy : interaction {
    playerManager vPlayer;
    characterStats stats;

    void Start() {
        stats = GetComponent<characterStats>();
        vPlayer = playerManager.referenceInstance;
    }
    // debuging trouble shooting 'Interact' not being called when attacking enemy is not present when interacting with enemy 
    // the if statement calling interact from "interaction" script is working 
    // Solution is enemy - enemyStats - enemyControler all have to be on the enemy hit box to function 
    public override void Interact() {
        //Debug.Log("attacking enemy");
        base.Interact();
        characterCombat playerCombat = vPlayer.player.GetComponent<characterCombat>();
        if (playerCombat != null) {
            playerCombat.Attack(stats);
        }
    }
}
