using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager Instance = null;

    public List<ItemSO> InventoryItemList = new List<ItemSO>();
    public ItemSO CurrentWeapon;
    public ItemSO CurrentArmor;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        CurrentWeapon = null;
        CurrentArmor = null;
    }


}
