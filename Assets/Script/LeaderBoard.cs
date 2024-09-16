using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Leaderboards.Models;
using System;
using TMPro;
using UnityEngine.UI;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] LeaderBoard_Controller leaderBoard_Controller;
    public int state = 1;
    [SerializeField] GameObject menu_pause;
    [SerializeField] GameObject menu_end;
    [SerializeField] GameObject LOGO;
    [SerializeField] List<PlyerScore_Component> list;
    [SerializeField] GameObject leaderboard_Group;
    [SerializeField] GameObject leaderboard_Single;
    [SerializeField] TMP_Text btn;
    [SerializeField] Image btn_color;
    public bool is_Challenge = false;
    void Start()
    {
        Set_Score("Suika-LeaderBoard");
        leaderboard_Group.SetActive(true);
        leaderboard_Single.SetActive(false);
    }
    public void Change_Btn()
    {
        FindObjectOfType<Sound>().GetComponent<AudioSource>().Play();
        if (leaderboard_Group.activeSelf && !is_Challenge)
        {
            leaderboard_Single.GetComponent<High_Score>().mode = 0;
            btn_color.color = Color.red;
            btn.text = "GLOBAL";
            leaderboard_Group.SetActive(false);
            leaderboard_Single.SetActive(true);
        }
        else if (leaderboard_Single.activeSelf && !is_Challenge)
        {
            btn.text = "LOCAL";
            is_Challenge = !is_Challenge;
            Set_Score("Challenge_Suika");
            leaderboard_Single.SetActive(false);
            leaderboard_Group.SetActive(true);
        }
        else if (leaderboard_Group.activeSelf && is_Challenge)
        {
            leaderboard_Single.GetComponent<High_Score>().mode = 1;
            btn_color.color = Color.white;
            btn.text = "GLOBAL";
            leaderboard_Group.SetActive(false);
            leaderboard_Single.SetActive(true);
        }
        else if (leaderboard_Single && is_Challenge)
        {
            btn.text = "LOCAL";
            is_Challenge = !is_Challenge;
            Set_Score("Suika-LeaderBoard");
            leaderboard_Single.SetActive(false);
            leaderboard_Group.SetActive(true);
        }
    }
    public void Button_Back()
    {
        FindObjectOfType<Sound>().GetComponent<AudioSource>().Play();
        LOGO.SetActive(true);
        if (state == 1)
        {
            menu_pause.SetActive(true);
        }
        else if (state == 2)
        {
            menu_end.SetActive(true);;
        }
        gameObject.SetActive(false);
    }
    async void Set_Score(string table)
    {
        List<LeaderboardEntry> score = await leaderBoard_Controller.GetPaginatedScores(table);
        print(score);
        for (int i = 0 ; i < 10 ; i++)
        {
            if (i < score.Count)
            {
                list[i].Set_Name( score[i].PlayerName.Split("#")[0] );
                list[i].Set_Score( Convert.ToInt32(score[i].Score).ToString() );
            }
            else
            {
                list[i].Set_Name("");
                list[i].Set_Score("");
            }
        }
    }
}
