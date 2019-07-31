using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{

    [SerializeField] AudioSource backgroundAudio;
    Text text;


    void Start()
    {
        UIController.soundControl += SoundController;
    }

    void Awake()
    {

        
        //text = textButton.GetComponent<Text>();
        backgroundAudio.Play();

        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
      //  print("FindObjectOfType<MusicPlayer>() "+ FindObjectOfType<MusicPlayer>());
       
         if (numMusicPlayers > 1)
            Destroy(gameObject);

        else
            DontDestroyOnLoad(gameObject);
    }

    public void SoundController()
    {
        if (backgroundAudio.isPlaying)
            backgroundAudio.Pause();
        else
            backgroundAudio.Play();

    }


}
