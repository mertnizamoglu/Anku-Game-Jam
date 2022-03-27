using System;
using System.Collections;
using System.Collections.Generic;
using ANKU.Controllers.Concretes;
using ANKU.UIs.Concretes;
using StarterAssets;
using UnityEngine;

public class PuzzleCamera : MonoBehaviour
{
    public bool InPuzzleArea;
    public bool puzzleMode = false;
    public FirstPersonController _firstPersonController;
    public CharacterChangerController _characterChanger;
    public GameObject _arm;
    public GameObject puzzleCamera;
    public ButtonManager buttonManager;


    void Update()
    {
        ControlPuzzleCamera();

        DeactivePlayerController();

        ActivateMouseCursor();
        if(buttonManager == null)
        {
            return;
        }
        
        if (buttonManager.winPuzzle)
        {
            puzzleCamera.SetActive(false);
            _firstPersonController.enabled = true;
            _arm.SetActive(false);
            _characterChanger.enabled = true;
            Cursor.visible = false;
            this.gameObject.SetActive(false);
        }

    }

    private void OnTriggerStay(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            InPuzzleArea = true;
        }
        else
        {
            InPuzzleArea = false;
        }
        
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            InPuzzleArea = false;
        }
        else
        {
            InPuzzleArea = true;
        }
        
    }

    void ControlPuzzleCamera()
    {
        if(InPuzzleArea && !puzzleMode && Input.GetKeyDown(KeyCode.E))
        {
            puzzleCamera.SetActive(true);

            puzzleMode = true;
        }
        else if(InPuzzleArea && puzzleMode && Input.GetKeyDown(KeyCode.E))
        {
            puzzleCamera.SetActive(false);  

            puzzleMode = false;
        }
    }

    void DeactivePlayerController()
    {
        if(InPuzzleArea && !puzzleMode && Input.GetKeyDown(KeyCode.E))
        {
            _firstPersonController.enabled = true;
            if(_characterChanger == null) return;
            _characterChanger.enabled = true;
        }
        else if(InPuzzleArea && puzzleMode && Input.GetKeyDown(KeyCode.E))
        {
           _firstPersonController.enabled = false;
           if(_characterChanger == null) return;
            _characterChanger.enabled = false;
        }
    }

    void ActivateMouseCursor()
    {
        if(InPuzzleArea && !puzzleMode && Input.GetKey(KeyCode.E))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            
        }
        else if(InPuzzleArea && puzzleMode && Input.GetKey(KeyCode.E))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

}
