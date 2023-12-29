using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    #region 변수
    [Header("=====> 옵션 버튼 세팅 <=====")]
    [SerializeField] private Ease SelectEase;
    [SerializeField] private GameObject OptionSettingGroup;
    [SerializeField] private Button OptionSettingButton;

    [Header("=====> 옵션 설정창 세팅 <=====")]
    [SerializeField] private Button OptionExitButton;
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
        OptionSettingButton.onClick.AddListener(() =>
        {
            OptionSettingGroup.transform.DOLocalMove(new Vector3(0, -1200, 0), 0.4f).SetEase(SelectEase).SetRelative();
        });

        OptionExitButton.onClick.AddListener(() =>
        {
            OptionSettingGroup.transform.DOLocalMove(new Vector3(0, 1200, 0), 0.4f).SetEase(SelectEase).SetRelative();
        });
    }
    #endregion // 함수
}
