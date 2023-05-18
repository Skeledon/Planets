using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILinker : MonoBehaviour
{
    [SerializeField]
    ShipController _controller;

    [SerializeField]
    GameObject GravityText;


    // Start is called before the first frame update
    void Start()
    {
        _controller.GravityO.WellInsideGravity += SetGravityOn;
        _controller.GravityO.WellOutsideGravity += SetGravityOff;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetGravityOn()
    {
        GravityText.SetActive(true);
    }

    private void SetGravityOff()
    {
        GravityText.SetActive(false);
    }
}
