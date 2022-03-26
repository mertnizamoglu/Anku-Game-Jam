using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Events;

public class ButtonManager : MonoBehaviour
{
    public List<Buttons> _buttons = new List<Buttons>();
    public int counter;
    public int winCounter;
    public GameObject[] _winObjects;
    public bool mistakenState;
    public int ClickedHitButtonIndex;

    // private event System.Action<int> OnButtonClicked;
    private void Start()
    {
        winCounter = _winObjects.Length;
    }
    private void Update()
    {

        ControlButtonsOrder();

        if(mistakenState == true)
        {
            ResetAllButtonStates();
        }


    }

    private void ControlButtonsOrder()
    {
        
            
        for (int i = 0; i < ClickedHitButtonIndex; i++)
        {
            if(_buttons[i].CompareTag("HitButton") && _buttons[i].buttonState == false)
            {
                mistakenState = true;
                ClickedHitButtonIndex = 0;
            }
        }
    }
    
    public void ResetAllButtonStates()
    {
        for(int i = 0; i<9; i++)
        {
            _buttons[i].buttonState = false;
        }

        mistakenState = false;

    }
}


