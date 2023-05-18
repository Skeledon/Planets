using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityObject : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidbody;

    private int _currentWells;

    public delegate void GravityWellInsideGravity();
    public event GravityWellInsideGravity WellInsideGravity;

    public delegate void GravityWellOutsideGravity();
    public event GravityWellInsideGravity WellOutsideGravity;

    private void Awake()
    {
        _currentWells = 0;
        this.WellInsideGravity += EnterGravity;
        this.WellOutsideGravity += ExitGravity;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ApplyGravity(Vector2 force)
    {
        _rigidbody.AddForce(force, ForceMode2D.Force);
    }

    public void AddWell(GravityWell well)
    {
        _currentWells++;
        if (_currentWells == 1)
            WellInsideGravity.Invoke();
    }

    public void RemoveWell(GravityWell well)
    {
        _currentWells--;
        if (_currentWells == 0)
            WellOutsideGravity.Invoke();
    }

    private void EnterGravity()
    {

    }

    private void ExitGravity()
    {

    }
}
