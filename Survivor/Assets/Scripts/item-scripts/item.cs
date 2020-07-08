using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")] // create a menu in the assets that can create an item in the inspector
public class item : ScriptableObject { // the script does not sit on a game object thus derives from scriptable object
    public string itemname = "New Item"; // default name for item
    public Sprite icon = null; // store a sprite for the icon
    public bool isDefaultItem = false; // will the character inherit the item at the start of the game

    public virtual void Use() { // create a method that will trigger when an item is used appropritately
        Debug.Log("Using " + name); 
    }
    public void removeFromInventory() { // create a method to remove inventory 
        inventory.referenceInstance.Remove(this); // refer to inventory and remove this item
    }
}
