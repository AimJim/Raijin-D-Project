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
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Awake()
    {
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
