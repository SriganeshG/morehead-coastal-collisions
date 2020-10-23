using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swipeInfoButtonClick : MonoBehaviour
{
    public swipeInfo panels;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        panels.PanelSelection(this.gameObject, 1);
    }
}
