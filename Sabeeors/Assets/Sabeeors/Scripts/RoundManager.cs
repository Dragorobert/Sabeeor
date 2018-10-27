using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
///  Handles the state of the current game round, like player score, round time and random tile generation. 
/// </summary>
public class RoundManager : MonoBehaviour {

    public string ResultsScene;  // Name of the scene where the results are shown.

    public float RoundLength;  // Time in seconds.
    private float roundTimer;

    public string playerOneTag;
    public string playerTwoTag;

    private int playerOneScore = 0;
    private int playeTwoScore = 0;

    private Text playerOneText;
    private Text playerTwoText;

    // Use this for initialization
    void Start () {
        roundTimer = RoundLength;

        GameObject canvas = GameObject.Find("Canvas");
        playerOneText = canvas.transform.Find("P1 Score").GetComponent<Text>();
        playerTwoText = canvas.transform.Find("P2 Score").GetComponent<Text>();

        if (playerOneText == null || playerTwoText == null)
            Debug.LogError("Error finding score text objects.");
    }
	
	// Update is called once per frame
	void Update () {
        roundTimer -= Time.deltaTime;

        if (roundTimer <= 0)
            SceneManager.LoadScene(ResultsScene);
	}
    
    public void AddScore(string player,int score)
    {
        if (player == playerOneTag)
        {
            playerOneScore += score;
            playerOneText.text = playerOneScore.ToString();
        }
        else if (player == playerTwoTag)
        {
            playeTwoScore += score;
            playerTwoText.text = playeTwoScore.ToString();
        }
    }
}
