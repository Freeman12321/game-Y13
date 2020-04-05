using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//to use the foundational code from our original script "interaction" in this script "pickUpItem"
public class pickUpItem : interaction {
    public item item;
    public override void Interact() {
        base.Interact();
        fpickUpItem();
    }
    void fpickUpItem() {
        Debug.Log("Picking up item " + item.itemname);
        if (inventory.notEnoughSpace == false) {
            Destroy(gameObject); //works but we want to make sure we can only interact when we are close
            inventory.referenceInstance.Add(item);
        }
    }
}
