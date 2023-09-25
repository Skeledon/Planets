using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterCountdown : MonoBehaviour
{

    [SerializeField]
    private float _timer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Countdown(_timer));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Countdown(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
