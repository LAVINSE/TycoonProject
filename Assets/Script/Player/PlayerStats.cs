using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region ������Ƽ
    public int PlayerLevel { get; set; }
    public int PlayerArchitectureLevel { get; set; }
    public int PlayerFriendshipLevel { get; set; }
    public int PlayerFindLevel { get; set; }
    public int PlayerAutoLevel { get; set; }
    public int PlayerElectricLevel { get; set; }
    public float PlayerLevelRequireExp { get; set; }
    #endregion // ������Ƽ

    #region �Լ�
    public void IncreaseStats()
    {

    }
    #endregion // �Լ�
}
