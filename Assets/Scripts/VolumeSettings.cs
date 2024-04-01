using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider MasterSlider;
    [SerializeField] Slider MusicSlider;
    [SerializeField] Slider SFXSlider;
    
    const string MIXER_MUSIC = "MusicVolume";
    const string SFX_MUSIC = "SFXVolume";
    void Awake()
    {
        MusicSlider.onValueChanged.AddListener(SetMusicVolume);
        SFXSlider.onValueChanged.AddListener(SetSFXVolume);
    }
    void SetMusicVolume(float value) 
    {
        mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value)*20);
    }
    void SetSFXVolume(float value) 
    {
        mixer.SetFloat(SFX_MUSIC, Mathf.Log10(value)*20);
    }
}
  