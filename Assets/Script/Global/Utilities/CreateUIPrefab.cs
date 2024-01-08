using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUIPrefab : MonoBehaviour
{
    #region 변수
    #endregion // 변수

    #region 함수
    /** 알람 UI를 생성한다 */
    public static AlarmUI CreateAlarmUI(GameObject parentObject)
    {
        var alarm = CFactory.CreateCloneObj<AlarmUI>("Alarm", Resources.Load<GameObject>("Prefabs/UI/AlarmUI"),
            parentObject, Vector3.zero, Vector3.one, Vector3.zero);

        return alarm;
    }

    /** 플레이어 정보 UI를 생성한다 */
    public static PlayerInfoUI CreatePlayerInfoUI(GameObject parentObject)
    {
        var info = CFactory.CreateCloneObj<PlayerInfoUI>("PlayerInfo", Resources.Load<GameObject>("Prefabs/UI/PlayerInfoUI"),
            parentObject, Vector3.zero, Vector3.one, Vector3.zero);

        return info;
    }
    #endregion // 함수
}
