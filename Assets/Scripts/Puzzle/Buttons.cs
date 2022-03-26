using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    // her butonun 2 state'i olabilir. True/False. True ise tıklanmış, false ise tıklanmamış.
 
    public bool buttonState;
    private ButtonManager _buttonManager;

    private void Awake()
    {
        _buttonManager = FindObjectOfType<ButtonManager>();
    }

    void Start()
    {
        buttonState = false;
    }

    private void Update()
    {
        
        if(buttonState)
            this.gameObject.GetComponent<Image>().color = Color.green;
        else
            this.gameObject.GetComponent<Image>().color = Color.white;

        CheckTagOnClick();
    }

    public void OnClickButton()
    {
        buttonState = !buttonState;  
    }

    public void SetButtonIndex()
    {
        if(this.gameObject.CompareTag("HitButton") && buttonState == false)
        {
            _buttonManager.ClickedHitButtonIndex = Int32.Parse(this.gameObject.name.ToString());

            Debug.Log("my index:" + _buttonManager.ClickedHitButtonIndex);
        }   
    }

    public void CheckTagOnClick()
    {
        if(this.gameObject.CompareTag("NotHitButton") && buttonState == true )
        {
            _buttonManager.mistakenState = true;
        }
    }

    



}
