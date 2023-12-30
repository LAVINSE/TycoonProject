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

    [Header("=====> �ҷ����� ��ư ���� <=====")]
    [SerializeField] private Button LoadDataButton;

    [Header("=====> �������� ��ư ���� <=====")]
    [SerializeField] private Button GameExitButton;

    [Header("=====> ���ӽ��� ��ư ���� <=====")]
    [SerializeField] private Button GameStarButton;

    [Header("=====> �ɼ� ����â ���� <=====")]
    [SerializeField] private Button OptionExitButton;
    [SerializeField] private Slider BGMSlider;
    [SerializeField] private Slider SFXSlider;
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
        OptionSettingButton.onClick.AddListener(() =>{
            OptionSettingGroup.transform.DOLocalMove(new Vector3(0, -1200, 0), 0.4f).SetEase(SelectEase).SetRelative();
        });

        OptionExitButton.onClick.AddListener(() =>{
            OptionSettingGroup.transform.DOLocalMove(new Vector3(0, 1200, 0), 0.4f).SetEase(SelectEase).SetRelative();
        });

        LoadDataButton.onClick.AddListener(() =>{
            var IsData = DataManager.Inst.LoadGameData();
            if (IsData)
            {
                StartCoroutine(CreateAlarmMoveCo());
            }
            else
            {
                StartCoroutine(CreateAlarmMoveCo());
            }
        });

        GameExitButton.onClick.AddListener(() =>{
            // ����Ƽ ����
            Application.Quit();
        });

        GameStarButton.onClick.AddListener(() =>{
            // �� �̵�
        });
    }
    #endregion // �Լ�

    #region �ڷ�ƾ
    /** �˶� UI�� �����ϰ� �����δ� */
    private IEnumerator CreateAlarmMoveCo()
    {
        var Alarm = CreateUIPrefab.CreateAlarmUI(this.gameObject);
        Alarm.transform.localPosition = new Vector3(0, 700, 0);
        Alarm.transform.DOLocalMove(new Vector3(0, -300, 0), 0.5f).SetEase(Ease.Unset)
            .SetRelative().SetLoops(2, LoopType.Yoyo).SetAutoKill();

        yield return new WaitForSeconds(1.2f);

        Destroy(Alarm.gameObject);
    }
    #endregion // �ڷ�ƾ
}
