using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterStats : MonoBehaviour {
    public double maxHealth = 100; // create a max health of 100
    public double currentHealth {get; private set;} // get a health of the player  

    public stat damage; // get correct damage value from stat script
    public stat armour; // get correct armour value form stat script

    void Awake() {
        currentHealth = maxHealth; // set the current health to the max health
    }
    /* to test damage actually worked
    void Update() {
        if (Input.GetKeyDown(KeyCode.T)) { // when T is clicked
            TakeDamage(10); // take 10 damage
        }
    }*/

    public void TakeDamage(double damage) { // takes in a double of damage
        // debug damage -= armour.getValue(); // subtracts armour from damage
        // debug int damageMultiplier = armour.getValue()/100 + armour.getValue(); // armour value that would decrease damage the same percent of the remaining damage every decrease. 
        // debug int damageMultiplier = 100/100 + armour.getValue(); // armour value that will decrease damage the same percent of the remaining damage every decrease.
        double damageMultiplier = 100/(100 + armour.getValue()); // armour value that will decrease damage the same percent of the remaining damage every decrease.
        // damage = stat.getValue();
        damage *= damageMultiplier; // change the damage
        //damage = Mathf.Clamp(damage, 0, int.MaxValue);
        Debug.Log(transform.name + " takes " + damage + " damage.");
        //Debug.Log(armour.getValue()); // for testing
        currentHealth -= damage; // get the final damage value take it away from current health
        //debug heath can go below zero
        if (currentHealth <= 0) { // if current health is below zero
            Death(); // trigger the death of the character
        }
    }
    public virtual void Death() { // kill the character (overridable method)
        Debug.Log(transform.name + " has died."); 
    } 
}
