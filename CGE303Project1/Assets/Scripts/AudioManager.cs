using TMPro;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    // Initialize audio mixer
    [SerializeField]
    private AudioMixer Mixer;

    // Initialize audio source
    [SerializeField]
    private AudioSource AudioSource;

    // Initialize volume value text
    [SerializeField]
    private TextMeshProUGUI ValueText;

    // Initialize audio mix mode
    [SerializeField]
    private AudioMixMode MixMode;

    private void Start()
    {
        // Sets default volume to 1 on start
        Mixer.SetFloat("Volume", Mathf.Log10(PlayerPrefs.GetFloat("Volume", 1) * 20));
    }

    public void OnChangeSlider(float Value) // Initialize dynamic float parameter
    {
        // Limits text value to 2 digits past the decimal point
        ValueText.SetText($"{Value.ToString("N2")}");

        switch (MixMode) // Allow logrithmic mixer values
        {
            case AudioMixMode.LogrithmicMixerVolume:
                Mixer.SetFloat("Volume", Mathf.Log10(Value) * 20);
                break;
        }

        // Logrithmic decibel unit equation
        float a = Mathf.Log10(Value) * 20; 

        // Set and save new volume level
        PlayerPrefs.SetFloat("Volume", Value);
        PlayerPrefs.Save();
    }

    public enum AudioMixMode
    {
        // Allow logrithmic mixer case
        LogrithmicMixerVolume
    }
}