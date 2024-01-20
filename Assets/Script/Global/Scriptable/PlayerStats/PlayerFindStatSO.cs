using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerFindStat", menuName = "ScriptTable Obejects / PlayerStats / PlayerFindStatSO")]
public class PlayerFindStatSO : ScriptableObject
{
    // 탐색
    [TextArea]
    public string statDesc;

    public float[] decreasePlanetFindTime; // 행성 탐색시간 감소
    public float[] decreaseFindGold; // 행성 탐색 골드 감소
}
