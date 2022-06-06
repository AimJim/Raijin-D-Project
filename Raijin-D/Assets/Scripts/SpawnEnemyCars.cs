using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyCars : MonoBehaviour
{


    [SerializeField]
    int cantCoches = 0;
    [SerializeField]
    GameObject[] cochesPosibles;
    // Update is called once per frame
    void Awake()
    {
        for(int i = 0; i < cantCoches; i++)
        {
            var car = Instantiate(cochesPosibles[Random.Range(0,cochesPosibles.Length)], gameObject.transform);
          
            car.AddComponent<GetCheckpoints>();
            car.GetComponent<GetCheckpoints>().enabled = true;
            car.GetComponent<EnemyController>().enabled = true;
            Destroy(car.GetComponent<BloqueBien>());
            Destroy(car.GetComponentInChildren<Canvas>());
            Destroy(car.GetComponentInChildren<Camera>());
        }
        
    }
}
