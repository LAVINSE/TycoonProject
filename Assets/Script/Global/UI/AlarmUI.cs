using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class AlarmUI : MonoBehaviour
{
    #region 변수
    [SerializeField] private TMP_Text Alarm_Text;
    #endregion // 변수

    #region 프로퍼티
    #endregion // 프로퍼티

    #region 함수
    /** 알람 팝업 초기설정을 한다 */
    public void Init(string AlarmText)
    {
        Alarm_Text.text = AlarmText;
    }
    #endregion // 함수
}
