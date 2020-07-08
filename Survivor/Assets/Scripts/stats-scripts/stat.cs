using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable] // fields of this class will show up in the inspector by making unity serialise a custom class
public class stat {

    [SerializeField] // make this class editable in the inspector
    private int baseValue; // base value edited in the inspector

    private List<int> itemsStats = new List<int>(); // create a list of numbers of the item stats in the equipment
    public int getValue () {
        //Debug armour/damage values from items do not impact the players stats for the code "return baseValue;"
        int finalValue = baseValue; 
        itemsStats.ForEach(v => finalValue += v); // change the base value based on all of the item values
        return finalValue; // return the final value as the int
    }

    public void addItemStats(int modifier) { // take an integer of the number of modifier
        if (modifier != 0) { // if we have a modifier
            itemsStats.Add(modifier); // add the modifiers
        }
    }
    public void removeItemStats(int modifier) { // take an integer of the number of modifier
        if (modifier != 0) { // if we have a modifier
            itemsStats.Remove(modifier); // remove the modifiers
        }
    }
}
