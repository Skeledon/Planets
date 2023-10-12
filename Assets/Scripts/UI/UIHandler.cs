using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    [SerializeField]
    private UISensorsHandler _sensorHandler;

    [HideInInspector]
    public UILinker MyUILinker;

    private void Awake()
    {
        _sensorHandler.SensorsAwake();
    }

    private void OnEnable()
    {
        _sensorHandler.SensorsOnEnable();
    }

    void Start()
    {
        _sensorHandler.SensorsStart();
    }


    void Update()
    {
        _sensorHandler.SensorsUpdate();

    }

    private void FixedUpdate()
    {
        _sensorHandler.SensorsFixedUpdate();
    }

    private void LateUpdate()
    {
        _sensorHandler.SensorsLateUpdate();
    }

    public void AddGravityWell(GravityWell gravityWell)
    {
        _sensorHandler.AddGravityWell(gravityWell);
    }

    public void RemoveGravityWell(GravityWell gravityWell) 
    {
        _sensorHandler.RemoveGravityWell(gravityWell);
    }

    public void GravityApplied(GravityWell origin, Vector2 force)
    {
        _sensorHandler.GravityApplied(origin, force);   
    }
}
