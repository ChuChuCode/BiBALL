using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Sound_Control : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider Volume_Slider;
    [SerializeField] Slider BGM_Slider;
    [SerializeField] Slider SFX_Slider;
    const string MIXER_VOLUME = "VOLUME";
    const string MIXER_BGM = "BGM";
    const string MIXER_SFX = "SFX";
    [SerializeField] GameObject menu;
    void OnEnable()
    {
        Volume_Slider.value = PlayerPrefs.GetFloat(MIXER_VOLUME,1);
        BGM_Slider.value = PlayerPrefs.GetFloat(MIXER_BGM,1);
        SFX_Slider.value = PlayerPrefs.GetFloat(MIXER_SFX,1);
    }
    public void Change_VOLUME(float value)
    {
        mixer.SetFloat(MIXER_VOLUME,Mathf.Log10(value)*20);
        PlayerPrefs.SetFloat(MIXER_VOLUME,value);
    }
    public void Change_BGM(float value)
    {
        mixer.SetFloat(MIXER_BGM,Mathf.Log10(value)*20);
        PlayerPrefs.SetFloat(MIXER_BGM,value);
    }
    public void Change_SFX(float value)
    {
        mixer.SetFloat(MIXER_SFX,Mathf.Log10(value)*20);
        PlayerPrefs.SetFloat(MIXER_SFX,value);
    }
    public void Button_Back()
    {
        FindObjectOfType<Sound>().GetComponent<AudioSource>().Play();
        menu.SetActive(true);
        gameObject.SetActive(false);
    }
}
