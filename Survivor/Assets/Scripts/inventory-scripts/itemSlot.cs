using UnityEngine;
using UnityEngine.UI;

public class itemSlot : MonoBehaviour {

    public Image icon;

    public Button removeButton;

    item item;

    public void addItem(item newItem) {
        item = newItem;
        //debug Image = Image.icon;
        icon.sprite = item.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void clearItem() {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void whenRemoveButtonPressed() {
        inventory.referenceInstance.Remove(item);
    }
    public void useItem() {
        if (item != null) {
            item.Use();
        }
    }
}
