using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUI : MonoBehaviour
{
    public GameObject mainUI;
    public GameObject statsUI;
    public GameObject inventoryUI;

    public void EnterStats()
    {
        statsUI.SetActive(true);
        mainUI.SetActive(false);
    }

    public void EnterInventory()
    {
        inventoryUI.SetActive(true);
        mainUI.SetActive(false);
    }
    public void ExitStats()
    {
        mainUI.SetActive(true);
        statsUI.SetActive(false);
    }

    public void ExitInventory()
    {
        mainUI.SetActive(true);
        inventoryUI.SetActive(false);
    }

}
