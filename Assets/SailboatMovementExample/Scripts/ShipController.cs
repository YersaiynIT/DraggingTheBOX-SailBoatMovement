using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField] private SailController _sailController;
    [SerializeField] private WindManager _windManager;

    [SerializeField] private float _shipSpeed;
    [SerializeField] private float _rotationSpeed;

    private Vector3 _windDirection;
    private Vector3 _sailDirection;

    private void Update()
    {
        ProcessRotateShip();

        SetDirectionWindAndSail();

        if (CanMoveShip() == true)
            MoveShip();
    }

    private void ProcessRotateShip()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up, -_rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
        }
    }

    private void MoveShip()
    {
        float windSailDot = Vector3.Dot(_windDirection, _sailDirection);

        Vector3 moveDirection = transform.forward * windSailDot * _shipSpeed * Time.deltaTime;

        transform.Translate(moveDirection, Space.World);
    }

    private bool CanMoveShip()
    {
        float windSailDot = Vector3.Dot(_windDirection, _sailDirection);

        if (windSailDot <= 0) return false;

        float shipSailDot = Vector3.Dot(transform.forward, _sailDirection);

        if (Mathf.Abs(shipSailDot) < 0.1f) return false;
        if (shipSailDot < 0) return false;

        float shipWindDot = Vector3.Dot(transform.forward, _windDirection);

        if (shipWindDot < 0) return false;

        return true;
    }

    private void SetDirectionWindAndSail()
    {
        _windDirection = _windManager.WindDirection.normalized;
        _sailDirection = -_sailController.transform.forward.normalized; 
    }
}
