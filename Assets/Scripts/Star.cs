using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField]
    private Color[] _colors;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().color = _colors[Random.Range(0, _colors.Length)];
    }

}
