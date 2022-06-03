using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CargarNivel : MonoBehaviour
{
    float WAIT = 5f;
    private void Awake()
    {
        
        SceneManager.LoadScene(CarAndCircuit.instance.getCircuit(), LoadSceneMode.Additive);
    }

    private void Update()
    {
        StartCoroutine(waitForLoading());
        
        
    }

    IEnumerator waitForLoading()
    {
        yield return new WaitForSecondsRealtime(WAIT);
        if (SceneManager.GetSceneByName(CarAndCircuit.instance.getCircuit()).isLoaded)
        {

            SceneManager.UnloadSceneAsync(gameObject.scene);
        }
    }


}
