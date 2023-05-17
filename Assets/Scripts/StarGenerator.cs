using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject _starPrefab;

    [SerializeField]
    private Vector2 _starfieldSize; //better if multiple of 10. 

    [SerializeField]
    private int _starDensity; // number of stars in a 10x10 square

    [SerializeField]
    private Vector2 _starSize;

    [SerializeField]
    private int[] starLayers;

    private int currentX;
    private int currentY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void GenerateStar()
    {

    }
}
