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

    public float ThrustForce { get {  return _thrust; } }

    private float _currentThrust;
    private bool _thrustApplied;

    private Vector2 _currentTotalForces;

    private WeaponsHandler _weaponsHandler;

    private List<Vector2> _forcesToApply = new List<Vector2>();

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

        foreach(Vector2 f in _forcesToApply)
        {
            _rigidBody.AddForce(f,ForceMode2D.Force);
        }
        _currentTotalForces = _rigidBody.totalForce;
        _forcesToApply.Clear();
    }

    public void ApplyThrust()
    {
        Vector2 force = transform.up;
        Vector2 velocity = _rigidBody.velocity;
        force *= _thrust;
        float velocityCoeff = Mathf.Clamp(velocity.magnitude / _maxSpeed, 0 , 1);
        //Add thrust
        _forcesToApply.Add(force);
        //Add counterforce
        _forcesToApply.Add(_thrust * velocityCoeff * -velocity.normalized);

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

    private void DrawForces()
    {

    }

}
