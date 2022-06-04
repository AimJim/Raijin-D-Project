using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CircuitSelect : MonoBehaviour
{
    [SerializeField]
    Button nextButton;
    [SerializeField]
    Button prevButton;
    [SerializeField]
    Button confirmButton;

    [SerializeField]
    string[] circuitNames;
    [SerializeField]
    Sprite[] circuitPictures;
    [SerializeField]
    Image circuitImage;
    [SerializeField]
    private InputActionAsset inputActionAsset;

    InputAction selectAction;
    InputAction confirmAction;

    int actualCircuit = 0;

    private void Awake()
    {
        nextButton.onClick.AddListener(nextButtonClick);
        prevButton.onClick.AddListener(prevButtonClick);
        confirmButton.onClick.AddListener(confirmButtonClick);

        selectAction = inputActionAsset.FindAction("Steer");
        confirmAction = inputActionAsset.FindAction("Nitro");

        drawImage();
    }

    private void confirmButtonClick()
    {
        CarAndCircuit.instance.setCircuit(circuitNames[actualCircuit]); //añadirlo
        SceneManager.LoadScene("LoadScene", LoadSceneMode.Single);
    }

    private void prevButtonClick()
    {
        if (actualCircuit > 0)
        {
            actualCircuit--;
        }
        else
        {
            actualCircuit = circuitNames.Length - 1;
        }
        drawImage();
    }

    private void nextButtonClick()
    {
        actualCircuit = (actualCircuit + 1) % circuitNames.Length;
        drawImage();
    }


    void drawImage()
    {
        circuitImage.sprite = circuitPictures[actualCircuit];
    }


    bool change = false;
    bool changeConfirm = false;
    void Update()
    {
        if (Mathf.Clamp(selectAction.ReadValue<Vector2>().x, -1, 1) == 0 )
        {
            change = true;
        }
        if(confirmAction.ReadValue<float>() == 0)
        {
            changeConfirm = true;
        }

        if (Mathf.Clamp(selectAction.ReadValue<Vector2>().x, -1, 1) > 0.5 && change)
        {
            
            actualCircuit = (actualCircuit + 1) % circuitNames.Length;
            drawImage();

            change = false;
        }
        else if (Mathf.Clamp(selectAction.ReadValue<Vector2>().x, -1, 1) < -0.5 && change)
        {
            
            if (actualCircuit > 0)
            {
                actualCircuit--;
            }
            else
            {
                actualCircuit = circuitNames.Length - 1;
            }
            drawImage();

            change = false;
        }

        if (confirmAction.ReadValue<float>() != 0 && changeConfirm)
        {
            
            CarAndCircuit.instance.setCircuit(circuitNames[actualCircuit]); //añadirlo
            SceneManager.LoadScene("LoadScene", LoadSceneMode.Single);
            change = false;
        }
    }
}
