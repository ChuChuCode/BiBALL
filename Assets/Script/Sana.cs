using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sana : MonoBehaviour
{

    [SerializeField] AudioClip Combine_Sound;
    AudioSource audioSource;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        // LeaderBoard
        PlayerPrefs.SetInt("Sana_Eternal", PlayerPrefs.GetInt("SanSana_Eternala_Make") + 1 );
    }
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            Destroy(this.gameObject);
        }
    }
    public void Play_Combine()
    {
        audioSource.clip = Combine_Sound;
        audioSource.Play();
    }
}
