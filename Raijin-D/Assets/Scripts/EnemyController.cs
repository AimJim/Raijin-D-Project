using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    [SerializeField]
    Transform[] waypoints;


    

    int currentWaypoint = 0;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        

        navMeshAgent.SetDestination(waypoints[currentWaypoint].position);
    }
    private void Update()
    {
        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            currentWaypoint++;


            if (currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
            navMeshAgent.SetDestination(waypoints[currentWaypoint].position);
        }
    }
}
