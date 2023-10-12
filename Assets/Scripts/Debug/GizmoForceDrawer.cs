using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoForceDrawer : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D _rigidbody;
    // Start is called before the first frame update

    private Vector2 _totalForces;

    private void FixedUpdate()
    {
        _totalForces = _rigidbody.totalForce;
    }
    private void OnDrawGizmos()
    {
        //Draw velocity
        Gizmos.color = Color.green;
        Vector2 velocity = _rigidbody.velocity;
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
        Vector3[] points = new Vector3[2]
        {
            currentPosition, currentPosition + velocity
        };
        Gizmos.DrawLineStrip(points, false);

        //Draw totalforce
        Gizmos.color = Color.red;
        points = new Vector3[2]
        {
            currentPosition, currentPosition + _totalForces
        };
        Gizmos.DrawLineStrip(points, false);
    }
}
