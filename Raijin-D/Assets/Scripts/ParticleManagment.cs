using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        GetComponentInChildren<Image>().enabled = false;

    }

    bool driftBool = false;
    bool anim = false;
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
        if (ear.getExplosion() && !anim)
        {

            GetComponentInChildren<Image>().enabled = true;
            StartCoroutine(GetComponentInChildren<ExplosionAnim>().Change());
            anim = true;
        }
        else if(!ear.getExplosion() && anim)
        {
            anim = false;
            GetComponentInChildren<Image>().enabled = false;
        }
        
    }
}
