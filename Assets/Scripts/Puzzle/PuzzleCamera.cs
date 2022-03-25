using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class PuzzleCamera : MonoBehaviour
{
    public bool InPuzzleArea;
    public bool puzzleMode = false;
    public FirstPersonController _firstPersonController;
    public GameObject puzzleCamera;
    
    
    void Update()
    {
        ControlPuzzleCamera();

        DeactivePlayerController();

        ActivateMouseCursor();

        Debug.Log("puzzleMode" + puzzleMode);

        Debug.Log("puzzleArea" +InPuzzleArea);
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
        Debug.Log(Input.GetKeyDown(KeyCode.E));

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
        }
        else if(InPuzzleArea && puzzleMode && Input.GetKeyDown(KeyCode.E))
        {
            _firstPersonController.enabled = false; 
        }
    }

    void ActivateMouseCursor()
    {
        if(InPuzzleArea && !puzzleMode && Input.GetKeyDown(KeyCode.E))
        {
            
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.None;
            
        }
        else if(InPuzzleArea && puzzleMode && Input.GetKeyDown(KeyCode.E))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
