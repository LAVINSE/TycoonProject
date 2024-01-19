using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.Analytics;

public class PlayerLevel : MonoBehaviour
{
    #region 변수
    private PlayerStats playerStats;
    #endregion // 변수

    #region 함수
    /** 초기화 */
    private void Awake()
    {
        playerStats = GetComponent<PlayerStats>();
    }

    /** 경험치 획득 */
    public void GainExp(int expAmount)
    {
        playerStats.PlayerLevelRequireExp += expAmount;
        CheckForLevel();
    }

    /** 경험치 획득량에 따른 레벨 체크 */
    private void CheckForLevel()
    {
        while (true)
        {
            // 다음레벨 경험치 요구량 가져오기
            int requiredExp = DataManager.Inst.GetExpForLevel(playerStats.PlayerLevel + 1);

            if (requiredExp == 0) { break; }
            if (playerStats.PlayerLevelRequireExp < requiredExp) { break; }

            // 플레이어 경험치가 다음레벨에 필요한 경험치를 모았을 경우
            if (playerStats.PlayerLevelRequireExp >= requiredExp)
            {
                Levelup();
            }

            playerStats.PlayerLevelRequireExp -= requiredExp;
        }
    }

    /** 레벨 증가 */
    private void Levelup()
    {
        var sceneManager = CSceneManager.GetSceneManager<MainGameSceneManager>(CDefine.MainGameScene);

        playerStats.PlayerLevel++;
        // 레벨업 >> 스텟포인트 2 증가
        playerStats.IncreaseStatPoint();
        // UI 업데이트
        sceneManager.PlayerInfoUIObject.GetComponent<PlayerInfoUI>().PlayerStatPointTextUpdate();
        Debug.Log("레벨업");
    }
    #endregion // 함수
}
