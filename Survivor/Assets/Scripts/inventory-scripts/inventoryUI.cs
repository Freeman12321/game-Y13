using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryUI : MonoBehaviour {

    inventory vInventory;

    public GameObject itemsParent;

    public GameObject inventoryGraphics;

    itemSlot[] slots;

	void Start () {
        //debug inventory.referenceInstance;	
        vInventory = inventory.referenceInstance;
        vInventory.onItemChangedCallBack += UpdateUI;
        // debug slots = itemsParent.GetComponent<itemSlot>();
        slots = itemsParent.GetComponentsInChildren<itemSlot>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Inventory")) {
            inventoryGraphics.SetActive(!inventoryGraphics.activeSelf);
        }
		for (int i = 0; i < slots.Length; i = i + 1) {
            if (i < vInventory.items.Count) {
                slots[i].addItem(vInventory.items[i]);
            }
            else {
                slots[i].clearItem();
            }
        }
	}

    void UpdateUI () {
        Debug.Log("Updating UI");
    }
}