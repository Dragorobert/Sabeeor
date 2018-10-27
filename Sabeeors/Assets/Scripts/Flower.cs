﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script for flowers the playes can collide with to gain points.
/// Flower must be a trigger.
/// </summary>
public class Flower : MonoBehaviour {

    public int Points = 1;  // Score obtained by getting this flower.

    private RoundManager roundManager;

    private string playerOneTag;
    private string playerTwoTag;

	// Use this for initialization
	void Start () {
        roundManager = GameObject.Find("RoundManager").GetComponent<RoundManager>();

        if (roundManager == null)
            Debug.LogError("Round manager not found!");

        playerOneTag = roundManager.playerOneTag;
        playerTwoTag = roundManager.playerTwoTag;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(playerOneTag))
            roundManager.AddScore(playerOneTag, Points);
        else if (collision.gameObject.CompareTag(playerTwoTag))
            roundManager.AddScore(playerTwoTag, Points);

        if (collision.gameObject.CompareTag(playerOneTag) || collision.gameObject.CompareTag(playerTwoTag))
            Destroy(gameObject);
    }
}
