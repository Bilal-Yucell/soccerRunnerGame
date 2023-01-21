using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{

    public AudioSource kosma;
    public AudioSource topSesi;
    // public AudioSource sampleMusic;

    void Start()
    {
        int sound = PlayerPrefs.GetInt("sound");
        PlayerPrefs.SetInt("sound", sound == 1 ? 0 : 1);
        Debug.Log(PlayerPrefs.GetInt("sound"));
        if (sound == 1)
        {
            topSesi.enabled = true;
            topSesi.enabled = true;
        }
        else { kosma.enabled = false;
            topSesi.enabled = false;
        }

    }

    void Update()
    {
        
    }
}
