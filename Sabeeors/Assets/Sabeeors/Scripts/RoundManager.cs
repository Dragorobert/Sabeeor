using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
///  Handles the state of the current game round, like player score, round time and random tile generation. 
/// </summary>
public class RoundManager : MonoBehaviour {

    public GameObject FlowerPrefab;
    private float flowerSpawnTimer = 10;

    public string ResultsScene;  // Name of the scene where the results are shown.

    public float RoundLength;  // Time in seconds.
    private float roundTimer;

    public string playerOneTag;
    public string playerTwoTag;

    private int playerOneScore = 0;
    private int playeTwoScore = 0;

    private Text playerOneText;
    private Text playerTwoText;
    private Text timerText;

    // Use this for initialization
    void Start () {
        roundTimer = RoundLength;

        GameObject canvas = GameObject.Find("Canvas");
        playerOneText = canvas.transform.Find("P1 Score").GetComponent<Text>();
        playerTwoText = canvas.transform.Find("P2 Score").GetComponent<Text>();
        timerText = canvas.transform.Find("Timer").GetComponent<Text>();

        if (playerOneText == null || playerTwoText == null || timerText == null)
            Debug.LogError("Error finding text objects.");

        for (int i = 0; i < 5; i++)
            SpawnFlower();
    }

    private void SpawnFlower()
    {
        Vector3 spawnPosition = new Vector3(RandomGridPosition(), RandomGridPosition(), 0);
        Instantiate(FlowerPrefab, spawnPosition, Quaternion.identity);
    }

    private float RandomGridPosition()
    {
        return Mathf.Round(Random.Range(-5f, 4f));
    }
	
	// Update is called once per frame
	void Update () {
        roundTimer -= Time.deltaTime;
        timerText.text = Mathf.Round(roundTimer).ToString();

        if (roundTimer <= 0)
            SceneManager.LoadScene(ResultsScene);

        flowerSpawnTimer -= Time.deltaTime;
        if (flowerSpawnTimer <= 0) {
            SpawnFlower();
            flowerSpawnTimer = Random.Range(5, 15);
        }
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
