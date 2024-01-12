using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    #region 변수
    [Header("=====> 옵션 버튼 세팅 <=====")]
    [SerializeField] private Ease selectEase;
    [SerializeField] private GameObject optionSettingGroup;
    [SerializeField] private Button optionSettingButton;

    [Header("=====> 불러오기 버튼 세팅 <=====")]
    [SerializeField] private Button loadDataButton;

    [Header("=====> 게임종료 버튼 세팅 <=====")]
    [SerializeField] private Button gameExitButton;

    [Header("=====> 게임시작 버튼 세팅 <=====")]
    [SerializeField] private Button GameStarButton;

    [Header("=====> 옵션 설정창 세팅 <=====")]
    [SerializeField] private Button optionExitButton;
    [SerializeField] private Slider bgmSlider;
    [SerializeField] private Slider sfxSlider;
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
            // 유니티 종료
            Application.Quit();
        });

        GameStarButton.onClick.AddListener(() =>{
            // 씬 이동
            LoadingScene.LoadScene("MainGameScene");
        });
    }
    #endregion // 함수

    #region 코루틴
    /** 알람 UI를 생성하고 움직인다 */
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
    #endregion // 코루틴
}
