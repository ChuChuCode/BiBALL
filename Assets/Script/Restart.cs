using System;
using System.Collections;
using System.Collections.Generic;

using System.Xml.Linq;
using UnityEngine;
using UnityEngine.Networking;
#if !UNITY_EDITOR && UNITY_WEBGL
using System.Runtime.InteropServices;
#endif

using UnityEngine.SceneManagement;
using Unity.Services.Authentication;
using TMPro;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    [SerializeField] GameObject save_btn;
    [SerializeField] GameObject Score_Panel;
    [SerializeField] Data data;
    [SerializeField] LeaderBoard_Controller leaderBoard_Controller;
    [SerializeField] GameObject leaderboard;
    [SerializeField] TMP_InputField input_name;
    [SerializeField] List<GameObject> score_list ;
    int score;
    [SerializeField] private string _imgurClientId;

#if !UNITY_EDITOR && UNITY_WEBGL
    [DllImport("__Internal")]
    private static extern string TweetFromUnity(string rawMessage);
#endif
    string message;
    void OnEnable()
    {
        score = data.new_score;
        string socre_str = score.ToString();
        foreach (Transform child in Score_Panel.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (char num in socre_str)
        {
            Instantiate(score_list[ (int) (num - '0') ], Vector3.zero, Quaternion.identity, Score_Panel.transform);
        }
    }
    public void Rank()
    {
        FindObjectOfType<Sound>().GetComponent<AudioSource>().Play();
        leaderboard.SetActive(true);
        leaderboard.GetComponent<LeaderBoard>().state = 2;
        gameObject.SetActive(false);
    }
    public void Btn_Reset()
    {
        // Reset mode
        FindObjectOfType<Sound>().count = 0;
        FindObjectOfType<Sound>().GetComponent<AudioSource>().Play();
        if (!FindObjectOfType<BGM>().GetComponent<AudioSource>().isPlaying)
        {
            FindObjectOfType<BGM>().GetComponent<AudioSource>().Play();
        }
        Time.timeScale = 1f;
        // Reset Scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Menu()
    {
        FindObjectOfType<Sound>().GetComponent<AudioSource>().Play();
        // Reset mode
        FindObjectOfType<Sound>().count = 0;
        if (!FindObjectOfType<BGM>().GetComponent<AudioSource>().isPlaying)
        {
            FindObjectOfType<BGM>().GetComponent<AudioSource>().Play();
        }
        Time.timeScale = 1f;
        // Back to Menu
        SceneManager.LoadScene("MainMenu");
    }
    public void Save()
    {
        FindObjectOfType<Sound>().GetComponent<AudioSource>().Play();
        // Prevent empty name
        if (input_name.text == "") return;
        PlayerPrefs.SetString("name",input_name.text);
        // Update LeaderBoard Name
        AuthenticationService.Instance.UpdatePlayerNameAsync(input_name.text);
        // Add Score to LeaderBoard
        if (FindObjectOfType<Sound>().mode == 0)
        {
            leaderBoard_Controller.AddScore("Suika-LeaderBoard",score);
        }
        else
        {
            leaderBoard_Controller.AddScore("Challenge_Suika",score);
        }
        leaderBoard_Controller.AddScore("Suika-LeaderBoard",score);
        // Disable GameObject
        input_name.gameObject.SetActive(false);
        save_btn.SetActive(false);
    }
    public void TweetWithScreenshot()
    {
        StartCoroutine(TweetWithScreenshotCo());
    }

    IEnumerator TweetWithScreenshotCo()
    {
        yield return new WaitForEndOfFrame();
        // Get Image to Texture2D
        Texture2D tex = ScreenCapture.CaptureScreenshotAsTexture();

        var wwwForm = new WWWForm();
        wwwForm.AddField("image", Convert.ToBase64String(tex.EncodeToJPG()));
        wwwForm.AddField("type", "base64");

        // Upload to Imgur
        UnityWebRequest www = UnityWebRequest.Post("https://api.imgur.com/3/image.xml", wwwForm);
        www.SetRequestHeader("AUTHORIZATION", "Client-ID " + _imgurClientId);

        yield return www.SendWebRequest();

        var uri = "";

        if (!www.isNetworkError)
        {
            XDocument xDoc = XDocument.Parse(www.downloadHandler.text);
            uri = xDoc.Element("data")?.Element("link")?.Value;

            // Remove Ext
            uri = uri?.Remove(uri.Length - 4, 4);
        }

#if !UNITY_EDITOR && UNITY_WEBGL

        message =$"I got {score.ToString()} in BiBALL.%0aPlay with me at https://kerwinchu.itch.io/biball%0a{uri}%0a%0a%23BiBALL";

        TweetFromUnity(message);
#endif
    }
}

