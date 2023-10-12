using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISensorsHandler : MonoBehaviour
{
    [SerializeField]
    private List<UISensor> _sensors;

    public UIHandler MyUIHandler;

    public void SensorsAwake()
    {
        foreach (var sensor in _sensors)
        {
            sensor.SensorAwake(this);
        }
    }

    public void SensorsOnEnable()
    {
        foreach (var sensor in _sensors)
        {
            sensor.SensorOnEnable(this);
        }
    }

    public void SensorsStart()
    {
        foreach (var sensor in _sensors)
        {
            sensor.SensorStart(this);
        }
    }


    public void SensorsUpdate()
    {
        foreach (var sensor in _sensors)
        {
            sensor.SensorUpdate(this);
        }

    }

    public void SensorsFixedUpdate()
    {
        foreach (var sensor in _sensors)
        {
            sensor.SensorFixedUpdate(this);
        }
    }

    public void SensorsLateUpdate()
    {
        foreach (var sensor in _sensors)
        {
            sensor.SensorLateUpdate(this);
        }
    }

    public void AddGravityWell(GravityWell gravityWell)
    {

    }

    public void RemoveGravityWell(GravityWell gravityWell)
    {

    }

    public void GravityApplied(GravityWell origin, Vector2 force)
    {

    }
}
