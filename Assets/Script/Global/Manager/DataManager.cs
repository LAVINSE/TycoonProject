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
    #region 변수
    [Header("=====> 파일 설정 <=====")]
    [SerializeField] private string GameDataFilePath;
    #endregion // 변수

    #region 함수
    /** 초기화 */
    private void Start()
    {
        GameDataFilePath = Path.Combine(Application.dataPath + "/SaveData/", "DataFile");
        // 데이터 로드
        LoadGameData();
    }

    /** 유니티가 종료될때 */
    private void OnApplicationQuit()
    {
        SaveGameData();
    }

    /** 데이터 로드 */
    public bool LoadGameData()
    {
        SaveData Data = new SaveData();

        if (!File.Exists(GameDataFilePath)){
            Debug.Log(" 불러올 데이터가 없음 ");
            return false;
        }
        else{
            string LoadJson = File.ReadAllText(GameDataFilePath);
            Data = JsonUtility.FromJson<SaveData>(LoadJson);

            if(Data != null){
                // 인게임데이터 = Data.데이터;
            }

            Debug.Log(" 데이터를 불러왔습니다. ");
            return true;
        }
    }

    /** 데이터 저장 */
    public void SaveGameData()
    {
        SaveData Data = new SaveData();

        // Data.데이터 = 인게임 데이터

        string Json = JsonUtility.ToJson(Data, true);

        File.WriteAllText(GameDataFilePath, Json);
    }
    #endregion // 함수
}
