using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour {

    public static inventory referenceInstance;

    public int space = 20;

    public static bool notEnoughSpace = false;

    public delegate void OnItemChanged();

    public OnItemChanged onItemChangedCallBack;

    void Awake() {
        if (referenceInstance != null) {
            Debug.LogWarning("More than one instance of inventory found!");
        }
        referenceInstance = this;
    }
    public List<item> items = new List<item>();

    public void Add(item Item) {
        if (!Item.isDefaultItem) {
            if (items.Count >= space) {
                Debug.Log("Not enough room for " + Item.itemname);
                notEnoughSpace = true;
                return;
            }
            items.Add(Item);
            notEnoughSpace = false;
            if (onItemChangedCallBack != null) {
                onItemChangedCallBack.Invoke();
            }
        }
    }

    public void Remove(item Item) {
        items.Remove(Item);
        if (onItemChangedCallBack != null) {
            onItemChangedCallBack.Invoke();
        }
    }
}
