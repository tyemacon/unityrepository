using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.5f;

    private void Start()
    {
        Debug.Log(GetInstanceID() + ": OptionsController is attached to: " 
            + volumeSlider.name + " with ID: " + volumeSlider.GetInstanceID());
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
    
    }

    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
    }

    public void SaveAndExit()
    {
        float volume = volumeSlider.value;
        PlayerPrefsController.SetMasterVolume(volume);
        FindObjectOfType<LevelLoader>().LoadStartScene();
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
    }
}
