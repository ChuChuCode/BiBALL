using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject Process_Map;
    [SerializeField] GameObject New;
    [SerializeField] SpriteRenderer phone;
    [SerializeField] Sprite phone_light;
    [SerializeField] Sprite phone_dark;
    [SerializeField] Mouse_Click click;
    void Start()
    {
        Process_Map.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
       Process_Map.SetActive(true);
       New.SetActive(false);
       phone.sprite = phone_light;
       click.GameOver = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        Process_Map.SetActive(false);
        phone.sprite = phone_dark;
        click.GameOver = false;
    }
}
