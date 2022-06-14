using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FxManager : MonoBehaviour
{
    [SerializeField]
    AudioSource nitroAD;
    [SerializeField]
    AudioSource driftAD;

    BloqueBien bb;
    

    private void Awake()
    {
        bb = gameObject.GetComponentInParent<BloqueBien>();
    }

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
    }
}
