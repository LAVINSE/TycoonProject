using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerFriendshipStat", menuName = "ScriptTable Obejects / PlayerStats / PlayerFriendshipStatSO")]
public class PlayerFriendshipStatSO : ScriptableObject
{
    // 호감도
    [TextArea]
    public string statDesc;

    public float[] decreaseEmigrationTime; // 이주 시간 감소
    public float[] increaseFriendship; // NPC 호감도 증가
}
