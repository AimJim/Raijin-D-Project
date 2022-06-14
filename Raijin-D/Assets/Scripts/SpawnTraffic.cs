using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTraffic : MonoBehaviour
{
    [SerializeField]
    int NTrafico;
    
    [SerializeField]
    GameObject[] cochesPosibles;

    [SerializeField]
    Transform[] posibleSpawns;

    
    private void Awake()
    {
        for(int i = 0; i < NTrafico; i++)
        {
            var car = Instantiate(cochesPosibles[Random.Range(0, cochesPosibles.Length)], gameObject.transform);
            int spawnP = Random.Range(0, posibleSpawns.Length);
            
            foreach (Transform child in posibleSpawns)
            {
                
                car.GetComponent<TrafficBehaviout>().checkPoints.Add(child.gameObject);
            }
            car.transform.position = posibleSpawns[spawnP].position + new Vector3(0, 5, 0);
            car.GetComponent<TrafficBehaviout>().setCurrentCheckpoint(spawnP);
            car.GetComponent<TrafficBehaviout>().enabled = true;
            
        }
        
    }
}
