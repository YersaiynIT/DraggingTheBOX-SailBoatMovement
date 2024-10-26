using UnityEngine;

public class WindManager : MonoBehaviour
{
    private Vector3 _windDirection;
    public Vector3 WindDirection => _windDirection;

    private void Update()
    {
        _windDirection = transform.forward;
        Debug.DrawRay(transform.position, WindDirection * 10, Color.blue);
    }
}
