using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour {

    [SerializeField] private int scorePerHit = 12;

    private int score;
    private Text scoreText;


	// Use this for initialization
	void Start () {

        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();


	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Update the score
    public void ScoreHit()
    {
        // Add points
        score = score + scorePerHit;

        // Display score
        scoreText.text = score.ToString();

    }

}
