using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
   
    //IA propia
    [SerializeField]
    GameObject[] checkPoints;
    [SerializeField]
    float acceleration;
    [SerializeField]
    float maxSpeed;
    [SerializeField]
    float steer;
    [SerializeField]
    float maxAngle;
    [SerializeField]
    float downforce;
    
    Rigidbody carRB;

    bool canAccelerate = true;

    int currentCheckPoint = 0;
    private void Awake()
    {
        carRB = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (canAccelerate)
        {
            Accelerate();
        }
        LimitSpeed();
        Rotate();
        DownForce();
    }

    private void Rotate()
    {
        
       
        transform.LookAt(checkPoints[currentCheckPoint].transform);
    }
    void DownForce()
    {
        carRB.AddForce(-transform.up * downforce);
    }
    private void Accelerate()
    {
        carRB.velocity += transform.forward * acceleration;
    }
    private void LimitSpeed()
    {
        if (carRB.velocity.magnitude > maxSpeed)
        {
            canAccelerate = false;
        }
        else
        {
            canAccelerate = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        currentCheckPoint++;
        currentCheckPoint = currentCheckPoint % checkPoints.Length;
    }
}
