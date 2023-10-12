using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _impulseForce;

    [SerializeField]
    float _recoil;

    [SerializeField]
    private int _damage;

    [SerializeField]
    private Rigidbody2D _rigidbody;

    private GameObject _owner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Quaternion rot = Quaternion.FromToRotation(transform.up, _rigidbody.velocity);
        transform.Rotate(rot.eulerAngles);
    }

    public void Init(GameObject owner, Vector2 startingVelocity)
    {
        _owner = owner;
        _rigidbody.velocity = startingVelocity;
        _rigidbody.AddForce(transform.up * _impulseForce, ForceMode2D.Impulse);
        _owner.GetComponent<Rigidbody2D>().AddForce(-transform.up * _recoil, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject != _owner)
        {
            ShipController controller;
            if(collision.gameObject.TryGetComponent<ShipController>(out controller))
            {
                controller.ApplyDamage(_damage);
                Destroy(gameObject);
            }

        }

    }
}
