using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerStats : characterStats {

	// Use this for initialization
	void Start () {
        equipmentManager.referenceInstance.onEquipmentChanged = OnEquipmentChanged;
	}

    void OnEquipmentChanged(equipment newItem, equipment oldItem)
    {
        if (newItem != null) {
            armour.addItemStats(newItem.armourModifier);
            damage.addItemStats(newItem.damageModifier);
        }
        if (oldItem != null) {
            armour.addItemStats(newItem.armourModifier);
            damage.addItemStats(newItem.damageModifier);
        }
    }
}
