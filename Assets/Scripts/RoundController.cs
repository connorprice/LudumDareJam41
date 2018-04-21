﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundController : MonoBehaviour {

    public TurnController tc;
    public bool nextRound = true;
    private GameObject player1;
    private GameObject player2;
    private Vector3 player1_startpos;
    private Vector3 player2_startpos;
    public float positioning_period_time;
    public float positioning_period_time_remaining;
    public Text timeRemainingText;


    private void Start()
    {
        player1 = tc.player1.gameObject;
        player2 = tc.player2.gameObject;
        player1_startpos = player1.transform.position;
        player2_startpos = player2.transform.position;
        positioning_period_time = 10f;
        positioning_period_time_remaining = positioning_period_time;
    }

    private void Update()
    {

        if (nextRound)
        {
            
            timeRemainingText.text = ((int)positioning_period_time_remaining+1).ToString();
            positioning_period_time_remaining -= Time.deltaTime;

            if(positioning_period_time_remaining <= 0)
            {
                timeRemainingText.gameObject.SetActive(false);

                tc.stopPlayer(tc.player2);
                nextRound = false;
                tc.running = true;
            }

        }

    }

    public void resetGame (){


        player1.GetComponent<HealthManager>().health = player1.GetComponent<HealthManager>().maxHealth;
        player2.GetComponent<HealthManager>().health = player2.GetComponent<HealthManager>().maxHealth;
        player1.transform.position = player1_startpos;
        player2.transform.position = player2_startpos;
        tc.currentPlayer = null;
        tc.startPlayer(tc.player1);
        tc.startPlayer(tc.player2);

        // Move to conditional
        // tc.running = true;
        // nextRound = false;

    }

}