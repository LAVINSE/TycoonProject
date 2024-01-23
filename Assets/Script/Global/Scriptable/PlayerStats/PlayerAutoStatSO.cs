using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAutoStat", menuName = "ScriptTable Obejects / PlayerStats / PlayerAutoStatSO")]
public class PlayerAutoStatSO : ScriptableObject
{
    // 자동화
    [TextArea]
    public string StatDesc;

    public float[] IncreaseGetResource; // 자원 획득량 증가
}