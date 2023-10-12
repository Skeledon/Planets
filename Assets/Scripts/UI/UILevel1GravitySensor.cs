using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UILevel1GravitySensor : UIGravitySensorAbstract
{
    [SerializeField]
    private float _timeBetweenPings;

    [SerializeField]
    private Image _gravityBar;

    [SerializeField]
    private Gradient _gravityBarGradient;

    [SerializeField]
    private Image _pingBar;

    private float currentTime;

    private Vector2 _totalGravity;



    public override void SensorFixedUpdate(UISensorsHandler sensorsHandler)
    {
        currentTime += Time.fixedDeltaTime;
        SetPingBar();
        if(currentTime >= _timeBetweenPings) 
        {
            SetGravityBar(sensorsHandler.MyUIHandler.MyUILinker.MyShipController.ThrustForce);
            currentTime = 0;
        }
        _totalGravity = Vector2.zero;
    }

    public override void GravityApplied(GravityWell origin, Vector2 force)
    {
        base.GravityApplied(origin, force);
        _totalGravity += force;
        Debug.Log(_totalGravity);
    }

    private void SetPingBar()
    {
        float coeff = currentTime / _timeBetweenPings;
        _pingBar.transform.localScale = new Vector3(coeff, _pingBar.transform.localScale.y, _pingBar.transform.localScale.z);
    }

    private void SetGravityBar(float maxThrust)
    {
        float coeff = _totalGravity.magnitude / maxThrust;
        _gravityBar.transform.localScale = new Vector3(coeff, _gravityBar.transform.localScale.y, _gravityBar.transform.localScale.z);
        _gravityBar.color = _gravityBarGradient.Evaluate(coeff);
    }




}
