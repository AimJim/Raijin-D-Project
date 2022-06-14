using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortTamanyo : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<BloqueBien>().ChangeSize();
    }
}
