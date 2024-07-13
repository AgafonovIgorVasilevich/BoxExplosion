using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Box : MonoBehaviour
{
    [SerializeField] private float _explosionForce = 300;
    [SerializeField] private float _explosionRadius = 3;
    [SerializeField] private int _childCount = 2;
    [SerializeField] private Effect _effect;

    public float _splitFactor;
    public float _scaleFactor;
    private BoxPool _pool;

    public void Initialize(BoxPool pool, float splitFactor, float scaleFactor)
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV();
        _splitFactor = splitFactor;
        _scaleFactor = scaleFactor;
        _pool = pool;
    }

    private void OnMouseDown() => Explode();

    private void Explode()
    {
        _effect.gameObject.SetActive(true);
        _splitFactor /= 2;
        _scaleFactor /= 2;
        _pool.Put(this);

        if (Random.value >= _splitFactor)
            return;

        foreach (Rigidbody child in CreateChildren())
            child.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }

    private List<Rigidbody> CreateChildren()
    {
        List<Rigidbody> children = new List<Rigidbody>();
        Box child;

        for (int i = 0; i < _childCount; i++)
        {
            child = _pool.Get(_splitFactor, _scaleFactor);
            child.transform.position = transform.position;
            children.Add(child.GetComponent<Rigidbody>());
        }

        return children;
    }
}