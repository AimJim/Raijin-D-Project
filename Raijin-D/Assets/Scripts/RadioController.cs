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
        currentSong = Random.Range(0, songList.Length);
        audioSource.clip = songList[currentSong];
    }

    void Update()
    {
        
        if (!audioSource.isPlaying)
        {
            audioSource.clip = songList[currentSong];
            audioSource.Play();
            currentSong = (currentSong + 1) % songList.Length;
            

        }
    }

    
}
