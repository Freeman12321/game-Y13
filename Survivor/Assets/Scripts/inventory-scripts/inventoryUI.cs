using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryUI : MonoBehaviour {

    inventory vInventory; // reference the inventory

    public GameObject itemsParent; // controls the behavour of the items

    public GameObject inventoryGraphics; // holds the UI of inventory

    public GameObject instructionText; // Tutorial Text

    itemSlot[] slots; // create an array of item slots  

	void Start () {
        //debug inventory.referenceInstance;	
        vInventory = inventory.referenceInstance; // access the inventory script
        vInventory.onItemChangedCallBack += UpdateUI; // when the inventory is changed 
        // debug slots = itemsParent.GetComponent<itemSlot>();
        slots = itemsParent.GetComponentsInChildren<itemSlot>(); // gets the item slots
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Inventory")) { // if I is pressed
            inventoryGraphics.SetActive(!inventoryGraphics.activeSelf); // toggle the inventory
        }
        if (Input.GetButtonDown("Instructions")) { // if H is pressed
            instructionText.SetActive(!instructionText.activeSelf); // toggle the tutorial text
        }
		for (int i = 0; i < slots.Length; i = i + 1) { // create a for loop that 
            if (i < vInventory.items.Count) { // if there are more items to add
<<<<<<< HEAD
                slots[i].addItem(vInventory.items[i]); // take the ith slot (index) pass in the corresponding item from the inventory items array
=======
                slots[i].addItem(vInventory.items[i]); // take the ith slot pass in the corresponding item from the inventory items array
>>>>>>> 4be645352fa7435b49f0624285de94fb540b56fb
            }
            else { // there are no more items to add
                slots[i].clearItem(); // clear the ith slots
            }
        }
	}

    void UpdateUI () {
        Debug.Log("Updating UI");
    }
}