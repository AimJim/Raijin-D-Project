using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameStarter : MonoBehaviour
{
    [SerializeField]
    private InputActionAsset inputActionAsset;
    [SerializeField]
    TMP_Text texto;
    [SerializeField]
    Transform spawner;

    InputAction startAction;
    InputAction pauseAction;
    bool click = false;

    private void Awake()
    {
        startAction = inputActionAsset.FindAction("Nitro");
        pauseAction = inputActionAsset.FindAction("Start");
    }

    private void Update()
    {
        if (startAction.ReadValue<float>() != 0 && !click && !SceneManager.GetSceneByName("LoadScene").isLoaded)
        {
            click = true;
            StartCoroutine(startGame());
        }
        if (click && pauseAction.ReadValue<float>() != 0)
        {
            texto.text = "Pause";
            Time.timeScale = 0f;
            GetComponent<Canvas>().enabled = true;
            click = false;
        }
    }

    IEnumerator startGame()
    {
        texto.text = "3";
        yield return new WaitForSecondsRealtime(1);
        texto.color = new Color(0xff,0xa5,0x00);
        texto.text = "2";
        yield return new WaitForSecondsRealtime(1);
        texto.color = new Color(0xFF, 0xFF, 0x00);
        texto.text = "1";
        yield return new WaitForSecondsRealtime(1);
        texto.color = new Color(0x00, 0xFF, 0x00);
        texto.text = "GO!";
        foreach(Transform child in spawner)
        {
            if(child.GetComponent<BloqueBien>() != null)
            {
                child.GetComponent<BloqueBien>().enabled = true;
                child.GetComponentInChildren<Canvas>().enabled = true;
            } else if(child.GetComponent<EnemyController>() != null)
            {
                child.GetComponent<EnemyController>().enabled = true;
            }
            
            
        }
        yield return new WaitForSecondsRealtime(1);
        GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1f;
    }

}
