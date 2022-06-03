using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectLoadingImage : MonoBehaviour
{
    [SerializeField]
    Sprite[] posibleSprites;

    private void Awake()
    {
        var image = gameObject.GetComponent<Image>();
        image.sprite = posibleSprites[Random.Range(0, posibleSprites.Length - 1)];
    }
}
