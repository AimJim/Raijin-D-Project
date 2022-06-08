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
        //Z = Y para los calculos
        //Gira directamente al angulo, no a la direccion
        /*
        Vector2 carV = new Vector2(gameObject.transform.TransformDirection(transform.forward).x, gameObject.transform.TransformDirection(transform.forward).z);
        Vector2 checKV = new Vector2(currentDirection.transform.TransformDirection(transform.right).x, currentDirection.transform.TransformDirection(transform.right).z);
        float angle = Mathf.Acos((carV.x * checKV.x + carV.y * checKV.y)/(Mathf.Sqrt(carV.x * carV.x + carV.y *carV.y)*Mathf.Sqrt(checKV.x * checKV.x + checKV.y * checKV.y))) * Mathf.Rad2Deg;
        Debug.Log(angle);
        if(angle > 1 && angle < 179)
        {
            carRB.MoveRotation(transform.rotation * Quaternion.Euler(transform.up * -steer * Time.fixedDeltaTime));
        } else if(angle < 359 && angle > 181)
        {
            carRB.MoveRotation(transform.rotation * Quaternion.Euler(transform.up * steer * Time.fixedDeltaTime));
        }*/
        Vector3 target = currentDirection.transform.position - transform.position;
        float step = steer * Time.fixedDeltaTime * Mathf.Deg2Rad;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, target, step, 0f);

        transform.rotation = Quaternion.LookRotation(newDirection);




    }
    void DownForce()
    {
        carRB.AddForce(-transform.up * downforce);
    }
    private void Accelerate()
    {
        carRB.velocity += transform.forward * acceleration *  Time.fixedDeltaTime;
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
