using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnEnemyCars : MonoBehaviour
{


    [SerializeField]
    int cantCoches = 0;
    [SerializeField]
    GameObject[] cochesPosibles;

    [SerializeField]
    Transform enemyspawn;
    // Update is called once per frame
    void Awake()
    {
        for(int i = 0; i < cantCoches; i++)
        {
            var car = Instantiate(cochesPosibles[Random.Range(0,cochesPosibles.Length)], gameObject.transform);
            car.transform.position = enemyspawn.position;
          
            car.AddComponent<GetCheckpoints>();
            car.GetComponent<GetCheckpoints>().enabled = true;
            car.GetComponent<EnemyController>().enabled = false;
            Destroy(car.GetComponentInChildren<FxManager>());
            Destroy(car.GetComponentInChildren<AudioListener>());
            Destroy(car.GetComponentInChildren<CameraScript>());
            Destroy(car.GetComponent<BloqueBien>());
            car.GetComponentInChildren<Canvas>().enabled = false;
            Destroy(car.GetComponentInChildren<Camera>());
            Destroy(car.GetComponent<MoverRuedas>());
            Destroy(car.GetComponentInChildren<SpeedView>());
            Destroy(car.GetComponentInChildren<TMP_Text>());
        }
        
    }
}
