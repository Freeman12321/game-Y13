using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterStats : MonoBehaviour {
    public double maxHealth = 100;
    public double currentHealth {get; private set;}

    public stat damage;
    public stat armour;

    void Awake() {
        currentHealth = maxHealth;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            TakeDamage(10);
        }
    }

    public void TakeDamage(double damage) {
        // debug damage -= armour.getValue();
        // debug int damageMultiplier = armour.getValue()/100 + armour.getValue();
        // debug int damageMultiplier = 100/100 + armour.getValue();
        double damageMultiplier = 100/(100 + armour.getValue());
        // damage = stat.getValue();
        damage *= damageMultiplier;
        //damage = Mathf.Clamp(damage, 0, int.MaxValue);
        Debug.Log(transform.name + " takes " + damage + " damage.");
        //Debug.Log(armour.getValue());
        currentHealth -= damage;
        //debug heath can go below zero
        if (currentHealth <= 0) {
            Death();
        }
    }
    public virtual void Death() {
        Debug.Log(transform.name + " has died.");
    } 
}
