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
                StartCoroutine(CreateAlarmMoveDownCo());
            }
            else
            {
                StartCoroutine(CreateAlarmMoveDownCo());
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
    private IEnumerator CreateAlarmMoveDownCo()
    {
        var AlarmComponent = this.gameObject.GetComponentInChildren<AlarmUI>();
        if(AlarmComponent == null) {
            var Alarm = CreateUIPrefab.CreateAlarmUI(this.gameObject);
            Alarm.transform.localPosition = new Vector3(0, 700, 0);
            Alarm.transform.DOLocalMove(new Vector3(0, -300, 0), 0.6f).SetEase(Ease.Unset)
                .SetRelative().SetAutoKill();//SetLoops(2, LoopType.Yoyo).SetAutoKill();

            yield return new WaitForSeconds(0.8f);

            Alarm.transform.DOLocalMove(new Vector3(0, 300, 0), 0.3f).SetEase(Ease.Unset).SetRelative().SetAutoKill();

            yield return new WaitForSeconds(0.7f);

            Destroy(Alarm.gameObject);
        }
        else
        {
            yield return null;
        }
    }
    #endregion // �ڷ�ƾ
}
