using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueBien : MonoBehaviour
{
    [SerializeField]
    float maxSpeed;
    [SerializeField]
    float acceleration;
    [SerializeField]
    float steer;
    [SerializeField]
    float handBrakeAngle;
    [SerializeField]
    float brake;
    [SerializeField]
    float maxSpeedBackwards;
    [SerializeField]
    [Range(1,100)]
    float changeRatio;
    [SerializeField]
    [Range(0,100)]
    float nitroRatio;
    [SerializeField]
    float downforce;

    
    float currentSpeed = 0;
    float accelInput;
    float brakeInput;
    float steerInput;
    bool handbrakeInput;
    bool changeSizeInput;
    bool nitroInput;

    bool drifting;
    bool changeSize;
    bool canAccelerate;
    
    [SerializeField]
    Rigidbody carRB;

    private void Awake()
    {
        carRB = GetComponent<Rigidbody>();
        maxSpeedBackwards = -maxSpeedBackwards;
        changeRatio = changeRatio / 100;
        nitroRatio = nitroRatio / 100;
        maxSpeedOG = maxSpeed;
        accelerationOG = acceleration;
    }

    private void Update()
    {
        //Get inputs
        accelInput = Mathf.Clamp(Input.GetAxis("Vertical"),0,1);
        brakeInput = -Mathf.Clamp(Input.GetAxis("Vertical"), -1, 0);
        steerInput = Mathf.Clamp(Input.GetAxis("Horizontal"), -1, 1);
        handbrakeInput = Input.GetKey(KeyCode.Space); //cambiar todos los inputs
        changeSizeInput = Input.GetKeyDown(KeyCode.O);
        nitroInput = Input.GetKey(KeyCode.P);
        Debug.Log(currentSpeed);
        //No es de fisica
        if (changeSizeInput)
        {
            ChangeSize();
        }
        if (!changeSize)
        {
            Nitro();
        }
        
    }

    private void FixedUpdate()
    {
        if (canAccelerate)
        {
            currentSpeed += acceleration * accelInput * Time.deltaTime;//Se calcula siempre que la aceleracion sea posible
        }
       
        if (handbrakeInput || drifting)
        {
            drifting = true;
            HandBrake();
        } else
        {
            Accelerate();
            Steer();
            Brake();
        }
       
        
        LimitSpeed();
        Friction();
        DownForce();
        
        
    }

    bool ft;
    float maxSpeedOG;
    float accelerationOG;
    void Nitro()
    {
        if (!ft && nitroInput)
        {
            maxSpeed +=  maxSpeed * nitroRatio;
            acceleration += acceleration * nitroRatio;
            ft = true;
        } else if (!nitroInput && ft)
        {
            maxSpeed = maxSpeedOG;
            acceleration = accelerationOG;
            ft = false;
        }
    }

    void ChangeSize()
    {
        if (!changeSize)
        {
            transform.localScale = transform.localScale * changeRatio;
            maxSpeed = maxSpeed * changeRatio;
            maxSpeedBackwards = maxSpeedBackwards * changeRatio;
            changeSize = !changeSize;
        } else
        {
            transform.localScale = transform.localScale / changeRatio;
            transform.position = transform.position + new Vector3(0, 0.5f, 0);
            maxSpeed = maxSpeed / changeRatio;
            maxSpeedBackwards = maxSpeedBackwards / changeRatio;
            changeSize = !changeSize;
        }
    }
    void Brake()
    {
        currentSpeed -= brake * brakeInput * Time.deltaTime;
    }

    void Friction()
    {
        if (accelInput == 0 && currentSpeed > 0 || !canAccelerate)
        {
            currentSpeed -= acceleration * Time.deltaTime;
        } else if( brakeInput == 0 && currentSpeed < 0)
        {
            currentSpeed += brake * Time.deltaTime;
        }
    }

    void Accelerate()
    {
        
        
        carRB.MovePosition(transform.position + transform.forward * currentSpeed);
        
  
    }

    void LimitSpeed()
    {
        if(currentSpeed > maxSpeed)
        {
            canAccelerate = false; //Sino, al desactivar el nitro, la velocidad salta y no hace "friccion"
        } else if(currentSpeed < maxSpeedBackwards)
        {
            currentSpeed = maxSpeedBackwards; //Marcha atras lo del nitro no da problema
        } else
        {
            canAccelerate = true;
        }
    }

    void Steer()
    {
        if(currentSpeed > 1 || currentSpeed < -1)
        {
            carRB.MoveRotation(transform.rotation * Quaternion.Euler(transform.up * steerInput * steer * Time.deltaTime));
        }
       
    }

    void HandBrake()
    {
        drifting = steerInput != 0 && accelInput > 0;
       
           
        carRB.MoveRotation(transform.rotation * Quaternion.Euler(transform.up * handBrakeAngle * steerInput * Time.deltaTime) );
            
        carRB.MovePosition(transform.position + new Vector3(-steerInput, 0, 0) * currentSpeed*0.7f + transform.forward * currentSpeed*0.7f);
        
        
    }

    void DownForce()
    {
        carRB.AddForce(-Vector3.up * downforce);
    }
}

