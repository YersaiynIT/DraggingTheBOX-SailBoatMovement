using System.Collections.Generic;
using UnityEngine;

public class Shooter
{
    private Queue<IShooter> _shooters;

    private IShooter _currentShooter;

    public Shooter()
    {
        _shooters = new Queue<IShooter>();

        _shooters.Enqueue(new ExplosionShooter(500f, 5f, 1f));
        _shooters.Enqueue(new ExplosionShooter(1500f, 8f, 10f));

        _currentShooter = _shooters.Dequeue();
    }

    public void SwitchShooter()
    {
        _shooters.Enqueue(_currentShooter);

        _currentShooter = _shooters.Dequeue();
    }

    public void Shoot() => _currentShooter.Shoot();
}
