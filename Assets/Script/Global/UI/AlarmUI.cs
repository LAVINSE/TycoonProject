using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class AlarmUI : MonoBehaviour
{
    #region ����
    [SerializeField] private TMP_Text alarmText;
    #endregion // ����

    #region ������Ƽ
    #endregion // ������Ƽ

    #region �Լ�
    /** �˶� �˾� �ʱ⼳���� �Ѵ� */
    public void Init(string alarmText)
    {
        this.alarmText.text = alarmText;
    }
    #endregion // �Լ�
}
