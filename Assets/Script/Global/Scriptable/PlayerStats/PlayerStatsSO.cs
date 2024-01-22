using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "PlayerStats", menuName = "ScriptTable Obejects / PlayerStats / PlayerStatsSO")]
public class PlayerStatsSO : ScriptableObject
{
    public PlayerArchitectureStatSO PlayerArchitectureStatSO;
    public PlayerFriendshipStatSO PlayerfriendshipStatSO;
    public PlayerFindStatSO PlayerFindStatSO;
    public PlayerAutoStatSO PlayerAutoStatSO;
    public PlayerElectricStatSO PlayerElectrcStatSO;
}
