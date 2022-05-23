using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotaciòn : MonoBehaviour
{
    [SerializeField]
    private int Rspeed;

    [SerializeField]
    GameObject[] listaAutos;
    int posLista = 0;

    private GameObject plataforma;
    [SerializeField]
    private Transform Spawn;
    private GameObject vehiculo;


    private void Awake()
    {
        plataforma = gameObject;
       
        vehiculo = Instantiate(listaAutos[posLista]);
        vehiculo.transform.SetParent(gameObject.transform);
        posLista = (posLista + 1) % listaAutos.Length;
        vehiculo.transform.position = Spawn.position;

    }
    private void Update()
    {
        plataforma.transform.rotation *= Quaternion.Euler(new Vector3(0, Rspeed, 0) * Time.deltaTime);
        
        if (Input.GetKeyDown(KeyCode.D)) //cambiar en el funturo;
        {
            Destroy(vehiculo);
            posLista = (posLista + 1) % listaAutos.Length;
            ColocarVehiculo();
        }
        else if (Input.GetKeyDown(KeyCode.A)) //cambiar en el funturo;
        {
            Destroy(vehiculo);
            if (posLista > 0)
            {
                posLista--;
            }
            else
            {
                posLista = listaAutos.Length;
            }
            ColocarVehiculo();
        }

    }
    private void ColocarVehiculo()
    {
        vehiculo = Instantiate(listaAutos[posLista]);
        vehiculo.transform.SetParent(gameObject.transform);
        vehiculo.transform.position = Spawn.position;
        vehiculo.transform.rotation = Spawn.transform.rotation * Quaternion.Euler(new Vector3(0, -180, 0));
    }
}
