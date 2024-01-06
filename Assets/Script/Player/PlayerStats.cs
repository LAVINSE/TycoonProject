using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region 프로퍼티
    public int PlayerLevel { get; set; }
    public int PlayerArchitectureLevel { get; set; }
    public int PlayerFriendshipLevel { get; set; }
    public int PlayerFindLevel { get; set; }
    public int PlayerAutoLevel { get; set; }
    public int PlayerElectricLevel { get; set; }
    public float PlayerLevelRequireExp { get; set; }
    #endregion // 프로퍼티

    #region 함수
    public void IncreaseStats()
    {

    }
    #endregion // 함수
}
