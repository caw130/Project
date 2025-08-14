using DG.Tweening;
using UnityEngine;

/// <summary>
/// 게임 내부에 있는 드래그, 클릭, 호버 등을 관리하는 스크립트.
/// 절대로 직접적인 연산은 넣지 말기!!
/// </summary>
public class DragManager : MonoBehaviour
{
    [Header("컴포넌트")]
    [SerializeField] LayerMask _canClick;   // 클릭이 가능한 레이어 인식
    [SerializeField] LayerMask _canDrag;    // 드래그가 가능한 레이어 인식
    [SerializeField] LayerMask _canHover;   // 마우스를 인식하는 레이어
    [SerializeField] Camera _mainCamera;    // 메인 카메라

    [Header("마우스 관련 참조")]
    [SerializeField] float _mousethreshold; // 마우스의 최소 이동 거리를 정하는 변수

    // 데이터 처리 할 오브젝트들
    ICanClick _clickTarget;                 // 클릭한 오브젝트를 받아옴
    ICanDrag _dragTarget;                   // 드래그한 오브젝트를 받아옴
    ICanHover _previousHoverTarget;         // 아까 까지 호버 하던 대상 오브젝트
    ICanHover _currentHoverTarget;          // 현재 마우스를 놓은 오브젝트를 받아옴

    // 내가 필요한 것들
    LayerMask _interactableLayers;          // 모든 레이어 마스크를 받아옴
    Vector2 _worldPosition;                 // 현재 내 마우스의 위치를 저장하는 변수
    Vector2 _mousePosition;                 // 마우스를 클릭 하면, 클릭했던 위치를 받아오는 변수
    RaycastHit2D _hit;                      // 현재 마우스가 찍는 대상을 받아오는 변수

    [SerializeField] bool _isDragging;      // 현재 드레그 중인지 확인
    private void Start()
    {
        _interactableLayers = _canClick | _canDrag | _canHover;
    }
    private void Update()
    {
        _worldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        _hit = Physics2D.Raycast(_worldPosition, Vector2.zero, Mathf.Infinity, _interactableLayers);

        // 내가 드래그를 하지 않는다면
        if (!_isDragging)
        {
            Hover();
        }

        // 드레그 및 클릭 동작
        DragAndClick();
    }

    /// <summary>
    /// 마우스 클릭및 드래그 기능
    /// </summary>
    void DragAndClick()
    {
        // 마우스를 눌렀을 때 중
        if (Input.GetMouseButtonDown(0))
        {

            _mousePosition = _worldPosition;
            // 레이캐스트를 쏴 드래그가 가능한 물체를 받아옴

            if (_hit.collider != null)
            {
                var checkTarget = _hit.collider.GetComponent<ICanDrag>();
                // 해당 물체의 ICanDrag를 받아옴
                if (checkTarget != null && checkTarget.Dragable)
                    _dragTarget = _hit.collider.GetComponent<ICanDrag>();

                _clickTarget = _hit.collider.GetComponent<ICanClick>();
            }
                
        }
        // 만약 내가 드래그 중이고, 마우스를 꾹 누르고 있다면
        if (Input.GetMouseButton(0))
        {
            if (!_isDragging && _dragTarget != null && Vector2.Distance(_mousePosition, _worldPosition) > _mousethreshold)
            {
                _isDragging = true;
                _clickTarget = null;
                _dragTarget.OnBeginDrag();
            }

            if (_isDragging)
            {
                // 해당 오브젝트에게 위치를 보어, OnDrag 실행
                _dragTarget.OnDrag(_worldPosition);
            }

        }

        // 마우스에서 손을 뗏을때
        if (Input.GetMouseButtonUp(0))
        {
            // A. 내가 드래그 중이였다면
            if (_isDragging)
            {
                // 드래그 타겟이 있다면
                if (_dragTarget != null)
                {
                    // 해당 타겟을 놓고
                    _dragTarget.OnDrop();
                }
            }

            // B. 그게 아니라면
            else if (_clickTarget != null && _clickTarget.Clickable)
            {
                // 가져온 오브젝트에 클릭 신호 보냄
                _clickTarget.OnClicked();
            }

            _isDragging = false;
            _dragTarget = null;
            _clickTarget = null;
        }
    }

    void Hover()
    {
        _currentHoverTarget = (_hit.collider != null) ? _hit.collider.GetComponent<ICanHover>() : null;
        if (_currentHoverTarget != _previousHoverTarget)
        {

            if (_previousHoverTarget as MonoBehaviour )
            {
                
                _previousHoverTarget.HoverOut();
                
            }
            
            if (_currentHoverTarget as MonoBehaviour && _currentHoverTarget.Hoverable)
            {
                _currentHoverTarget.HoverIn();
            }
        }
        _previousHoverTarget = _currentHoverTarget;
    }

}
