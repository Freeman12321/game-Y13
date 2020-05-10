using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class equipment : item {

    public EquipmentSlots vEquipmentSlots;

    public int armourModifier = 0;
    public int damageModifier = 0;

    public override void Use()
    {
        //works but only items from the first inventory slot get equiped you can't equip through slots 2-20
        base.Use();
        equipmentManager.referenceInstance.Equip(this);
        removeFromInventory();
    }
}
//debug put outside of class equipment
public enum EquipmentSlots { Head, Chest, Legs, Feet, Shield, Sword };
