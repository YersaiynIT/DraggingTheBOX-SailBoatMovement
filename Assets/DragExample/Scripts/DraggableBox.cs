using UnityEngine;

public class DraggableBox : MonoBehaviour, IDraggable
{
    private Vector3 _cameraPosition => Camera.main.transform.position;
    private float _distanceToCamera;

    private Rigidbody _rigidbody;

    public bool IsDragging { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (IsDragging)
        {
            _distanceToCamera = Vector3.Distance(transform.position, _cameraPosition);

            OnDrag();
        }
    }

    public void OnDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 point = ray.GetPoint(_distanceToCamera);
        transform.position = new Vector3(point.x, transform.position.y, point.z);
    }
    public void OnDragStart()
    {
        _rigidbody.isKinematic = true;
        IsDragging = true;
    }

    public void OnDragEnd()
    {
        _rigidbody.isKinematic = false;
        IsDragging = false;
    }

}
