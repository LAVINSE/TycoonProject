using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoUI : MonoBehaviour
{
    #region 변수
    [SerializeField] private Button closeButton;
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
        closeButton.onClick.AddListener(() =>
        {
            this.gameObject.SetActive(false);
        });
    }
    #endregion // 함수
}
