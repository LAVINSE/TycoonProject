using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class AlarmUI : MonoBehaviour
{
    #region ����
    [SerializeField] private TMP_Text Alarm_Text;
    #endregion // ����

    #region ������Ƽ
    #endregion // ������Ƽ

    #region �Լ�
    /** �˶� �˾� �ʱ⼳���� �Ѵ� */
    public void Init(string AlarmText)
    {
        Alarm_Text.text = AlarmText;
    }
    #endregion // �Լ�
}
