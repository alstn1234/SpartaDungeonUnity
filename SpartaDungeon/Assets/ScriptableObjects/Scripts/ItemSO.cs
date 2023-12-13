using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Item/ItemData", order = 0)]

public class ItemSO : ScriptableObject
{
    [Header("Item Info")]
    public ItemType type;
    public string itemName;
    public Sprite itemSprite;
    public string desc;
    public int power;
    public int armor;
    public int Hp;
    public int critical;
    public int gold;
    public bool IsEquipped;
}
