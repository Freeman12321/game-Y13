using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equipmentManager : MonoBehaviour {

    public static equipmentManager referenceInstance; // create a variable shared by all instances of the class

    void Awake() {
        referenceInstance = this; // at the start of the game set the instance equal to this component meaning we can access the inventory component by using inventory.referenceInstance
    }

    equipment[] currentEquipment; // create a list to keep track of current equipment

    public delegate void OnEquipmentChanged(equipment oldItem, equipment newItem); // method that takes in the already equipped item and a previous item
    public OnEquipmentChanged onEquipmentChanged; // when the equipment changes

    inventory Inventory; // refer to inventory 
    void Start()  {
        Inventory = inventory.referenceInstance; // set inventory to the inventory class
        int numberOfEquipSlots = System.Enum.GetNames(typeof(EquipmentSlots)).Length; // get the number of possible equip slots
        currentEquipment = new equipment[numberOfEquipSlots]; // make the equipment array equal to this new number
    }

    public void Equip(equipment Item) { // create a method that takes in an equipment
        //Debug.Log("Equiping " + item.name);
        int slotIndex = (int)Item.vEquipmentSlots; // set the slot index to the correct slot the item should go in eg helmets go to helmet slot
        equipment oldItem = null; // we have no old item yet so discard previous old items
        if (currentEquipment[slotIndex] != null) { // if the slot is not empty 
            oldItem = currentEquipment[slotIndex]; // set the old item to the already equipped item
            Inventory.Add(oldItem); // add the old item back to the inventory when we equip a new item 
        }
        if (onEquipmentChanged != null) { // when there is a change in equipment
            onEquipmentChanged.Invoke(Item, oldItem); // change the items correctly (remove old item and add new item)
        }
        currentEquipment[slotIndex] = Item; // get the index of the slot in equipment e.g head = 0 chest = 1 etc  
    }
    public void Unequip(int slotIndex) { // take in a number
        if (currentEquipment[slotIndex] != null) { // if the particular slot number is full 
            equipment oldItem = currentEquipment[slotIndex]; // get the item currently equiped
            Inventory.Add(oldItem); // add the already equipped item back to the inventory
            currentEquipment[slotIndex] = null; // remove the item from the equip slot
            if (onEquipmentChanged != null) { // if there is a change
                onEquipmentChanged.Invoke(null, oldItem); // change the items correctly to the inventory and to the equipment no new item and remove old item
            }
        }
    }
    public void UnequipAll() {
        for (int x = 0; x < currentEquipment.Length; x = x + 1) { // if an int is less than the length of equip slots
            Unequip(x); // unequip each item in  0, 1, 2, 3, 4, 5, 6
        }
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.U)) { // if U is pressed
            UnequipAll();
        }
    }
    /* debugging
    public int space = 20;

    public static bool notEnoughSpaceForEquip = false;

    public delegate void OnItemChanged();

    public OnItemChanged onItemChangedCallBack;

    public static equipmentManager referenceInstance;

    public int numberOfSlots = 6;

    void Awake() {
        referenceInstance = this;
    }

    equipment[] currentEquipment;

    void Start() {
        currentEquipment = new equipment[numberOfSlots];
    }
    public List<item> Equipeditems = new List<item>();
    public void Equip(item Item)
    {
        if (!Item.isDefaultItem)
        {
            if (Equipeditems.Count >= space)
            {
                Debug.Log("Not enough room for " + Item.itemname);
                notEnoughSpaceForEquip = true;
                return;
            }
            Equipeditems.Add(Item);
            notEnoughSpaceForEquip = false;
            if (onItemChangedCallBack != null)
            {
                onItemChangedCallBack.Invoke();
            }
        }
    }

    public void Unequip(item Item)
    {
        Equipeditems.Remove(Item);
        if (onItemChangedCallBack != null)
        {
            onItemChangedCallBack.Invoke();
        }
    }*/
}
