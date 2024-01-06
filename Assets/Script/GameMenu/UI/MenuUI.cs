using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    #region ����
    [Header("=====> �ɼ� ��ư ���� <=====")]
    [SerializeField] private Ease selectEase;
    [SerializeField] private GameObject optionSettingGroup;
    [SerializeField] private Button optionSettingButton;

    [Header("=====> �ҷ����� ��ư ���� <=====")]
    [SerializeField] private Button loadDataButton;

    [Header("=====> �������� ��ư ���� <=====")]
    [SerializeField] private Button gameExitButton;

    [Header("=====> ���ӽ��� ��ư ���� <=====")]
    [SerializeField] private Button GameStarButton;

    [Header("=====> �ɼ� ����â ���� <=====")]
    [SerializeField] private Button optionExitButton;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;
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
        optionSettingButton.onClick.AddListener(() =>{
            optionSettingGroup.transform.DOLocalMove(new Vector3(0, -1200, 0), 0.4f).SetEase(selectEase).SetRelative();
        });

        optionExitButton.onClick.AddListener(() =>{
            optionSettingGroup.transform.DOLocalMove(new Vector3(0, 1200, 0), 0.4f).SetEase(selectEase).SetRelative();
        });

        loadDataButton.onClick.AddListener(() =>{
            var isData = DataManager.Inst.LoadGameData();
            if (isData)
            {
                StartCoroutine(CreateAlarmMoveDownCo());
            }
            else
            {
                StartCoroutine(CreateAlarmMoveDownCo());
            }
        });

        gameExitButton.onClick.AddListener(() =>{
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
        var alarmComponent = this.gameObject.GetComponentInChildren<AlarmUI>();
        if(alarmComponent == null) 
        {
            var alarm = CreateUIPrefab.CreateAlarmUI(this.gameObject);
            alarm.transform.localPosition = new Vector3(0, 700, 0);
            alarm.transform.DOLocalMove(new Vector3(0, -300, 0), 0.6f).SetEase(Ease.Unset)
                .SetRelative().SetAutoKill();//SetLoops(2, LoopType.Yoyo).SetAutoKill();

            yield return new WaitForSeconds(0.8f);

            alarm.transform.DOLocalMove(new Vector3(0, 300, 0), 0.3f).SetEase(Ease.Unset).SetRelative().SetAutoKill();

            yield return new WaitForSeconds(0.7f);

            Destroy(alarm.gameObject);
        }
        else
        {
            yield return null;
        }
    }
    #endregion // �ڷ�ƾ
}
