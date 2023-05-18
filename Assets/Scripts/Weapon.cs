using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    Transform _bulletSpawn;

    [SerializeField]
    GameObject _bulletPrefab;

    [SerializeField]
    float _bulletsPerSecond;

    private float _timeBetweenShots;
    private float _currentTimeBetweenShots;
    private bool _canShoot;

    private GameObject _owner;

    // Start is called before the first frame update
    void Start()
    {
        _timeBetweenShots = 1 / _bulletsPerSecond;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!_canShoot)
        {
            _currentTimeBetweenShots += Time.fixedDeltaTime;
            if (_currentTimeBetweenShots >= _timeBetweenShots)
            {
                _canShoot = true;
                _currentTimeBetweenShots = 0f;
            }
        }
    }

    public void SetOwner(GameObject owner)
    {
        _owner = owner;
    }

    public void Shoot()
    {
        if(_canShoot)
        {
            GameObject go = Instantiate(_bulletPrefab, _bulletSpawn.position, transform.rotation);
            go.GetComponent<Bullet>().Init(_owner, _owner.GetComponent<Rigidbody2D>().velocity);
            _canShoot = false;
        }
    }
}
