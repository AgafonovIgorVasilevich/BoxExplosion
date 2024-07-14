using UnityEngine;
using System;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _force = 200;
    [SerializeField] private float _radius = 3;
    [SerializeField] private int _divider = 2;

    [SerializeField] private EffectPool _effectPool;
    [SerializeField] private BoxPool _boxPool;

    public event Action<Vector3, float> NotExploded;

    public void Explode(Box box)
    {
        Vector3 position = box.transform.position;
        float splitFactor = box.Scale / _divider;
        _boxPool.Put(box);

        if (UnityEngine.Random.value >= splitFactor)
            ApplyForce(position, _force / splitFactor);
        else
            NotExploded?.Invoke(position, splitFactor);
    }

    private void ApplyForce(Vector3 position, float force)
    {
        Collider[] collisions = Physics.OverlapSphere(position, _radius);
        _effectPool.Get(position).Initialize(_effectPool);

        foreach (Collider collision in collisions)
            if (collision.TryGetComponent(out Rigidbody rigidbody))
                rigidbody.AddExplosionForce(force, position, _radius);
    }
}