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
        }

        void SetMasterVolume(float value)
        {
            mixer.SetFloat(MIXER_MASTER, Mathf.Log10(value) * 20);
        }

        void SetMusicVolume(float value)
        {
            mixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20);
        }

        void SetSFXVolume(float value)
        {
            mixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20);
        }
    }
}
