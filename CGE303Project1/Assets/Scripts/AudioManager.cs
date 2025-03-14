using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    // Reference to Audio Source
    public AudioSource audioSource;

    // Reference to UI Slider
    public Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        // Find the audio source
        audioSource = Camera.main.GetComponent<AudioSource>();

        // Set initial volume to 1
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1f);
        audioSource.volume = savedVolume;
        volumeSlider.value = savedVolume;

        // Add a listener to detect slider changes
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    // Function to change the volume
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;

        // Save the volume setting
        PlayerPrefs.SetFloat("Volume", volume);
    }
}
