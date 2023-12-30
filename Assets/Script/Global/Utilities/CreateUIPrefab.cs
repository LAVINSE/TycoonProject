using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateUIPrefab : MonoBehaviour
{
    #region ����
    #endregion // ����

    #region �Լ�
    /** �˶� UI�� �����Ѵ� */
    public static AlarmUI CreateAlarmUI(GameObject RootObject)
    {
        var Alarm = CFactory.CreateCloneObj<AlarmUI>("Alarm", Resources.Load<GameObject>("Prefabs/UI/AlarmUI"),
            RootObject, Vector3.zero, Vector3.one, Vector3.zero);

        return Alarm;
    }
    #endregion // �Լ�
}
