using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInit : MonoBehaviour
{
    #region 변수
    [SerializeField] private int playerLevel;
    [SerializeField] private int playerArchitectureLevel;
    [SerializeField] private int playerFriendshipLevel;
    [SerializeField] private int playerFindLevel;
    [SerializeField] private int playerAutoLevel;
    [SerializeField] private int playerElectricLevel;
    [SerializeField] private float playerLevelRequireExp;
    [SerializeField] private int playerStatPoint;
    private PlayerStats stats;
    #endregion // 변수

    #region 함수
    private void Awake()
    {
        stats = GetComponent<PlayerStats>();
        Init();
    }

    public void Init()
    {
        playerLevel = stats.PlayerLevel;
        playerArchitectureLevel = stats.PlayerArchitectureLevel;
        playerFriendshipLevel = stats.PlayerFriendshipLevel;
        playerFindLevel = stats.PlayerFindLevel;
        playerAutoLevel = stats.PlayerAutoLevel;
        playerElectricLevel = stats.PlayerElectricLevel;
        playerStatPoint = stats.PlayerStatPoint;
        playerLevelRequireExp = stats.PlayerLevelRequireExp;
    }
    #endregion // 함수
}
