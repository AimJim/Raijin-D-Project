using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RadioController : MonoBehaviour
{
    [SerializeField]
    AudioClip[] songList;
    [SerializeField]
    GameObject canvas;
    [SerializeField]
    TMP_Text text;

    AudioSource audioSource;

    int currentSong = 0;
    float waitTime = 2f;

    private float musicVolume = 1f;

    static RadioController instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
        currentSong = Random.Range(0, songList.Length);
        audioSource.clip = songList[currentSong];
        text.text = songList[currentSong].name;
    }

    void Update()
    {
        
        if (!audioSource.isPlaying)
        {
            audioSource.clip = songList[currentSong];
            audioSource.Play();
            currentSong = (currentSong + 1) % songList.Length;
           
            StartCoroutine(showRadioUI());
            

        }

        audioSource.volume = musicVolume;
    }

    IEnumerator showRadioUI()
    {
        canvas.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        canvas.SetActive(false);
        text.text = songList[currentSong].name;
    }


    public void setVolume(float volume)
    {
        musicVolume = volume;
    }

    
}
