using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class UIController : MonoBehaviour
{
    public event Action InfoChangedEvent;
    public event Action<PlayerStats> StatsChangedEvent;
    public event Action InventoryChangedEvent;
    public event Action<ItemSO> ItemEquipEvent;
    public event Action<ItemSO> ItemUnEquipEvent;

    public void CallInfoEvent()
    {
        InfoChangedEvent?.Invoke();
    }

    public void CallStatsEvent(PlayerStats playerStats)
    {
        StatsChangedEvent?.Invoke(playerStats);
    }

    public void CallInventoryEvent()
    {
        InventoryChangedEvent?.Invoke();
    }

    public void CallEquipEvent(ItemSO item)
    {
        ItemEquipEvent?.Invoke(item);
        CallInventoryEvent();
    }

    public void CallUnEquipEvent(ItemSO item)
    {
        ItemUnEquipEvent?.Invoke(item);
        CallInventoryEvent();
    }


}
