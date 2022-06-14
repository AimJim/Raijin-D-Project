using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCarOnGame : MonoBehaviour
{
    private void Awake()
    {
        var car = Instantiate(CarAndCircuit.instance.getCar(), gameObject.transform);
        Destroy(car.GetComponent<EnemyController>());
        car.GetComponent<BloqueBien>().enabled = false;
        car.GetComponentInChildren<Canvas>().enabled = false;
    }
}
