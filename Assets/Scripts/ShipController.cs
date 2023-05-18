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

    [SerializeField]
    GameObject _backFire;

    [SerializeField]
    GameObject _weapons;

    [SerializeField]
    GravityObject _gravityObject;

    public GravityObject GravityO { get { return _gravityObject; } }

    public int CurrentHP;

    public int MaxHP;

    private float _currentThrust;
    private bool _thrustApplied;

    private WeaponsHandler _weaponsHandler;

    public delegate void ShipDestroyedDelegate();
    public event ShipDestroyedDelegate ShipDestroyed;


    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        _weaponsHandler = _weapons.GetComponent<WeaponsHandler>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        if (!_thrustApplied)
            _backFire.SetActive(false);
        _thrustApplied = false;
    }

    public void ApplyThrust()
    {
        Vector2 force = transform.up;
        Vector2 velocty = _rigidBody.velocity;
        force *= _thrust;
        float velocityCoeff = Mathf.Clamp(velocty.magnitude / _maxSpeed, 0 , 1);
        _rigidBody.AddForce(force, ForceMode2D.Force);
        _rigidBody.AddForce(-velocty.normalized * velocityCoeff * _thrust, ForceMode2D.Force);
        _thrustApplied = true;
        _backFire.SetActive(true);
    }

    public void RotateShip(float sign)
    {
        transform.Rotate(Vector3.back, sign * _rotationRate * Time.deltaTime);
    }

    public void ShootWeapon(int weaponIndex)
    {
        _weaponsHandler.ShootWeapon(weaponIndex);
    }

    public void AddWeapon(GameObject weapon)
    {
        _weaponsHandler.AddWeapon(weapon);
    }

    public void ApplyDamage(int amount)
    {
        CurrentHP -= amount;
        if(CurrentHP <= 0)
        {
            DestroyShip();
        }
    }

    public void DestroyShip()
    {
        Destroy(gameObject);
    }
}
