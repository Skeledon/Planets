using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityWell : MonoBehaviour
{
    [SerializeField]
    private CircleCollider2D _collider;

    [SerializeField]
    private int _mass;

    [SerializeField]
    private Vector2 _gravityForceBounds;

    [SerializeField]
    private float _coreSize; //used to put the "center" of gravity outside the center itself and make it as if it's bigger. Only in the calculations.

    [SerializeField]
    private AnimationCurve _gravityCurve;

    private List<GravityObject> _gravityObjectsInWell;

    private const float GRAVITATIONAL_CONSTANT = .1f;

    private float _gravityRadius;
    
    // Start is called before the first frame update
    void Start()
    {
        _gravityObjectsInWell = new List<GravityObject>();
        _gravityRadius = _collider.radius - _coreSize;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach(GravityObject gravityObject in _gravityObjectsInWell)
        {
            Vector2 direction = transform.position - gravityObject.transform.position;
            float distance = direction.magnitude - _coreSize;
            float coeff = distance / _gravityRadius;
            float forceMagnitude = _gravityForceBounds.x + (_gravityCurve.Evaluate(coeff) * (_gravityForceBounds.y - _gravityForceBounds.x));
            gravityObject.ApplyGravity(direction.normalized * Mathf.Clamp(forceMagnitude, _gravityForceBounds.x, _gravityForceBounds.y));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name + " entered gravity well");
        GravityObject go;
        if (collision.TryGetComponent<GravityObject>(out go))
        {
            _gravityObjectsInWell.Add(go);
            go.AddWell(this);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.name + " left gravity well");
        GravityObject go;
        if (collision.TryGetComponent<GravityObject>(out go))
        {
            _gravityObjectsInWell.Remove(go);
            go.RemoveWell(this);
        }
    }

    public void UpdateGravityRadius()
    {
        _gravityRadius = _collider.radius - _coreSize;
    }

    public void SetCoreSize(float value)
    {
        _coreSize = value;
        UpdateGravityRadius();
    }

    public void SetGravityForceBounds(Vector2 value)
    {
        _gravityForceBounds = value;
    }
}
