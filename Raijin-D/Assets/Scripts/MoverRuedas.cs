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
        wheelFL.transform.rotation *= Quaternion.Euler(transform.right * carRB.velocity.magnitude * Time.deltaTime);
        wheelFR.transform.rotation *= Quaternion.Euler(transform.right * carRB.velocity.magnitude * Time.deltaTime);
        wheelRL.transform.rotation *= Quaternion.Euler(transform.right * carRB.velocity.magnitude * Time.deltaTime);
        wheelRR.transform.rotation *= Quaternion.Euler(transform.right * carRB.velocity.magnitude * Time.deltaTime);

        //Move global
        globalFL.transform.rotation = Quaternion.Euler(transform.up * GetComponent<BloqueBien>().getSteer() * wheelAngle);
        globalFR.transform.rotation = Quaternion.Euler(transform.up * GetComponent<BloqueBien>().getSteer() * wheelAngle);

    }
}
