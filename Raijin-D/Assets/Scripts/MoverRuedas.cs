using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverRuedas : MonoBehaviour
{
    [SerializeField]
    GameObject wheelFL;
    [SerializeField]
    GameObject wheelFR;
    [Space]
    [SerializeField]
    GameObject globalFL;
    [SerializeField]
    GameObject globalFR;
    [Space]
    [SerializeField]
    GameObject wheelRR;
    [SerializeField]
    GameObject wheelRL;
    [Space]
    [SerializeField]
    float wheelAngle;

    Rigidbody carRB;

    private void Awake()
    {
        carRB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Move local
        
        wheelFL.transform.localRotation *= Quaternion.Euler(new Vector3(carRB.velocity.magnitude*10 * Time.deltaTime,0,0));
        wheelFR.transform.localRotation *= Quaternion.Euler(new Vector3(carRB.velocity.magnitude * 10 * Time.deltaTime, 0, 0));
        wheelRL.transform.localRotation *= Quaternion.Euler(new Vector3(carRB.velocity.magnitude * 10 * Time.deltaTime, 0, 0));
        wheelRR.transform.localRotation *= Quaternion.Euler(new Vector3(carRB.velocity.magnitude * 10 * Time.deltaTime, 0, 0));

        //Move global
        
        globalFL.transform.localRotation = Quaternion.Euler(new Vector3(0, (GetComponent<BloqueBien>().getSteer()) * wheelAngle, 0));
        globalFR.transform.localRotation = Quaternion.Euler(new Vector3(0, (GetComponent<BloqueBien>().getSteer()) * wheelAngle, 0));

    }
}
