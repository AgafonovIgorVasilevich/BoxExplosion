using System.Collections.Generic;
using UnityEngine;
using System;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _force = 1000;
    [SerializeField] private float _radius = 3;
    [SerializeField] private int _divider = 2;

    [SerializeField] private EffectPool _effectPool;
    [SerializeField] private BoxPool _boxPool;

    public event Func<Vector3, float, List<Rigidbody>> Exploded;

    public void Explode(Box box)
    {
        Vector3 position = box.transform.position;
        _effectPool.Get(position).Initialize(_effectPool);
        _boxPool.Put(box);

        float splitFactor = box.Scale / _divider;

        if (UnityEngine.Random.value < splitFactor)
            ApplyForce(Exploded?.Invoke(position, splitFactor), position);
    }

    private void ApplyForce(List<Rigidbody> targets, Vector3 position)
    {
        foreach (Rigidbody target in targets)
            target.AddExplosionForce(_force, position, _radius);
    }
}