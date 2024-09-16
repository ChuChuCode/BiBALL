using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] GameObject LOGO;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject credit;
    [SerializeField] GameObject leaderboard;
    [SerializeField] AudioSource[] audioSource;
    public void Start_Game()
    {
        FindObjectOfType<Sound>().mode = 0;
        FindObjectOfType<Sound>().GetComponent<AudioSource>().Play();
        StartCoroutine(Load_Game());
    }
    public void Challenge_Game()
    {
        FindObjectOfType<Sound>().mode = 1;
        FindObjectOfType<Sound>().GetComponent<AudioSource>().Play();
        StartCoroutine(Load_Game());
    }
    public void Credit_Open()
    {
        FindObjectOfType<Sound>().GetComponent<AudioSource>().Play();
        credit.SetActive(true);
        LOGO.SetActive(false);
        menu.SetActive(false);
    }
    public void LeaderBoard()
    {
        FindObjectOfType<Sound>().GetComponent<AudioSource>().Play();
        leaderboard.SetActive(true);
        LOGO.SetActive(false);
        menu.SetActive(false);
    }
    public void push_ball()
    {
        FindObjectOfType<Sound>().count += 1;
        if(FindObjectOfType<Sound>().count <= 10)
        {
            audioSource[FindObjectOfType<Sound>().count-1].Play();
        }
    }
    IEnumerator Load_Game()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Game");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
