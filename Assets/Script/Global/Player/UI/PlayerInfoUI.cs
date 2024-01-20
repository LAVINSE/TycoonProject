using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoUI : MonoBehaviour
{
    /*
     * 스탯 순서 { 건축, 호감도, 탐색, 자동화, 전기}
     */

    #region 변수
    [Header("=====> 설정 <=====")]
    [SerializeField] private TMP_Text playerStatsText;
    [SerializeField] private GameObject UpgradeUIRootObject;
    [SerializeField] private Button closeButton;

    private PlayerStats playerStat;
    private PlayerInit playerTest;
    #endregion // 변수

    #region 프로퍼티
    public List<PlayerUpgradeUI> UpgradeList = new List<PlayerUpgradeUI>();
    #endregion // 프로퍼티

    #region 함수
    /** 초기화 */
    private void Awake()
    {
        // 씬 매니저 가져오기
        var sceneManager = CSceneManager.GetSceneManager<MainGameSceneManager>(CDefine.MainGameScene);
        
        // PlayerInfoUI 등록
        sceneManager.PlayerInfoUIObject = this.gameObject;

        // 플레이어 컴포넌트 가져오기
        playerStat = sceneManager.PlayerObject.GetComponent<PlayerStats>();
        playerTest = sceneManager.PlayerObject.GetComponent<PlayerInit>();

        // 기본 설정
        InitUpgrade();
        InitButton();

        // 스텟포인트 표기
        PlayerStatPointTextUpdate();
    }

    /** UpgradeUI 기본 설정을 한다 */
    private void InitUpgrade()
    {
        for (int i = 0; i < UpgradeUIRootObject.transform.childCount; i++)
        {
            var upgradeUIComponent = UpgradeUIRootObject.transform.GetChild(i).GetComponent<PlayerUpgradeUI>();

            if(upgradeUIComponent != null)
            {
                UpgradeList.Add(upgradeUIComponent);
            }
        }

        // 컴포넌트, 기본설정
        for(int i = 0; i < UpgradeList.Count; i++)
        {
            UpgradeList[i].PlayerTest = playerTest;
            UpgradeList[i].PlayerStat = playerStat;
            UpgradeList[i].PlayerInfo = this;
        }

        // UI 추가 할때마다 등록해야됨
        UpgradeList[0].Init("건축", playerStat.PlayerArchitectureLevel, EStatType.Architecture);
        UpgradeList[1].Init("호감도", playerStat.PlayerFriendshipLevel, EStatType.Friendship);
        UpgradeList[2].Init("탐색", playerStat.PlayerFindLevel, EStatType.Find);
        UpgradeList[3].Init("자동화", playerStat.PlayerAutoLevel, EStatType.Auto);
        UpgradeList[4].Init("전기", playerStat.PlayerElectricLevel, EStatType.Electric);
    }

    /** 버튼 초기값을 세팅한다 */
    private void InitButton()
    {
        closeButton.onClick.AddListener(() =>
        {
            this.gameObject.SetActive(false);
        });
    }

    /** 스텟 포인트 텍스트를 업데이트 한다 */
    public void PlayerStatPointTextUpdate()
    {
        // TODO : "스텟" 수정할 수 있음
        playerStatsText.text = "스텟 : " + playerStat.PlayerStatPoint.ToString();
    }
    #endregion // 함수
}
