using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityObject : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rigidbody;

    private int _currentWells;

    public delegate void GravityWellInsideGravity(GravityWell well);
    public event GravityWellInsideGravity WellInsideGravity;

    public delegate void GravityWellOutsideGravity(GravityWell well);
    public event GravityWellInsideGravity WellOutsideGravity;

    public delegate void GravityApplied(GravityWell origin, Vector2 force);
    public event GravityApplied GravityWasApplied;


    private void Awake()
    {
        _currentWells = 0;
        this.WellInsideGravity += EnterGravity;
        this.WellOutsideGravity += ExitGravity;
        this.GravityWasApplied += GravityApply;

        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ApplyGravity(GravityWell well, Vector2 force)
    {
        _rigidbody.AddForce(force, ForceMode2D.Force);
        GravityWasApplied.Invoke(well, force);
    }

    public void AddWell(GravityWell well)
    {
        _currentWells++;
        if (_currentWells == 1)
            WellInsideGravity.Invoke(well);
    }

    public void RemoveWell(GravityWell well)
    {
        _currentWells--;
        if (_currentWells == 0)
            WellOutsideGravity.Invoke(well);
    }

    private void EnterGravity(GravityWell well)
    {

    }

    private void ExitGravity(GravityWell well)
    {

    }

    private void GravityApply(GravityWell origin, Vector2 force)
    {

    }
}
