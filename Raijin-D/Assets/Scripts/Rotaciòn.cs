using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    [SerializeField]
    private InputActionAsset inputActionAsset;

    [SerializeField]
    GameObject carCanvas;
    [SerializeField]
    GameObject circuitCanvas;
    [SerializeField]
    Button nextButton;
    [SerializeField]
    Button previousButton;
    [SerializeField]
    Button confirmButton;

    InputAction selectAction;
    InputAction confirmAction;


    private void Awake()
    {
        plataforma = gameObject;
       
        vehiculo = Instantiate(listaAutos[posLista]);
        vehiculo.transform.SetParent(gameObject.transform);
        Destroy(vehiculo.GetComponentInChildren<Camera>());
        Destroy(vehiculo.GetComponentInChildren<NitroBehaviur>());
        Destroy(vehiculo.GetComponentInChildren<FireAnimator>());
        Destroy(vehiculo.GetComponentInChildren<Image>());
        Destroy(vehiculo.GetComponent<BloqueBien>());
        Destroy(vehiculo.GetComponent<AudioSource>());
        CarAndCircuit.instance.setCar(listaAutos[posLista]);
        posLista = (posLista + 1) % listaAutos.Length;
        vehiculo.transform.position = Spawn.position;

        selectAction = inputActionAsset.FindAction("Steer");
        confirmAction = inputActionAsset.FindAction("Nitro");

        nextButton.onClick.AddListener(OnNextClicked);
        previousButton.onClick.AddListener(OnPrevClicked);
        confirmButton.onClick.AddListener(OnConfirmClicked);

    }

    private void OnConfirmClicked()
    {
        //Hacerlo selector de circuito
        carCanvas.SetActive(false);
        circuitCanvas.SetActive(true);
        Destroy(gameObject.GetComponent<Rotaciòn>());
    }

    private void OnPrevClicked()
    {
        Destroy(vehiculo);
        if (posLista > 0)
        {
            posLista--;
        }
        else
        {
            posLista = listaAutos.Length - 1;
        }
        ColocarVehiculo();
        

    }

    private void OnNextClicked()
    {
        
        Destroy(vehiculo);
        posLista = (posLista + 1) % listaAutos.Length;
        ColocarVehiculo();
        


    }

    bool change = true;
    private void Update()
    {
        plataforma.transform.rotation *= Quaternion.Euler(new Vector3(0, Rspeed, 0) * Time.deltaTime);
        if(Mathf.Clamp(selectAction.ReadValue<Vector2>().x, -1, 1) == 0)
        {
            change = true;
        }
        
        if (Mathf.Clamp(selectAction.ReadValue<Vector2>().x, -1, 1) > 0.5 && change) 
        {
            Destroy(vehiculo);
            posLista = (posLista + 1) % listaAutos.Length;
            ColocarVehiculo();
            
            change = false;
        }
        else if (Mathf.Clamp(selectAction.ReadValue<Vector2>().x, -1, 1) < -0.5 && change) 
        {
            Destroy(vehiculo);
            if (posLista > 0)
            {
                posLista--;
            }
            else
            {
                posLista = listaAutos.Length -1;
            }
            ColocarVehiculo();
            
            change = false;
        }

        if(confirmAction.ReadValue<float>() != 0)
        {
            carCanvas.SetActive(false);
            circuitCanvas.SetActive(true);
            Destroy(gameObject.GetComponent<Rotaciòn>());
        }

    }
    private void ColocarVehiculo()
    {
        
        vehiculo = Instantiate(listaAutos[posLista]);
        vehiculo.transform.SetParent(gameObject.transform);
        Destroy(vehiculo.GetComponentInChildren<Camera>());
        Destroy(vehiculo.GetComponent<BloqueBien>());
        Destroy(vehiculo.GetComponent<AudioSource>());
        Destroy(vehiculo.GetComponentInChildren<NitroBehaviur>());
        Destroy(vehiculo.GetComponentInChildren<FireAnimator>());
        Destroy(vehiculo.GetComponentInChildren<Image>());
        vehiculo.transform.position = Spawn.position;
        vehiculo.transform.rotation = Spawn.transform.rotation * Quaternion.Euler(new Vector3(0, -180, 0));
        CarAndCircuit.instance.setCar(listaAutos[posLista]);
    }
}
