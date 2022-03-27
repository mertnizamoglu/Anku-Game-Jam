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
    public int ClickedHitButtonIndex = 0;
    public bool winPuzzle;
    public int buttonCount;
    public GameObject _gate;

    // private event System.Action<int> OnButtonClicked;
    private void Start()
    {
        winCounter = _winObjects.Length;

        buttonCount = _buttons.Count;

        Debug.Log("winCounter: "  +winCounter);
    }
    private void Update()
    {

        ControlButtonsOrder();
        
        
        
        if(mistakenState == true)
        {
            ResetAllButtonStates();
        }

        CheckWinStatus();

        if(winPuzzle)
        {
            _gate.SetActive(false);
        }


        Debug.Log("win puzzle status:" + winPuzzle);
        Debug.Log("counter:" + counter);

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
        for(int i = 0; i<buttonCount; i++)
        {
            _buttons[i].buttonState = false;
        }

        mistakenState = false;
    }

    public void CheckWinStatus()
    {
        counter = 0;

        for(int j=0; j<buttonCount; j++)
        {
            if(_buttons[j].CompareTag("HitButton") && _buttons[j].buttonState == true)
            {
                counter++;
            }
        }

        if(counter == winCounter)
        {
            winPuzzle = true;
        }
    }
}


