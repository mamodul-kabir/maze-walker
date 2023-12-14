using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionSection : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Color activeColor;
    public Color inactiveColor;
    static public bool music = true; 
    void Start()
    {
        button1.GetComponent<Image>().color = activeColor;
        button2.GetComponent<Image>().color = inactiveColor;
    }
    public void OnClick()
    {
        music = true; 
        button1.GetComponent<Image>().color = activeColor;
        button2.GetComponent<Image>().color = inactiveColor;
    }

    public void OffClick()
    {
        music = false; 
        button2.GetComponent<Image>().color = activeColor;
        button1.GetComponent<Image>().color = inactiveColor;
    }

}
