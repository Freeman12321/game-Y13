using UnityEngine;
using UnityEngine.UI;

public class itemSlot : MonoBehaviour {

    public Image icon; // store the icon of the item

    public Button removeButton; // store the button used to remove items

    item item; // store the item in the slot

    public void addItem(item newItem) {
        item = newItem; // update the item slot to the item that should be in it
        icon.sprite = item.icon; // change the graphics accordingly
        icon.enabled = true; // enable the icon
        removeButton.interactable = true; // enable the remove button
    }

    public void clearItem() {
        item = null; // remove item
        icon.sprite = null; // remove sprite
        icon.enabled = false; // remove graphics
        removeButton.interactable = false; // remove interactability
    }

    public void whenRemoveButtonPressed() {
        inventory.referenceInstance.Remove(item); // remove the item from inventory
    }
    public void useItem() {
        if (item != null) { // if we have an item
            item.Use(); // use the item
        }
    }
}
