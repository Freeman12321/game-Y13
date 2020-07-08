using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerStats : characterStats {

    // Use this for initialization
    // debug += !=
    void Start() {
        equipmentManager.referenceInstance.onEquipmentChanged += OnEquipmentChanged; // take the function from equipment manager that modifies the players stats based on the player equipment
    }

    void OnEquipmentChanged(equipment newItem, equipment oldItem) { // when the equipment is changed get 
        if (newItem != null) { // if there is a new item
            armour.addItemStats(newItem.armourModifier); // add the new item's armour
            damage.addItemStats(newItem.damageModifier); // add the new item's damage
        }
        if (oldItem != null) { // if there is an old item
            armour.removeItemStats(oldItem.armourModifier); // remove the old item's armour
            damage.removeItemStats(oldItem.damageModifier); // remove the old item's damage
        }
    }
    public override void Death() { // when the player dies
        base.Death();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // reload the scene
    }
}
