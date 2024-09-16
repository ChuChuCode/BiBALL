using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mouse_Click : MonoBehaviour
{   
    public bool GameOver = false;
    [SerializeField] Next_Ball next_ball;
    [SerializeField] List<GameObject> dict_ = new List<GameObject>();
    [SerializeField] GameObject temp_go;
    [Header("Biboo")]
    float hand_left = 0.3f;
    float hand_right = 1.42f;
    [SerializeField] Sprite open;
    [SerializeField] Sprite close;
    [SerializeField] Sprite happy;
    [SerializeField] Sprite normal;
    [SerializeField] Animator Doodle_eye;
    [SerializeField] SpriteRenderer Face;
    [SerializeField] SpriteRenderer Hand;
    [SerializeField] Transform Arm;
    int random_int;
    int random_next_int;
    float position_x;
    float height = 3.6f;
    float right = 5.8f;
    float left = -4.0f;
    bool is_easter = false;
    Vector2 mousePosition;
    [Header("Mode GameObject")]
    [SerializeField] GameObject Normal;
    [SerializeField] GameObject Challenge;
    void Start()
    {
        if (FindObjectOfType<Sound>().count > 9 )
        {
            is_easter = true;
        }
        if (FindObjectOfType<Sound>().mode == 0 )
        {
            Normal.SetActive(true);
            Challenge.SetActive(false);
        }
        else
        {
            Normal.SetActive(false);
            Challenge.SetActive(true);
        }
        Hand.sprite = close;
        if (is_easter)
        {
            Doodle_eye.gameObject.SetActive(true);
            Face.gameObject.SetActive(false);
        }
        else
        {
            Doodle_eye.gameObject.SetActive(false);
            Face.sprite = normal;
        }
        random_int = Random.Range (0, dict_.Count);
        random_next_int = Random.Range (0, dict_.Count);
        next_ball.Set_Image(random_next_int);
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position_x = Position_Check(mousePosition.x);
        temp_go = Instantiate(dict_[random_int],new Vector3(position_x,height,0),Quaternion.identity);
        Hand.transform.position = new Vector3(position_x,height,0);
        float x = (position_x - left) / (right - left) * (hand_right - hand_left) + hand_left ;
        Arm.localScale = new Vector3(x,Arm.localScale.y,Arm.localScale.z);
        temp_go.GetComponent<Rigidbody2D>().isKinematic = true;
        temp_go.GetComponent<CircleCollider2D>().enabled = false;
    }
    void Update()
    {
        if (GameOver) return;
        if (Application.isMobilePlatform)
        {
            mousePosition = Input.GetTouch(0).position ;
        }
        else
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        position_x = Position_Check(mousePosition.x);
        Hand.transform.position = new Vector3(position_x,height,0);
        float x = (position_x - left) / (right - left) * (hand_right - hand_left) + hand_left ;
        Arm.localScale = new Vector3(x,Arm.localScale.y,Arm.localScale.z);
        if(temp_go == null) return;
        temp_go.transform.position = new Vector3(position_x,height,0);

        if (   (!Application.isMobilePlatform && Input.GetButtonDown("Fire1") )
            || (Application.isMobilePlatform && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended) )
        {
            PlayerPrefs.SetInt("Throw_Time", PlayerPrefs.GetInt("Throw_Time") + 1 );
            Hand.sprite = open;
            if (is_easter)
            {
                Doodle_eye.SetTrigger("Doodle");
            }
            else
            {
                Face.sprite = happy;
            }
            temp_go.GetComponent<Ball>().Play_Drop();
            temp_go.GetComponent<Rigidbody2D>().isKinematic = false;
            temp_go.GetComponent<CircleCollider2D>().enabled = true;
            temp_go = null;
            Spawn();
        }
    }
    public void Spawn()
    {
        random_int = random_next_int ;
        random_next_int = Random.Range (0, dict_.Count);
        StartCoroutine(Spawn_Ball());
    }
    IEnumerator Spawn_Ball()
    {
        yield return new WaitForSeconds(0.7f);
        Hand.sprite = close;
        if (!is_easter)
        {
            Face.sprite = normal;
        }
        next_ball.Set_Image(random_next_int);
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        position_x = Position_Check(mousePosition.x);
        temp_go = Instantiate(dict_[random_int],new Vector3(position_x,height,0),Quaternion.identity);
        temp_go.GetComponent<Rigidbody2D>().isKinematic = true;
        temp_go.GetComponent<CircleCollider2D>().enabled = false;
    }
    float Position_Check(float mouse)
    {
        if (mouse <= left ) 
        {
            return left;
        }
        else if (mouse >= right )
        {
            return right;
        } 
        else
        {
            return mouse;
        }
    }
}
