using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class CameraMoveCursor : MonoBehaviour
{
    #region 변수
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float zoomSpeed;
    [SerializeField] private float dragSpeed;
    [SerializeField] private float minCamSize;
    [SerializeField] private float maxCamSize;
    [SerializeField] private SpriteRenderer mapRenderer;

    private bool mouseLeftClick;
    private bool mouseLeftClickDown;
    private float zoomValue;
    private float mapMinX;
    private float mapMinY;
    private float mapMaxX;
    private float mapMaxY;
    private Vector3 dragOrigin;
    #endregion // 변수

    #region 함수
    /** 초기화 */
    private void Awake()
    {
        // 맵 크기 계산
        MapSizeCaculate();
    }

    /** 초기화 => 상태를 갱신한다 */
    private void Update()
    {
        // 카메라 입력처리
        CameraInput();
        // 카메라 드래그
        CameraDrag();
        // 카메라 확대,축소
        CameraZoomInOut();
    }

    /** 카메라 입력처리 */
    private void CameraInput()
    {
        zoomValue = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        mouseLeftClick = Input.GetMouseButton(0);
        mouseLeftClickDown = Input.GetMouseButtonDown(0);
    }

    /** 카메라를 드래그 한다 */
    private void CameraDrag()
    {
        // 마우스 왼쪽 클릭을 했을 경우 (한번)
        if (mouseLeftClickDown)
        {
            // 현재 위치 저장
            dragOrigin = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        }

        // 마우스 왼쪽 클릭을 했을 경우 (지속)
        if (mouseLeftClick)
        {
            // 원래 위치와 변경된 위치의 차이
            Vector3 difference = dragOrigin - mainCamera.ScreenToWorldPoint(Input.mousePosition);

            // 카메라 차이값 만큼 이동
            mainCamera.transform.position = LimitMoveCamera(mainCamera.transform.position + difference * dragSpeed);
        }
    }

    /** 카메라를 확대,축소한다 */
    public void CameraZoomInOut()
    {
        if(zoomValue == 0) { return; }
        // 크기 계산
        float newSize = mainCamera.orthographicSize - zoomValue;

        // 축소 제한
        mainCamera.orthographicSize = Mathf.Clamp(newSize, minCamSize, maxCamSize);

        // 카메라 움직임 제한
        mainCamera.transform.position = LimitMoveCamera(mainCamera.transform.position);
    }

    /** 맵 최대,최소 계산 */
    private void MapSizeCaculate()
    {
        // 맵 SpriteRenderer의 절반 값 구하기
        mapMinX = mapRenderer.transform.position.x - mapRenderer.bounds.size.x / 2f;
        mapMaxX = mapRenderer.transform.position.x + mapRenderer.bounds.size.x / 2f;

        mapMinY = mapRenderer.transform.position.y - mapRenderer.bounds.size.y / 2f;
        mapMaxY = mapRenderer.transform.position.y + mapRenderer.bounds.size.y / 2f;
    }

    /** 카메라가 움직일 수 있는 위치 계산 */
    private Vector3 LimitMoveCamera(Vector3 targetPosition)
    {
        // 절반 높이, 넓이 구하기
        float cameraHeight = mainCamera.orthographicSize;
        float cameraWidth = mainCamera.orthographicSize * mainCamera.aspect;

        // 최대, 최소 값 구하기
        float minX = mapMinX + cameraWidth;
        float maxX = mapMaxX - cameraWidth;
        float minY = mapMinY + cameraHeight;
        float maxY = mapMaxY - cameraHeight;
        
        // 카메라 제한된 범위 값
        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

        // 값 반환
        return new Vector3(newX, newY, targetPosition.z);
    }
    #endregion // 함수
}
