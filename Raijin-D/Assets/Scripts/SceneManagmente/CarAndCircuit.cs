using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarAndCircuit : MonoBehaviour
{
    static private GameObject carPrefab;
    static string circuit;

    static public CarAndCircuit instance;

    CarAndCircuit()
    {
        
        
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
           Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    public void setCar(GameObject car)
    {
        carPrefab = car;
    }

    public GameObject getCar()
    {
        return carPrefab;
    }

    public void setCircuit(string circuitI)
    {
        circuit = circuitI;
    }

    public string getCircuit()
    {
        return circuit;
    }
}
