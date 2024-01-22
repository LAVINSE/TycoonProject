using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerElectricStat", menuName = "ScriptTable Obejects / PlayerStats / PlayerElectricStatSO")]
public class PlayerElectricStatSO : ScriptableObject
{
    // 전기
    [TextArea]
    public string StatDesc;

    public float[] DecreaseElectric; // 전기 요구량 감소
}
