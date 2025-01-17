﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class GameEndController : MonoBehaviour {

    public GameObject topBar;
    public GameObject upperSection;
    public GameObject middleSection;
    public GameObject lowerSection;

    public static int[] aDefense;
    public static int[] bDefense;
    public static int[] cDefense;
    public int wipeRoll;


    public RawImage image;
    public string nextScene;
    public UnityEngine.Video.VideoPlayer videoPlayer;
    private VideoSource videoSource;
    /*
     * 0 - Sand Dunes
     * 1 - Oyster Reefs
     * 2 - Bulkheads
     * 3 - Floodgates
     * 4 - Sandgrass
     */
    private int[] currentResourceNumbers;

    // Use this for initialization
    void Start () {
        Application.runInBackground = true;
        StartCoroutine(playVideo());
        currentResourceNumbers = GameController.GetResourceNumbers();
        // Debugging purposes, manually putting in 1 of each resource
        if(currentResourceNumbers == null) {
            currentResourceNumbers = new int[5] { 1, 1, 1, 1, 1 };
        }

        aDefense = new int[] {2, 11, 3, 6, 8};
        bDefense = new int[] {7, 4, 6, 16, 3};
        cDefense = new int[] {3, 1, 9, 25, 4};
        wipeRoll = WipeChance();

        LoadResources();
        //StartCoroutine(playVideo());
        //nextScreen();
    }

    IEnumerator playVideo()
    {
        //Disable Play on Awake for both Video and Audio
        videoPlayer.playOnAwake = false;

        //Wait until video is prepared
        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }

        Debug.Log("Done Preparing Video");

        //Assign the Texture from Video to RawImage to be displayed
        image.texture = videoPlayer.texture;

        //Play Video
        videoPlayer.Play();

        Debug.Log("Playing Video");
        while (videoPlayer.isPlaying)
        {
            yield return null;
        }

        Debug.Log("Done Playing Video");
        SceneManager.LoadScene(nextScene);
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void nextScreen()
    {
        SceneManager.LoadScene("endgame");
    }

    private void LoadResources() {
        GameObject mainGame = GetChildren(upperSection)[0];

        for (int resourceNumber = 0; resourceNumber < currentResourceNumbers.Length; resourceNumber++) {
            GameObject resourceArray = GetChildren(mainGame)[resourceNumber + 1];
            
            for(int i = 0; i < currentResourceNumbers[resourceNumber]; i++) {
                GameObject desiredResource = GetChildren(resourceArray)[i];

                desiredResource.SetActive(true);
            }
        }
    }
    private void RemoveResources() {
        GameObject mainGame = GetChildren(upperSection)[0];

        for (int resourceNumber = 0; resourceNumber < currentResourceNumbers.Length; resourceNumber++) {
            GameObject resourceArray = GetChildren(mainGame)[resourceNumber + 1];

            for (int i = 0; i < currentResourceNumbers[resourceNumber]; i++) {
                GameObject desiredResource = GetChildren(resourceArray)[i];

                int destructionRoll = Random.Range(1, 100);
                Debug.Log(destructionRoll);
                if(destructionRoll > wipeRoll) {
                    desiredResource.SetActive(false);
                }
            }
        }
    }

    private int WipeChance() {
        int aTotalDefense = 0;
        int bTotalDefense = 0;
        int cTotalDefense = 0;

        for (int i = 0; i < currentResourceNumbers.Length; i++)
        {
            aTotalDefense += currentResourceNumbers[i] * aDefense[i];
            bTotalDefense += currentResourceNumbers[i] * bDefense[i];
            cTotalDefense += currentResourceNumbers[i] * cDefense[i];
        }

        int maximumScore = aTotalDefense;
        if (bTotalDefense > maximumScore)
        {
            maximumScore = bTotalDefense;
        }
        if (cTotalDefense > maximumScore)
        {
            maximumScore = cTotalDefense;
        }

        int wipeChance = (int)(maximumScore / 70.0) * 100;

        return wipeChance;
    }
    private int HumanDefense() {
        int humanDefenseScore = currentResourceNumbers[0] * 2 + currentResourceNumbers[1] * 2 + currentResourceNumbers[2] * 10
            + currentResourceNumbers[3] * 30 + currentResourceNumbers[4] * 3;

        return humanDefenseScore;
    }
    private int resourceDefense() {
        int resourceDefenseScore = currentResourceNumbers[0] * 2 + currentResourceNumbers[1] * 2 + currentResourceNumbers[2] * 10
            + currentResourceNumbers[3] * 30 + currentResourceNumbers[4] * 3;

        return resourceDefenseScore;
    }

    // Returns all immediate children for a given GameObject
    private GameObject[] GetChildren(GameObject g) {
        GameObject[] output = new GameObject[g.transform.childCount];

        for (int i = 0; i < output.Length; i++) {
            output[i] = g.transform.GetChild(i).gameObject;
        }

        return output;
    }

    IEnumerator TimeStall(int stallTime) {
        Debug.Log("Time Stall began");
        yield return new WaitForSeconds(stallTime);
    }
}
