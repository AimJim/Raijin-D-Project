using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SkipCutscene : MonoBehaviour
{
    [SerializeField]
    InputActionAsset inputActionAsset;
    [SerializeField]
    Button boton;

    InputAction skipAction;
    private void Awake()
    {
        skipAction = inputActionAsset.FindAction("Start");
        boton.onClick.AddListener(loadMenu);
    }

    private void loadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    // Update is called once per frame
    bool hit;
    void Update()
    {
        
        if(skipAction.ReadValue<float>() != 0 && !hit)
        {
            hit = true;
            SceneManager.LoadScene("Menu");
        }
    }
}
