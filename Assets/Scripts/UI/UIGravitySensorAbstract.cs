using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIGravitySensorAbstract : UISensor
{
    public override void SensorStart(UISensorsHandler sensorsHandler)
    {
        sensorsHandler.MyUIHandler.MyUILinker.MyShipController.GravityO.WellInsideGravity += AddGravityWell;
        sensorsHandler.MyUIHandler.MyUILinker.MyShipController.GravityO.WellOutsideGravity += RemoveGravityWell;
        sensorsHandler.MyUIHandler.MyUILinker.MyShipController.GravityO.GravityWasApplied += GravityApplied;
    }

    public virtual void AddGravityWell(GravityWell gravityWell)
    {

    }

    public virtual void RemoveGravityWell(GravityWell gravityWell)
    {
    }

    public virtual void GravityApplied(GravityWell origin, Vector2 force)
    {

    }

}
