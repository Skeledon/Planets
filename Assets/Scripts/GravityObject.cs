using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityObject : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ApplyGravity(Vector2 force)
    {
        _rigidbody.AddForce(force, ForceMode2D.Force);
        Debug.Log(force.magnitude);
    }
}
