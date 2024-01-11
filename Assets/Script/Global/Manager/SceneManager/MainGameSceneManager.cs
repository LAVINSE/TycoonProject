using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameSceneManager : CSceneManager
{
    #region 변수
    [SerializeField] private GameObject playerObject;
    #endregion // 변수

    #region 프로퍼티
    public override string SceneName => CDefine.MainGameScene;
    #endregion // 프로퍼티

    #region 함수
    public override void Awake()
    {
        base.Awake();
        PlayerObject = playerObject;
        TimerManagerComponent = GetComponent<TimerManager>();
    }
    #endregion // 함수
}
