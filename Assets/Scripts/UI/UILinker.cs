using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILinker : MonoBehaviour
{
    [SerializeField]
    ShipController _controller;

    [SerializeField]
    UIHandler _uiHandler;

    public ShipController MyShipController { get { return _controller; } }  

    // Start is called before the first frame update
    void Awake()
    {
        _controller.GravityO.WellInsideGravity += AddGravityWell;
        _controller.GravityO.WellOutsideGravity += RemoveGravityWell;
        _controller.GravityO.GravityWasApplied += GravityApplied;

        _uiHandler.MyUILinker = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AddGravityWell(GravityWell well)
    {
        _uiHandler.AddGravityWell(well);
    }

    private void RemoveGravityWell(GravityWell well)
    {
        _uiHandler.RemoveGravityWell(well);
    }

    private void GravityApplied(GravityWell origin, Vector2 force)
    {
        _uiHandler.GravityApplied(origin, force);
    }
}
