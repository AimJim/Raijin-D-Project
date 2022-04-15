using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play(string nombreJuego)
    {
        SceneManager.LoadScene(nombreJuego);
    }

    public void Opciones(string nombreOp)
    {
        SceneManager.LoadScene(nombreOp);
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Salido del juego");
          
    }
}
