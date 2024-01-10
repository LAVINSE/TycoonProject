using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "PlayerStats", menuName = "ScriptTable Obejects / PlayerStats / PlayerStatsSO")]
public class PlayerStatsSO : ScriptableObject
{
    public PlayerArchitectureStatSO playerArchitectureStatSO;
    public PlayerFriendshipStatSO playerfriendshipStatSO;
    public PlayerFindStatSO playerFindStatSO;
    public PlayerAutoStatSO playerAutoStatSO;
    public PlayerElectricStatSO playerElectrcStatSO;
}
