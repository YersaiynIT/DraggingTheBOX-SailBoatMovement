using UnityEngine;

public class ExplosionShooter : IShooter
{
    private float _explosionForce;
    private float _explosionRadius;
    private float _upwardsModifier;

    public ExplosionShooter(float explosionForce, float explosionRadius, float upwardsModifier)
    {
        _explosionForce = explosionForce;
        _explosionRadius = explosionRadius;
        _upwardsModifier = upwardsModifier;
    }

    public void Shoot()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            Vector3 explosionPoint = hitInfo.point;

            Collider[] colliders = Physics.OverlapSphere(explosionPoint, _explosionRadius);

            foreach (Collider nearbyObject in colliders)
            {
                Rigidbody rigidbody = nearbyObject.GetComponent<Rigidbody>();

                if (rigidbody != null)
                {
                    rigidbody.AddExplosionForce(_explosionForce, explosionPoint, _explosionRadius, _upwardsModifier);
                }
            }
        }
    }
}
