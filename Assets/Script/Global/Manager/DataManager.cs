using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class DataManager : CSingleton<DataManager>
{
    [System.Serializable]
    public class SaveData
    {
        
    }

    #region ����
    [Header("=====> ���� ���� <=====")]
    [SerializeField] private string gameDataFilePath;
    [SerializeField] private string expDataTableFilePath;
    [SerializeField] private string gameDataFileName = "DataFile";
    [SerializeField] private string expDataFileName = "LevelDataFile";

    private Dictionary<int, int> ExpDic;
    #endregion // ����

    #region �Լ�
    /** �ʱ�ȭ */
    private void Start()
    {
        gameDataFilePath = Path.Combine(Application.dataPath + "/SaveData/", gameDataFileName);
        expDataTableFilePath = Path.Combine(Application.dataPath + "/SaveData/", expDataFileName);

        // ���� ������ �ε�
        LoadGameData();
        // ����ġ ������ �ε�
        LoadExpTable();
    }

    /** ����Ƽ�� ����ɶ� */
    private void OnApplicationQuit()
    {           
        SaveGameData();
    }

    /** ���� ������ �ε� */
    public bool LoadGameData()
    {
        SaveData data = new SaveData();

        if (!File.Exists(gameDataFilePath))
        {
            Debug.Log(" �ҷ��� �����Ͱ� ���� ");
            return false;
        }
        else
        {
            string loadJson = File.ReadAllText(gameDataFilePath);
            data = JsonUtility.FromJson<SaveData>(loadJson);

            if(data != null)
            {
                // �ΰ��� ������ = Data.������
            }

            Debug.Log(" �����͸� �ҷ��Խ��ϴ�. ");
            return true;
        }
    }

    /** ���� ������ ���� */
    public void SaveGameData()
    {
        SaveData data = new SaveData();

        // Data.������ = �ΰ��� ������

        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(gameDataFilePath, json);
    }

    /** Exp ������ �ε� */
    public void LoadExpTable()
    {
        ExpDic = new Dictionary<int, int>();

        if (File.Exists(expDataTableFilePath))
        {
            string json = File.ReadAllText(expDataTableFilePath);
            ExpDic = JsonConvert.DeserializeObject<Dictionary<int, int>>(json);
            Debug.Log(" ����ġ ���̺��� �ҷ��Խ��ϴ� ");
        }
        else
        {
            Debug.Log("����ġ ���̺� ����");
        }
    }

    /** ������ ����ġ �䱸�� �������� */
    public int GetExpForLevel(int level)
    {
        if (ExpDic.ContainsKey(level))
        {
            return ExpDic[level];
        }

        return 0;
    }
    #endregion // �Լ�
}
