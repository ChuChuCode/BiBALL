using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Next_Ball : MonoBehaviour
{
    [SerializeField] List<Sprite> ball_image = new List<Sprite>();
    [SerializeField] Image image;
    public void Set_Image(int ball_size)
    {
        image.sprite = ball_image[ball_size];
    }
}
