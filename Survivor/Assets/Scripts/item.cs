using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class item : ScriptableObject {
    public string itemname = "New Item";
    public Sprite icon = null;
    public bool isDefaultItem = false;
}
