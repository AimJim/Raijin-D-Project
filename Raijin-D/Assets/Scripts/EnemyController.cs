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
    AudioSource sonidoEnemigo;

    int currentCheckPoint = 0;
    Transform currentDirection;
    private void Awake()
    {
        sonidoEnemigo = GetComponent<AudioSource>();
        carRB = GetComponent<Rigidbody>();
        currentDirection = checkPoints[currentCheckPoint].transform.GetChild(Random.Range(0, 2));
    }
    private void FixedUpdate()
    {
        sonidoEnemigo.pitch = carRB.velocity.magnitude / 150;
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
        
       
        transform.LookAt(currentDirection);
        Debug.Log(currentDirection.gameObject.name);
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
        currentDirection = checkPoints[currentCheckPoint].transform.GetChild(Random.Range(0, checkPoints[currentCheckPoint].transform.childCount));
    }
}
