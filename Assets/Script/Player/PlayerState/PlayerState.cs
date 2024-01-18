using PlayerStateFSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public enum EPlayerStateType
    {
        Wait,
    }

    #region 변수
    private bool isMouseLeftClickDown;
    private StateFSM[] stateArray;
    private Camera mainCamera;
    private Ray ray;
    private RaycastHit rayHit;
    #endregion // 변수

    #region 프로퍼티
    public StateFSM currentState { get; private set; }
    #endregion // 프로퍼티

    #region 함수
    /** 초기화 */
    private void Awake()
    {
        InitState();
    }

    /** 초기화 => 상태를 갱신한다 */
    private void Update()
    {
        // 플레이어 입력처리
        PlayerInput();
        // 건물 클릭
        ClickObject();

        // TODO : 상태 추가 예정 
        // 상태가 존재할 경우, 현재 상태가 ?? 가 아닐경우
        /*
        if(currentState != null && currentState != stateArray[(int)EplayerState.?])
        {

        }
        */

        // 상태가 존재할 경우
        if (currentState != null)
        {
            // 상태 업데이트 호출
            currentState.PlayerStateUpdate();
        }
    }

    /** 상태 초기 설정 */
    private void InitState()
    {
        // 상태 저장공간
        stateArray = new StateFSM[10];

        // 초기 상태
        stateArray[(int)EPlayerStateType.Wait] = new PlayerStateWait();
        currentState = stateArray[(int)EPlayerStateType.Wait];
    }

    /** 플레이어 입력처리 */
    private void PlayerInput()
    {
        isMouseLeftClickDown = Input.GetMouseButtonDown(0);
    }

    /** 건물을 클릭한다 */
    private void ClickObject()
    {
        // 마우스 왼쪽 버튼을 눌렀을 때
        if(isMouseLeftClickDown)
        {
            // 마우스 위치로부터 Ray 생성
            ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out rayHit, Mathf.Infinity))
            {
                // TODO : 태그 추가 예정 (건물)
                if (rayHit.transform.CompareTag("asdf"))
                {
                    // TODO : 행동
                }
            }
        }
    }

    /** 상태를 변경한다 */
    public void ChangeState(EPlayerStateType NewState)
    {
        if (stateArray[(int)NewState] == null) { return; }

        if (currentState != null)
        {
            currentState.PlayerStateExit();
        }

        currentState = stateArray[(int)NewState];
        currentState.PlayerStateEnter();
    }
    #endregion // 함수
}
