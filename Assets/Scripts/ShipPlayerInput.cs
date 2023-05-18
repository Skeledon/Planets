using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPlayerInput : MonoBehaviour
{
    [SerializeField]
    private int _playerIndex;

    [SerializeField]
    private ShipController _controller;

    private Rewired.Player _player;

    private int selectedWeapon;


    private void Awake()
    {
        _player = Rewired.ReInput.players.GetPlayer(_playerIndex);
    }

    // Start is called before the first frame update
    void Start()
    {
        selectedWeapon = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(_player.GetAxis("Rotate")) > .25f)
        {
            Rotate(Mathf.Sign(_player.GetAxis("Rotate")));
        }
        if ( _player.GetButton("Wpn1"))
        {
            selectedWeapon = 1;
        }
        if (_player.GetButton("Wpn2"))
        {
            selectedWeapon = 2;
        }
    }

    private void FixedUpdate()
    {
        if (_player.GetButton("Thrust"))
        {
            ApplyThrust();
        }
        if (_player.GetButton("Shoot"))
        {
            Shoot();
        }
    }

    void ApplyThrust()
    {
        _controller.ApplyThrust();
    }

    void Rotate(float sign)
    {
        _controller.RotateShip(sign);
    }

    void Shoot()
    {
        _controller.ShootWeapon(selectedWeapon);
    }
}
