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

    #region 변수
    [Header("=====> 파일 설정 <=====")]
    [SerializeField] private string gameDataFilePath;
    [SerializeField] private string expDataTableFilePath;
    [SerializeField] private string gameDataFileName = "DataFile";
    [SerializeField] private string expDataFileName = "LevelDataFile";

    private Dictionary<int, int> ExpDic;
    #endregion // 변수

    #region 함수
    /** 초기화 */
    private void Start()
    {
        gameDataFilePath = Path.Combine(Application.dataPath + "/SaveData/", gameDataFileName);
        expDataTableFilePath = Path.Combine(Application.dataPath + "/SaveData/", expDataFileName);

        // 게임 데이터 로드
        LoadGameData();
        // 경험치 데이터 로드
        LoadExpTable();
    }

    /** 유니티가 종료될때 */
    private void OnApplicationQuit()
    {           
        SaveGameData();
    }

    /** 게임 데이터 로드 */
    public bool LoadGameData()
    {
        SaveData data = new SaveData();

        if (!File.Exists(gameDataFilePath))
        {
            Debug.Log(" 불러올 데이터가 없음 ");
            return false;
        }
        else
        {
            string loadJson = File.ReadAllText(gameDataFilePath);
            data = JsonUtility.FromJson<SaveData>(loadJson);

            if(data != null)
            {
                // 인게임 데이터 = Data.데이터
            }

            Debug.Log(" 데이터를 불러왔습니다. ");
            return true;
        }
    }

    /** 게임 데이터 저장 */
    public void SaveGameData()
    {
        SaveData data = new SaveData();

        // Data.데이터 = 인게임 데이터

        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(gameDataFilePath, json);
    }

    /** Exp 데이터 로드 */
    public void LoadExpTable()
    {
        ExpDic = new Dictionary<int, int>();

        if (File.Exists(expDataTableFilePath))
        {
            string json = File.ReadAllText(expDataTableFilePath);
            ExpDic = JsonConvert.DeserializeObject<Dictionary<int, int>>(json);
            Debug.Log(" 경험치 테이블을 불러왔습니다 ");
        }
        else
        {
            Debug.Log("경험치 테이블 없음");
        }
    }

    /** 레벨별 경험치 요구량 가져오기 */
    public int GetExpForLevel(int level)
    {
        if (ExpDic.ContainsKey(level))
        {
            return ExpDic[level];
        }

        return 0;
    }
    #endregion // 함수
}
