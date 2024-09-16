using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class High_Score : MonoBehaviour
{
    [SerializeField]TMP_Text first_Score;
    [SerializeField]TMP_Text second_Score;
    [SerializeField]TMP_Text third_Score;
    public int mode;
    int first,second,third;
    void OnEnable()
    {
        if (mode == 0)
        {
            first = PlayerPrefs.GetInt("First", 0);
            second = PlayerPrefs.GetInt("Second", 0);
            third = PlayerPrefs.GetInt("Third", 0);
        }
        else
        {
            first = PlayerPrefs.GetInt("Challenge_First", 0);
            second = PlayerPrefs.GetInt("Challenge_Second", 0);
            third = PlayerPrefs.GetInt("Challenge_Third", 0);
        }
        first_Score.text = first.ToString() ;
        second_Score.text = second.ToString() ;
        third_Score.text = third.ToString() ;
    }
}
