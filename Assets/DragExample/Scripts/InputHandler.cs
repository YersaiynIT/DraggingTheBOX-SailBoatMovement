using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private const int LeftMouseBotton = 0;
    private const int RightMouseButton = 1;
    private const KeyCode SwitchShooterButton = KeyCode.Q;

    private Shooter _shooter;
    private RaycastHandler _raycastHandler;

    private IDraggable _currentDraggableObject;

    private void Awake()
    {
        _shooter = new Shooter();
        _raycastHandler = new RaycastHandler();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(RightMouseButton))
            _shooter.Shoot();
            
        if (Input.GetKeyDown(SwitchShooterButton))
            _shooter.SwitchShooter();

        if (Input.GetMouseButtonDown(LeftMouseBotton))
        {
            _currentDraggableObject = _raycastHandler.GetDraggableObject();

            if (_currentDraggableObject != null)
                _currentDraggableObject.OnDragStart();
        }

        if (Input.GetMouseButtonUp(LeftMouseBotton))
        {
            if (_currentDraggableObject != null)
            {
                _currentDraggableObject.OnDragEnd();
            }
        }
    }


}
