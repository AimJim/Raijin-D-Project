using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxManager : MonoBehaviour
{
    [SerializeField]
    AudioSource nitroAD;
    [SerializeField]
    AudioSource driftAD;
    [SerializeField]
    AudioSource explosionAD;
    BloqueBien bb;
    ExplosionAndRespawn ear;
    

    private void Awake()
    {
        bb = gameObject.GetComponentInParent<BloqueBien>();
        ear = gameObject.GetComponentInParent<ExplosionAndRespawn>();
    }

    bool explosion = false;
    private void Update()
    {
        if(bb.getDrift() && !driftAD.isPlaying)
        {
            driftAD.Play();
        } else if(!bb.getDrift() && driftAD.isPlaying)
        {
            driftAD.Stop();
        }

        if(bb.getNitroActivated() && !nitroAD.isPlaying)
        {
            nitroAD.Play();
        } else if(!bb.getNitroActivated() && nitroAD.isPlaying)
        {
            nitroAD.Stop();
        }

        if(ear.getExplosion() && !explosionAD.isPlaying && !explosion)
        {
            explosionAD.Play();
            explosion = true;
            
        } else if (!ear.getExplosion() && explosion)
        {
            explosion = false;
        }
        
    }
}
