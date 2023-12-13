using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerStatsHandler : MonoBehaviour
{
    [SerializeField] private PlayerStats baseStats;
    private UIController _controller;

    public PlayerStats CurrentStates { get; private set; }

    private void Awake()
    {
        _controller = GetComponent<UIController>();
    }

    private void Start()
    {
        UpdatePlayerStats();
        _controller.StatsChangedEvent += UpdatePlayerInfo;
    }

    private void UpdatePlayerStats()
    {
        CurrentStates = baseStats;

        CurrentStates.NextExp = baseStats.playerSO.level + 2;

        while(CurrentStates.NextExp <= CurrentStates.playerSO.Exp)
        {
            CurrentStates.playerSO.Exp -= CurrentStates.NextExp;
            CurrentStates.playerSO.level += 1;
            CurrentStates.NextExp += 2;
        }
    }

    private void UpdatePlayerInfo(PlayerStats newModifier)
    {
        CurrentStates.NextExp += newModifier.NextExp;
        if (CurrentStates.playerSO.GetType() != newModifier.playerSO.GetType()) return;
        CurrentStates.playerSO.Exp += newModifier.playerSO.Exp;
        CurrentStates.playerSO.gold += newModifier.playerSO.gold;
        
        // Stats
        CurrentStates.playerSO.power += newModifier.playerSO.power;
        CurrentStates.playerSO.armor += newModifier.playerSO.armor;
        CurrentStates.playerSO.hp += newModifier.playerSO.hp;
        CurrentStates.playerSO.critical += newModifier.playerSO.critical;

        while (CurrentStates.NextExp <= CurrentStates.playerSO.Exp)
        {
            CurrentStates.playerSO.Exp -= CurrentStates.NextExp;
            CurrentStates.playerSO.level += 1;
            CurrentStates.NextExp += 2;
        }
    }
}
