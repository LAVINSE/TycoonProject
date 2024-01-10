using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour
{
    #region 변수
    [Header("=====> UI <=====")]
    [SerializeField] private Ease selectEase;
    [SerializeField] private GameObject playerStatsGroupObject;
    [SerializeField] private Button playerStatsShowHideButton;

    [Header("=====> 정보 UI <=====")]
    [SerializeField] private Button playerInfoButton;
    [SerializeField] private GameObject playerInfoParentObject;

    private PlayerInfoUI playerInfoObject;
    private bool isButtonShow;
    #endregion // 변수

    #region 함수
    /** 초기화 */
    private void Awake()
    {
        InitButton();
    }

    /** 버튼 초기값을 세팅한다 */
    private void InitButton()
    {
        playerStatsShowHideButton.onClick.AddListener(() =>
        {
            if (isButtonShow)
            {
                playerStatsGroupObject.transform.DOLocalMove(new Vector3(630, 0, 0), 0.4f).SetEase(selectEase).SetRelative();
                isButtonShow = false;
            }
            else
            {
                playerStatsGroupObject.transform.DOLocalMove(new Vector3(-630, 0, 0), 0.4f).SetEase(selectEase).SetRelative();
                isButtonShow = true;
            }
        });

        playerInfoButton.onClick.AddListener(() =>
        {
            var playerInfoComponent = playerInfoParentObject.GetComponentInChildren<PlayerInfoUI>(true);

            if(playerInfoComponent == null || playerInfoObject == null)
            {
                playerInfoObject = CreateUIPrefab.CreatePlayerInfoUI(playerInfoParentObject);
            }
            else if(playerInfoObject != null)
            {
                playerInfoObject.gameObject.SetActive(true);
            }
        });
    }
    #endregion // 함수
}
