using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    GameObject objective;

    public float zDistance = 8;
    public float yDistance = 1;
    public float xDelta = 5;
    public float nitroDistanceRatio = 1.1f;
    public float rotSpeed = 0.1f;

    private float xPos = 0;

    BloqueBien moveScript;
    // Start is called before the first frame update
    private void Awake()
    {
        zDistance = -zDistance;
        moveScript = objective.GetComponent<BloqueBien>();
    }

    // Update is called once per frame
    void Update()
    {
        
        xPos += moveScript.getSteer() * Time.deltaTime * rotSpeed;
        if(moveScript.getSteer() == 0)
        {
            xPos -= Mathf.Clamp(xPos, -rotSpeed * Time.deltaTime, rotSpeed * Time.deltaTime); //para coger el signo de xPos y el valor de lo otro
            Debug.Log(xPos);
        }

        if (moveScript.getDrift())
        {
            xPos = Mathf.Clamp(xPos, -xDelta * nitroDistanceRatio*2, xDelta * nitroDistanceRatio*2);
        }
        else
        {
            xPos = Mathf.Clamp(xPos, -xDelta, xDelta);
        }
       

        if (moveScript.getNitroActivated())
        {
            
            transform.localPosition = new Vector3(xPos , yDistance, zDistance * nitroDistanceRatio);
        
            
        } else
        {
            
            transform.localPosition = new Vector3(xPos, yDistance, zDistance );
        }
        transform.LookAt(objective.transform);
    }
}
