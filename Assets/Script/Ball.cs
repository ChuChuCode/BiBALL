using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool isReact = false;
    [SerializeField] Data data;
    public int level;
    [SerializeField] int score;
    public GameObject spawn_prefab;
    [SerializeField] GameObject Star;
    [SerializeField] AudioClip Drop_Sound;
    [SerializeField] AudioClip Combine_Sound;
    [SerializeField] AudioSource audioSource;
    void Start()
    {
        data = FindObjectOfType<Data>();
        // LeaderBoard Add
        if (level == 11)
        {
            PlayerPrefs.SetInt("Sana_Make", PlayerPrefs.GetInt("Sana_Make") + 1 );
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        // Already Collision -> prevent collision twice
        if (isReact) return;
        // Collision is not ball
        if (col.gameObject.tag != "Ball") return;
        // Check 2 balls are same level
        if (col.gameObject.GetComponent<Ball>().level == level)
        {
            col.gameObject.GetComponent<Ball>().isReact = true;
            // Get Center of 2 balls
            Vector3 temp = Vector3.Lerp(col.transform.position, transform.position, 0.5f);
            // Instantiate ball of next level
            GameObject new_ball = Instantiate(spawn_prefab,temp,Quaternion.identity);
            // Check ball level is 11 or not by checking script type
            if (new_ball.GetComponent<Ball>() != null)
            {
                new_ball.GetComponent<Ball>().Play_Combine();
                FindObjectOfType<Show_New_Ball>().Change_Image(true,level+1,true);
            }
            else
            {
                new_ball.GetComponent<Sana>().Play_Combine();
            }
            isReact = true;
            // Add point
            data.new_score += score;
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
    }
    public void Play_Drop()
    {
        audioSource.clip = Drop_Sound;
        audioSource.Play();
    }
    public void Play_Combine()
    {
        audioSource.clip = Combine_Sound;
        audioSource.Play();
    }
}
