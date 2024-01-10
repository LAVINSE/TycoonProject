using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerArchitectureStat", menuName = "ScriptTable Obejects / PlayerStats / PlayerArchitectureStatSO")]
public class PlayerArchitectureStatSO : ScriptableObject
{
    // 건축
    [TextArea]
    public string statDesc;

    public float[] decreaseCraftingMaterials;
    public float[] decreaseCraftingTime;
    public float[] decreaseCraftingGold;
}
