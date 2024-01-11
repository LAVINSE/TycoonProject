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
        // 스탯
        public int PlayerMaxLevel;
        public int PlayerLevel;
        public int PlayerArchitectureLevel;
        public int PlayerFriendshipLevel;
        public int PlayerFindLevel;
        public int PlayerAutoLevel;
        public int PlayerElectricLevel;
        public float PlayerLevelRequireExp;
        public int PlayerStatPoint;

        // 시간
        public float GameTimer;
    }

    #region 변수
    [Header("=====> 파일 설정 <=====")]
    [SerializeField] private string gameDataFilePath;
    [SerializeField] private string expDataTableFilePath;
    [SerializeField] private string gameDataFileName = "DataFile";
    [SerializeField] private string expDataFileName = "LevelDataFile";

    private Dictionary<int, int> ExpDict;
    private PlayerStats playerStat;
    #endregion // 변수

    #region 함수
    /** 초기화 */
    public override void Awake()
    {
        base.Awake();
        playerStat = GetComponent<PlayerStats>();
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
                // 스탯
                playerStat.PlayerMaxLevel = data.PlayerMaxLevel;
                playerStat.PlayerLevel = data.PlayerLevel;
                playerStat.PlayerArchitectureLevel = data.PlayerArchitectureLevel;
                playerStat.PlayerFriendshipLevel = data.PlayerFriendshipLevel;
                playerStat.PlayerFindLevel = data.PlayerFindLevel;
                playerStat.PlayerAutoLevel = data.PlayerAutoLevel;
                playerStat.PlayerElectricLevel = data.PlayerElectricLevel;
                playerStat.PlayerLevelRequireExp = data.PlayerLevelRequireExp;
                playerStat.PlayerStatPoint = data.PlayerStatPoint;

                // 시간
                PlayerPrefs.SetFloat("GameTimer", data.GameTimer);
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
        // 스탯
        data.PlayerMaxLevel = playerStat.PlayerMaxLevel;
        data.PlayerLevel = playerStat.PlayerLevel;
        data.PlayerArchitectureLevel = playerStat.PlayerArchitectureLevel;
        data.PlayerFriendshipLevel = playerStat.PlayerFriendshipLevel;
        data.PlayerFindLevel = playerStat.PlayerFindLevel;
        data.PlayerAutoLevel = playerStat.PlayerAutoLevel;
        data.PlayerElectricLevel = playerStat.PlayerElectricLevel;
        data.PlayerLevelRequireExp = playerStat.PlayerLevelRequireExp;
        data.PlayerStatPoint = playerStat.PlayerStatPoint;

        // 시간
        // 시간값이 있을 경우
        if (PlayerPrefs.HasKey("GameTimer"))
        {
            data.GameTimer = PlayerPrefs.GetFloat("GameTimer");
        }

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
