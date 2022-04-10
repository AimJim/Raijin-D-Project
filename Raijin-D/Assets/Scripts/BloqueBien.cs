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
    [SerializeField]
    private LayerMask layerMask;


    float currentSpeed = 0;
    float accelInput;
    float brakeInput;
    float steerInput;
    float diferenciaSonido=150;
    bool handbrakeInput;
    bool changeSizeInput;
    bool nitroInput;

    bool drifting;
    bool changeSize;
    bool canAccelerate;
    int groundColision = 0;

    AudioSource sonido;
    
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
        sonido = GetComponent<AudioSource>();

    }

    private void Update()
    {
        sonido.pitch = carRB.velocity.magnitude / diferenciaSonido;
        //Get inputs
        accelInput = Mathf.Clamp(Input.GetAxis("Vertical"),0,1);
        brakeInput = -Mathf.Clamp(Input.GetAxis("Vertical"), -1, 0);
        steerInput = Mathf.Clamp(Input.GetAxis("Horizontal"), -1, 1);
        handbrakeInput = Input.GetKey(KeyCode.Space); //cambiar todos los inputs
        changeSizeInput = Input.GetKeyDown(KeyCode.O);
        nitroInput = Input.GetKey(KeyCode.P);
       // Debug.Log(currentSpeed);
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

    private void OnCollisionEnter(Collision collision)
    {
        if (layerMask == (layerMask | 1 << collision.gameObject.layer/*esto mueve un 1 el n�mero de veces que es su layer*/))
            {
            //Debug.Log("piso");
            groundColision++;
            }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (layerMask == (layerMask | 1 << collision.gameObject.layer/*esto mueve un 1 el n�mero de veces que es su layer*/))
        {
            //Debug.Log("piso");
            groundColision--;
        }
    }

    private void FixedUpdate()
    {
        if (groundColision > 0)
        {
            if (canAccelerate)
            {
                Accelerate();//Se calcula siempre que la aceleracion sea posible
            }

            if (handbrakeInput || (drifting && steerOG == steerInput))
            {
                drifting = true;
                HandBrake();
            } 
            else
            {
               // Accelerate();
                Steer();
                Brake();
                drifting = false;
               // Debug.Log("Fin drift");
            }
        } else
        {
           // Accelerate();
        }


        Debug.Log("Pison�t");
        LimitSpeed();
       // Friction();
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
            diferenciaSonido *= changeRatio;
            transform.localScale = transform.localScale * changeRatio;
            maxSpeed = maxSpeed * changeRatio;
            maxSpeedBackwards = maxSpeedBackwards * changeRatio;
            changeSize = !changeSize;
        } else
        {
            diferenciaSonido /= changeRatio;
            transform.localScale = transform.localScale / changeRatio;
            transform.position = transform.position + new Vector3(0, 0.5f, 0);
            maxSpeed = maxSpeed / changeRatio;
            maxSpeedBackwards = maxSpeedBackwards / changeRatio;
            changeSize = !changeSize;
        }
    }
    void Brake()
    {
        carRB.velocity -= transform.forward * brake * brakeInput ;
    }

    void Friction()
    {
        if (accelInput == 0 && currentSpeed > 0 || !canAccelerate)
        {
            carRB.velocity -= transform.forward * acceleration;
            
        } else if( brakeInput == 0 && currentSpeed < 0)
        {
            carRB.velocity += transform.forward * acceleration ;
        }
    }

    

    void Accelerate()
    {


        carRB.velocity += transform.forward * acceleration * accelInput;
        Debug.Log("Acelera");
        
  
    }

    void LimitSpeed()
    {
        if(carRB.velocity.magnitude > maxSpeed)
        {
            canAccelerate = false; //Sino, al desactivar el nitro, la velocidad salta y no hace "friccion"
        } else if(currentSpeed < maxSpeedBackwards)
        {
            carRB.velocity = transform.forward *  maxSpeedBackwards; //Marcha atras lo del nitro no da problema
        } else
        {
            canAccelerate = true;
        }
    }

    void Steer()
    {
        if(carRB.velocity.magnitude > 0.1 || carRB.velocity.magnitude < -0.1)
        {
            carRB.MoveRotation(transform.rotation * Quaternion.Euler(transform.up * steerInput * steer * Time.deltaTime));
        }
       
    }

    private float steerOG = 0;
    void HandBrake()
    {
        //Va raro
        drifting = steerInput != 0 && accelInput > 0;

        if (handbrakeInput && !drifting)
        {
            steerOG = steerInput;
        }

        Debug.Log("Iniciando drift");

        carRB.MoveRotation(transform.rotation * Quaternion.Euler(transform.up * handBrakeAngle * steerInput * Time.deltaTime));

        carRB.velocity += (new Vector3(-steerInput, 0, 0) * currentSpeed * 0.3f );
        
           
      
        
        
    }

    void DownForce()
    {
        carRB.AddForce(-transform.up * downforce);
    }
}

