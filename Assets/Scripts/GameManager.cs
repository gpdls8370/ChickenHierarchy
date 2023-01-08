using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    GameObject player;

    int score = 0;
    public Text scoreText;


    public static GameManager instance;



    void Awake()
    {

        if (GameManager.instance == null)

            GameManager.instance = this;

    }

    // Use this for initialization

    void Start()
    {

        //Invoke("StartGame", 3f);

    }



    void StartGame()
    {
        //player.GetComponent<player>().canShoot = true;
    }


    public void AddScore(int AddScore)
    {
        score = score + AddScore;           //AddScore만큼 점수 올리기
       // scoreText.text = "점수:"+ score;  //점수 띄우기

    }

    public void Result(string result,string SceneName)
    {
        if(result == "success")
        {
            SceneManager.LoadScene(SceneName);     //result가 success이면 다음화면으로 넘기기
        }
        else if(result == "fail")
        {
            SceneManager.LoadScene("Fail");    //result가 fail이면 Fail화면 띄우기(result보낼때 지연 invoke넣기)
        }
    }

}
