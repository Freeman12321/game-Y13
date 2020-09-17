using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(characterStats))] // this script must be using the character stats component  
public class enemy : interaction {
    playerManager vPlayer; // store the player
    characterStats stats; // store the stats

    void Start() {
        stats = GetComponent<characterStats>(); // set stats to character stats
        vPlayer = playerManager.referenceInstance; // set player to the player
    }
    // debuging trouble shooting 'Interact' not being called when attacking enemy is not present when interacting with enemy 
    // the if statement calling interact from "interaction" script is working 
    // Solution is enemy - enemyStats - enemyControler scripts all have to be on the enemy hit box to function 
    public override void Interact() {
        //Debug.Log("attacking enemy");
        base.Interact();
        characterCombat playerCombat = vPlayer.player.GetComponent<characterCombat>(); // get the character combat if the player is close 
<<<<<<< HEAD
        if (playerCombat != null) { // if the character combat is true 
=======
        if (playerCombat != null) { // if the charactor combat is true 
>>>>>>> 4be645352fa7435b49f0624285de94fb540b56fb
            playerCombat.Attack(stats); // attack the player and take the player stats down by the same amount as the enemy stats
        }
    }
}
