using UnityEngine;
using UnityEngine.UI;

public class itemSlot : MonoBehaviour {

    public Image icon;
    item item;

    public void addItem(item newItem) {
        item = newItem;
        //debug Image = Image.icon;
        icon.sprite = item.icon;
        icon.enabled = true;
    }

    public void ClearItem() {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
    }
}
