using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUI : MonoBehaviour
{
    public GameObject MainUI;
    public GameObject StatsUI;
    public GameObject InventoryUI;

    public void EnterStats()
    {
        StatsUI.SetActive(true);
        MainUI.SetActive(false);
    }

    public void EnterInventory()
    {
        InventoryUI.SetActive(true);
        MainUI.SetActive(false);
    }
    public void ExitStats()
    {
        MainUI.SetActive(true);
        StatsUI.SetActive(false);
    }

    public void ExitInventory()
    {
        MainUI.SetActive(true);
        InventoryUI.SetActive(false);
    }

}
