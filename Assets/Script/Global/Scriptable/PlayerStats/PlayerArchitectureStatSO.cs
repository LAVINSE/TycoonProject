using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerArchitectureStat", menuName = "ScriptTable Obejects / PlayerStats / PlayerArchitectureStatSO")]
public class PlayerArchitectureStatSO : ScriptableObject
{
    // 건축
    [TextArea]
    public string StatDesc;

    public float[] DecreaseCraftingMaterials; // 제작 재료 감소
    public float[] DecreaseCraftingTime; // 제작 시간 감소
    public float[] DecreaseCraftingGold; // 제작 비용 감소
}
