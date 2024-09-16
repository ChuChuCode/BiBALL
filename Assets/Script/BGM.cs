using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BGM : MonoBehaviour
{
    public static BGM instance;
    [SerializeField] AudioMixer mixer;
    const string MIXER_VOLUME = "VOLUME";
    const string MIXER_BGM = "BGM";
    const string MIXER_SFX = "SFX";
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        float Volume = PlayerPrefs.GetFloat(MIXER_VOLUME,1);
        float BGM = PlayerPrefs.GetFloat(MIXER_BGM,1);
        float SFX = PlayerPrefs.GetFloat(MIXER_SFX,1);
        mixer.SetFloat(MIXER_VOLUME,Mathf.Log10(Volume)*20);
        mixer.SetFloat(MIXER_BGM,Mathf.Log10(BGM)*20);
        mixer.SetFloat(MIXER_SFX,Mathf.Log10(SFX)*20);
    }
}
