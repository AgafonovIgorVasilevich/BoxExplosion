using System.Collections.Generic;
using UnityEngine;

public class BoxPool : MonoBehaviour
{
    [SerializeField] private Box _template;

    private Queue<Box> _pool = new Queue<Box>();

    public Box Get(float splitFactor, float scaleFactor)
    {
        Box instance;

        if (_pool.Count == 0)
            instance = Instantiate(_template, transform);
        else
            instance = _pool.Dequeue();

        instance.transform.localScale = Vector3.one * scaleFactor;
        instance.Initialize(this, splitFactor, scaleFactor);
        instance.gameObject.SetActive(true);
        return instance;
    }

    public void Put(Box instance)
    {
        instance.transform.parent = transform;
        instance.gameObject.SetActive(false);
        _pool.Enqueue(instance);
    }
}