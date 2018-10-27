using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
///  Handles the state of the current game round, like player score, round time and random tile generation. 
/// </summary>
public class RoundManager : MonoBehaviour {

    public string ResultsScene;  // Name of the scene where the results are shown.

    public float RoundLength;  // Time in seconds.
    private float roundTimer;

    private int playerOneScore = 0;
    private int playeTwoScore = 0;
    
    // Use this for initialization
	void Start () {
        roundTimer = RoundLength;
	}
	
	// Update is called once per frame
	void Update () {
        roundTimer -= Time.deltaTime;

        if (roundTimer <= 0)
            SceneManager.LoadScene(ResultsScene);
	}
}
