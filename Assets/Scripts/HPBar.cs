using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBar : MonoBehaviour
{
    [SerializeField]
    ShipController _controller;

    [SerializeField]
    Gradient _colors;

    [SerializeField]
    SpriteRenderer _spriteRenderer;

    private float _maxXScale;

    // Start is called before the first frame update
    void Start()
    {
        _maxXScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        float coeff = (float)_controller.CurrentHP / _controller.MaxHP;
        float scaleX = _maxXScale * coeff;
        transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
        _spriteRenderer.color = _colors.Evaluate(coeff);
    }
}
