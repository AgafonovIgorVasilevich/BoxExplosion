using UnityEngine;

public class Effect : MonoBehaviour
{
    private EffectPool _pool;

    private void OnDisable() => _pool.Put(this);

    public void Initialize(EffectPool pool) => _pool = pool;
}