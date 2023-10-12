using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityObjectInitializer : MonoBehaviour
{
    [SerializeField]
    private GameObject _gravityWellObject;

    [SerializeField]
    private GameObject _VisualObject;

    [SerializeField]
    private AnimationCurve _sizeConvertionCurve;
    [SerializeField]
    private Vector2 _sizeBounds;

    [SerializeField]
    private AnimationCurve _gravityWellSizeConvertionCurve;
    [SerializeField]
    private Vector2 _gravityWellSizeBounds;

    [SerializeField]
    private AnimationCurve _gravityWellForceConvertionCurve;
    [SerializeField]
    private Vector2 _gravityWellForceBounds;

    [SerializeField]
    private Gradient _colors;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Generate(float coeff)
    {
        //Set object size
        float sizeValue = _sizeConvertionCurve.Evaluate(coeff);
        sizeValue = (_sizeBounds.y - _sizeBounds.x) * sizeValue + _sizeBounds.x;
        _VisualObject.transform.localScale = new Vector3(sizeValue, sizeValue, 1);
        _gravityWellObject.GetComponent<GravityWell>().SetCoreSize(sizeValue / 2);

        //Set object color
        _VisualObject.GetComponent<SpriteRenderer>().color = _colors.Evaluate(coeff);

        //set gravity values
        float gravityForce = _gravityWellForceConvertionCurve.Evaluate(coeff);
        gravityForce = (_gravityWellForceBounds.y - _gravityWellForceBounds.x) * gravityForce + _gravityWellForceBounds.x;
        _gravityWellObject.GetComponent<GravityWell>().SetGravityForceBounds(new Vector2(1,gravityForce));

        float gravityRadius = _gravityWellSizeConvertionCurve.Evaluate(coeff);
        gravityRadius = (_gravityWellSizeBounds.y - _gravityWellSizeBounds.x) * gravityRadius + _gravityWellSizeBounds.x;
        _gravityWellObject.GetComponent<CircleCollider2D>().radius = gravityRadius;
        _gravityWellObject.GetComponent<GravityWell>().UpdateGravityRadius(); //needs to be called to update values correctly
    }
}
