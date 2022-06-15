using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplosionAnim : MonoBehaviour
{
    Image image;
    [SerializeField]
    Sprite[] spriteArray;
    int currentSprite = 0;
    [SerializeField]
    float waitSeconds = 0;
    private void Awake()
    {
        image = gameObject.GetComponent<Image>();
        image.sprite = spriteArray[currentSprite];
        /*currentSprite++;
        StartCoroutine(Change());*/
    }


    public IEnumerator Change()
    {
        yield return new WaitForSeconds(waitSeconds);
        image.sprite = spriteArray[currentSprite];
        currentSprite = (currentSprite + 1);
        if(currentSprite == spriteArray.Length)
        {
            currentSprite = 0;

        }
        else
        {
            StartCoroutine(Change());
        }
        
        
        
    }
}
