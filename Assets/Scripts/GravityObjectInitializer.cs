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
    private AnimationCurve _gravityWellSizeConvertionCurve;

    [SerializeField]
    private AnimationCurve _gravityWellForceConvertionCurve;

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
        _VisualObject.transform.localScale = new Vector3(sizeValue, sizeValue, 1);
        _gravityWellObject.GetComponent<GravityWell>().SetCoreSize(sizeValue / 2);

        //Set object color
        _VisualObject.GetComponent<SpriteRenderer>().color = _colors.Evaluate(coeff);

        //set gravity values
        _gravityWellObject.GetComponent<GravityWell>().SetGravityForceBounds(new Vector2(1, _gravityWellForceConvertionCurve.Evaluate(coeff)));
        _gravityWellObject.GetComponent<CircleCollider2D>().radius = _gravityWellSizeConvertionCurve.Evaluate(coeff);
        _gravityWellObject.GetComponent<GravityWell>().UpdateGravityRadius(); //needs to be called to update values correctly
    }
}
