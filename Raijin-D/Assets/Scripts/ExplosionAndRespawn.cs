using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExplosionAndRespawn : MonoBehaviour
{
    
    
    Transform lastCheckpoint;

    [SerializeField]
    LayerMask paredMask;
    [SerializeField]
    LayerMask checkPointsMask;
    [SerializeField]
    LayerMask metaMask;
    [SerializeField]
    float explosionForce;
    [SerializeField]
    float waitTime;
    [SerializeField]
    Button menuButton;
    [SerializeField]
    TMP_Text texto;

    [SerializeField]
    int vueltas = 3;
    [SerializeField]
    int vidas = 5;
    [SerializeField]
    GameObject canvas;
    bool explosion = false;
    public bool getExplosion()
    {
        return explosion;
    }

    private void Awake()
    {
        lastCheckpoint = GameObject.Find("Spawner").transform;
        menuButton.onClick.AddListener(MenuButtonLoad);
    }

    private void MenuButtonLoad()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (checkPointsMask == (checkPointsMask | 1 << other.gameObject.layer/*esto mueve un 1 el nùmero de veces que es su layer*/))
        {
            lastCheckpoint = other.transform;

        }
        if (metaMask == (metaMask | 1 << other.gameObject.layer/*esto mueve un 1 el nùmero de veces que es su layer*/))
        {
            vueltas--;
            if(vueltas < 0 && GetComponent<BloqueBien>() != null)
            {
                Time.timeScale = 0f;
                texto.text = "Ganaste";
                texto.color = new Color(0x00, 0xFF, 0x00);
                
                canvas.SetActive(true);
            }

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (paredMask == (paredMask | 1 << collision.gameObject.layer/*esto mueve un 1 el nùmero de veces que es su layer*/))
        {
            StartCoroutine(Colision());
        }
    }

    public IEnumerator Colision()
    {
        if(GetComponent<BloqueBien>() != null)
        {
            GetComponent<BloqueBien>().enabled = false;
            GetComponentInChildren<Canvas>().enabled = false;
        } else if(GetComponent<EnemyController>() != null)
        {
            GetComponent<EnemyController>().enabled = false;
        }
        GetComponent<Rigidbody>().AddForce(Vector3.up * explosionForce);
        explosion = true;
        vidas--;
        if(vidas < 0 && GetComponent<BloqueBien>() != null)
        {
            Time.timeScale = 0f;
            texto.text = "Perdiste";
            texto.color = new Color(0xFF, 0x00, 0x00);
            
            canvas.SetActive(true);
        }

        yield return new WaitForSeconds(waitTime);


        transform.position = (lastCheckpoint.position + new Vector3(0,5,0));
        transform.rotation = lastCheckpoint.rotation * Quaternion.Euler(new Vector3(0,90,0));
        if (GetComponent<BloqueBien>() != null)
        {
            GetComponent<BloqueBien>().enabled = true;
            GetComponentInChildren<Canvas>().enabled = true;
        }
        else if (GetComponent<EnemyController>() != null)
        {
            GetComponent<EnemyController>().enabled = true;
        }
        explosion = false;
    }


}
