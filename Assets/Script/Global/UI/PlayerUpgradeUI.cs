using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;
using static PlayerUpgradeUI;

public enum EStatType
{
    None = -1,
    Architecture,
    Friendship,
    Find,
    Auto,
    Electric
}

public class PlayerUpgradeUI : MonoBehaviour
{
    #region 변수
    [Header("=====> 인스펙터 확인 <=====")]
    [SerializeField] private EStatType statType = EStatType.None;

    [Header("=====> 설정 <=====")]
    [SerializeField] private Button upgradeButton;
    [SerializeField] private TMP_Text upgradeText;
    [SerializeField] private TMP_Text upgradeCountText;
    [SerializeField] private Image upgradeFillImg;
    #endregion // 변수

    #region 프로퍼티
    public PlayerInit PlayerTest { get; set; }
    public PlayerStats PlayerStat { get; set; }
    public PlayerInfoUI PlayerInfo { get; set; }
    #endregion // 프로퍼티

    #region 함수
    /** 업그레이드 이미지 슬라이더, 개수를 갱신한다 */
    private void UpdateUI(int maxAmount, int currentAmount)
    {
        upgradeFillImg.fillAmount = (float)currentAmount / maxAmount;
        this.upgradeCountText.text = currentAmount.ToString();
    }

    /** 기본 설정을 한다 */
    public void Init(string upgradeText, int upgradeCountText,EStatType statType)
    {
        this.upgradeText.text = upgradeText;
        this.upgradeCountText.text = upgradeCountText.ToString();
        this.statType = statType;

        InitButton();
    }

    /** 버튼을 설정한다 */
    private void InitButton()
    {
        upgradeButton.onClick.AddListener(() =>
        {
            if(PlayerStat.PlayerStatPoint != 0)
            {
                switch (statType)
                {
                    case EStatType.Architecture:
                        PlayerStat.IncreaseArchitectureLevel();
                        UpdateUI(PlayerStat.PlayerMaxLevel, PlayerStat.PlayerArchitectureLevel);
                        break;
                    case EStatType.Friendship:
                        PlayerStat.IncreaseFriendshipLevel();
                        UpdateUI(PlayerStat.PlayerMaxLevel, PlayerStat.PlayerFriendshipLevel);
                        break;
                    case EStatType.Find:
                        PlayerStat.IncreaseFindLevel();
                        UpdateUI(PlayerStat.PlayerMaxLevel, PlayerStat.PlayerFindLevel);
                        break;
                    case EStatType.Auto:
                        PlayerStat.IncreaseAutoLevel();
                        UpdateUI(PlayerStat.PlayerMaxLevel, PlayerStat.PlayerAutoLevel);
                        break;
                    case EStatType.Electric:
                        PlayerStat.IncreaseElectricLevel();
                        UpdateUI(PlayerStat.PlayerMaxLevel, PlayerStat.PlayerElectricLevel);
                        break;
                }

                PlayerStat.PlayerStatPoint--;
                PlayerInfo.PlayerStatPointTextUpdate();
                // 테스트 스텟 동기화
                PlayerTest.Init();
            }
            else
            {
                Debug.Log("포인트가 없습니다");
            }
        });
    }
    #endregion // 함수
}
