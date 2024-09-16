using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pause : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject pause;
    [SerializeField] Mouse_Click click;
    public void pause_btn()
    {
        FindObjectOfType<Sound>().GetComponent<AudioSource>().Play();
        click.GameOver = true;
        Time.timeScale = 0f;
        pause.SetActive(true);
        gameObject.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
       click.GameOver = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        click.GameOver = false;
    }
}
