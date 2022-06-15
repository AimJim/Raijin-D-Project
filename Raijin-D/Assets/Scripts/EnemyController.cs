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
    bool changeSize;
    float targetScale;
    float TamanioOriginal;
    float changeRatio=10;

    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private LayerMask triggerMask;
    int groundColision = 0;
    private void Awake()
    {
        changeRatio = changeRatio / 100;
        TamanioOriginal = transform.localScale.x;
        targetScale = TamanioOriginal;
        sonidoEnemigo = GetComponent<AudioSource>();
        carRB = GetComponent<Rigidbody>();
        if(checkPoints.Count !=0) currentDirection = checkPoints[currentCheckPoint].transform.GetChild(Random.Range(0, 2));
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

    public void ChangeSize()
    {
        if (!changeSize)
        {
            //diferenciaSonido *= changeRatio;
            //StartCoroutine(Intercambiador());

            targetScale = TamanioOriginal * changeRatio;

            //maxSpeed = maxSpeed * changeRatio;
            //maxSpeedBackwards = maxSpeedBackwards * changeRatio;
        }
        else
        {
            //diferenciaSonido /= changeRatio;
            //StartCoroutine(Intercambiador());

            targetScale = 1;

            transform.position = transform.position + new Vector3(0, 0.5f, 0);
            //maxSpeed = maxSpeed / changeRatio;
            //maxSpeedBackwards = maxSpeedBackwards / changeRatio;

        }
        changeSize = !changeSize;
    }

    private void Rotate()
    {
        
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
