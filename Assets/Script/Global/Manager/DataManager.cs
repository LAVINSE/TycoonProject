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
        public int PlayerMaxLevel;
        public int PlayerLevel;
        public int PlayerArchitectureLevel;
        public int PlayerFriendshipLevel;
        public int PlayerFindLevel;
        public int PlayerAutoLevel;
        public int PlayerElectricLevel;
        public float PlayerLevelRequireExp;
        public int PlayerStatPoint;
    }

    #region 변수
    [Header("=====> 파일 설정 <=====")]
    [SerializeField] private string gameDataFilePath;
    [SerializeField] private string expDataTableFilePath;
    [SerializeField] private string gameDataFileName = "DataFile";
    [SerializeField] private string expDataFileName = "LevelDataFile";

    private Dictionary<int, int> ExpDict;
    #endregion // 변수

    #region 프로퍼티
    public PlayerStats PlayerStat;
    #endregion // 프로퍼티

    #region 함수
    /** 초기화 */
    public override void Awake()
    {
        base.Awake();
        PlayerStat = GetComponent<PlayerStats>();
    }

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

            // 저장
            if(data != null)
            {
                // 인게임 데이터 = Data.데이터
                PlayerStat.PlayerMaxLevel = data.PlayerMaxLevel;
                PlayerStat.PlayerLevel = data.PlayerLevel;
                PlayerStat.PlayerArchitectureLevel = data.PlayerArchitectureLevel;
                PlayerStat.PlayerFriendshipLevel = data.PlayerFriendshipLevel;
                PlayerStat.PlayerFindLevel = data.PlayerFindLevel;
                PlayerStat.PlayerAutoLevel = data.PlayerAutoLevel;
                PlayerStat.PlayerElectricLevel = data.PlayerElectricLevel;
                PlayerStat.PlayerLevelRequireExp = data.PlayerLevelRequireExp;
                PlayerStat.PlayerStatPoint = data.PlayerStatPoint;
            }

            Debug.Log(" 데이터를 불러왔습니다. ");
            return true;
        }
    }

    /** 게임 데이터 저장 */
    public void SaveGameData()
    {
        SaveData data = new SaveData();

        // 불러오기
        // Data.데이터 = 인게임 데이터
        data.PlayerMaxLevel = PlayerStat.PlayerMaxLevel;
        data.PlayerLevel = PlayerStat.PlayerLevel;
        data.PlayerArchitectureLevel = PlayerStat.PlayerArchitectureLevel;
        data.PlayerFriendshipLevel = PlayerStat.PlayerFriendshipLevel;
        data.PlayerFindLevel = PlayerStat.PlayerFindLevel;
        data.PlayerAutoLevel = PlayerStat.PlayerAutoLevel;
        data.PlayerElectricLevel = PlayerStat.PlayerElectricLevel;
        data.PlayerLevelRequireExp = PlayerStat.PlayerLevelRequireExp;
        data.PlayerStatPoint = PlayerStat.PlayerStatPoint;

        string json = JsonUtility.ToJson(data, true);

        File.WriteAllText(gameDataFilePath, json);
    }

    /** Exp 데이터 로드 */
    public void LoadExpTable()
    {
        ExpDict = new Dictionary<int, int>();

        if (File.Exists(expDataTableFilePath))
        {
            string json = File.ReadAllText(expDataTableFilePath);
            ExpDict = JsonConvert.DeserializeObject<Dictionary<int, int>>(json);
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
        if (ExpDict.ContainsKey(level))
        {
            return ExpDict[level];
        }

        return 0;
    }
    #endregion // 함수
}
