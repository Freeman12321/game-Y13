using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class stat {

    [SerializeField]
    private int baseValue;

    private List<int> itemsStats = new List<int>();
    public int getValue () {
        //Debug armour/damage values from items do not impact the players stats for the code "return baseValue;"
        int finalValue = baseValue;
        itemsStats.ForEach(v => finalValue += v);
        return finalValue;
    }

    public void addItemStats(int modifier) {
        if (modifier != 0) {
            itemsStats.Add(modifier);
        }
    }
    public void removeItemStats(int modifier) {
        if (modifier != 0) {
            itemsStats.Remove(modifier);
        }
    }
}
