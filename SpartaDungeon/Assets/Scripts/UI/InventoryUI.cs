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
        if(unEquipUI.activeSelf) unEquipUI.SetActive(false);
    }

    public void EquipConfirmClick()
    {
        backButton.interactable = true;
        switch(_item.type)
        {
            case ItemType.Weapon:
                if (GameManager.Instance.CurrentWeapon != null)
                    GameManager.Instance.CurrentWeapon.IsEquipped = false;
                GameManager.Instance.CurrentWeapon = _item;
                break;
            case ItemType.Armor:
                if (GameManager.Instance.CurrentArmor != null)
                    GameManager.Instance.CurrentArmor.IsEquipped = false;
                GameManager.Instance.CurrentArmor = _item;
                break;
        }

        _item.IsEquipped = true;
        _controller.CallInventoryEvent();
        equipUI.SetActive(false);
    }
    
    public void UnEquipConfirmClick()
    {
        backButton.interactable = true;

        switch (_item.type)
        {
            case ItemType.Weapon:
                GameManager.Instance.CurrentWeapon = null;
                break;
            case ItemType.Armor:
                GameManager.Instance.CurrentArmor = null;
                break;
        }

        _item.IsEquipped = false;
        _controller.CallInventoryEvent();
        unEquipUI.SetActive(false);
    }
}
