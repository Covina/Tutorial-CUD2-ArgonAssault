using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour {

    [SerializeField] private int scorePerHit = 12;

    // time based score bonus
    private int survivalBonus = 1;
    private float timeBonusInterval = 2.0f;
    private float currentTimeBonusTracker = 0.0f;

    // Score
    private int score;
    private Text scoreText;


	// Use this for initialization
	void Start () {

        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();

        currentTimeBonusTracker = timeBonusInterval;

	}
	
	// Update is called once per frame
	void Update () {

        // bonus points for being alive
        currentTimeBonusTracker -= Time.deltaTime;
        if(currentTimeBonusTracker <= 0)
        {
            // add score
            score += survivalBonus;

            // Update score
            UpdateScore();

            // reset timer
            currentTimeBonusTracker = timeBonusInterval;
        }
		
	}

    /// <summary>
    /// Add to score the amount for the enemy
    /// </summary>
    public void ScoreHit(int points)
    {
        // Add points
        score += points;

        UpdateScore();

    }

    /// <summary>
    /// Update the HUD display for score
    /// </summary>
    public void UpdateScore()
    {
        // Display score
        scoreText.text = score.ToString();
    }

}
