using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;


public class Inventory : MonoBehaviour
{
    private UIController _controller;
    private void Awake()
    {
        _controller = GetComponent<UIController>();
    }

    private void Start()
    {
        _controller.ItemEquipEvent += Equip;
        _controller.ItemUnEquipEvent += UnEquip;
    }

    private void Equip(ItemSO item)
    {
        switch (item.type)
        {
            case ItemType.Weapon:
                if (GameManager.Instance.CurrentWeapon != null)
                    GameManager.Instance.CurrentWeapon.IsEquipped = false;
                GameManager.Instance.CurrentWeapon = item;
                break;
            case ItemType.Armor:
                if (GameManager.Instance.CurrentArmor != null)
                    GameManager.Instance.CurrentArmor.IsEquipped = false;
                GameManager.Instance.CurrentArmor = item;
                break;
        }

        item.IsEquipped = true;
    }

    private void UnEquip(ItemSO item)
    {
        switch (item.type)
        {
            case ItemType.Weapon:
                GameManager.Instance.CurrentWeapon = null;
                break;
            case ItemType.Armor:
                GameManager.Instance.CurrentArmor = null;
                break;
        }

        item.IsEquipped = false;
    }
}
    
