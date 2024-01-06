using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Analytics;

public class PlayerLevel : MonoBehaviour
{
    public int playerLevel;
    public int playerExp;
    public int ind;

    #region 함수
    /** 경험치 획득 */
    public void GainExp(int expAmount)
    {
        playerExp += expAmount;
        CheckForLevel();
    }

    /** 경험치 획득량에 따른 레벨 체크 */
    private void CheckForLevel()
    {
        while (true)
        {
            // 다음레벨 경험치 요구량 가져오기
            int requiredExp = DataManager.Inst.GetExpForLevel(playerLevel + 1);
            ind = DataManager.Inst.GetExpForLevel(playerLevel + 1);

            if (requiredExp == 0) { break; }
            if (playerExp < requiredExp) { break; }

            // 플레이어 경험치가 다음레벨에 필요한 경험치를 모았을 경우
            if (playerExp >= requiredExp)
            {
                Levelup();
            }

            playerExp -= requiredExp;
        }
    }

    /** 레벨 증가 */
    private void Levelup()
    {
        playerLevel++;
        // TODO : 레벨 증가시 증가하는 스텟? PlayerStats.()
        Debug.Log("레벨업");
    }
    #endregion // 함수
}
