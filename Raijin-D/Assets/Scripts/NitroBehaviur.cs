using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NitroBehaviur : MonoBehaviour
{
    [SerializeField]
    BloqueBien bloqueBien;

    [SerializeField]
    float nitroPerSecond;

    AudioSource audioSource;
    [SerializeField]
    private RectTransform maskTransform;

    float nitroValue;

    

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        maskTransform.offsetMax = new Vector2(20, 0);

    }


    void Update()
    {
        if (bloqueBien.getNitroActivated())
        {
            
            nitroValue = Mathf.Clamp(nitroValue += nitroPerSecond * Time.deltaTime, 0, 1);

            if (nitroValue >= .8f && !audioSource.isPlaying)
            {
                audioSource.Play();
                
            }
            else if (nitroValue < .8f && audioSource.isPlaying)
            {
                audioSource.Stop();
                
            }
            if (nitroValue > 0.99f)
            {
               StartCoroutine(GetComponentInParent<ExplosionAndRespawn>().Colision());
               nitroValue = 0;
            }

        }
        else{
            
            
           nitroValue = Mathf.Clamp(nitroValue -= nitroPerSecond * Time.deltaTime, 0, 1);

        }
        
        maskTransform.anchorMax = new Vector2(nitroValue, maskTransform.anchorMax.y);
    }
}
