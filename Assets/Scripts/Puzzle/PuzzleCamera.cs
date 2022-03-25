using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class PuzzleCamera : MonoBehaviour
{
    public bool InPuzzleArea;
    public FirstPersonController _firstPersonController;
    public GameObject puzzleCamera;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        ControlPuzzleCamera();
    }

    private void OnTriggerEnter(Collider other) 
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
        if(InPuzzleArea)
        {
            puzzleCamera.SetActive(true);
            _firstPersonController.enabled = false;
            
            
        }
        else
        {
            puzzleCamera.SetActive(false);  
            _firstPersonController.enabled = true; 
        }
    }

    void DeactivePlayerController()
    {
        if(InPuzzleArea)
        {
            _firstPersonController.enabled = false;
        }
        else
        {
            _firstPersonController.enabled = true; 
        }
    }
}
