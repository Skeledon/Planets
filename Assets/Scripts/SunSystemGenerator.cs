using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSystemGenerator : MonoBehaviour
{
    [Header ("Sun Settings")]
    [SerializeField]
    private GameObject _sunPrefab;

    [Header ("Planets Settings")]
    [SerializeField]
    private GameObject _planetPrefab;

    [Header ("Workhole Settings")]
    [SerializeField]
    private GameObject _workholePrefab;

    [Header("Layout Settings")]
    [SerializeField]
    private Vector2[] _orbitsBounds;

    [SerializeField]
    private Vector2Int _numberOfPlanets;

    private List<GameObject> _gravityObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        CreateSun();
        CreatePlanets();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            foreach(GameObject go in _gravityObjects)
                Destroy(go);
            CreateSun();
            CreatePlanets();
        }

    }

    private void CreateSun()
    {
        GameObject sun = Instantiate(_sunPrefab, Vector3.zero, Quaternion.identity, transform);
        _gravityObjects.Add(sun);

        float size = Random.value;

        sun.GetComponent<GravityObjectInitializer>().Generate(size);
    }

    private void CreatePlanets()
    {
        int numberOfPlanets = Random.Range(_numberOfPlanets.x, _numberOfPlanets.y);

        for(int i = 0; i < numberOfPlanets; i++)
        {
            Vector2 direction = Random.insideUnitCircle;
            CreatePlanet(direction *= Random.Range(_orbitsBounds[i].x, _orbitsBounds[i].y));
        }
    }

    private void CreatePlanet(Vector2 position)
    {
        GameObject planet = Instantiate(_planetPrefab, position, Quaternion.identity, transform);
        _gravityObjects.Add(planet);

        float size = Random.value;

        planet.GetComponent<GravityObjectInitializer>().Generate(size);
    }
}
