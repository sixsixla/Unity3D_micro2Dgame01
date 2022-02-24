using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackMusic : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip bgMusic1,bgMusic2,bgMusic3,bgMusic4,bgMusicBoss,bgMusicEnd;
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setBackgroundMusic(string Music)
{
    switch(Music)
    {
        case "Music1":GetComponent<AudioSource>().clip = bgMusic1;
        break;
        case "Music2": GetComponent<AudioSource>().clip = bgMusic2;
        break;
          case "Music3": GetComponent<AudioSource>().clip = bgMusic3;
        break;
          case "Music4": GetComponent<AudioSource>().clip = bgMusic4;
        break;
        case "MusicBoss": GetComponent<AudioSource>().clip = bgMusicBoss;
        break;
          case "MusicEnd": GetComponent<AudioSource>().clip = bgMusicEnd;
        break;

    }
    GetComponent<AudioSource>().Play();
}
}
