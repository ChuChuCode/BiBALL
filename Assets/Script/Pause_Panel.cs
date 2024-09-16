using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Panel : MonoBehaviour
{
    [SerializeField] GameObject pause_btn;
    [SerializeField] GameObject leaderboard;
    [SerializeField] GameObject setting;
    [SerializeField] Mouse_Click click;
    public void Resume()
    {
        FindObjectOfType<Sound>().GetComponent<AudioSource>().Play();
        click.GameOver = false;
        Time.timeScale = 1f;
        pause_btn.SetActive(true);
        gameObject.SetActive(false);
    }
    public void New_Game()
    {
        FindObjectOfType<Sound>().count = 0;
        FindObjectOfType<Sound>().GetComponent<AudioSource>().Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void LeaderBoard()
    {
        FindObjectOfType<Sound>().GetComponent<AudioSource>().Play();
        leaderboard.SetActive(true);
        leaderboard.GetComponent<LeaderBoard>().state = 1;
        gameObject.SetActive(false);
    }
    public void Menu()
    {
        FindObjectOfType<Sound>().count = 0;
        FindObjectOfType<Sound>().GetComponent<AudioSource>().Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void Setting()
    {
        FindObjectOfType<Sound>().GetComponent<AudioSource>().Play();
        setting.SetActive(true);
        gameObject.SetActive(false);
    }
}
