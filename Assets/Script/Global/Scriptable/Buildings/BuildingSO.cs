using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EBuildingType
{
    None,
}

[CreateAssetMenu(fileName = "BuildingSO", menuName = "ScriptTable Obejects / Buildings / BuildingSO")]
public class BuildingSO : ScriptableObject
{
    public EBuildingType BuildingType;
}
