using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerFindStat", menuName = "ScriptTable Obejects / PlayerStats / PlayerFindStatSO")]
public class PlayerFindStatSO : ScriptableObject
{
    // 탐색
    [TextArea]
    public string StatDesc;

    public float[] DecreasePlanetFindTime; // 행성 탐색시간 감소
    public float[] DecreaseFindGold; // 행성 탐색 골드 감소
}
