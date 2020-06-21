using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class equipmentManager : MonoBehaviour {

    public static equipmentManager referenceInstance;

    void Awake() {
        referenceInstance = this;
    }

    equipment[] currentEquipment;

    public delegate void OnEquipmentChanged(equipment oldItem, equipment newItem);
    public OnEquipmentChanged onEquipmentChanged;

    inventory Inventory;
    void Start()  {
        Inventory = inventory.referenceInstance;
        int numberOfEquipSlots = System.Enum.GetNames(typeof(EquipmentSlots)).Length;
        currentEquipment = new equipment[numberOfEquipSlots];
    }

    public void Equip(equipment Item) {
        int slotIndex = (int)Item.vEquipmentSlots;
        equipment oldItem = null;
        if (currentEquipment[slotIndex] != null) {
            oldItem = currentEquipment[slotIndex];
            Inventory.Add(oldItem);
        }
        if (onEquipmentChanged != null) {
            onEquipmentChanged.Invoke(Item, oldItem);
        }
        currentEquipment[slotIndex] = Item;
    }
    public void Unequip(int slotIndex) {
        if (currentEquipment[slotIndex] != null) {
            equipment oldItem = currentEquipment[slotIndex];
            Inventory.Add(oldItem);
            currentEquipment[slotIndex] = null;
            if (onEquipmentChanged != null) {
                onEquipmentChanged.Invoke(null, oldItem);
            }
        }
    }
    public void UnequipAll() {
        for (int x = 0; x < currentEquipment.Length; x = x + 1) {
            Unequip(x);
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U)) {
            UnequipAll();
        }
    }
    /*
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
