using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour
{
    #region field
    [Header("Player Info")]
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI playerlevelText;
    public TextMeshProUGUI playerExpText;
    public TextMeshProUGUI playerGoldText;
    public Slider playerExpSlider;

    [Header("Stats Info")]
    public TextMeshProUGUI powerText;
    public TextMeshProUGUI armorText;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI criticalText;

    [Header("Inventory Info")]
    public Transform ItemList;


    private PlayerStatsHandler _stathandler;
    private PlayerSO _playerStat;
    private UIController _controller;

    #endregion

    private void Awake()
    {
        _stathandler = GetComponent<PlayerStatsHandler>();
        _controller = GetComponent<UIController>();
    }

    private void Start()
    {
        _playerStat = _stathandler.CurrentStates.playerSO;
        UpdateUI();

        _controller.InfoChangedEvent += UpdateMainUI;
        _controller.StatsChangedEvent += UpdateStats;
        _controller.InventoryChangedEvent += UpdateInventory;
    }

    private void UpdateUI()
    {
        UpdateStats(new PlayerStats());
        UpdateMainUI();
        UpdateInventory();
    }   

    private void UpdateStats(PlayerStats newModifier)
    {
        powerText.text = _playerStat.power.ToString();
        armorText.text = _playerStat.armor.ToString();
        hpText.text = _playerStat.hp.ToString();
        criticalText.text = _playerStat.critical.ToString();
    }

    private void UpdateMainUI()
    {
        playerNameText.text = _playerStat.playerName;
        playerlevelText.text = _playerStat.level.ToString();
        playerGoldText.text = _playerStat.gold.ToString();

        playerExpSlider.maxValue = _stathandler.CurrentStates.NextExp;
        playerExpSlider.value = _playerStat.Exp;
        string levelText = _playerStat.Exp.ToString() + " / " + _stathandler.CurrentStates.NextExp.ToString();
        playerExpText.text = levelText;
    }

    private void UpdateInventory()
    {
        var inventoryItemList = GameManager.Instance.InventoryItemList;
        for (int i = 0; i < inventoryItemList.Count; i++)
        {
            Image itemImage = ItemList.GetChild(i).GetChild(1).GetComponent<Image>();
            itemImage.sprite = inventoryItemList[i].itemSprite;

            GameObject equipMark = ItemList.GetChild(i).GetChild(2).gameObject;
            if (inventoryItemList[i].IsEquipped) equipMark.SetActive(true);
            else equipMark.SetActive(false);
        }
    }
}
