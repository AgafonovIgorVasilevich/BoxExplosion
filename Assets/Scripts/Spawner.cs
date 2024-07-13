using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnRadius = 4;
    [SerializeField] private int _count = 3;
    [SerializeField] private BoxPool _pool;

    [SerializeField] private float _splitFactor = 2;
    [SerializeField] private float _scaleFactor = 1;

    private void Start()
    {
        Vector2 spawnPoint;
        Box box;

        for(int i = 0; i < _count; i++)
        {
            spawnPoint = Random.insideUnitSphere * _spawnRadius;
            box = _pool.Get(_splitFactor, _scaleFactor);
            box.transform.position = new Vector3(spawnPoint.x, transform.position.y, spawnPoint.y);
        }
    }
}