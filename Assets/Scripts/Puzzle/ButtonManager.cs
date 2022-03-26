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

    private bool _flag = false;

    // private event System.Action<int> OnButtonClicked;
    private void Start()
    {
        winCounter = _winObjects.Length;
    }
    private void Update()
    {
        ControlButtons();
        CheckWinStatus();
    }

    private void ControlButtons()
    {
        foreach (var button in _buttons)
        {
            for (int i = 0; i < button.MyIndex; i++)
            {
                if (_buttons[i].CompareTag("HitButton") && !_buttons[i].buttonState)
                {
                    Die();
                }
                if (_buttons[i].CompareTag("NotHitButton") && _buttons[i].buttonState)
                {
                    Die();
                }
            }
        }
    }
    private void Die()
    {
        foreach (var button in _buttons)
        {
            Debug.Log("lose aldin");
            button.buttonState = false;
        }
    }

    private void CheckWinStatus()
    {
        foreach(var button in _buttons)
        {
            Debug.Log("BUTTON COUNTER: " + counter);
            if (counter >= winCounter)
            {
                
                Debug.Log("game win");
            }
        }
    }

}
