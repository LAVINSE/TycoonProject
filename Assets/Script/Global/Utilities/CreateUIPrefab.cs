using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUIPrefab : MonoBehaviour
{
    #region 변수
    #endregion // 변수

    #region 함수
    /** 알람 UI를 생성한다 */
    public static AlarmUI CreateAlarmUI(GameObject RootObject)
    {
        var Alarm = CFactory.CreateCloneObj<AlarmUI>("Alarm", Resources.Load<GameObject>("Prefabs/UI/AlarmUI"),
            RootObject, Vector3.zero, Vector3.one, Vector3.zero);

        return Alarm;
    }
    #endregion // 함수
}
