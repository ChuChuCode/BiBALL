using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Show_New_Ball : MonoBehaviour
{
    [Header("Image")]
    [SerializeField]Image Ina_img;
    [SerializeField] Image Fauna_img;
    [SerializeField] Image Kiara_img;
    [SerializeField] Image IRyS_img;
    [SerializeField] Image Calli_img;
    [SerializeField] Image Kronii_img;
    [SerializeField] Image Sana_img;
    [Header("Sprites")]
    [SerializeField] Sprite Ina;
    [SerializeField] Sprite Fauna;
    [SerializeField] Sprite Kiara;
    [SerializeField] Sprite IRyS;
    [SerializeField] Sprite Calli;
    [SerializeField] Sprite Kronii;
    [SerializeField] Sprite Sana;
    [Header("New_Tab")]
    [SerializeField] GameObject New;
    void OnEnable()
    {
        Change_Image( PlayerPrefs.GetInt("Ina"   , 0) != 0, 5 ,false);
        Change_Image( PlayerPrefs.GetInt("Fauna" , 0) != 0, 6 ,false);
        Change_Image( PlayerPrefs.GetInt("Kiara" , 0) != 0, 7 ,false);
        Change_Image( PlayerPrefs.GetInt("IRyS"  , 0) != 0, 8 ,false);
        Change_Image( PlayerPrefs.GetInt("Calli" , 0) != 0, 9 ,false);
        Change_Image( PlayerPrefs.GetInt("Kronii", 0) != 0, 10,false);
        Change_Image( PlayerPrefs.GetInt("Sana"  , 0) != 0, 11,false);
    }

    // Change Image Show/Hide
    public void Change_Image(bool isShow, int level,bool isNew)
    {
        if (!isShow) return;
        switch (level)
        {
            case 5:
                if (PlayerPrefs.GetInt("Ina",0) == 0)
                {
                    New.SetActive(true);
                }
                PlayerPrefs.SetInt("Ina", 1);
                Ina_img.sprite = Ina;
                break;
            case 6:
                if (PlayerPrefs.GetInt("Fauna",0) == 0)
                {
                    New.SetActive(true);
                }
                PlayerPrefs.SetInt("Fauna", 1);
                Fauna_img.sprite = Fauna;
                break;
            case 7:
                if (PlayerPrefs.GetInt("Kiara",0) == 0)
                {
                    New.SetActive(true);
                }
                PlayerPrefs.SetInt("Kiara", 1);
                Kiara_img.sprite = Kiara;
                break;
            case 8:
                if (PlayerPrefs.GetInt("IRyS",0) == 0)
                {
                    New.SetActive(true);
                }
                PlayerPrefs.SetInt("IRyS", 1);
                IRyS_img.sprite = IRyS;
                break;
            case 9:
                if (PlayerPrefs.GetInt("Calli",0) == 0)
                {
                    New.SetActive(true);
                }
                PlayerPrefs.SetInt("Calli", 1);
                Calli_img.sprite = Calli;
                break;
            case 10:
                if (PlayerPrefs.GetInt("Kronii",0) == 0)
                {
                    New.SetActive(true);
                }
                PlayerPrefs.SetInt("Kronii", 1);
                Kronii_img.sprite = Kronii;
                break;
            case 11:
                if (PlayerPrefs.GetInt("Sana",0) == 0)
                {
                    New.SetActive(true);
                }
                PlayerPrefs.SetInt("Sana", 1);
                Sana_img.sprite = Sana;
                break;
            default:
                return;
        }
    }
}
