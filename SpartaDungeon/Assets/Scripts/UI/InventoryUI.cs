using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    private ItemSO _item;
    private UIController _controller;

    public GameObject equipUI;
    public GameObject unEquipUI;

    private void Awake()
    {
        _controller = GetComponent<UIController>();
    }

    public void ItemClick(int index)
    {
        if (index >= GameManager.Instance.InventoryItemList.Count) return;

        _item = GameManager.Instance.InventoryItemList[index];
        if (!_item.IsEquipped)
            equipUI.SetActive(true);
        else
            unEquipUI.SetActive(true);
    }

    public void CancleClick()
    {
        if (equipUI.activeSelf) equipUI.SetActive(false);
        if (unEquipUI.activeSelf) unEquipUI.SetActive(false);
    }

    public void EquipConfirmClick()
    {
        equipUI.SetActive(false);
        _controller.CallEquipEvent(_item);
    }

    public void UnEquipConfirmClick()
    {
        unEquipUI.SetActive(false);
        _controller.CallUnEquipEvent(_item);
    }
}
