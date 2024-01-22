using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestInfoSO", menuName = "ScriptTable Obejects / QuestInfo / QuestInfoSO")]
public class QuestInfoSO : ScriptableObject
{
    [System.Serializable]
    public struct QuestInfoReward
    {

    }

    public int QuestId;
    public string QuestName;
    [TextArea]
    public string QuestDescription;
    public QuestInfoReward QuestReward;
}
