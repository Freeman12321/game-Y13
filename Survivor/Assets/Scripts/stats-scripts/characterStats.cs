using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterStats : MonoBehaviour {
    public int maxHealth = 100; // create a max health of 100
    // debug: public stat maxHealth;
    public int currentHealth {get; private set;} // get a health of the player 
    public stat damage; // get correct damage value from stat script
    public stat armour; // get correct armour value form stat script
        
    void Awake() {
        currentHealth = maxHealth; // set the current health to the max health at the start of the game
    }
    public healthBar vHealthBar; // refence the health bar script
    void Start() {
        vHealthBar = GetComponent<healthBar>(); // define the health bar script
        vHealthBar.SetMaxHealth(maxHealth); // set healthbar to the maximum 
    }
    void Update() {
        /*if (Input.GetKeyDown(KeyCode.T)) { // when T is clicked
            TakeDamage(10); // take 10 damage
        }*/
        vHealthBar.SetCurrentHealth(currentHealth); // set healthbar to the current level of health
    }

    public void TakeDamage(int damage) { // takes in a int of damage
        damage -= armour.getValue(); // subtracts armour from damage
        // debug int damageMultiplier = armour.getValue()/100 + armour.getValue(); // armour value that would decrease damage the same percent of the remaining damage every decrease. 
        // debug int damageMultiplier = 100/100 + armour.getValue(); // armour value that will decrease damage the same percent of the remaining damage every decrease.
        // int damageMultiplier = 100/(100 + armour.getValue()); // armour value that will decrease damage the same percent of the remaining damage every decrease.
        // damage *= damageMultiplier; // change the damage
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        Debug.Log(transform.name + " takes " + damage + " damage.");
        //Debug.Log(armour.getValue()); // for testing
        currentHealth -= damage; // get the final damage value take it away from current health
        // debug heath can go below zero
        if (currentHealth <= 0) { // if current health is below zero
            Death(); // trigger the death of the character
        }
    
    }
    public virtual void Death() { // kill the character (overridable method)
        Debug.Log(transform.name + " has died."); 
    } 
}
