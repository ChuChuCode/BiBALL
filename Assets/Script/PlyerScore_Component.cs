using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlyerScore_Component : MonoBehaviour
{
    [SerializeField] TMP_Text Name;
    [SerializeField] TMP_Text Score;
    void Start()
    {
        Name.text = "";
        Score.text = "";
    }

    public void Set_Name(string name)
    {
        // String trim
        if (name.Length > 20)
        {
            name = name.Substring(0,20) + "...";
        }
        Name.text = name;
    }
    public void Set_Score(string score)
    {
        Score.text = score;
    }
}
