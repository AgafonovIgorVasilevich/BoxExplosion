using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Exploder _exploder;
    [SerializeField] private BoxPool _pool;

    [SerializeField] private float _startScale = 2;
    [SerializeField] private int _minCount = 2;
    [SerializeField] private int _maxCount = 6;

    private void OnEnable() => _exploder.Exploded += CreateBoxes;

    private void OnDisable() => _exploder.Exploded -= CreateBoxes;

    private void Start() => CreateBoxes(Vector3.up, _startScale);

    private List<Rigidbody> CreateBoxes(Vector3 spawnPoint, float scale)
    {
        List<Rigidbody> fragments = new List<Rigidbody>();
        int count = Random.Range(_minCount, _maxCount);
        Box box;

        for (int i = 0; i < count; i++)
        {
            box = _pool.Get(spawnPoint);
            box.Initialize(_exploder, scale);
            fragments.Add(box.GetComponent<Rigidbody>());
        }

        return fragments;
    }
}