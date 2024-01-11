using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    #region 변수
    [SerializeField] private float gameTimer = 0f;
    [SerializeField] private float gametimerScale = 1.0f;
    #endregion // 변수

    #region 함수
    /** 초기화 */
    private void Update()
    {
        
    }

    /** 게임시간을 증가시킨다 */
    public void IncreaseGameTimer()
    {
        gameTimer += Time.deltaTime * gametimerScale;
    }

    /** 게임시간 속도를 설정한다 */
    public void SetGameTimerScale(float timerScale)
    {
        gametimerScale = Mathf.Max(0f, timerScale);
    }

    /** 게임 시간 불러오기 */
    public void LoadGameTimer()
    {
        // 시간값이 없을 경우
        if (!PlayerPrefs.HasKey("GameTimer")) { Debug.Log("저장된 시간이 없습니다"); return; }
        gameTimer = PlayerPrefs.GetFloat("GameTimer");
    }

    /** 게임 시간 저장 */
    public void SaveGameTimer()
    {
        PlayerPrefs.SetFloat("GameTimer", gameTimer);
    }

    /** 게임 시간 초기화 */
    public void ResetGameTimer()
    {
        gameTimer = 0f;
    }
    #endregion // 함수
}
