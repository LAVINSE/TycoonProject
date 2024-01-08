using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    #region 프로퍼티
    public int PlayerLevel { get; set; } = 0;
    public int PlayerArchitectureLevel { get; set; } = 0;
    public int PlayerFriendshipLevel { get; set; } = 0;
    public int PlayerFindLevel { get; set; } = 0;
    public int PlayerAutoLevel { get; set; } = 0;
    public int PlayerElectricLevel { get; set; } = 0;
    public float PlayerLevelRequireExp { get; set; } = 0;
    public int PlayerStatPoint { get; set; } = 0;
    #endregion // 프로퍼티

    #region 함수
    /** 레벨업할 때 스텟포인트 2 추가 */
    public void IncreaseStatPoint()
    {
        // 레벨업 할때마다 스텟포인트 2 주기
        PlayerStatPoint += 2;
    }

    /** 건축 레벨을 증가시킨다 */
    public void IncreaseArchitectureLevel()
    {

    }

    /** 호감도 레벨을 증가시킨다 */
    public void IncreaseFriendshipLevel()
    {

    }

    /** 탐색 레벨을 증가시킨다 */
    public void IncreaseFindLevel()
    {

    }

    /** 자동화 레벨을 증가시킨다 */
    public void IncreaseAutoLevel()
    {

    }

    /** 전기 레벨을 증가시킨다 */
    public void InincreaseElectricLevel()
    {

    }
    #endregion // 함수
}
