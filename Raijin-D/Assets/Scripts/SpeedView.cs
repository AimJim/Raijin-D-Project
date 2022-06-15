using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeedView : MonoBehaviour
{
    [SerializeField]
    TMP_Text textArea;
    void Update()
    {
        int temp = (int)GetComponentInParent<Rigidbody>().velocity.magnitude;
        textArea.text = temp.ToString() + "KM/h";
        if(temp < 120)
        {
            textArea.color = new Color(0x00, 0xFF, 0x00);
        } else if (temp < 200)
        {
            textArea.color = new Color(0xFF, 0xFF, 0x00);
        }
        else
        {
            textArea.color = new Color(0xFF, 0x00, 0x00);
        }
       
    }
}
