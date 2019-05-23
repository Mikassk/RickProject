using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ez.Msg;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Counter : MonoBehaviour {
    //variaveis de score
    //public Text ScoreText;
    //public Text HighScoreText;

    //public float pontoscore ;
    //public float HighScoreCount;

   

    //fim variaveis score

    public int point = 1;

   public EzMsg.EventAction<IScoreCount> ApplyPointMsg
    {
        get { return _ => _.ApplyScore(point); }
    }
    public static EzMsg.EventFunc<IScoreCount, float?> GetpointScore = _ => _.GetScore();


    public AudioClip coinSound;

    private AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
       

    }
   

    //sistema de score
    public void Update()
    {

       
       

    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {



           EzMsg.Send<IScoreCount>(gameObject,_ => _.ApplyScore(point))
            .Wait(0.5f)
            .Run();
          // gSceneManager.Instance.score++;
            source.PlayOneShot(coinSound, 1.0f);
            Destroy(collision.gameObject);
        }
        var pontos = EzMsg.Request<IScoreCount, float?>(gameObject, GetpointScore);
        
    }
    //void addpontos()
    //{
    //    pontoscore += 1;
    //    try
    //    {
    //        ScoreText.text = "Score: " + pontoscore.ToString();
    //    }
    //    catch (NullReferenceException ex)
    //    {
    //        Debug.Log("error");
    //    }
    //}
    //void highscorepontos()
    //{
    //    HighScoreText.text = "HighScore: " + HighScoreCount.ToString();
    //}
}


