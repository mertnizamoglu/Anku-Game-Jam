using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonManager : MonoBehaviour
{
    public List<Buttons> _buttons = new List<Buttons>();

    // private event System.Action<int> OnButtonClicked;

    private void Update()
    {
        ControlButtons();
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
        Debug.Log("yarra yedin");
        
        foreach (var button in _buttons)
        {
            button.buttonState = false;
        }
    }
}
