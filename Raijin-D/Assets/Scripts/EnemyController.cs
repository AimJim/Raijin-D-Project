using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
   
    //IA propia
    
    public List<GameObject> checkPoints;
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

    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private LayerMask triggerMask;
    int groundColision = 0;
    private void Awake()
    {
        sonidoEnemigo = GetComponent<AudioSource>();
        carRB = GetComponent<Rigidbody>();
        currentDirection = checkPoints[currentCheckPoint].transform.GetChild(Random.Range(0, 2));
    }
    private void FixedUpdate()
    {
        sonidoEnemigo.pitch = carRB.velocity.magnitude / 150;
        if (canAccelerate && groundColision > 0)
        {
            Accelerate();
        }
        LimitSpeed();
        Rotate();
        DownForce();
    }

    private void Rotate()
    {
        //Va mal
        Debug.Log(Mathf.Atan2(transform.position.z - currentDirection.transform.position.z, transform.position.x - currentDirection.transform.position.x) * Mathf.Rad2Deg + " ANGULO");
        if(Mathf.Atan2(transform.position.z - currentDirection.transform.position.z, transform.position.x - currentDirection.transform.position.x) * Mathf.Rad2Deg < 170 && Mathf.Atan2(transform.position.z - currentDirection.transform.position.z, transform.position.x - currentDirection.transform.position.x) * Mathf.Rad2Deg > 0)
        {
            carRB.MoveRotation(transform.rotation * Quaternion.Euler(transform.up * steer * Time.deltaTime));
        } else if(Mathf.Atan2(transform.position.z - currentDirection.transform.position.z, transform.position.x - currentDirection.transform.position.x) * Mathf.Rad2Deg > -170 && Mathf.Atan2(transform.position.z - currentDirection.transform.position.z, transform.position.x - currentDirection.transform.position.x) * Mathf.Rad2Deg < 0)
        {
            carRB.MoveRotation(transform.rotation * Quaternion.Euler(transform.up * -steer * Time.deltaTime));
        }
       
        
        
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
        if (triggerMask == (triggerMask | 1 << other.gameObject.layer/*esto mueve un 1 el nùmero de veces que es su layer*/))
        {
            currentCheckPoint = (currentCheckPoint + 1) % checkPoints.Count;
            currentDirection = checkPoints[currentCheckPoint].transform.GetChild(Random.Range(0, checkPoints[currentCheckPoint].transform.childCount));

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (layerMask == (layerMask | 1 << collision.gameObject.layer/*esto mueve un 1 el nùmero de veces que es su layer*/))
        {
            //Debug.Log("piso");
            groundColision++;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (layerMask == (layerMask | 1 << collision.gameObject.layer/*esto mueve un 1 el nùmero de veces que es su layer*/))
        {
            //Debug.Log("piso");
            groundColision--;
        }
    }
}
