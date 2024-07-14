using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Exploder _exploder;
    [SerializeField] private BoxPool _pool;

    [SerializeField] private float _startScale = 2;
    [SerializeField] private int _minCount = 2;
    [SerializeField] private int _maxCount = 6;

    private void OnEnable() => _exploder.NotExploded += CreateBoxes;

    private void OnDisable() => _exploder.NotExploded -= CreateBoxes;

    private void Start() => CreateBoxes(Vector3.up, _startScale);

    private void CreateBoxes(Vector3 spawnPoint, float scale)
    {
        int count = Random.Range(_minCount, _maxCount);

        for (int i = 0; i < count; i++)
            _pool.Get(spawnPoint).Initialize(_exploder, scale);
    }
}