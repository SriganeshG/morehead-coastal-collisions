using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ScoreScreenController : MonoBehaviour
{
    public GameObject upperSection;
    private int[] currentResourceNumbers;
    public string nextScene;

    private VideoSource videoSource;
    void Start()
    {
        Application.runInBackground = true;
        currentResourceNumbers = GameController.GetResourceNumbers();
        LoadResources();
    }
    private void LoadResources()
    {
        GameObject mainGame = GetChildren(upperSection)[0];

        for (int resourceNumber = 0; resourceNumber < currentResourceNumbers.Length; resourceNumber++)
        {
            GameObject resourceArray = GetChildren(mainGame)[resourceNumber + 1];

            for (int i = 0; i < currentResourceNumbers[resourceNumber]; i++)
            {
                GameObject desiredResource = GetChildren(resourceArray)[i];

                desiredResource.SetActive(true);
            }
        }
    }

    private GameObject[] GetChildren(GameObject g)
    {
        GameObject[] output = new GameObject[g.transform.childCount];

        for (int i = 0; i < output.Length; i++)
        {
            output[i] = g.transform.GetChild(i).gameObject;
        }

        return output;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
