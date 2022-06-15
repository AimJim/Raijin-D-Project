using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManagment : MonoBehaviour
{
    [SerializeField]
    ParticleSystem psRight;
    [SerializeField]
    ParticleSystem psLeft;


    BloqueBien bloqueBien;
    ExplosionAndRespawn ear;
    

    private void Awake()
    {
        
        if(GetComponentInParent<BloqueBien>() != null)
        {
            bloqueBien = GetComponentInParent<BloqueBien>();
        }
        ear = GetComponentInParent<ExplosionAndRespawn>();
        
    }

    bool driftBool = false;
    void Update()
    {
        if(bloqueBien != null)
        {
            if (!driftBool && bloqueBien.getDrift())
            {
                psLeft.Play();
                psRight.Play();
                driftBool = true;
            } else if (driftBool && !bloqueBien.getDrift())
            {
                psLeft.Stop();
                psRight.Stop();
                driftBool = false;
            }
        }
        
    }
}
