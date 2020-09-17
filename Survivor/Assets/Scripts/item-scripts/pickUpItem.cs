using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//to use the foundational code from our original script "interaction" in this script "pickUpItem"
public class pickUpItem : interaction { // derive pickUpItem from interaction
    public item item; // refer to the item class
    public override void Interact() { 
        base.Interact();
<<<<<<< HEAD
        PickUpItem(); // when we interact with an item pick it up
=======
        fPickUpItem(); // when we interact with an item pick it up
>>>>>>> 4be645352fa7435b49f0624285de94fb540b56fb
    }
    void PickUpItem() {
        Debug.Log("Picking up item " + item.itemname);
<<<<<<< HEAD
        if (inventory.notEnoughSpace == false) { // if there is room in the inventory
=======
        if (inventory.notEnoughSpace == false) {
>>>>>>> 4be645352fa7435b49f0624285de94fb540b56fb
            Destroy(gameObject); 
            //works but we want to make sure we can only interact when we are close
            inventory.referenceInstance.Add(item); // refer to inventory Add the item to the inventory
        }
    }
}
