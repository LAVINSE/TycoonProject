using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    
}

public class DataManager : CSingleton<DataManager>
{
    #region ����
    [Header("=====> ���� ���� <=====")]
    [SerializeField] private string GameDataFilePath;
    #endregion // ����

    #region �Լ�
    /** �ʱ�ȭ */
    private void Start()
    {
        GameDataFilePath = Path.Combine(Application.dataPath + "/SaveData/", "DataFile");
        // ������ �ε�
        LoadGameData();
    }

    /** ����Ƽ�� ����ɶ� */
    private void OnApplicationQuit()
    {
        SaveGameData();
    }

    /** ������ �ε� */
    public bool LoadGameData()
    {
        SaveData Data = new SaveData();

        if (!File.Exists(GameDataFilePath)){
            Debug.Log(" �ҷ��� �����Ͱ� ���� ");
            return false;
        }
        else{
            string LoadJson = File.ReadAllText(GameDataFilePath);
            Data = JsonUtility.FromJson<SaveData>(LoadJson);

            if(Data != null){
                // �ΰ��ӵ����� = Data.������;
            }

            Debug.Log(" �����͸� �ҷ��Խ��ϴ�. ");
            return true;
        }
    }

    /** ������ ���� */
    public void SaveGameData()
    {
        SaveData Data = new SaveData();

        // Data.������ = �ΰ��� ������

        string Json = JsonUtility.ToJson(Data, true);

        File.WriteAllText(GameDataFilePath, Json);
    }
    #endregion // �Լ�
}
