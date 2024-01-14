using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraMoveCursor : MonoBehaviour
{
    #region 변수
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float dragSpeed;
    [SerializeField] private float zoomValue;
    [SerializeField] private float minCamSize;
    [SerializeField] private float maxCamSize;

    private Vector3 dragOrigin;
    #endregion // 변수

    #region 함수
    /** 초기화 => 상태를 갱신한다 */
    private void Update()
    {
        CameraDrag();
    }

    /** 카메라를 드래그 한다 */
    private void CameraDrag()
    {
        // 마우스 왼쪽 클릭을 했을 경우 (한번)
        if (Input.GetMouseButtonDown(0))
        {
            // 현재 위치 저장
            dragOrigin = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }

        // 마우스 왼쪽 클릭을 했을 경우 (지속)
        if (Input.GetMouseButton(0))
        {
            // 원래 위치와 변경된 위치의 차이
            Vector3 difference = dragOrigin - mainCamera.ScreenToWorldPoint(Input.mousePosition);

            // 카메라 차이값 만큼 이동
            mainCamera.transform.position += difference * dragSpeed;
        }
    }

    /** 카메라를 확대한다 */
    public void ZoomIn()
    {
        float newSize = mainCamera.orthographicSize - zoomValue;
        mainCamera.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);
    }

    /** 카메라를 축소한다 */
    public void ZoomOut()
    {
        float newSize = mainCamera.orthographicSize + zoomValue;
        mainCamera.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);
    }
    #endregion // 함수
}
