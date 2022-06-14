using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAndRespawn : MonoBehaviour
{
    
    
    Transform lastCheckpoint;

    [SerializeField]
    LayerMask paredMask;
    [SerializeField]
    LayerMask checkPointsMask;
    [SerializeField]
    float explosionForce;
    [SerializeField]
    float waitTime;

    private void Awake()
    {
        lastCheckpoint = GameObject.Find("Spawner").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (checkPointsMask == (checkPointsMask | 1 << other.gameObject.layer/*esto mueve un 1 el nùmero de veces que es su layer*/))
        {
            lastCheckpoint = other.transform;

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (paredMask == (paredMask | 1 << collision.gameObject.layer/*esto mueve un 1 el nùmero de veces que es su layer*/))
        {
            StartCoroutine(Colision());
        }
    }

    public IEnumerator Colision()
    {
        if(GetComponent<BloqueBien>() != null)
        {
            GetComponent<BloqueBien>().enabled = false;
            GetComponentInChildren<Canvas>().enabled = false;
        } else if(GetComponent<EnemyController>() != null)
        {
            GetComponent<EnemyController>().enabled = false;
        }
        GetComponent<Rigidbody>().AddForce(Vector3.up * explosionForce);

        yield return new WaitForSeconds(waitTime);


        transform.position = (lastCheckpoint.position + new Vector3(0,5,0));
        transform.rotation = lastCheckpoint.rotation * Quaternion.Euler(new Vector3(0,90,0));
        if (GetComponent<BloqueBien>() != null)
        {
            GetComponent<BloqueBien>().enabled = true;
            GetComponentInChildren<Canvas>().enabled = true;
        }
        else if (GetComponent<EnemyController>() != null)
        {
            GetComponent<EnemyController>().enabled = true;
        }
    }


}
