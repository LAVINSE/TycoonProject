using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    #region ����
    [Header("=====> �ɼ� ��ư ���� <=====")]
    [SerializeField] private Ease SelectEase;
    [SerializeField] private GameObject OptionSettingGroup;
    [SerializeField] private Button OptionSettingButton;

    [Header("=====> �ɼ� ����â ���� <=====")]
    [SerializeField] private Button OptionExitButton;
    #endregion // ����

    #region �Լ�
    /** �ʱ�ȭ */
    private void Awake()
    {
        InitButton();
    }

    /** ��ư �ʱⰪ�� �����Ѵ� */
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
    #endregion // �Լ�
}
