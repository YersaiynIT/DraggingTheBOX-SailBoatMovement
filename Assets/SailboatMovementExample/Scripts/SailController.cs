using UnityEngine;

public class SailController : MonoBehaviour
{
    private const float _minSailRotate = -90f;
    private const float _maxSailRotate = 90f;

    [SerializeField] private float _rotationSpeed;
    private float _currentSailAngle = 0f;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _currentSailAngle -= _rotationSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _currentSailAngle += _rotationSpeed * Time.deltaTime;
        }

        _currentSailAngle = Mathf.Clamp(_currentSailAngle, _minSailRotate, _maxSailRotate);

        transform.localEulerAngles = new Vector3(0f, _currentSailAngle, 0f);
    }
}
