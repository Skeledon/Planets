using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject _owner;

    [SerializeField]
    private GameObject[] _weapons_slots;

    private List<Weapon> _weapons = new List<Weapon>();

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject go in _weapons_slots) 
        {
            Weapon w = go.GetComponentInChildren<Weapon>();
            if(w != null) 
            {
                _weapons.Add(w);
            }
        }
        //Debug
        foreach (var weapon in _weapons)
        {
            weapon.SetOwner(_owner);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootWeapon(int n)
    {
        _weapons[n-1].Shoot();
    }

    public void AddWeapon(GameObject weapon)
    {

    }
}
