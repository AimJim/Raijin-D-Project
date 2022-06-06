using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCheckpoints : MonoBehaviour
{

    GameObject checkpointArray;

    private void Awake()
    {
        checkpointArray = GameObject.Find("Checkpoints");
        foreach (Transform child in checkpointArray.transform)
        {
            gameObject.GetComponent<EnemyController>().checkPoints.Add(child.gameObject);
        }
    }
}
