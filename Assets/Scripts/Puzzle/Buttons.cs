using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    // her butonun 2 state'i olabilir. True/False. True ise tıklanmış, false ise tıklanmamış.
 
    public bool buttonState;
    private GameObject thisButton; 

    void Start()
    {
        buttonState = false;
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    public void OnClickButton()
    {
        buttonState = !buttonState; 
    }

    public bool CheckButtonState()
    {
        return this.buttonState;
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
