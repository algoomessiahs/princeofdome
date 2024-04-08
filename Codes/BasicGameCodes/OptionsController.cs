using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{

    public Slider volumeSlider;
    public float defaultVolume = 0.7f;


    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetVolume();
    }


    public void Update()
    {
        var musicPlayer = FindObjectOfType<Audio>();

        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.Log("No music player found, Did you start from splash screen?");
        }
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetVolume(volumeSlider.value);
    }

    public void SetDefault()
    {
        volumeSlider.value = defaultVolume;
    }
}
