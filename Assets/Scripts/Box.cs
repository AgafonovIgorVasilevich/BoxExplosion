using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Box : MonoBehaviour
{
    private Exploder _exploder;
    
    public float Scale => transform.localScale.x;

    private void OnMouseDown() => _exploder.Explode(this);

    public void Initialize(Exploder exploder, float scale)
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV();
        transform.localScale = Vector3.one * scale;
        _exploder = exploder;
    }
}