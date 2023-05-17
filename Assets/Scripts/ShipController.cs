using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField]
    private int _maxSpeed;

    [SerializeField]
    float _thrust;

    [SerializeField]
    float _rotationRate;

    [SerializeField]
    Rigidbody2D _rigidBody;

    private float _currentThrust;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ApplyThrust()
    {
        Vector2 force = transform.up;
        Vector2 velocty = _rigidBody.velocity;
        force *= _thrust;
        float velocityCoeff = Mathf.Clamp(velocty.magnitude / _maxSpeed, 0 , 1);
        _rigidBody.AddForce(force, ForceMode2D.Force);
        _rigidBody.AddForce(-velocty.normalized * velocityCoeff * _thrust, ForceMode2D.Force);
    }

    public void RotateShip(float sign)
    {
        transform.Rotate(Vector3.back, sign * _rotationRate * Time.deltaTime);
    }
}
