using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadordePonto : MonoBehaviour
{
    public Text scoretext;
    public Text highscoretext;

    public float score;
    public float highscore;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        scoretext.text = "score: " + score;
        highscoretext.text = "highscore: " + highscore;

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            Debug.Log("é");
            score += 1;
        }
    }
}
