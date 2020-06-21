using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerStats : characterStats {

    // Use this for initialization
    // debug += !=
    void Start() {
        equipmentManager.referenceInstance.onEquipmentChanged += OnEquipmentChanged;
    }

    void OnEquipmentChanged(equipment newItem, equipment oldItem) {
        if (newItem != null) {
            armour.addItemStats(newItem.armourModifier);
            damage.addItemStats(newItem.damageModifier);
        }
        if (oldItem != null) {
            armour.removeItemStats(oldItem.armourModifier);
            damage.removeItemStats(oldItem.damageModifier);
        }
    }
    public override void Death() {
        base.Death();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
