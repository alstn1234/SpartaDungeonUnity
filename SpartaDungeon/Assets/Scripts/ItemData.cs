using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Weapon,
    Armor,
}

[Serializable]
public class ItemData 
{
    public ItemType type;
    public string itemName;
    public Sprite itemSprite;
    public int power = 0;
    public int armor = 0;
    public int Hp = 0;
    public int critical = 0;
    public int gold;
    public bool IsEquipped = false;

}
