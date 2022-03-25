using System.Collections.Generic;
using ANKU.Enums.Concretes;
using ANKU.Controllers.Abstracts;
using ANKU.UIs.Concretes;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ANKU.Controllers.Concretes
{
    public class CharacterChangerController : MonoBehaviour
    {
        [SerializeField] private List<PlayerController> playerControllers;

        [SerializeField] public PlayerEnum playerEnum;

        public MyInputActions inputActions; 
        
        private InputAction _changeCharacter;
        
        private void Awake()
        {
            inputActions = new MyInputActions();
        }

        private void OnEnable()
        {
            _changeCharacter = inputActions.Player.ChangeCharacter;
            _changeCharacter.Enable();
            _changeCharacter.performed += ChangeCharacter;
        }

        private void OnDisable()
        {
            _changeCharacter.Disable();
        }

        private void ChangeCharacter(InputAction.CallbackContext context)
        {
            if(playerEnum == PlayerEnum.ANGEL_CHARACTER_MODE)
            {
                playerEnum++;
                SetComponentVisibilities(0, false);
                SetComponentVisibilities(1, true);
                
            }
            else if(playerEnum == PlayerEnum.VILLIAN_CHARACTER_MODE)
            {
                playerEnum--;
                SetComponentVisibilities(0, true);
                SetComponentVisibilities(1, false);
            }
        }

        private void SetComponentVisibilities(int index, bool situation)
        {
            playerControllers[index].enabled = situation;
        } 
    }
}