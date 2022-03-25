using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCamera : MonoBehaviour
{
    public bool InPuzzleArea;
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
        }
        else
        {
            puzzleCamera.SetActive(false);   
        }
    }

}
