using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceCalculator : MonoBehaviour
{
    [SerializeField] GameObject tank;
    [SerializeField] GameObject missile;
    //Transform tank;
    //Transform missile;
    void Start()
    {
        tank = GameObject.FindGameObjectWithTag("Enemy");
        missile = this.gameObject;
        var DistanceBetweenTankAndPlayer = tank.transform.position - missile.transform.position;
        Debug.Log(DistanceBetweenTankAndPlayer);
    }
    
    void Update()
    {
    }
}
