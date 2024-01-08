using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerInfoUIMovement : MonoBehaviour, IPointerDownHandler, IDragHandler
{
    #region 변수
    [SerializeField] private Transform targetTransform;

    private Vector2 targetBeginPoint;
    private Vector2 moveBegin;
    #endregion // 변수

    #region 함수
    /** 드래그 시작 위치 */
    public void OnPointerDown(PointerEventData eventData)
    {
        targetBeginPoint = targetTransform.position;
        moveBegin = eventData.position;
    }

    /** 드래그 */
    public void OnDrag(PointerEventData eventData)
    {
        targetTransform.position = targetBeginPoint + (eventData.position - moveBegin);
    }
    #endregion // 함수
}
