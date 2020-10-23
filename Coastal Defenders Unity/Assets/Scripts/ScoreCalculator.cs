using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculator : MonoBehaviour
{
    public Text netScoreText;
    public static int netScore;
    private int[] trash;
    public GameObject highScore, medScore, lowScore;
    

    // Use this for initialization
    void Awake()
    {
        int sandDuneCount = PlayerPrefs.GetInt("sandDune");
        int oysterReefCount = PlayerPrefs.GetInt("oysterReef");
        int bulkheadCount = PlayerPrefs.GetInt("bulkhead");
        int floodGateCount = PlayerPrefs.GetInt("floodGate");
        int seaGrassCount = PlayerPrefs.GetInt("seaGrass");
        //PlayerPrefs.SetFloat("netScore", netScore);
        netScore = 60 + (sandDuneCount*30) + (oysterReefCount*44) + (bulkheadCount*15) + (floodGateCount*20) + (seaGrassCount*36);
        netScoreText.text = Mathf.RoundToInt(netScore).ToString();
        if(netScore >= 60 && netScore < 150)
        {
            lowScore.SetActive(true);
        }else if (netScore >= 150 && netScore < 275)
        {
            medScore.SetActive(true);
        }else if (netScore >= 275)
        {
            highScore.SetActive(true);
        }
    
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int[] getScores()
    {
        return trash;
    }
}
