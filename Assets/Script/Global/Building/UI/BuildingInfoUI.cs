using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingInfoUI : MonoBehaviour
{
    #region 변수
    [SerializeField] private Button cancelButton;
    [SerializeField] private Button destroyButton;
    [SerializeField] private Button upgradeButton;
    #endregion // 변수

    #region 함수
    /** 버튼 초기설정 */
    private void InitButton()
    {
        cancelButton.onClick.AddListener(() =>
        {
            this.gameObject.SetActive(false);
        });
        destroyButton.onClick.AddListener(() =>
        {
            // 건물 파괴
        });
        upgradeButton.onClick.AddListener(() =>
        {
            // 건물 업그레이드
        });
    }
    #endregion // 함수
}