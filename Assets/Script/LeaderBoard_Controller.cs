using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Leaderboards;
using Unity.Services.Leaderboards.Models;
using UnityEngine;

public class LeaderBoard_Controller : MonoBehaviour
{
    const string LeaderboardId = "Suika-LeaderBoard";
    const string Throw_Time = "Throw_Time";
    const string Sana_Make = "Sana_Make";
    const string Sana_Eternal = "Sana_Eternal";
    string VersionId { get; set; }
    int Offset { get; set; }
    int Limit { get; set; }
    int RangeLimit { get; set; }
    List<string> FriendIds { get; set; }
    async void Awake()
    {
        await UnityServices.InitializeAsync();

        await SignInAnonymously();
    }
    async Task SignInAnonymously()
    {
        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log("Signed in as: " + AuthenticationService.Instance.PlayerId);
        };
        AuthenticationService.Instance.SignInFailed += s =>
        {
            // Take some action here...
            Debug.Log(s);
        };
        if (!AuthenticationService.Instance.IsSignedIn)
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
        }      
    }
    public async void AddScore(string id,int score)
    {
        var scoreResponse = await LeaderboardsService.Instance.AddPlayerScoreAsync(id, score);
        Debug.Log(JsonConvert.SerializeObject(scoreResponse));
    }
    public async Task<List<LeaderboardEntry>> GetPaginatedScores(string table)
    {
        Offset = 0;
        Limit = 10;
        LeaderboardScoresPage scoresResponse =
            await LeaderboardsService.Instance.GetScoresAsync(table, new GetScoresOptions{Offset = Offset, Limit = Limit});
        return new(scoresResponse.Results);
    }
    public async void GetScores()
    {
        LeaderboardScoresPage scoresResponse =
            await LeaderboardsService.Instance.GetScoresAsync(LeaderboardId);
        double sum = 0;
        for (int i = 0 ; i < scoresResponse.Results.Count ; i++)
        {
            sum += scoresResponse.Results[i].Score;
        }
        print(sum);
    }


    public async void GetPlayerScore()
    {
        var scoreResponse = 
            await LeaderboardsService.Instance.GetPlayerScoreAsync(LeaderboardId);
        Debug.Log(JsonConvert.SerializeObject(scoreResponse));
    }
}
