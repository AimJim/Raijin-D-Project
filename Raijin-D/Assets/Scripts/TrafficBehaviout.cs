using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficBehaviout : MonoBehaviour
{
    
    public List<GameObject> checkPoints;
    [SerializeField]
    float acceleration;
    [SerializeField]
    float maxSpeed;
    [SerializeField]
    float steer;
  
    [SerializeField]
    float downforce;

    Rigidbody carRB;

    bool canAccelerate = true;
    

    int currentCheckPoint = 0;
    Transform currentDirection;

    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private LayerMask triggerMask;
    int groundColision = 0;

    int route = 0;
    private void Awake()
    {
        
        carRB = GetComponent<Rigidbody>();
        currentDirection = checkPoints[currentCheckPoint].transform.GetChild(Random.Range(0, 2));
        route = Random.Range(0, checkPoints[currentCheckPoint].transform.childCount);
    }
    private void FixedUpdate()
    {
        
        if (canAccelerate && groundColision > 0)
        {
            Accelerate();
        }
        LimitSpeed();
        Rotate();
        DownForce();
    }

    public void setCurrentCheckpoint(int check)
    {
        currentCheckPoint = (check + 1) % checkPoints.Count;
        currentDirection = checkPoints[currentCheckPoint].transform.GetChild(route);
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
        carRB.velocity += transform.forward * acceleration * Time.fixedDeltaTime;
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
            currentDirection = checkPoints[currentCheckPoint].transform.GetChild(route);

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
