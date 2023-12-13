using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;


public class Inventory : MonoBehaviour
{
    [SerializeField] private PlayerStats baseStats;
    private UIController _controller;

    private int extraPower = 0;
    private int extraArmor = 0;
    private int extraHp = 0;
    private int extraCritical = 0;

    private void Awake()
    {
        _controller = GetComponent<UIController>();
    }

    private void Start()
    {
        _controller.ItemEquipEvent += Equip;
        _controller.ItemUnEquipEvent += UnEquip;
        foreach (var item in GameManager.Instance.InventoryItemList)
        {
            if (!item.IsEquipped) continue;
            switch (item.type)
            {
                case ItemType.Weapon:
                    GameManager.Instance.CurrentWeapon = item;
                    break;

                case ItemType.Armor:
                    GameManager.Instance.CurrentArmor = item;
                    break;
            }
        }
    }

    private void Equip(ItemSO item)
    {
        switch (item.type)
        {
            case ItemType.Weapon:
                if (GameManager.Instance.CurrentWeapon != null)
                {
                    CalculateStats(item, GameManager.Instance.CurrentWeapon);
                    GameManager.Instance.CurrentWeapon.IsEquipped = false;
                }
                else CalculateStats(item);
                GameManager.Instance.CurrentWeapon = item;
                break;

            case ItemType.Armor:
                if (GameManager.Instance.CurrentArmor != null)
                {
                    CalculateStats(item, GameManager.Instance.CurrentArmor);
                    GameManager.Instance.CurrentArmor.IsEquipped = false;
                }
                else CalculateStats(item);
                GameManager.Instance.CurrentArmor = item;
                break;
        }

        item.IsEquipped = true;
        _controller.CallStatsEvent(CreatePlayerSO());
    }

    private void UnEquip(ItemSO item)
    {
        InitStats();
        switch (item.type)
        {
            case ItemType.Weapon:
                CalculateStats(null, GameManager.Instance.CurrentWeapon);
                GameManager.Instance.CurrentWeapon = null;
                break;

            case ItemType.Armor:
                CalculateStats(null, GameManager.Instance.CurrentArmor);
                GameManager.Instance.CurrentArmor = null;
                break;
        }

        item.IsEquipped = false;
        _controller.CallStatsEvent(CreatePlayerSO());
    }

    private void CalculateStats(ItemSO equipitem, ItemSO UnEquipitem = null)
    {
        if (equipitem != null)
        {
            extraPower = equipitem.power;
            extraArmor = equipitem.armor;
            extraHp = equipitem.Hp;
            extraCritical = equipitem.critical;
        }

        if (UnEquipitem != null)
        {
            extraPower -= UnEquipitem.power;
            extraArmor -= UnEquipitem.armor;
            extraHp -= UnEquipitem.Hp;
            extraCritical -= UnEquipitem.critical;
        }
    }

    private void InitStats()
    {
        extraPower = 0;
        extraArmor = 0;
        extraHp = 0;
        extraCritical = 0;
    }

    private PlayerStats CreatePlayerSO()
    {
        PlayerSO playerSO = Instantiate(baseStats.playerSO);
        playerSO.power += extraPower;
        playerSO.armor += extraArmor;
        playerSO.hp += extraHp;
        playerSO.critical += extraCritical;

        PlayerStats playerStats = new PlayerStats { playerSO = playerSO };

        return playerStats;
    }
}

