using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsHandler : MonoBehaviour
{
    [SerializeField] private PlayerStats baseStats;

    public PlayerStats CurrentStates { get; private set; }

    private void Awake()
    {
        UpdatePlayerStats();
    }

    private void UpdatePlayerStats()
    {
        PlayerSO playerSO = null;
        if(baseStats != null)
        {
            playerSO = Instantiate(baseStats.playerSO);
        }
        CurrentStates = new PlayerStats { playerSO = playerSO };

        CurrentStates.NextExp = baseStats.playerSO.level + 2;

        while(CurrentStates.NextExp <= CurrentStates.playerSO.Exp)
        {
            CurrentStates.playerSO.Exp -= CurrentStates.NextExp;
            CurrentStates.playerSO.level += 1;
            CurrentStates.NextExp += 2;
        }
    }
}
