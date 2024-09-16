using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Data : MonoBehaviour
{
    [SerializeField]TMP_Text new_Score_text;
    private int _new_score;
    public int new_score
    {
        get
        {
            return _new_score;
        }
        set
        {
            _new_score = value;
            Change_Text();
            Check_Character();
        }
    }
    int first ;
    int second ;
    int third ;
    int challenge_first;
    int challenge_second;
    int challenge_thrid;
    [Header("GameObject")]
    [SerializeField]GameObject fuwawa_human;
    [SerializeField]GameObject mococo_human;
    [SerializeField]GameObject shiori;
    [SerializeField]GameObject nerissa;
    [SerializeField]GameObject fuwawa_puppy;
    [SerializeField]GameObject mococo_puppy;
    [SerializeField] GameObject[] Easter;
    [Header("Music")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip fuwawa_human_clip;
    [SerializeField] AudioClip fuwawa_puppy_clip;
    [SerializeField] AudioClip mococo_human_clip;
    [SerializeField] AudioClip mococo_puppy_clip;
    [SerializeField] AudioClip shiori_clip;
    [SerializeField] AudioClip nerissa_clip;
    int stage = 0;
    void Start()
    {
        new_score = 0 ;
        first = PlayerPrefs.GetInt("First", 0);
        second = PlayerPrefs.GetInt("Second", 0);
        third = PlayerPrefs.GetInt("Third", 0);
        challenge_first = PlayerPrefs.GetInt("Challenge_First", 0);
        challenge_second = PlayerPrefs.GetInt("Challenge_Second", 0);
        challenge_thrid = PlayerPrefs.GetInt("Challenge_Third", 0);
        fuwawa_human.SetActive(false);
        mococo_human.SetActive(false);
        shiori.SetActive(false);
        nerissa.SetActive(false);
        fuwawa_puppy.SetActive(false);
        mococo_puppy.SetActive(false);
    }
    public int Save()
    {
        if (FindObjectOfType<Sound>().mode == 0)
        {
            if (_new_score > first)
            {
                third = second;
                second = first;
                first = _new_score;
                PlayerPrefs.SetInt("First", first);
                PlayerPrefs.SetInt("Second", second);
                PlayerPrefs.SetInt("Third", third);
                return first;
            }
            else if (_new_score > second)
            {
                third = second;
                second = _new_score;
                PlayerPrefs.SetInt("Second", second);
                PlayerPrefs.SetInt("Third", third);
            }
            else if (_new_score > third)
            {
                third = _new_score;
                PlayerPrefs.SetInt("Third", third);
            }
            return 0;
        }
        else
        {
            if (_new_score > challenge_first)
            {
                challenge_thrid = challenge_second;
                challenge_second = challenge_first;
                challenge_first = _new_score;
                PlayerPrefs.SetInt("Challenge_First", challenge_first);
                PlayerPrefs.SetInt("Challenge_Second", challenge_second);
                PlayerPrefs.SetInt("Challenge_Third", challenge_thrid);
                return challenge_first;
            }
            else if (_new_score > challenge_second)
            {
                challenge_thrid = challenge_second;
                challenge_second = _new_score;
                PlayerPrefs.SetInt("Challenge_Second", challenge_second);
                PlayerPrefs.SetInt("Challenge_Third", challenge_thrid);
            }
            else if (_new_score > challenge_thrid)
            {
                challenge_thrid = _new_score;
                PlayerPrefs.SetInt("Challenge_Third", challenge_thrid);
            }
            return 0;
        }
    }
    void Change_Text()
    {
        new_Score_text.text = _new_score.ToString();
    }
    void Check_Character()
    {
       if (_new_score >= (10000 + (stage - 6)* 5000 ) && stage > 5)
        {
            int rand_int = Random.Range(0,Easter.Length);
            StartCoroutine(easter_egg(Easter[rand_int]));
            stage ++;
        }
        else if (_new_score >= 9000 && stage == 5)
        {
            audioSource.clip = mococo_puppy_clip;
            audioSource.Play();
            mococo_puppy.SetActive(true);
            mococo_human.SetActive(false);
            stage ++;
        }
        else if (_new_score >= 7500 && stage == 4)
        {
            audioSource.clip = fuwawa_puppy_clip;
            audioSource.Play();
            fuwawa_puppy.SetActive(true);
            fuwawa_human.SetActive(false);
            stage ++;
        }
        else if (_new_score >= 6000 && stage == 3)
        {
            audioSource.clip = nerissa_clip;
            audioSource.Play();
            nerissa.SetActive(true);
            stage ++;
        }
        else if (_new_score >= 4500 && stage == 2)
        {
            audioSource.clip = shiori_clip;
            audioSource.Play();
            shiori.SetActive(true);
            stage ++;
        }
        else if (_new_score >= 3000 && stage == 1)
        {
            audioSource.clip = mococo_human_clip;
            audioSource.Play();
            mococo_human.SetActive(true);
            stage ++;
        }
        else if (_new_score >= 1500 && stage == 0)
        {
            audioSource.clip = fuwawa_human_clip;
            audioSource.Play();
            fuwawa_human.SetActive(true);
            stage ++;
        }
    }
    IEnumerator easter_egg(GameObject show)
    {
        show.SetActive(true);
        yield return new WaitForSeconds(10);
        show.SetActive(false);
    }
}
