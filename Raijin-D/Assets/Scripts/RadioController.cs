using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioController : MonoBehaviour
{
    [SerializeField]
    AudioClip[] songList;

    AudioSource audioSource;

    public int currentSong = 0;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = songList[0];
    }

    void Update()
    {
        
        if (!audioSource.isPlaying)
        {
            audioSource.clip = songList[currentSong];
            audioSource.Play();
            StartCoroutine(playMusic());

        }
    }

    IEnumerator playMusic()
    {
        yield return new WaitForEndOfFrame();
        
         currentSong = (currentSong + 1) % songList.Length;
            
        
        

    }
}
