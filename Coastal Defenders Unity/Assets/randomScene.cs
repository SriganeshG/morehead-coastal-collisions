using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class randomScene : MonoBehaviour
{
    
    public Button yourButton;
    public void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        
    }
    void TaskOnClick()
    {

        int randNum = Random.Range(0,3);
        switch (randNum)
        {
            case 0:
                SceneManager.LoadScene("learnmore");
                break;
            case 1:
                SceneManager.LoadScene("learnmore2");
                break;
            case 2:
                SceneManager.LoadScene("learnmore3");
                break;
            default:
                SceneManager.LoadScene("learnmore");
                break;
        }
        
    }
}
