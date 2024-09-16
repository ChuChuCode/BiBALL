using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Authentication;

public class Game_End : MonoBehaviour
{
    [SerializeField] GameObject Save;
    [SerializeField] GameObject Input;
    [SerializeField] GameObject GameOver;
    [SerializeField] GameObject pause_btn;
    [SerializeField] Mouse_Click click;
    [SerializeField] Data data;
    [SerializeField] SpriteRenderer Face;
    [SerializeField] Sprite Shock;
    [SerializeField] AudioClip end_game;
    AudioSource audiosource;
    [SerializeField] LeaderBoard_Controller leaderBoard_Controller;
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ball")
        {
            FindObjectOfType<BGM>().GetComponent<AudioSource>().Stop();
            // Play Music
            audiosource.clip = end_game;
            audiosource.Play();
            pause_btn.SetActive(false);
            Face.sprite = Shock;
            // Time Stop
            Time.timeScale = 0f;
            // UI Show
            GameOver.SetActive(true);
            Save.SetActive(false);
            Input.SetActive(false);
            // Data Save While End Game
            int score = data.Save();
            if (score > 0)
            {
                Save.SetActive(true);
                Input.SetActive(true);
            }
            print("Game Over");
            // Let Mouse Not Move
            click.GameOver = true;
            // Svae
            AuthenticationService.Instance.UpdatePlayerNameAsync( PlayerPrefs.GetString("name","no_name_data") );
            leaderBoard_Controller.AddScore("Throw_Time"  , PlayerPrefs.GetInt("Throw_Time"   , 0));
            leaderBoard_Controller.AddScore("Sana_Make"   , PlayerPrefs.GetInt("Sana_Make"    , 0));
            leaderBoard_Controller.AddScore("Sana_Eternal", PlayerPrefs.GetInt("Sana_Eternal" , 0));
            // Reset
            PlayerPrefs.SetInt("Sana_Make"   ,0 );
            PlayerPrefs.SetInt("Sana_Eternal",0 );
            PlayerPrefs.SetInt("Throw_Time"  ,0 );
            StartCoroutine(Check_Music());
        }       
    }
    IEnumerator Check_Music()
    {
        while (audiosource.isPlaying)
        {
            yield return null;  
        }
        FindObjectOfType<BGM>().GetComponent<AudioSource>().Play();
    }
}
