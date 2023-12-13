using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player/PlayerData", order = 0)]
public class PlayerSO : ScriptableObject
{
    [Header("Player Info")]
    public string playerName;
    public int level;
    public int Exp;
    public int gold;

    [Header("Player Stats")]
    public int power;
    public int armor;
    public int hp;
    public int critical;
}
