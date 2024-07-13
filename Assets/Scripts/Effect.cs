using System.Collections;
using UnityEngine;

public class Effect : MonoBehaviour
{
    [SerializeField] private Transform _parent;
    [SerializeField] private float _delay = 1;

    private void OnEnable() => StartCoroutine(DelayDisable());

    private IEnumerator DelayDisable()
    {
        transform.parent = null;
        yield return new WaitForSeconds(_delay);

        transform.parent = _parent;
        gameObject.SetActive(false);
    }
}