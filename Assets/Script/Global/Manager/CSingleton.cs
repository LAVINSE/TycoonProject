using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSingleton<T> : MonoBehaviour where T : CSingleton<T>
{
    #region ����
    private static T oInst = null;
    #endregion // ����

    #region Ŭ���� ������Ƽ
    public static T Inst
    {
        get
        {
            // �ν��Ͻ��� ���� ���
            if (CSingleton<T>.oInst == null)
            {
                var Gameobj = new GameObject(typeof(T).Name);
                CSingleton<T>.oInst = Gameobj.AddComponent<T>();
            }

            return CSingleton<T>.oInst;
        }
    }
    #endregion // Ŭ���� ������Ƽ

    #region �Լ�
    /** �ʱ�ȭ */
    public virtual void Awake()
    {
        if (CSingleton<T>.oInst != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Debug.Assert(CSingleton<T>.oInst == null);

        if (oInst != null)
        {
            Destroy(this.gameObject);
            return;
        }

        CSingleton<T>.oInst = this as T;
        DontDestroyOnLoad(this.gameObject);
    }
    #endregion // �Լ�

    #region Ŭ���� �Լ�
    /** �ν��Ͻ��� �����Ѵ� */
    public static T Create()
    {
        return CSingleton<T>.Inst;
    }
    #endregion // Ŭ���� �Լ�
}
