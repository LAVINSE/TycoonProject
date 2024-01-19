using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** 모든 건물이 지니고 있는 스크립트 */
public class Building : MonoBehaviour
{
    public enum EBuildingType
    {
        None,
    }

    #region 변수
    [SerializeField] private EBuildingType type;
    #endregion // 변수

    #region 함수
    #endregion // 함수
}
