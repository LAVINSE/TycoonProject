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

    [Header("=====> 불러오기 버튼 세팅 <=====")]
    [SerializeField] private Button LoadDataButton;

    [Header("=====> 게임종료 버튼 세팅 <=====")]
    [SerializeField] private Button GameExitButton;

    [Header("=====> 게임시작 버튼 세팅 <=====")]
    [SerializeField] private Button GameStarButton;

    [Header("=====> 옵션 설정창 세팅 <=====")]
    [SerializeField] private Button OptionExitButton;
    [SerializeField] private Slider BGMSlider;
    [SerializeField] private Slider SFXSlider;
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
            // 유니티 종료
            Application.Quit();
        });

        GameStarButton.onClick.AddListener(() =>{
            // 씬 이동
        });
    }
    #endregion // 함수

    #region 코루틴
    /** 알람 UI를 생성하고 움직인다 */
    private IEnumerator CreateAlarmMoveCo()
    {
        var Alarm = CreateUIPrefab.CreateAlarmUI(this.gameObject);
        Alarm.transform.localPosition = new Vector3(0, 700, 0);
        Alarm.transform.DOLocalMove(new Vector3(0, -300, 0), 0.5f).SetEase(Ease.Unset)
            .SetRelative().SetLoops(2, LoopType.Yoyo).SetAutoKill();

        yield return new WaitForSeconds(1.2f);

        Destroy(Alarm.gameObject);
    }
    #endregion // 코루틴
}
