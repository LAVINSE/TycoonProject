using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFactory : MonoBehaviour
{
    #region Ŭ���� �Լ�
    // ���� ��ü�� �����Ѵ�
    public static GameObject CreateObject(string Name, GameObject ParentObject,
        Vector3 Pos, Vector3 Scale, Vector3 Rotate, bool WorldPositionStays = false)
    {
        var Gameobj = new GameObject(Name);
        Gameobj.transform.SetParent(ParentObject?.transform, WorldPositionStays);

        Gameobj.transform.localPosition = Pos;
        Gameobj.transform.localScale = Scale;
        Gameobj.transform.localEulerAngles = Rotate;

        return Gameobj;
    }

    // �纻 ��ü�� �����Ѵ�
    public static GameObject CreateCloneObj(string Name, GameObject OriginObject, GameObject ParentObject,
        Vector3 Pos, Vector3 Scale, Vector3 Rotate, bool WorldPositionStays = false)
    {
        var Gameobj = GameObject.Instantiate(OriginObject, Vector3.zero, Quaternion.identity);
        Gameobj.name = Name;
        Gameobj.transform.SetParent(ParentObject?.transform, WorldPositionStays);

        Gameobj.transform.localPosition = Pos;
        Gameobj.transform.localScale = Scale;
        Gameobj.transform.localEulerAngles = Rotate;

        return Gameobj;
    }
    #endregion Ŭ���� �Լ�

    #region ���׸� �Լ�
    // ���� ��ü�� �����Ѵ�
    public static T CreateObject<T>(string Name, GameObject ParentObject,
        Vector3 Pos, Vector3 Scale, Vector3 Rotate, bool WorldPositionStays = false) where T : Component
    {
        var Gameobj = CFactory.CreateObject(Name, ParentObject, Pos, Scale, Rotate, WorldPositionStays);

        // new�� �����Ǿ��� ������ ������Ʈ�� ����
        return Gameobj.GetComponent<T>() ?? Gameobj.AddComponent<T>();
    }

    // �纻 ��ü�� �����Ѵ�
    public static T CreateCloneObj<T>(string Name, GameObject OriginObject, GameObject ParentObject,
        Vector3 Pos, Vector3 Scale, Vector3 Rotate, bool WorldPositionStays = false) where T : Component
    {
        var Gameobj = CFactory.CreateCloneObj(Name, OriginObject, ParentObject, Pos, Scale, Rotate, WorldPositionStays);

        return Gameobj.GetComponent<T>() ?? Gameobj.AddComponent<T>();
    }
    #endregion // ���׸� �Լ�
}
