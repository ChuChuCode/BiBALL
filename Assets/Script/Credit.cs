using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject LOGO;
    [SerializeField] GameObject credit;
    public void Button_Back()
    {
        FindObjectOfType<Sound>().GetComponent<AudioSource>().Play();
        menu.SetActive(true);
        LOGO.SetActive(true);
        credit.SetActive(false);
    }
    // Open URL
    public void To_URL(string url)
    {
        Application.OpenURL(url);
    }
}
