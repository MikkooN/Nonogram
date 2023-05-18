using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Nonogram
{
    public class VolumeSettings : MonoBehaviour

    {
        [SerializeField] AudioMixer mixer;
        [SerializeField] Slider masterSlider;
        [SerializeField] Slider musicSlider;
        [SerializeField] Slider sfxSlider;

        const string MIXER_MASTER = "MasterVolume";
        const string MIXER_MUSIC = "MusicVolume";
        const string MIXER_SFX = "SFXVolume";

        void Awake()
        {
            masterSlider.onValueChanged.AddListener(SetMasterVolume);
            musicSlider.onValueChanged.AddListener(SetMusicVolume);
            sfxSlider.onValueChanged.AddListener(SetSFXVolume);

            masterSlider.value = PlayerPrefs.GetFloat("masterVolume", 0);
            musicSlider.value = PlayerPrefs.GetFloat("musicVolume", 0);
            sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume", 0);
        }

        void SetMasterVolume(float value)
        {
            mixer.SetFloat(MIXER_MASTER, value);
            PlayerPrefs.SetFloat("masterVolume", value);
        }

        void SetMusicVolume(float value)
        {
            mixer.SetFloat(MIXER_MUSIC, value);
            PlayerPrefs.SetFloat("musicVolume", value);
        }

        void SetSFXVolume(float value)
        {
            mixer.SetFloat(MIXER_SFX, value);
            PlayerPrefs.SetFloat("sfxVolume", value);
        }
    }
}
