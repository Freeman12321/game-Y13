using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//to use the foundational code from our original script "interaction" in this script "pickUpItem"
public class pickUpItem : interaction { // derive pickUpItem from interaction
    public item item; // refer to the item class
    public override void Interact() { 
        base.Interact();
        PickUpItem(); // when we interact with an item pick it up
    }
    void PickUpItem() {
        Debug.Log("Picking up item " + item.itemname);
        if (inventory.notEnoughSpace == false) { // if there is room in the inventory
            Destroy(gameObject); 
            //works but we want to make sure we can only interact when we are close
            inventory.referenceInstance.Add(item); // refer to inventory Add the item to the inventory
        }
    }
}
