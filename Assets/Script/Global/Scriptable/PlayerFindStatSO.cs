using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerFindStat", menuName = "ScriptTable Obejects / PlayerStats / PlayerFindStatSO")]
public class PlayerFindStatSO : ScriptableObject
{
    // 탐색
    [TextArea]
    public string statDesc;

    public float[] decreasePlanetFindTime;
    public float[] decreaseFindGold;
}
