using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    // her butonun 2 state'i olabilir. True/False. True ise tıklanmış, false ise tıklanmamış.
 
    public bool buttonState;

    private ButtonManager _buttonManager;
    
    private GameObject thisButton;
    private int _myIndex;


    public int MyIndex => _myIndex;


    private void Awake()
    {
        _buttonManager = FindObjectOfType<ButtonManager>();
    }

    void Start()
    {
        buttonState = false;
    }

    public void OnClickButton()
    {
        buttonState = !buttonState;
    }

    public void OnCheckWinCondition()
    {
        _buttonManager.counter++;
    }

    public bool CheckButtonState()
    {
        return this.buttonState;
    }

    public void SetButtonIndex()
    {
        _myIndex = Int32.Parse(this.gameObject.name.ToString());
        Debug.Log("MY INDEX IS:" + _myIndex);
    }

    public string CheckButtonTag()
    {
        return this.gameObject.tag;
    }

    public void ResetButtonState()
    {
        this.buttonState = false;
    }

    public void SetState(bool boll)
    {
        this.buttonState = boll;
    }

}
