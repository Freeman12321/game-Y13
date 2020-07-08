using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Equipment", menuName = "Inventory/Equipment")]
public class equipment : item {

    public EquipmentSlots vEquipmentSlots; // holds the list for all places the player can equip an iten too.

    public int armourModifier = 0; // armour value of an item
    public int damageModifier = 0; // damage value of an item

    public override void Use()
    {
        // works but only items from the first inventory slot get equiped you can't equip through slots 2-20
        base.Use();
        equipmentManager.referenceInstance.Equip(this); // when an item is used from the inventory equip the item
        removeFromInventory(); 
    }
}
//debug put outside of class equipment
public enum EquipmentSlots { Head, Chest, Legs, Feet, Shield, Sword }; // creates a list of slots that you can equip e.g you can have only 1 helmet equipped at a time
