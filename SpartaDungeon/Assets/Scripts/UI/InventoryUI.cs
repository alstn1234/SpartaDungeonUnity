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
    public Button backButton;

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
        backButton.interactable = false;
    }

    public void CancleClick()
    {
        backButton.interactable = true;
        if (equipUI.activeSelf) equipUI.SetActive(false);
        if (unEquipUI.activeSelf) unEquipUI.SetActive(false);
    }

    public void EquipConfirmClick()
    {
        backButton.interactable = true;
        equipUI.SetActive(false);
        _controller.CallEquipEvent(_item);
    }

    public void UnEquipConfirmClick()
    {
        backButton.interactable = true;
        unEquipUI.SetActive(false);
        _controller.CallUnEquipEvent(_item);
    }
}
