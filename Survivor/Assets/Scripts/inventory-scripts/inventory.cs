using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour {

    public static inventory referenceInstance; // creates a reference of this class that can be used in other clases inventory.referenceInstance 

    public int space = 20; // max inventory items

    public static bool notEnoughSpace = false; // does the inventory have room

    public delegate void OnItemChanged(); // define the delegate type

    public OnItemChanged onItemChangedCallBack; // when ever something changes in our this will be called

    void Awake() {
        if (referenceInstance != null) {
            Debug.LogWarning("More than one instance of inventory found!"); // we should not have a reference instance at this point
        }
        referenceInstance = this; // assigns reference instance to this class
    }
    public List<item> items = new List<item>(); // Create a public list of items 

    public void Add(item Item) { // add an item
        if (!Item.isDefaultItem) { // if the item is not a default item
            if (items.Count >= space) { // if there are too many items
                Debug.Log("Not enough room for " + Item.itemname);
                notEnoughSpace = true; // there is not enough space
                return; // don't add the item into the inventory
            }
            items.Add(Item); // add the item to the list of items
            notEnoughSpace = false; // there is enough space
            if (onItemChangedCallBack != null) { // when there is a change (add) in the items
                onItemChangedCallBack.Invoke(); // apply the necessary changes to the items
            }
        }
    }

    public void Remove(item Item) {
        items.Remove(Item); // remove item from the inventory
        if (onItemChangedCallBack != null) { // when there is a change (remove) in the items
            onItemChangedCallBack.Invoke(); // apply the necessary changes to the items
        }
    }
}
